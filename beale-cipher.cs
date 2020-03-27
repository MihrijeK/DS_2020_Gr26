using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ds
{
    class beale
    {
        static void Main(string[] args)
        {
            if (args[0].Equals("e"))
            {

                string plaintext = args[2];
                string libri = args[1];

                Console.WriteLine(Enkriptimi(libri, plaintext));
         
            }
if (args[0].Equals("d"))
            {
                var text = args[1];
                string decrypt = args[2];

                Dekriptimi(decrypt, text);
            }
        }

private static string Enkriptimi(string libri, string plaintext)
        {
    
            libri = File.ReadAllText(@"libri.txt");
            libri = libri.ToLower();
            
            plaintext = plaintext.ToLower();
            string[] Dokument = libri.Split(' ');
            
              
            char[] plain = plaintext.ToCharArray();
            string ch = "";
            string ch1 = "";

            Random random = new Random();

            for (int i = 0; i < plaintext.Length; i++)
            {
                string strCh = "";
               
                if (plaintext[i] == ' ')
                {
                    continue;
                }     
            
                 for (int j = 0; j < Dokument.Length; j++)
                {

                    string str = Dokument[j];
                    
                    if (str.StartsWith(plain[i].ToString()))
                    {
                        
                        strCh += j + 1 + " "; 

                    }
                }
                
                string[] strArray = strCh.Split(' ');
                int k = random.Next(strArray.Length - 1);
                ch1 += strArray[k].ToString() + " ";

                ch = ch1.Substring(0, ch1.Length - 1);
            }
           
            return ch;
        }
public static void Dekriptimi(string ciphertext, string tex)
{
            tex = File.ReadAllText(@"libri.txt");

            string[] t = ciphertext.Split(' ');
 
            string[] st = new string[t.Length];

            
            string[] Dokument = tex.Split(' ');
 

  for (int i = 0; i < t.Length; i++)
            {
                st[i] = Dokument[(Int32.Parse(t[i])) - 1];
            }
            string cplain = "";
 
 
  for (int l = 0; l < st.Length; l++)
            {
                
                cplain += st[l].Substring(0, 1) + "";
            }
            Console.Write(cplain);

        }

  }




}
