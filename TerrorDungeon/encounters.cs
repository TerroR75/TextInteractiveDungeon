using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorDungeon
{
    class encounters
    {
        static Random rand = new Random();
        static Random rand2 = new Random();
        //Encounter Generic



        //Encounters
        public static void Encounter1()
        {
            Console.WriteLine("Lokalny bandzior ze sztyletem szarżuje prosto na Ciebie.");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Ranny Bandyta", "", 30, 4, 0, 0, 0);

        }
        public static void RandomEncounter()
        {
            Console.WriteLine("Coś słyszysz.. hałas, zgrzyt, szelest.., a może szept?");
            Console.ReadKey();
            Console.WriteLine("Nagle zza zakrętu wyskakuje na Ciebie...");
            Console.ReadKey();
            Console.Clear();
            Combat(true, "", "", 0, 0, 0, 0, 0);
        }

        //Encounter Tools

        public static void Combat(bool random, string name, string rarity, int health, int power, int armor, double eCritChance, double eCritMulti)
        {
            string typeOfMonster = "";
            string monsterSuffix = "";
            string n = "";
            string pref = "";
            int p = 0;
            double h = 0;
            int a = 0;
            // MONSTER crit chance & multi
            double eCC = 0.95;
            double eCM = 2;
            // PLAYER crit chance & multi
            double pCC = 0.95;
            double pCM = 2;


            if (random)
            {
                // TYPE OF MONSTER SELECTION - type of monsters is assigned based on its name stored in |string n|
                n = LosowaNazwaPrzeciwnika();

                        // spirits
                if (n == "Zjawa" || n == "Duch" || n == "Upiór")
                    typeOfMonster = "spirit";
                        // humanlike
                else if (n == "Bandyta")
                    typeOfMonster = "humanlike";
                        // undead
                else if (n == "Ghoul" || n == "Zombie" || n == "Zgnilec" || n == "Topielec")
                    typeOfMonster = "undead";              

                //=== PREFIX SELECTION + PREFIX and TYPE BOOSTS ===//
                pref = LosowyPrefixPrzeciwnika();

                // TYPE BOOST - stats increase based on monster type
                h = rand.Next(10, 21);
                if (typeOfMonster == "undead")
                    h = h * 1.3;
                a = rand.Next(1, 3);
                if (typeOfMonster == "spirit")
                    a = 0;
                p = rand.Next(5, 11);
                eCC = 0.95;
                eCM = 1.2;


                // RARIRTY BOOST - further increased stats based on monster rarity

                if (pref == "[Magic] ")
                {

                        int randomNumber = rand.Next(0, 5);
                        if (randomNumber == 0)
                        {
                            p = Convert.ToInt32(p * 1.2);
                            monsterSuffix = "|Powered|";
                        }
                        else if (randomNumber == 1)
                        {
                            h = h * 1.3;
                            monsterSuffix = "|Durable|";
                        }
                        else if (randomNumber == 2)
                        {
                            a = Convert.ToInt32(a * 1.3);
                            monsterSuffix = "|Tough|";
                        }
                        else if (randomNumber == 3)
                        {
                            eCC -= 0.5;
                            monsterSuffix = "|Crit Lucky|";
                        }
                        else if (randomNumber == 4)
                        {
                            eCM += 0.3;
                            monsterSuffix = "|Empowered|";
                        }
                    

                }
                else if (pref == "[RARE] ")
                {

                        int randomNumber = rand.Next(0, 2);

                        if (randomNumber == 0)
                        {
                            p = Convert.ToInt32(p * 1.5);
                            eCC -= 0.10;
                            eCM += 0.5;
                            monsterSuffix = "|Hard Hitter|";
                        }
                        else if (randomNumber == 1)
                        {
                            a = Convert.ToInt32(a * 1.5);
                            h = h * 1.5;
                            monsterSuffix = "|Armored|";

                        }
                }
                else if (pref == "[ENRAGED] ")
                {
                    h = h / 3;
                    a = a / 3;
                    int randomNumber = rand.Next(0, 5);
                        if (randomNumber == 0 || randomNumber == 1)
                    {
                        p = Convert.ToInt32(p * 3);
                        monsterSuffix = "|of Killing|";
                    }
                        else if (randomNumber == 2 || randomNumber == 3)
                    {
                        eCC -= 0.35;
                        eCM += 1.3;
                        monsterSuffix = "|of Precision|";
                    }
                        else if (randomNumber == 4)
                    {
                        p = Convert.ToInt32(p * 2.5);
                        eCC -= 0.25;
                        eCM += 1.8;
                        monsterSuffix = "|of Deadly Precision|";
                    }

                    
                }
                else if (pref == "[MINI BOSS] ")
                {
                    h = h * 3;
                    a = Convert.ToInt32(a * 1.5);
                    p = Convert.ToInt32(p * 3);
                    eCC -= 0.05;
                    eCM += 0.8;
                    monsterSuffix = "|of Conquer|";

                }


            }
            else
            {
                n = name;
                p = power;
                h = health;
                a = armor;
                pref = rarity;      
                // MONSTER Crit chance & multi
                eCC -= (eCritChance / 100);
                eCM += (eCritMulti / 100);
                // PLAYER crit chance & multi
                pCC -= (Program.currentPlayer.weaponCritChance / 100);
                pCM += (Program.currentPlayer.weaponCritDmgMult / 100);
            }
            while(h > 0)
            {
                Console.WriteLine("---------------------------");
                if (random)
                {
                    if (pref == "[Magic] ")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(pref);
                        Console.ResetColor();
                    }
                    else if (pref == "[RARE] ")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(pref);
                        Console.ResetColor();
                    }
                    else if (pref == "[ENRAGED] ")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(pref);
                        Console.ResetColor();
                    }
                    else if (pref == "[MINI BOSS] ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(pref);
                        Console.ResetColor();
                    }
                    else if (pref == "[normal] ")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(pref);
                        Console.ResetColor();
                    }
                }
                        Console.Write(n +" "+monsterSuffix);
                Console.WriteLine("\nSiła wroga: " + p);
                Console.WriteLine("Życie wroga: " + h+"\n");
                Console.WriteLine("Crit %: " + (1 - eCC) * 100 + "% " + " Crit multi: " + eCM * 100 + "%");
                Console.WriteLine("---------------------------\n\n\n");
                Console.WriteLine(Program.currentPlayer.name);
                Console.WriteLine("=======================");
                Console.WriteLine("(A)takuj    (B)roń się");
                Console.WriteLine("(U)ciekaj   (L)ecz się");
                Console.WriteLine("=======================");
                Console.Write("Crit chance: ");
                Console.Write((1 - pCC - Program.currentPlayer.weaponCritChance)*100);
                Console.Write("%       ");
                Console.Write("Crit multi: ");
                Console.Write((pCM + Program.currentPlayer.weaponCritDmgMult) * 100);
                Console.Write("%\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Życie: "+Program.currentPlayer.health);
                Console.ResetColor();
                Console.WriteLine("Poty: " + Program.currentPlayer.potion);
                Console.Write("Twój ruch: ");
                string input1 = Console.ReadLine();
                Console.Clear();

                if(input1.ToLower() == "a" || input1.ToLower() == "atakuj")
                {
                    // ATAK

                    double randomCritValueP = rand2.NextDouble();
                    double randomCritValueE = rand2.NextDouble();

                    if (randomCritValueP > pCC)
                    {
                        double attack = (rand.Next(2, Program.currentPlayer.weaponPower) + rand.Next(1, 4) * pCM ) - a;
                        Console.WriteLine("KRYTYK! Zadajesz dodatkowe " +pCM*100+"% obrażeń");
                        Console.WriteLine("Wykonujesz zamach bronią i uderzasz " + n + " za łącznie " + attack + " punktów życia.");
                        Console.WriteLine("==========================\n");
                        h -= attack;
                    }
                    else
                    {
                        double attack = (rand.Next(2, Program.currentPlayer.weaponPower) + rand.Next(1, 4))- a;
                        Console.WriteLine("Wykonujesz zamach bronią i uderzasz " + n + " za " + attack + " punktów życia.");
                        Console.WriteLine("==========================\n");
                        h -= attack;
                    }

                    if (h > 0) { 
                        if (randomCritValueE > eCC)
                        {
                            double damage = (rand.Next(1, p) * eCM) - Program.currentPlayer.armorValue;
                            Console.WriteLine("KRYTYK! " + n + " zadaje ci dodatkowe " + eCM*100 + "% obrażeń");
                            Console.WriteLine(n + " zadaje ci łącznie " + damage + " obrażeń");
                            Program.currentPlayer.health -= damage;
                        }
                        else
                        {
                            double damage = rand.Next(1, p) - Program.currentPlayer.armorValue;
                            Console.WriteLine(n + " zadaje ci łącznie " + damage + " obrażeń");
                            Program.currentPlayer.health -= damage;
                        }
                    }
                    Console.ReadKey();
                }
                else if(input1.ToLower() == "b" || input1.ToLower() == "broń się" || input1.ToLower() == "obrona" || input1.ToLower() == "bron sie")
                {
                    // OBRONA
                    double criticalHitDmgMult = 1;
                    if (rand2.Next(1, 11) == 1)
                        criticalHitDmgMult = 2 + Program.currentPlayer.weaponCritDmgMult;

                    double attack = (rand.Next(1, Program.currentPlayer.weaponPower) / 2) * criticalHitDmgMult;
                    int damage = (p/2) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    Console.WriteLine("Przygotowujesz się na cios od " + name + " w kontrze zadajesz " + attack + " obrażeń");
                    Console.WriteLine("Samemu tracisz " + damage + " życia");

                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input1.ToLower() == "u" || input1.ToLower() == "uciekaj" || input1.ToLower() == "ucieczka")
                {
                    // UCIECZKA
                    if(rand.Next(0, 2) == 0)
                    {
                        int damage = p * 3 - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine("Nie udaje ci się odwrócić i uciec od " + n);
                        Console.WriteLine("Przeciwnik dostaje bonus do ataku i zadaje ci " + damage + " w plecy");

                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Udaje ci się uciec z walki!");
                        Console.ReadKey();
                        // go to store
                    }

                }
                else if (input1.ToLower() == "l" || input1.ToLower() == "lecz się" || input1.ToLower() == "lecz sie" || input1.ToLower() == "ulecz")
                {
                    // POTY
                    if (Program.currentPlayer.potion > 0)
                    {
                        
                        
                        if(rand.Next(0,3) == 0)
                        {
                            int potionHealth = rand.Next(10, 21);
                            int damage = p * 2 - Program.currentPlayer.armorValue;
                            if (damage < 0)
                                damage = 0;
                            Console.WriteLine("!!! Częściowe niepowodzenie !!! (Otrzymujesz obrażenia)");
                            Console.WriteLine("Używasz potki i leczysz się za " + potionHealth + " punktów życia");
                            Console.WriteLine("Nim zdążysz zareagować, przeciwnik wykonuje zamach i zadaje ci " + damage + " obrażeń");
                            Program.currentPlayer.health += potionHealth;
                            Program.currentPlayer.health -= damage;
                            Program.currentPlayer.potion--;
                            Console.ReadKey();
                        }
                        else if(rand.Next(0,3) == 1)
                        {
                            int potionHealth = rand.Next(10, 21);
                            int bonus = potionHealth / 2;
                            int potionAndBonus = potionHealth + bonus;
                            Console.WriteLine("!!! BONUSOWE powodzenie !!! (+50% bonusowa siła leczenia)");
                            Console.WriteLine("Leczysz się za "+potionAndBonus+" punktów życia");
                            Program.currentPlayer.health += potionAndBonus;
                            Program.currentPlayer.potion--;
                            Console.ReadKey();
                        }
                        else
                        {
                            int potionHealth = rand.Next(10, 21);
                            Console.WriteLine("!!! Powodzenie !!!");
                            Console.WriteLine("Uleczyłeś się za " + potionHealth + " życia i udało ci się uniknąć ataku wroga!");
                            Program.currentPlayer.health += potionHealth;
                            Program.currentPlayer.potion--;
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        int damage = p * 2 - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Kiedy sięgałeś po eliksir i wyczułeś, że już ich nie masz, " + n + " zauważył okazję");
                        Console.WriteLine("i zadał ci " + damage + " obrażeń.");

                            Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }    

                }
                if(Program.currentPlayer.health <= 0)
                {
                    // ŚMIERĆ
                    Console.WriteLine("NIE ŻYJESZ.");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

            }
            if (h <= 0)
            {
                Console.Clear();
                Console.WriteLine("Twój przeciwnik leży na ziemi w kałuży krwi.\n");
                Console.WriteLine("Podchodzisz, aby zebrać to, co z niego zostało i znajdujesz:\n");
                Console.ReadKey();
                int coinsLoot = rand.Next(5, 21);
                Console.WriteLine(coinsLoot + " monet");
                Program.currentPlayer.coins += coinsLoot;
                Console.ReadLine();
            }
        }

        public static string LosowaNazwaPrzeciwnika()
        {
            switch (rand.Next(1, 11))
            {
                case 1:
                    return "Szkielet Wojownik";
                case 2:
                    return "Slime";
                case 3:
                    return "Ghoul";
                case 4:
                    return "Zjawa";
                case 5:
                    return "Upiór";
                case 6:
                    return "Szkielet Łucznik";
                case 7:
                    return "Zombie";
                case 8:
                    return "Zgnilec";
                case 9:
                    return "Topielec";
                case 10:
                    return "Poczwara";
            }
            return "Bandyta";
        }
        public static string LosowyPrefixPrzeciwnika()
        {
            double prefMagicC = rand.NextDouble();
            double prefRareC = rand.NextDouble();
            double prefEnragedC = rand.NextDouble();
            double prefMiniBossC = rand.NextDouble();


            if (prefMiniBossC > 0.95)
            {
                return "[MINI BOSS] ";
            }
            else if (prefEnragedC > 0.90)
            {
                return "[ENRAGED] ";
            }
            else if (prefRareC > 0.90)
            {
                return "[RARE] ";
            }
            else if (prefMagicC > 0.80)
            {
                return "[Magic] ";
            }
            return "[normal] ";

        }

        
      
    }
}
