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
            if (args.Length == 1)
             {
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
               if (DoesKeyExist(KeyName))
                {
                      

                    if (File.Exists(Path.Combine(KeyPath, privat)) && File.Exists(Path.Combine(KeyPath, publik)))
                    {
                        var cp = new CspParameters
                        {
                            KeyContainerName = KeyName,
                            Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,
                        };


                    
                        var rsa = new RSACryptoServiceProvider(cp)
                        {

                            PersistKeyInCsp = false
                        };
                        rsa.Clear();
                        File.Delete(Path.Combine(KeyPath, privat));
                        File.Delete(Path.Combine(KeyPath, publik));
                        Console.WriteLine("Eshte larguar celesi privat " + String.Concat("keys/", KeyName, ".xml"));
                        Console.WriteLine("Eshte larguar celesi publik " + String.Concat("keys/", KeyName, ".pub", ".xml"));
                    }

                     else if (File.Exists(Path.Combine(KeyPath, publik)))
                    {
                        // If file found, delete it  

                        var cp = new CspParameters
                        {
                            KeyContainerName = KeyName,
                            Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,
                        };


                        
                        var rsa = new RSACryptoServiceProvider(cp)
                        {

                            PersistKeyInCsp = false
                        };
                        rsa.Clear();
                        File.Delete(Path.Combine(KeyPath, publik));
                        Console.WriteLine("Eshte larguar celesi publik " + String.Concat("keys/", KeyName, ".pub", ".xml"));

                    }

                }
                 else if (!DoesKeyExist(KeyName))
                {
                    Console.WriteLine("Celesi " + KeyName + " nuk ekziston.");
                }
            }
            else
            {
                Console.WriteLine("Shenoni vetem emrin");
            }
        }
    }
}
