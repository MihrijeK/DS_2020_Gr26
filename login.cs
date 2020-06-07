using Newtonsoft.Json;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ds
{
    public class login
    {

        static RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();
        public void Login(string username)
        {
            string query = "Select * FROM users WHERE name =" + "'" + username + "'";
            string pass = "";
            DataSet ds;
            ds = Connection.DataSet(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Console.Write("Jepni fjalekalimin:");
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);
                string dbPassword = ds.Tables[0].Rows[0]["passwordd"].ToString();
                string dbSalt = ds.Tables[0].Rows[0]["salt"].ToString();



                HashAlgorithm algorithm = new SHA256Managed();
                byte[] ssalt = System.Text.Encoding.UTF8.GetBytes(pass + dbSalt);
                byte[] hash = algorithm.ComputeHash(ssalt);
                string SaltedHashPassword = Convert.ToBase64String(hash);

                if (dbPassword.Equals(SaltedHashPassword))
                {
                    var payloadOBJ = new JwtPayload
            {
                {"exp: ", DateTimeOffset.UtcNow.AddMinutes(3).ToUnixTimeSeconds()},
                {"name", username}
            };

                    string payload = JsonConvert.SerializeObject(payloadOBJ);
                    Console.WriteLine("\nToken: " + SignToken(payload, username));

                }
                else
                    Console.WriteLine("\nGabim: Shfrytezuesi ose fjalekalimi i gabuar.");
            }
            else
            {
                Console.WriteLine("\nGabim: Shfrytezuesi nuk ekziston!");
            }
        }
