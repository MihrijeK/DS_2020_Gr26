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
             var cp = new CspParameters();
            
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
                Console.WriteLine("Celesi " + KeyName + " ekziston paraprakisht");
            }


            if (!DoesKeyExist(KeyName))

            {

                cp.KeyContainerName = KeyName;
                cp.Flags = CspProviderFlags.NoPrompt | CspProviderFlags.UseArchivableKey
               | CspProviderFlags.UseMachineKeyStore;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);



                try
                {

                    var fs = new FileStream(
                        String.Concat(KeyPath, "\\", KeyName, ".xml"), FileMode.Create);

                    using (StreamWriter sw = new StreamWriter(fs))
                    {

                        sw.WriteLine(rsa.ToXmlString(true));
                    }
                    Console.WriteLine("Eshte krijuar celesi privat " + String.Concat("keys/", KeyName, ".xml"));

                }
