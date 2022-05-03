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
            Console.WriteLine("Local bandit charges you with a dagger!");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Wounded Bandit", "", 30, 4, 0, 0, 0, 0.2);

        }
        public static void RandomEncounter1()
        {
            Console.Clear();
            Console.WriteLine("You hear some noise...");
            Console.ReadKey();
            Console.WriteLine("Then suddenly you are jumped by...");
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
                if (n == "Phantom" || n == "Ghost" || n == "Wraith")
                    typeOfMonster = "spirit";
                        // humanlike
                else if (n == "Bandit")
                    typeOfMonster = "humanlike";
                        // undead
                else if (n == "Ghoul" || n == "Zombie" || n == "Rotted Zombie" || n == "Drowned Undead")
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
                Console.WriteLine($"-----Difficulty modifier ({Math.Round(diffMod,4)*100}%)------");
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
                Console.WriteLine("\nEnemy power: " + Math.Round(p,1));
                Console.WriteLine("Enemy health: " + Math.Round(h,1)+"\n");
                Console.WriteLine("Crit %: " + Math.Round((1 - eCC) * 100) + "% " + " Crit multi: " + Math.Round(eCM * 100,2) + "%");
                Console.WriteLine("---------------------------\n\n\n");
                Console.WriteLine(Program.currentPlayer.name);
                Console.WriteLine("=======================");
                Console.WriteLine("(A)ttack    (D)efend");
                Console.WriteLine("(R)un   (H)eal");
                Console.WriteLine("=======================");
                Console.WriteLine($"STATISTICS:\nAttack: {Program.currentPlayer.weaponPower}\nArmour: {Program.currentPlayer.armorValue}\n==================");
                Console.WriteLine($"Kill count: {Program.currentPlayer.killCount}\n");
                Console.Write("Crit chance: ");
                Console.Write((1 - pCC - Program.currentPlayer.weaponCritChance)*100);
                Console.Write("%       ");
                Console.Write("Crit multi: ");
                Console.Write((pCM + Program.currentPlayer.weaponCritDmgMult) * 100);
                Console.Write("%\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hp: "+Program.currentPlayer.health);
                Console.ResetColor();
                Console.WriteLine("Potions: " + Program.currentPlayer.potion);
                Console.WriteLine($"EXP: {Program.currentPlayer.playerXP}    LEVEL: {Program.currentPlayer.playerLEVEL}");
                Console.Write("Your turn: ");
                string input1 = Console.ReadLine();
                Console.Clear();

                if(input1.ToLower() == "a" || input1.ToLower() == "attack")
                {
                    // ATAK

                    double randomHitChanceP = rand2.NextDouble();

                    if (randomHitChanceP > Program.currentPlayer.hitChance) {
                        double randomCritValueP = rand2.NextDouble();

                        if (randomCritValueP > pCC)
                        {
                            double attack = (rand.Next(2, Program.currentPlayer.weaponPower) + rand.Next(1, 4) * pCM ) - a;
                            Console.WriteLine("CRITICAL! You deal an additional " +pCM*100+"% damage");
                            Console.WriteLine("You attack and hit " + n + " for " + attack + " damage.");
                            Console.WriteLine("==========================\n");
                            h -= Math.Round(attack,1);
                        }
                        else
                        {
                            double attack = (rand.Next(2, Program.currentPlayer.weaponPower) + rand.Next(1, 4))- a;
                            Console.WriteLine("You attack and hit " + n + " for " + attack + " damage.");
                            Console.WriteLine("==========================\n");
                            h -= Math.Round(attack, 1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("MISS! You miss with your attack.\n");
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
                                Console.WriteLine("CRITICAL! " + n + " deals you an additional " + eCM*100 + "% dmg");
                                Console.WriteLine(n + " deals you in total " + damage + " damage");
                                Program.currentPlayer.health -= damage;
                            }
                            else
                            {
                                double damage = rand.Next(1, Convert.ToInt32(p)) - Program.currentPlayer.armorValue;
                                if (damage < 0)
                                    damage = 1;
                                Console.WriteLine(n + " deals you in total " + damage + " damage");
                                Program.currentPlayer.health -= Math.Round(damage, 1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("MISS! " + n + " attacks but it misses!\n");
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                else if(input1.ToLower() == "d" || input1.ToLower() == "defend")
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

                    Console.WriteLine("You prepare for an attack from " + name + " and you also parry and deal " + attack + " damage");

                    double randomHitChanceE = rand2.NextDouble();
                    if (randomHitChanceE > eHC) { 
                        Console.WriteLine("You lose " + Math.Round(damage,1) + " hp");

                        Program.currentPlayer.health -= Math.Round(damage, 1);
                        h -= Math.Round(attack, 1);
                    }
                    else
                    {
                        Console.WriteLine("MISS! " + n + " attacks but it misses!\n");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (input1.ToLower() == "r" || input1.ToLower() == "run")
                {
                    // UCIECZKA
                    if(rand.Next(0, 2) == 0)
                    {
                        double damage = p * 3 - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;

                        Console.WriteLine("You turn around and unsuccessfully run from " + n);
                        Console.WriteLine("Enemy gains a bonus and deals you " + Math.Round(damage,1) + " damage");

                        Program.currentPlayer.health -= Math.Round(damage,1);
                        
                    }
                    else
                    {
                        Console.WriteLine("You successfully dodged the fight!");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                        // go to store
                    }
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (input1.ToLower() == "h" || input1.ToLower() == "heal")
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
                            Console.WriteLine("!!! Partial Success !!! (You take damage)");
                            Console.WriteLine("You heal for " + potionHealth + " hp");
                            Console.WriteLine("Enemy also deals you " + Math.Round(damage, 1) + " damage");
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
                            Console.WriteLine("!!! BONUS success !!! (+50% bonus to healing power)");
                            Console.WriteLine("You heal for "+potionAndBonus+" hp");
                            Program.currentPlayer.health += potionAndBonus;
                            Program.currentPlayer.potion--;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            int potionHealth = rand.Next(10, 21);
                            Console.WriteLine("!!! SUCCESS !!!");
                            Console.WriteLine("You have healed for " + potionHealth + " hp and you dodged enemy attack!");
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
                        Console.WriteLine("When you were reaching for potions that you didnt have, " + n + " saw the opportunity");
                        Console.WriteLine("and dealt you " + Math.Round(damage,1) + " damage.");

                            Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                        Console.Clear();
                    }    

                }
                if(Program.currentPlayer.health <= 0)
                {
                    // ŚMIERĆ
                    Console.WriteLine("YOU ARE DEAD. Press any button to go back to the main menu...");
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
                Console.WriteLine($"You successfully defeated: {pref} {n} {monsterSuffix}  ({typeOfMonster})");
                Console.WriteLine("You have found:\n");
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
                Console.WriteLine(coinsLoot + " gold coins");
                Program.currentPlayer.coins += coinsLoot;
                Console.WriteLine($"You gain {xpGain}");
                Console.ReadLine();
                Shop.LoadShop(Program.currentPlayer);
            }
        }

        public static string LosowaNazwaPrzeciwnika()
        {
            switch (rand.Next(1, 11))
            {
                case 1:
                    return "Skeleton Warrior";
                case 2:
                    return "Slime";
                case 3:
                    return "Ghoul";
                case 4:
                    return "Phantom";
                case 5:
                    return "Wraith";
                case 6:
                    return "Skeleton Archer";
                case 7:
                    return "Zombie";
                case 8:
                    return "Rotted Zombie";
                case 9:
                    return "Drowned Undead";
                case 10:
                    return "Thing";
            }
            return "Bandit";
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
