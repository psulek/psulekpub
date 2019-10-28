using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TxTimeSynchro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
//            Config cfg = new Config();
//            cfg.Servers.Add("xxx");
//            cfg.Servers.Add("yyy");
//            cfg.StartPointDate = DateTime.Now.Ticks;
//            cfg.RunAutoSynchro = true;
//            cfg.SynchroEvery = 1;
//            cfg.SynchroMode = SynchroMode.Minutes;
//            cfg.SynchroFailureRetry = true;
//            cfg.SynchroFailureRetryCount = 20;
//            cfg.MakeLog = true;
//            string xml = cfg.Save();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
