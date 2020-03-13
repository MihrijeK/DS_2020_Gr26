# DS_2020_Gr26
Cryptography is a method of protecting information and communications through the use of codes so that only those for whom the information is intended can read and process it.The pre-fix "crypt" means "hidden" or "vault" and the suffix "graphy" stands for "writing." Cryptography is most often associated with scrambling plaintext (ordinary text, sometimes referred to as cleartext) into ciphertext (a process called encryption), then back again (known as decryption).


A beale cipher is a modified Book Cipher. Instead of replacing each word in the secret message with a number, you replace each letter in the secret message which  is replaced with a number that represents the position of a word in the book which starts with this letter.
The same number should not be used for the same letter throughout the secret message.


The Playfair cipher is a digraph substitution cipher.The Playfair cipher uses a 5 by 5 table containing a key word or phrase. To generate the key table, one would first fill in the spaces in the table  with the letters of the keyword (dropping any duplicate letters), then fill the remaining spaces with the rest of the letters of the alphabet in order (usually omitting "J" or "Q" to reduce the alphabet to fit; other versions put both "I" and "J" in the same space). To perform the substitution, apply the following 4 rules, in order, to each pair of letters in the plaintext:
If both letters are the same (or only one letter is left), add an "X" after the first letter.
If the letters appear on the same row of your table, replace them with the letters to their immediate right respectively 
If the letters appear on the same column of your table, replace them with the letters immediately below respectively 
If the letters are not on the same row or column, replace them with the letters on the same row respectively but at the other pair of corners of the rectangle defined by the original pair. The order is important – the first letter of the encrypted pair is the one that lies on the same row as the first letter of the plaintext pair.


Morse code is a method of transmitting text information as a series of on-off tones, lights, or clicks that can be directly understood by a skilled listener or observer without special equipment. It is named for Samuel F. B. Morse, an inventor of the telegraph.
The algorithm is very simple.Every character is substituted by a series of ‘dots’ and ‘dashes’ or sometimes just singular ‘dot’ or ‘dash’ and vice versa.
Every text string is converted into the series of dots and dashes. For this every character is converted into its Morse code and appended in encoded message.
Encode a message by replacing each letter by its code symbol. Then decode the message using Morse code. Make sure you use a delimiter symbol between coded letters.

--> Some References : https://www.geeksforgeeks.org/morse-code/,
                      https://www.braingle.com/brainteasers/codes/beale.php,
                      https://searchsecurity.techtarget.com/definition/cryptography
                      http://rumkin.com/tools/cipher/playfair.php
                      
