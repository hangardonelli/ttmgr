using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;

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

            SHA256Handler sha256 = new SHA256Handler();

            string patch = Process.GetProcessesByName("chrome")[10].MainModule.FileName;

            Console.WriteLine(sha256.FileToSHA256(patch));




            
            Console.ReadKey();

          
           
            Console.ReadKey();




        }
    }


}