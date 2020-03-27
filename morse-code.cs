using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morse-code
{
    class Program
    {
       public static Dictionary<string, string> morse = new Dictionary<string, string>()
        {
            {"A", ".-"},
            {"B", "-..."},
            {"C", "-.-."},
            {"D", "-.."},
            {"E", "."},
            {"F", "..-."},
            {"G", "--."},
            {"H", "...."},
            {"I", ".."},
            {"J", ".---"},
            {"K", "-.-"},
            {"L", ".-.."},
            {"M", "--"},
            {"N", "-."},
            {"O", "---"},
            {"P", ".--."},
            {"Q", "--.-"},
            {"R", ".-."},
            {"S", "..."},
            {"T", "-"},
            {"U", "..-"},
            {"V", "...-"},
            {"W", ".--"},
            {"X", "-..-"},
            {"Y", "-.--"},
            {"Z", "--.."},
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
            {" ", "/" },
              };
        

        static void Main(string[] args)
        {
           
            if (args[0].Equals("decode"))
            {
                string plaintext = args[1];
                string output = " ";

                // Nese plaintexti permban se paku nje prej shkronjave te njohura morse
                if (morse.Values.Any(morseLetter => plaintexti.Contains(morseLetter)))
                {
                    output = Decode(plaintexti);
                }
                Console.WriteLine(output);
            Console.WriteLine();
            Console.ReadKey();
             }
             else if (args[0].Equals("encode"))
            {
                string plaintexti = args[1];
                

                string output;

                output = Encode(plaintexti);


                Console.WriteLine(output);

                Console.WriteLine();
                Console.ReadKey();
            }
            else if (args[0].Equals("beep"))
            {
                string plaintexti = args[1];
                int tone = 415; //G# note
                int dotDuration = 300; //The duration of one time unit
                int dashDuration = dotDuration * 3; //A dash is 3 time units
                int charSpaceDuration = dotDuration * 3; //The pause between characters is 3 time units
                int wordSpaceDuration = dotDuration * 7; //The pause between words is 7 time units
                foreach (char c in plaintexti)
                {
                    if (c == '.')
                    {
                        Console.Beep(tone, dotDuration);
                    }
                    else if (c == '-')
                    {
                        Console.Beep(tone, dashDuration);
                    }
                    else if (c == ' ')
                    {
                        System.Threading.Thread.Sleep(charSpaceDuration);
                    }
                    else if (c == '/')
                    {
                        System.Threading.Thread.Sleep(wordSpaceDuration);
                    }
                }
            
            }
            
        public static string EncodeChar(char letter)
        {
            string letterAsString = letter.ToString();
            if (morse.Keys.Any(qelsi => qelsi.Equals(letterAsString, StringComparison.OrdinalIgnoreCase)))
            {
                return morse[letterAsString.ToLower()];
            }

            return "unsupported latin letter";
        }
        
        public static string Encode(string inputPhrase)
        {   
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char letter in inputPhrase)
            {
                stringBuilder.Append(EncodeChar(letter) + " ");
            }
            return stringBuilder.ToString();
        }
        
        public static string Decode(string encodedPhrase)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string[] encodedLetters = encodedPhrase.Split(' ');
            foreach (string encodedLetter in encodedLetters)
            {
                stringBuilder.Append(DecodeLetter(encodedLetter));
               
            }
            return stringBuilder.ToString();
        }
        
         public static string DecodeLetter(string encodedLetter)
        {
            
            foreach (KeyValuePair<string, string> rreshti in morse)
            {
                if (rreshti.Value.Equals(encodedLetter))
                {
                    return rreshti.Key;
                }
            }

            return "unknown morse letter";
        }
           
    }
}
