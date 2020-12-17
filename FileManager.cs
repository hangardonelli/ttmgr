using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ttmgr
{
    class FileManager
    {
        public string GetFileNameByPatch(string patch)
            /*
             * Purpose: Return the name of the file of specified patch 
             * Parameters:
             *      patch: The location of the file
             */
        {
            return patch.Substring(patch.LastIndexOf("\\") + 1);
        }

        public long GetFileSize(string patch, string unit = "bytes")
        {
            /*
             * Purpose: Returns the file size of the file located in 'patch' argument
             * Parameters:
             *      patch: The location of the file
             * Optional Parameters:
             *      unit: <bits, bytes, kbytes, mbytes, gbytes> [DEFAULT: bytes] - The file size unit that you want to express the return value.
             */

            FileStream file = File.OpenRead(patch);

            switch (unit)
            {
                case "bits":
                    return file.Length * 8;
                case "bytes":
                    return file.Length;
                case "kbytes":
                    return file.Length / 1024;
                case "mbytes":
                    return file.Length / (1024 * 1024);
                case "gbytes":
                    return file.Length / (1024 * 1024 * 1024);
                default:
                    return -1;
            }

        }
    }
}
