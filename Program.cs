using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ttmgr
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentParser argp = new ArgumentParser();
            ProcessManager ph = new ProcessManager();
            ProcessInfo pInfo = new ProcessInfo();


            Process process = new Process();

            Console.WriteLine(Process.GetProcessesByName("chrome")[15].PriorityClass);
            //Console.WriteLine(Process.GetProcessesByName("chrome")[15].Modules);

            Console.ReadKey();

          
           
            Console.ReadKey();




        }
    }


}