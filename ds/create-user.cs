using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;


namespace createuser
{
    class createuser
    {
        static void Main(string[] args)
        {
            string Key_Name = args[0];
            string Key_Path = "C://Users//dell//source//keys";
             var cp = new CspParameters
                    {
                        KeyContainerName = Key_Name,
                        Flags = CspProviderFlags.NoPrompt | CspProviderFlags.UseArchivableKey
                   | CspProviderFlags.UseMachineKeyStore,

                    };
            
