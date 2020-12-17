using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace ttmgr
{
    abstract class Crypto
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

        public string FileToMD5(string patch)
        {
            FileStream file = File.OpenRead(patch);
            MD5 md5 = MD5.Create();

            byte[] md5Bytes = md5.ComputeHash(file);
            StringBuilder sb = new StringBuilder();

            foreach (byte md5Byte in md5Bytes)
            {
                sb.Append(md5Byte.ToString("x2"));
            }

            return sb.ToString();
        }
    }

    class SHA256Handler
    {
        public string FileToSHA256(string patch)
        {

            FileStream file = File.OpenRead(patch);
            SHA256 sha256 = SHA256.Create();

            byte[] sha256Bytes = sha256.ComputeHash(file);
            StringBuilder sb = new StringBuilder();

            foreach(byte sha256byte in sha256Bytes)
            {
                sb.Append(sha256byte.ToString("x2"));
            }

            return sb.ToString();
         
        } 
      

    }
}
