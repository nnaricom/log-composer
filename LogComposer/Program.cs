using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogComposer
{

    class Log
    {
        private string[] ComposedLog;
        private string[] CurrentLog;
        private string[] Paths;
        private string[] Space = new string[] { "\n", "\n", "\n" };


        public Log(string[] paths)
        {
            this.Paths = paths;
            try
            {
                CurrentLog = File.ReadAllLines(Paths[1]);
                if(!File.Exists(Paths[0]))
                {
                    File.Create(Paths[0]).Close();
                    
                }
                ComposedLog = File.ReadAllLines(Paths[0]);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("performance.log file not found in {0}: {1}", Directory.GetCurrentDirectory(), e);
            }
        }

        public void Write()
        {
            try
            {
                File.AppendAllLines(Paths[0], CurrentLog);
                File.AppendAllLines(Paths[0], Space);
                Console.WriteLine("Wrote total of {0}", CurrentLog.Count());
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Log file not found: {0}", e);
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("No any lines in the current log: {0}", e);
                Console.ReadKey();
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            string[] filepaths = new string[] { @"Composed.log", @"performance.log" };
            Log log = new Log(filepaths);
            log.Write();

        }
    }
}
