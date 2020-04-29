using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
namespace ConsoleApp10
{
    class Program
    {
        static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        static void Main(string[] args)
        {
            string KeyName = args[0];
            string pp = args[1];
            string KeyPath = "C:\\Users\\Admin\\source\\repos\\lll\\prova\\bin\\Debug\\key";
            string exportfolder = args[2];
