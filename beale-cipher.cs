 private static string Enkriptimi(string libri, string plaintext)
        {
    
            libri = File.ReadAllText(@"libri.txt");
            libri = libri.ToLower();
            
            
            
            
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
                
                
                
                
                string[] strArray = strCh.Split(' ');
                int k = random.Next(strArray.Length - 1);



