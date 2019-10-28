using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TxTimeSynchro
{
    [XmlType("Config")]
    [Serializable]
    public class Config
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public Config()
        {
            Servers = new List<string>();
        }

        public static Config Load(string xml)
        {
            return Util.DeserializeObjectFromXml(typeof(Config), new Type[0], xml) as Config;
        }

        public string Save()
        {
            return Util.SerializeObjectToXml(typeof (Config), new Type[0], this);
        }

        [XmlArrayItem("Server")]
        public List<string> Servers { get; set; }

        public long StartPointDate { get; set; }

        public bool RunAutoSynchro { get; set; }

        public int SynchroEvery { get; set; }

        public SynchroMode SynchroMode { get; set; }

        public bool SynchroFailureRetry { get; set; }

        public int SynchroFailureRetryCount { get; set; }

        public bool MakeLog { get; set; }

        //public bool RunWinStartup { get; set; }
    }

    public enum SynchroMode
    {
        Seconds,
        Minutes,
        Hours,
        Days
    }
}