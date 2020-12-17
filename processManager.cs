using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace ttmgr
{
    /// <summary>
    ///  This class contains the main process handling and information methods.
    /// </summary>
    /// 
    
    class ProcessManager
    {
       
        protected static Process[] getAllProcess()
        {
            /*
            * Purpose: Returns an array of Processes that are running at the time the method is called.
            */

            Process[] process = Process.GetProcesses();
           
            
            return process;         
          
        }


        protected int getProcessID(Process process)
        {
            return process.Id;
        }
        protected string getProcessName(Process process)
        {
            return process.ProcessName;
           
        }

        protected int getProcessPriority(Process process)
        {
            return process.BasePriority;
        }


        protected string getPriorityById(int priority)
        {
            switch (priority)
            {
                case 4:
                    return "Idle";
                case 8:
                    return "Normal";
                case 13:
                    return "High";
                case 24:
                    return "Real-Time";
                default:
                    return "UNKNOW_PROCESS_PRIORITY";
            }
        }

        protected string getProcessWindowsTitle(Process process)
        {
            return process.MainWindowTitle;
        }

        protected string getProcessPatch(Process process)
        {
            return process.MainModule.FileName;
        }

       

        
        public string[] getAllProcessName(Process[] processes)
        {
            /*
           * Purpose: Returns an array of Strings with the name of the process that are running by 'processes' argument.
           */
            var processNames = new string[processes.Length];
            
            int i = 0;
            foreach(Process process in processes)
            {
                processNames[i] = process.ProcessName;
                i = i + 1;
            }

            return processNames;
        }



        
    }

    /// <summary>
    ///  This class contains final user information like print stuff.
    /// </summary>
    class ProcessInfo : ProcessManager
    {
        /// <summary>
        ///  Print in console a list with all process names separated by a new line(s)
        /// </summary>
        public void printAllProcessNames()
        {
            string[] processArray = getAllProcessName(getAllProcess());
            foreach (string process in processArray)
            {
                Console.WriteLine(process);
            }

        }

        public void printAllProcessInformation(
            bool showID = true,
            bool showName = true,
            bool showPriority = false,
            bool showPatch = false, 
            bool showInstances = false, 
            bool showWindowsTitle = false
            
            ){
                string[] processArray = getAllProcessName(getAllProcess());
                foreach(string process in processArray)
                {
                
                }

            }

    }
}






