using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;

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
