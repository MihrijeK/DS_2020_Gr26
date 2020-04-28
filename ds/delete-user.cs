using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;


namespace deleteuser
{
    class deleteuser
    {
        static void Main(string[] args)
        {
            string KeyName = args[0];
            string KeyPath = "C://Users//dell//source//keys";

            string publik = String.Concat(KeyPath, "\\", KeyName, ".pub", ".xml");
            string privat = String.Concat(KeyPath, "\\", KeyName, ".xml");
