using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ds
{
    class Fjalori
    {
       public static Dictionary<string, string> MorseDictionary = new Dictionary<string, string>()
        {
           //Alfabeti
            {"a", ".-"},
            {"b", "-..."},
            {"c", "-.-."},
            {"d", "-.."},
            {"e", "."},
            {"f", "..-."},
            {"g", "--."},
            {"h", "...."},
            {"i", ".."},
            {"j", ".---"},
            {"k", "-.-"},
            {"l", ".-.."},
            {"m", "--"},
            {"n", "-."},
            {"o", "---"},
            {"p", ".--."},
            {"q", "--.-"},
            {"e", ".-."},
            {"s", "..."},
            {"t", "-"},
            {"u", "..-"},
            {"v", "...-"},
            {"w", ".--"},
            {"x", "-..-"},
            {"y", "-.--"},
            {"z", "--.."},
           //Numrat
            {"0", "-----"},
            {"1", ".----"},
            {"2", "..---"},
            {"3", "...--"},
            {"4", "....-"},
            {"5", "....."},
            {"6", "-...."},
            {"7", "--..."},
            {"8", "---.."},
            {"9", "----."},
           //Formatimi
            {" ", "/" },
           //Shenjat e pikesimit
            { ".", ".-.-.-" },
            { ",", "--..--" },
            { "?", "..--.." },
            { "'", ".----." },
            { "!", "-.-.--" },
            { "/", "-..-." },
            { "(", "-.--." },
            { ")", "-.--.-" },
            { "&", ".-..." },
            { ":", "---..." },
            { ";", "-.-.-." },
            { "=", "-...-" },
            { "+", ".-.-." },
            { "-", "-....-" },
            { "_", "..--.-" },
            { "$", "...-..-" },
            { "@", ".--.-." }, 
        };
        
        public static string KtheCharNeMorse(char c)
        {
            string perkthimi = " ";
            string s = c.ToString().ToLower();
            if (MorseDictionary.ContainsKey(s))
            {
                perkthimi = MorseDictionary[s];
            }
            perkthimi +=" ";
            
            return perkthimi;
        }
        
        public static string KtheMorseNeChar(string s)
        {   
            string perkthimi = " ";
          
            foreach (KeyValuePair<string, string> rreshti in MorseDictionary)
            {
                if(rreshti.Value.Equals(s))
                {
                    return perkthimi = rreshti.Key.ToString();
                }
            }
            return perkthimi;
        }
    }        
    
    public class Morse
    {   
        //Vlera hyrese prej perdoruesit
        private string Input;
        
        //Ruan perkthimin e Input-it
        private string Perkthimi;
        private string Argumentet;
        //Konstruktori
        public Morse(string input)
        {
            this.Input = input;
        }
        
        public string GetInput()
        {
            return input;
        }
        
        public string Perkthe(string argumentet)
        {
            this.Argumentet = argumentet;
            //Kontrollo nese hyrjet jane Valide perndryshe jep detaje se si duhet te jete ajo
            if (Regex.Matches(Input, @"[a-zA-Z0-9.,?'!/()$@_+-=;:&]").Count != 0)
            {
                if (Argumentet == "encode")
                {
                    return KtheNeMorse();
                }
                else if (Argumentet == "decode")
                    return KtheNeLatin();
            }
            else
            {
                Console.WriteLine("Keni jepur karaktere jo valide. Teksti juaj duhet te permbaje ndonjeren prej Shkronjave te alfabetit Latin ose numer ose Karakteret : .,?'!/()$@_+-=;:&");
            }
            return argumentet;
         }
        public string KtheNeLatin()
        {   //Kthen vleren hyrese ne shkronja latine,numra,shenja te pikesimit ose " " hapsire 
            string[] ndarjaEShkronjave = Input.Split(' ');
            foreach (string s in ndarjaEShkronjave)
            {
                Perkthimi += Fjalori.KtheCharNeMorse(s);
            }
            return Perkthimi;
        }
        
         public string KtheNeMorse()
        {
            //Kthen vleren hyrese ne Morse Kod per cdo karakter te dhene ne hyrje
            foreach (char c in Input)
            {
                Perkthimi += Fjalori.KtheMorseNeChar(c);
            }

            return Perkthimi.Trim();
         }
        
          public void audio(string input)
          {

            try
            {
                this.Input = input;
                int frekuenca = 415;
                int dotDuration = 300; //Kohëzgjatja e nje "."
                int dashDuration = dotDuration * 3; //Kohëzgjatja e nje "-"
                int charSpaceDuration = dotDuration * 3; //Pauza mes karaktereve
                int wordSpaceDuration = dotDuration * 7; //Pauza mes fjaleve
                foreach (char c in Input)
                {
                    if (c == '.')
                    {
                        Console.Beep(frekuenca, dotDuration);
                    }
                    else if (c == '-')
                    {
                        Console.Beep(frekuenca, dashDuration);
                    }
                    else if (c == ' ')
                    {
                        Thread.Sleep(charSpaceDuration);
                    }
                    else if (c == '/')
                    {
                        Thread.Sleep(wordSpaceDuration);
                    }
                }
            }
            catch (System.PlatformNotSupportedException ex)
            {
                Console.WriteLine("ERROR: Morse.Audio() : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}
