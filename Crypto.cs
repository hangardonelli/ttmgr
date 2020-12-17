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
        //Byte handling abstract class for specific hash classes

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

    class HashHandler : Crypto
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

        public string FileToSHA256(string patch)
        {

            FileStream file = File.OpenRead(patch);
            SHA256 sha256 = SHA256.Create();

            byte[] sha256Bytes = sha256.ComputeHash(file);
            StringBuilder sb = new StringBuilder();

            foreach (byte sha256byte in sha256Bytes)
            {
                sb.Append(sha256byte.ToString("x2"));
            }

            return sb.ToString();

        }



        public string FileToSHA1(string patch)
        {

            FileStream file = File.OpenRead(patch);
            SHA1 sha1 = SHA1.Create();

            byte[] sha1Bytes = sha1.ComputeHash(file);
            StringBuilder sb = new StringBuilder();

            foreach (byte sha1byte in sha1Bytes)
            {
                sb.Append(sha1byte.ToString("x2"));
            }

            return sb.ToString();

        }
       
       public string FileToSHA384(string patch)
        {
            FileStream file = File.OpenRead(patch);
            SHA384 sha384 = SHA384.Create();

            byte[] sha384Bytes = sha384.ComputeHash(file);
            StringBuilder sb = new StringBuilder();

            foreach(byte sha384byte in sha384Bytes)
            {
                sb.Append(sha384byte.ToString("x2"));
            }

            return sb.ToString();
        }


        public string FileToSHA512(string patch)
        {
            FileStream file = File.OpenRead(patch);
            SHA512 sha512 = SHA512.Create();

            StringBuilder sb = new StringBuilder();

            byte[] sha512Bytes = sha512.ComputeHash(file);

            foreach(byte sha512byte in sha512Bytes)
            {
                sb.Append(sha512byte.ToString("x2"));
            }

            return sb.ToString();
        }
    }

}
