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
            string KeyPath = "C://keys";

            string publik = String.Concat(KeyPath, "\\", KeyName, ".pub", ".xml");
            string privat = String.Concat(KeyPath, "\\", KeyName, ".xml");
              bool DoesKeyExist(string name)
                {

                    var cspParams = new CspParameters
                    {

                        Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,


                        KeyContainerName = name
                    };

                    try
                    {
                        var rsa = new RSACryptoServiceProvider(cspParams);



                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    return true;

                }
