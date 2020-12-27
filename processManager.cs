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

        protected Process getProcessById(int processID)
        {
            return Process.GetProcessById(processID);
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

        protected bool isProcessResponding(Process process)
        {
            return process.Responding;
        }

        protected DateTime getProcessStartDate(Process process)
        {
            return process.StartTime;
        }

        protected string getProcessFileVersion(Process process)
        {
            return process.MainModule.FileVersion;
        }
       
        public string getStartingMemoryLocation(Process process, byte _base = 16)
        {
            /*
             * Purpose: Returns the initial memory location of a specific process
             * Parameters:
             *      process: The selected process to see his initial memory location
             * Default parameters:
             *      _base: Set the base of numbers for representing the starting memory location where:
             *          2: Binary,
             *          8: Octal,
             *          10: Decimal,
             *          16: Hexadecimal
             */
            //Saving the memory location expressed like a 64-bits pointer into a int64 data type.
            Int64 processMemoryLocation = process.MainModule.BaseAddress.ToInt64();


           

            switch (_base)
            {

                case 2:
                    //Converting to bianry
                    return Convert.ToString(processMemoryLocation, 2);
                case 8:
                    //Converting to octal (please dont use this >_>)
                    return Convert.ToString(processMemoryLocation, 8);
                case 16:
                    //Converting to hexdec
                    return processMemoryLocation.ToString("X");
                

                default:
                    // If you were to cause the execution of this default:, you don't even deserve to be alive wtf man
                    return "UNKNOW_BASE_SYSTEM";
            }


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

        public void KillProcessById(int processID)
        {
            /*
             * Purpose: Kill a process determined by its ID
             * Parameters:
             *      processID: The ID of the process to be killed
             * Exceptions:
             *      There may be an exception related to the access denied, or that the process does not exist directly
             * */
             try
             {
                // Search the process by his ID, and kill him :))
                Process process = Process.GetProcessById(processID);
                 process.Kill();
                

                 Console.WriteLine($"[INFO]: Process {getProcessName(process)} with ID {processID} has been killed succesfully");
             }
             catch(Exception)
             {
                 Console.WriteLine($"[ERROR]: Failed while trying to kill process with ID {processID}. Process ID Does not exist or accces denied.");

             }

         }
         public void KillProcessByName(string processName)
         {
            // Search the process by his name
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
                     Console.WriteLine($"[INFO]: Process {processName} at instance {i} has been killed succesfully");
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



        public void printProcessInformation(
            Process process,
            bool showID = true,
            bool showName = true,
            bool showPriority = false,
            bool showPatch = false,
            bool showInstances = false, 
            bool showWindowsTitle = false,
            bool showStartingMemoryLocation = false,
            bool showMD5 = false,
            bool showSHA1 = false,
            bool showSHA256 = false, 
            bool showSHA512 = false,
            bool showFileVersion = false
            )

        {

            HashHandler hs = new HashHandler();

            if (showID)
            {
                Console.WriteLine($"Process ID: {getProcessID(process)}");
            }

            if (showName)
            {
                Console.WriteLine($"Process Name: {getProcessName(process)}");
            }

            if (showPriority)
            {
                Console.WriteLine($"Priority: {getProcessPriority(process)} ({getPriorityById(getProcessPriority(process))})");
            }

            if (showPatch)
            {
                Console.WriteLine($"File Patch: {getProcessPatch(process)}");
            }

            if (showInstances)
            {
                Console.WriteLine($"Process Instances: {getProcessFamilyByName(process.ProcessName).Length}");
            }

            if (showWindowsTitle)
            {
                Console.WriteLine($"Main title name: {getProcessWindowsTitle(process)}");
            }

            if (showStartingMemoryLocation)
            {
                Console.WriteLine($"Starting memory location: 0x{getStartingMemoryLocation(process)}");
            }
            if (showMD5)
            {

                Console.WriteLine($"File MD5: {hs.FileToMD5(getProcessPatch(process))}");
            }
            if (showSHA1)
            {

                Console.WriteLine($"File SHA1: {hs.FileToSHA1(getProcessPatch(process))}");
            }
            if (showSHA256)
            {

                Console.WriteLine($"File SHA256: {hs.FileToSHA256(getProcessPatch(process))}");
            }
            if (showSHA512)
            {

                Console.WriteLine($"File SHA512: {hs.FileToSHA512(getProcessPatch(process))}");
            }

            if (showFileVersion)
            {
                Console.WriteLine($"{getProcessFileVersion(process)}");
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