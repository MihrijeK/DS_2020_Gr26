# DS_2020_Gr26
Zhvillimi i projektit gjendet në folderin ds përkatësisht në klasen ds.cs në të cilen permes objekteve i kemi thirrur klasat që në vete përmbajnë funksionet për Komanden Beale(beale-cipher.cs) për Komanden Morse Code (morse-code.cs) dhe Komanden Playfair(playfair-cipher.cs).Programi është zhvilluar ne gjuhen programuese C# dhe implementohet ne Console.

# 1.Komanda Beale
Beale cipher është një algoritëm qe e shfrytëzon një tekst dokument si libër.Me këtë metodë zëvendësohet cdo shkronjë në mesazhin
sekret me indeksin e një  fjale në libër që fillon me atë shkronjë.Gjithashtu duhet pasur kujdes që per shkaqe sigurie mos të enkriptohet shkronja e njejtë me të njëjtin numer.Ndërsa nëse duam ta dekpritojm mesazhin  sekret atëherë  numri në atë mesazh paraqet indeksin e një fjale në  libër dhe marrim shkronjën e parë të saj.
Shkrimi i argumenteve në mënyrë adekuate bëhet siq është paraqitur më poshtë pra ashtu si sintaksa në kërkesën e projektit.
![](Images/Beale.png)
# 2.Komanda Morse Code
Komanda Morse është një kod që përdoret për të koduar mesazhe që përbëhen nga shkronja dhe shifra. Cdo shkronjë në alfabetin Latin si dhe shifrat janë ekuivalent me një seri . dhe -. në Morse Code. 
Ruajtja e shkronjave&shifrave dhe vlerave përkatese të tyre në Morse Code është bërë duke krijuar objektin MorseDictionary në kuader te klasës Dictionary si dhe për secilin funksion është dhëne përshkrimi si koment në program.
Kërkesa shtesë --audio është bërë në atë menyrë që të ekzekutohet në momentin kur si argument është "audio" dhe teksti hyrës është në Morse Code atëherë ndëgjohet ajo vlerë hyrëse si nga makina Morse.
Shkrimi i argumenteve në mënyrë adekuate bëhet siq është paraqitur më poshtë pra ashtu si sintaksa në kërkesën e projektit.
![](Images/Morse.PNG)
# 3.Komanda Playfair
Komanda Playfair bazohet në matricën 5x5.Në atë matricë e vendosim alfabetin mirëpo pasi alfabeti i ka 26 shkronja, i dhe j e marrin të njëjtën qeli.Matrica qelës formohet duke u bazuar në një keyword.Nëse një shkronjë përsëritet më shumë se 1 herë ajo shënohet vetëm herën e parë.Mesazhi sekret duhet të ndahet në grupacion nga dy shkronja.Nëse mesazhi sekret nuk ka nr cift të shkronjave duhet të vendosim 'x'.Rregullat për enkriptim:
1.Nëse shkronjat jane në rreshta të njëjtë atëherë duhet të merret elementi pasues
2.Nëse ato jane në kolona të njëjta atëherë merret el. i rreshtit pasues por i kolonës të njëjtë.
3.Nëse ato nuk janë as në kolona e as në rreshta të njejtë atëherë merret el. i rreshtit të njëjtë por ne kolonën e karakterit tjetër.
Shkrimi i argumenteve në mënyrë adekuate bëhet siq është paraqitur më poshtë pra ashtu si sintaksa në kërkesën e projektit.
![](Images/Playfair.png)
# --> Referencat : 
 https://www.geeksforgeeks.org , 
 https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7 , 
 https://searchsecurity.techtarget.com/definition/cryptography.
                      
