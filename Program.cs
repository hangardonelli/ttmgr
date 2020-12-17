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

            Console.WriteLine(Process.GetProcessesByName("chrome")[15].MainModule);

            MD5 hash = MD5.Create();
            byte[] textBytes = Encoding.ASCII.GetBytes("hola");
            byte[] hashBytes = hash.ComputeHash(textBytes);

            byte[] example = { 65, 66, 67 };
            ASCIIEncoding ac = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();

            foreach(byte byteInHash in hashBytes)
            {
                sb.Append(byteInHash.ToString("x2"));
            }
            Console.WriteLine(sb.ToString());
            


           
            //Console.WriteLine(Process.GetProcessesByName("chrome")[15].Modules);
            
            Console.ReadKey();

          
           
            Console.ReadKey();




        }
    }


}