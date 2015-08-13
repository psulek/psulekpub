using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StackExchange.Redis.SentinelTests
{
    public class SentinelTests: IDisposable
    {
        private ConnectionMultiplexer sentinelConnection;
        private ConnectionMultiplexer redisConnection;
        private readonly FileStream fileLogStream;
        private bool disposed;
        private readonly StreamWriter fileStreamWriter;
        
        private TimeSpan testLoopTimeout = TimeSpan.FromSeconds(60);
        private readonly string logFile;
        private string testKey = "sentinel_test_key";
        private string testValue;

        private ManualResetEvent stopEvent = new ManualResetEvent(false);

        public SentinelTests(string logFile)
        {
            this.logFile = logFile;
            fileLogStream = File.Open(logFile, FileMode.Create, FileAccess.Write, FileShare.Read);
            fileStreamWriter = new StreamWriter(fileLogStream);

            string settingTestLoopTimeout = ConfigurationManager.AppSettings["test.loop.timeout"];
            if (!string.IsNullOrEmpty(settingTestLoopTimeout))
            {
                int i;
                if (int.TryParse(settingTestLoopTimeout, out i))
                {
                    testLoopTimeout = TimeSpan.FromSeconds(i);
                }
            }
        }

        public void Run()
        {
            Console.WriteLine("Loggin to file: " + logFile);

            sentinelConnection = GetSentinelConnection();
            if (sentinelConnection.IsConnected)
            {
                redisConnection = GetRedisConnection();
                if (redisConnection.IsConnected)
                {
                    DoTests();
                }
                else
                {
                    Console.WriteLine("Master was not connected, tests stopped.");
                }
            }
            else
            {
                Console.WriteLine("Sentinels was not connected, tests stopped.");
            }
        }

        private void DoTests()
        {
            Console.WriteLine();
            Console.WriteLine("== BEGIN TESTS ==");

            fileStreamWriter.WriteLine("===============================================");
            fileStreamWriter.WriteLine("===============================================");
            fileStreamWriter.Flush();

            try
            {
                testValue = Guid.NewGuid().ToString("N");
                WriteConnectionMsg(string.Format("SET key '{0}' with value '{1}'...", testKey, testValue));

                IDatabase db = redisConnection.GetDatabase(0);
                bool success = db.StringSet(testKey, testValue);
                WriteConnectionMsg(string.Format("SET key '{0}' with value '{1}'... {2}", testKey, testValue,
                    GetResultString(success)));

                WriteConnectionMsg(String.Format("Start lopp of GET calls for {0} seconds...", testLoopTimeout.TotalSeconds));

                WriteConnectionMsg("");
                SaveCursorPos();

                Task task = Task.Factory.StartNew(() => LoopTask(db));
                task.Wait(testLoopTimeout);
                stopEvent.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " " + e.StackTrace);
            }
            finally
            {
                Console.WriteLine("== END TESTS ==");
            }
        }

        private void LoopTask(IDatabase db)
        {
            int idx = 1;
            while (true)
            {
                string loopMsg = string.Format("GET#{0} for key '{1}'...", idx, testKey);
                WriteConnectionMsg(loopMsg);

                bool callSuccess = false;
                try
                {
                    fileStreamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " " + loopMsg + "...");

                    RedisValue redisValue = db.StringGet(testKey);
                    callSuccess = !redisValue.IsNullOrEmpty && redisValue == testValue;
                }
                catch (Exception e)
                {
                    fileStreamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss.ffff") + " " + loopMsg + " failed on error: " + e.Message);
                }

                WriteConnectionMsg(loopMsg + " " + GetResultString(callSuccess));

                if (stopEvent.WaitOne(1))
                {
                    WriteConnectionMsg(string.Format("LoopTask was cancelled on {0} loop (before delay).", idx));
                    break;
                }

                Thread.Sleep(1000);

                if (stopEvent.WaitOne(1))
                {
                    WriteConnectionMsg(string.Format("LoopTask was cancelled on {0} loop (after delay).", idx));
                    break;
                }

                idx++;
            }
        }

        private string GetResultString(bool result)
        {
            return result ? "OK" : "ERR";
        }

        private int? cursorLeft = null;
        private int? cursorTop = null;

        private void SaveCursorPos()
        {
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
        }

        private string GetMasterEndpoint()
        {
            return redisConnection == null || redisConnection.MasterEndpointForService == null
                ? "-"
                : redisConnection.MasterEndpointForService.ToString();
        }

        private void WriteConnectionMsg(string message, bool restoreCursorPos = true)
        {
            if (cursorLeft != null && restoreCursorPos)
            {
                Console.SetCursorPosition(cursorLeft.Value, cursorTop.Value);
            }

            

            Console.WriteLine("{0} [{1}] {2}",DateTime.Now.ToString("HH:mm:ss.ffff"), GetMasterEndpoint(), message);
        }

        public ConnectionMultiplexer GetSentinelConnection()
        {
            // create a connection

            string sentinelCfg = ConfigurationManager.AppSettings["sentinel.cfg"];
            var options = ConfigurationOptions.Parse(sentinelCfg);
            options.CommandMap = CommandMap.Sentinel;
            options.AllowAdmin = true;
            options.TieBreaker = string.Empty;

            options.SyncTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["sentinel.synctimeout"]);


            Console.WriteLine("Connecting to sentinels...");
            var connection = ConnectionMultiplexer.Connect(options, fileStreamWriter);
            Thread.Sleep(1000);

            Console.WriteLine(connection.IsConnected ? "CONNECTED" : "FAILED");
            
            return connection;
        }

        public ConnectionMultiplexer GetRedisConnection()
        {
            // create a connection
            var options = new ConfigurationOptions();
            options.AllowAdmin = true;
            options.SentinelConnection = sentinelConnection;
            options.ResponseTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["redis.responsetimeout"]);
            options.SyncTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["redis.synctimeout"]); ;

            Console.WriteLine("Connecting to master...");
            var connection = ConnectionMultiplexer.Connect(options, fileStreamWriter);
            Thread.Sleep(1000);

            Console.WriteLine(connection.IsConnected ? "CONNECTED at :" + GetMasterEndpoint() : "FAILED");
            return connection;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                fileStreamWriter.Close();
                fileLogStream.Close();

                disposed = true;
            }
        }
    }
}