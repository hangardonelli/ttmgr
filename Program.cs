using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;

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

            HashHandler sha256 = new HashHandler();
            FileManager fm = new FileManager();

            ProcessAction pa = new ProcessAction();

            Process[] chrome = Process.GetProcessesByName("notepad");

            pInfo.printProcessInformation(chrome[0], true, true, true, true, true, true);








            Console.ReadKey();

          
           
            Console.ReadKey();

           


        }
    }


}