using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorDungeon
{
    public class encounters
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
            Combat(false, "Ranny Bandyta", "", 30, 4, 0, 0, 0, 0.2);

        }
        public static void RandomEncounter1()
        {
            Console.Clear();
            Console.WriteLine("Coś słyszysz.. hałas, zgrzyt, szelest.., a może szept?");
            Console.ReadKey();
            Console.WriteLine("Nagle zza zakrętu wyskakuje na Ciebie...");
            Console.ReadKey();
            Console.Clear();
            Combat(true, "", "", 0, 0, 0, 0, 0, 0);
        }

        //Encounter Tools

        public static void RandomEncounterHolder()
        {
            switch (rand.Next(0, 1))
            {
                case 0:
                    RandomEncounter1();
                    break;

            }
        }
        public static void Combat(bool random, string name, string rarity, int health, int power, int armor, double eCritChance, double eCritMulti, double eHitChance)
        {
            double xpGain = 100;
            string typeOfMonster = "";
            string monsterSuffix = "";
            string n;
            string pref;
            double p;
            double h;
            double a;

            // MONSTER crit chance, multi & hit chance
            double eCC = 0.95;
            double eCM = 2;
            double eHC = 0.2;
            // PLAYER crit chance & multi
            double pCC = 0.95;
            double pCM = 2;

            // DIFFICULTY MOD
            double diffMod = Player.GetDiffMod(Program.currentPlayer);



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
                h = Math.Round(rand.Next(10, 21) * diffMod,1);
                if (typeOfMonster == "undead")
                    h = Math.Round(h * 1.3,1);
                a = Math.Round(rand.Next(1, 3)*diffMod,1);
                if (typeOfMonster == "spirit")
                    a = 0;
                
                p = Math.Round(rand.Next(5, 11) * diffMod,1);
                eCC = 0.95 - (diffMod / 200);
                eCM = 1.2 * (diffMod/2);


                // RARIRTY BOOST - further increased stats based on monster rarity

                if (pref == "[Magic] ")
                {

                        int randomNumber = rand.Next(0, 5);
                        if (randomNumber == 0)
                        {
                            p = Math.Round(p * 1.2,1);
                            monsterSuffix = "|Powered|";
                        }
                        else if (randomNumber == 1)
                        {
                            h = Math.Round(h * 1.3,1);
                            monsterSuffix = "|Durable|";
                        }
                        else if (randomNumber == 2)
                        {
                            a = Math.Round(a * 1.3,1);
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
                            p = Math.Round(p * 1.5,1);
                            eCC -= 0.10;
                            eCM += 0.5;
                            monsterSuffix = "|Hard Hitter|";
                        }
                        else if (randomNumber == 1)
                        {
                            a = Math.Round(a * 1.5,1);
                            h = Math.Round(h * 1.5,1);
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
                        p = Math.Round(p * 3,1);
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
                        p = Math.Round(p * 2.5,1);
                        eCC -= 0.25;
                        eCM += 1.8;
                        monsterSuffix = "|of Deadly Precision|";
                    }

                    
                }
                else if (pref == "[MINI BOSS] ")
                {
                    h = h * 3;
                    a = Math.Round(a * 1.5,1);
                    p = Math.Round(p * 3,1);
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
                eHC = eHitChance;
                // MONSTER Crit chance & multi
                eCC -= (eCritChance / 100);
                eCM += (eCritMulti / 100);
                // PLAYER crit chance & multi
                pCC -= (Program.currentPlayer.weaponCritChance / 100);
                pCM += (Program.currentPlayer.weaponCritDmgMult / 100);
            }
            while(h > 0)
            {
                Console.WriteLine($"-----Modyfikator trudności ({Math.Round(diffMod,4)*100}%)------");
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

                // USER "INTERFACE"
                        Console.Write(n +" "+monsterSuffix);
                Console.WriteLine("\nSiła wroga: " + Math.Round(p,1));
                Console.WriteLine("Życie wroga: " + Math.Round(h,1)+"\n");
                Console.WriteLine("Crit %: " + Math.Round((1 - eCC) * 100) + "% " + " Crit multi: " + Math.Round(eCM * 100,2) + "%");
                Console.WriteLine("---------------------------\n\n\n");
                Console.WriteLine(Program.currentPlayer.name);
                Console.WriteLine("=======================");
                Console.WriteLine("(A)takuj    (B)roń się");
                Console.WriteLine("(U)ciekaj   (L)ecz się");
                Console.WriteLine("=======================");
                Console.WriteLine($"STATYSTYKI:\nAtak: {Program.currentPlayer.weaponPower}\nPancerz: {Program.currentPlayer.armorValue}\n==================");
                Console.WriteLine($"Liczba zabójstw: {Program.currentPlayer.killCount}\n");
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
                Console.WriteLine($"EXP: {Program.currentPlayer.playerXP}    LEVEL: {Program.currentPlayer.playerLEVEL}");
                Console.Write("Twój ruch: ");
                string input1 = Console.ReadLine();
                Console.Clear();

                if(input1.ToLower() == "a" || input1.ToLower() == "atakuj")
                {
                    // ATAK

                    double randomHitChanceP = rand2.NextDouble();

                    if (randomHitChanceP > Program.currentPlayer.hitChance) {
                        double randomCritValueP = rand2.NextDouble();

                        if (randomCritValueP > pCC)
                        {
                            double attack = (rand.Next(2, Program.currentPlayer.weaponPower) + rand.Next(1, 4) * pCM ) - a;
                            Console.WriteLine("KRYTYK! Zadajesz dodatkowe " +pCM*100+"% obrażeń");
                            Console.WriteLine("Wykonujesz zamach bronią i uderzasz " + n + " za łącznie " + attack + " punktów życia.");
                            Console.WriteLine("==========================\n");
                            h -= Math.Round(attack,1);
                        }
                        else
                        {
                            double attack = (rand.Next(2, Program.currentPlayer.weaponPower) + rand.Next(1, 4))- a;
                            Console.WriteLine("Wykonujesz zamach bronią i uderzasz " + n + " za " + attack + " punktów życia.");
                            Console.WriteLine("==========================\n");
                            h -= Math.Round(attack, 1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("PUDŁO! Wykonujesz zamach bronią, ale nie trafiłeś.\n");
                        Console.WriteLine("==========================\n");
                    }

                    double randomHitChanceE = rand2.NextDouble();

                    if (h > 0)
                    {
                        if (randomHitChanceE > eHC) {
                            double randomCritValueE = rand2.NextDouble();

                            if (randomCritValueE > eCC)
                            {
                                double damage = (rand.Next(1, Convert.ToInt32(p)) * eCM) - Program.currentPlayer.armorValue;
                                if (damage < 0)
                                    damage = 1;
                                Console.WriteLine("KRYTYK! " + n + " zadaje ci dodatkowe " + eCM*100 + "% obrażeń");
                                Console.WriteLine(n + " zadaje ci łącznie " + damage + " obrażeń");
                                Program.currentPlayer.health -= damage;
                            }
                            else
                            {
                                double damage = rand.Next(1, Convert.ToInt32(p)) - Program.currentPlayer.armorValue;
                                if (damage < 0)
                                    damage = 1;
                                Console.WriteLine(n + " zadaje ci łącznie " + damage + " obrażeń");
                                Program.currentPlayer.health -= Math.Round(damage, 1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("PUDŁO! " + n + " atakuje, ale nie trafia. Nie otrzymujesz obrażeń!\n");
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if(input1.ToLower() == "b" || input1.ToLower() == "broń się" || input1.ToLower() == "obrona" || input1.ToLower() == "bron sie")
                {
                    // OBRONA
                    double criticalHitDmgMult = 1;
                    if (rand2.Next(1, 11) == 1)
                        criticalHitDmgMult = 2 + Program.currentPlayer.weaponCritDmgMult;

                    double attack = (rand.Next(1, Program.currentPlayer.weaponPower) / 2) * criticalHitDmgMult;
                    double damage = (p/2) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    Console.WriteLine("Przygotowujesz się na cios od " + name + " w kontrze zadajesz " + attack + " obrażeń");

                    double randomHitChanceE = rand2.NextDouble();
                    if (randomHitChanceE > eHC) { 
                        Console.WriteLine("Samemu tracisz " + Math.Round(damage,1) + " życia");

                        Program.currentPlayer.health -= Math.Round(damage, 1);
                        h -= Math.Round(attack, 1);
                    }
                    else
                    {
                        Console.WriteLine("PUDŁO! " + n + " atakuje, ale nie trafia. Nie otrzymujesz obrażeń!\n");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (input1.ToLower() == "u" || input1.ToLower() == "uciekaj" || input1.ToLower() == "ucieczka")
                {
                    // UCIECZKA
                    if(rand.Next(0, 2) == 0)
                    {
                        double damage = p * 3 - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine("Nie udaje ci się odwrócić i uciec od " + n);
                        Console.WriteLine("Przeciwnik dostaje bonus do ataku i zadaje ci " + Math.Round(damage,1) + " w plecy");

                        Program.currentPlayer.health -= Math.Round(damage,1);
                        
                    }
                    else
                    {
                        Console.WriteLine("Udaje ci się uciec z walki!");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                        // go to store
                    }
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (input1.ToLower() == "l" || input1.ToLower() == "lecz się" || input1.ToLower() == "lecz sie" || input1.ToLower() == "ulecz")
                {
                    // POTY
                    if (Program.currentPlayer.potion > 0)
                    {
                        
                        
                        if(rand.Next(0,3) == 0)
                        {
                            int potionHealth = rand.Next(10, 21);
                            double damage = p * 2 - Program.currentPlayer.armorValue;
                            if (damage < 0)
                                damage = 0;
                            Console.WriteLine("!!! Częściowe niepowodzenie !!! (Otrzymujesz obrażenia)");
                            Console.WriteLine("Używasz potki i leczysz się za " + potionHealth + " punktów życia");
                            Console.WriteLine("Nim zdążysz zareagować, przeciwnik wykonuje zamach i zadaje ci " + Math.Round(damage, 1) + " obrażeń");
                            Program.currentPlayer.health += potionHealth;
                            Program.currentPlayer.health -= Math.Round(damage, 1);
                            Program.currentPlayer.potion--;
                            Console.ReadKey();
                            Console.Clear();
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
                            Console.Clear();
                        }
                        else
                        {
                            int potionHealth = rand.Next(10, 21);
                            Console.WriteLine("!!! Powodzenie !!!");
                            Console.WriteLine("Uleczyłeś się za " + potionHealth + " życia i udało ci się uniknąć ataku wroga!");
                            Program.currentPlayer.health += potionHealth;
                            Program.currentPlayer.potion--;
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        double damage = p * 2 - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("Kiedy sięgałeś po eliksir i wyczułeś, że już ich nie masz, " + n + " zauważył okazję");
                        Console.WriteLine("i zadał ci " + Math.Round(damage,1) + " obrażeń.");

                            Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                        Console.Clear();
                    }    

                }
                if(Program.currentPlayer.health <= 0)
                {
                    // ŚMIERĆ
                    Console.WriteLine("NIE ŻYJESZ. Kliknij dowolny przycisk, aby wrócić do menu głównego...");
                    Console.ReadKey();
                    Console.Clear();
                    Program.currentPlayer.coins = 0;
                    Program.currentPlayer.health = 10;
                    Program.currentPlayer.damage = 1;
                    Program.currentPlayer.armorValue = 0;
                    Program.currentPlayer.potion = 5;
                    Program.currentPlayer.weaponPower = 5;
                    Program.currentPlayer.weaponCritDmgMult = 0;
                    Program.currentPlayer.weaponCritChance = 0;
                    Program.currentPlayer.playerXP = 0;
                    Program.currentPlayer.playerLEVEL = 1;
                    Program.currentPlayer.killCount = 0;
                    Program.currentPlayer.playerCurrentWeapon = "";
                    Program.currentPlayer.playerCurrentArmor = "";
                }

            }
            if (h <= 0)
            {
                ++Program.currentPlayer.killCount;
                Console.Clear();
                Console.WriteLine($"Udało ci się pokonać: {pref} {n} {monsterSuffix}  ({typeOfMonster})");
                Console.WriteLine("Twój przeciwnik leży na ziemi w kałuży krwi.\n");
                Console.WriteLine("Podchodzisz, aby zebrać to, co z niego zostało i znajdujesz:\n");
                Console.ReadKey();
                int coinsLoot = rand.Next(8, 21);
                if (pref.Contains("[Magic] "))
                {
                    coinsLoot = Convert.ToInt32(coinsLoot * 1.2);
                }
                else if (pref.Contains("[RARE] "))
                {
                    coinsLoot = Convert.ToInt32(coinsLoot * 1.4);
                }
                else if (pref.Contains("[ENRAGED] "))
                {
                    coinsLoot = Convert.ToInt32(coinsLoot * 1.4);
                }
                else if (pref.Contains("[MINI BOSS] "))
                {
                    coinsLoot = Convert.ToInt32(coinsLoot * 1.8);
                }
                Console.WriteLine(coinsLoot + " monet");
                Program.currentPlayer.coins += coinsLoot;
                Console.WriteLine($"Zdobywasz {xpGain}");
                Console.ReadLine();
                Shop.LoadShop(Program.currentPlayer);
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


            if (prefMiniBossC > 0.98)
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
