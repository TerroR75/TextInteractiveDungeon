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
            Console.WriteLine("Z głębi ciemności słyszysz szelest krzaków i zauważasz nagły zryw...");
            Console.WriteLine("Lokalny bandzior ze sztyletem szarżuje prosto na Ciebie.");
            Console.ReadKey();
            Console.Clear();
            Combat(false, "Ranny Bandyta", 30, 4, 0, 0,0);

        }


        //Encounter Tools

        public static void Combat(bool random, string name, int health, int power, int armor, double eCritChance, double eCritMulti)
        {
            string n = "";
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

            }
            else
            {
                n = name;
                p = power;
                h = health;
                a = armor;
                // MONSTER Crit chance & multi
                eCC -= (eCritChance / 100);
                eCM += (eCritMulti / 100);
                // PLAYER crit chance & multi
                pCC -= (Program.currentPlayer.weaponCritChance / 100);
                pCM += (Program.currentPlayer.weaponCritDmgMult / 100);
            }
            while(h > 0)
            {
                Console.WriteLine(n);
                Console.WriteLine("Siła wroga: " + p);
                Console.WriteLine("Życie wroga: " + h);
                Console.WriteLine("=======================");
                Console.WriteLine("(A)takuj    (B)roń się");
                Console.WriteLine("(U)ciekaj   (L)ecz się");
                Console.WriteLine("=======================");
                Console.WriteLine("Życie: "+Program.currentPlayer.health);
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
                while (h <= 0)
                {
                    Console.WriteLine("Twój przeciwnik leży na ziemi w kałuży krwi.\n");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Podchodzisz, aby zebrać to, co z niego zostało i znajdujesz:\n");
                    Console.ReadKey();
                    int coinsLoot = rand.Next(5, 21);
                    Console.WriteLine(coinsLoot + " monet");
                    Program.currentPlayer.coins += coinsLoot;
                    Console.ReadLine();
                    break;
                }

            }
        }
        
      
    }
}
