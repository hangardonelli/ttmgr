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

        protected Process[] getProcessFamilyByName(string processName)
        {
            return Process.GetProcessesByName(processName);
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


    class ProcessAction : ProcessManager
    {
        public void KillProcessByName(string processName)
        {
            Process[] processes = getProcessFamilyByName(processName);
            if (!(processes.Length > 0))
            {
                //Check if a valid/running process name was given in processName argument  
                Console.WriteLine($"[ERROR] No processes has been founded with name {processName} ");
                return;
            }
            for (int i = 0; i < processes.Length; i++)
            {
                //Going through the array of processes with the indicated name and try to eliminate all
                 
                try
                {
                    processes[i].Kill();
                    Console.WriteLine($"[INFO]: Process {processName} at instance {i} has been killed");
                }
                catch (Exception ex)
                {
                    /*A process may not be killed because the program does not have permissions to do so,
                     * either because it was not run as administrator, or because it has access denied
                     * (for example, trying to stop an antivrius)
                     * */
                    Console.WriteLine($"[WARNING]: Error while trying to kill process {processName} at instance {i}");
                    Console.WriteLine($"[INFO]: Exception: {ex.Message}");

                }
            }
            Console.WriteLine("[INFO]: Done!");
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






