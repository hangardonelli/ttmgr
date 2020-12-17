using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace ttmgr
{
    class Crypto
    {

        protected byte[] StringToByte(string input)
        {
            return Encoding.ASCII.GetBytes(input);
        }
        protected string ByteArrayToString(byte[] input)
        {
            StringBuilder sb = new StringBuilder();
            foreach(byte inputByte in input)
            {
                sb.Append(inputByte.ToString("x2"));
            }

            return sb.ToString();
        }


   
     


    }

    class MD5Handler : Crypto
    {
        protected string StringToMD5(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = StringToByte(input);
            byte[] md5Bytes = md5.ComputeHash(inputBytes);

            return ByteArrayToString(md5Bytes);

        }
    }
}
