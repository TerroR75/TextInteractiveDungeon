using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorDungeon
{
    public class Shop
    {

        static Random rand = new Random();
        public static void LoadShop(Player p)
        {
            // BASE PRICE OF ITEMS
            int itemPriceW1 = rand.Next(8,13)+Program.currentPlayer.addShopValue;
            int itemPriceW2 = rand.Next(8, 13)+ Program.currentPlayer.addShopValue;
            int itemPriceA1 = rand.Next(8, 13)+ Program.currentPlayer.addShopValue;
            int itemPriceA2 = rand.Next(8, 13)+ Program.currentPlayer.addShopValue;
            int potionPrice = 15;

            // BASE VALUES OF ITEMS
            int itemStatValueW1 = 1;
            int itemStatValueW2 = 1;
            int itemStatValueA1 = 1+ Program.currentPlayer.addShopValue;
            int itemStatValueA2 = 1+ Program.currentPlayer.addShopValue;

            // ITEM GENERATION
            string itemW1 = Items.LosowyItemPreffix() + Items.RandomWeaponGenerator();
            string itemW2 = Items.LosowyItemPreffix() + Items.RandomWeaponGenerator();
            string itemA1 = Items.LosowyItemPreffix() + Items.RandomArmorGenerator();
            string itemA2 = Items.LosowyItemPreffix() + Items.RandomArmorGenerator();

            int potionNumber = 2;

            // DIFFICULTY MODIFIER
            double diffMod = Player.GetDiffMod(Program.currentPlayer);




            // FIRST PRICE CALC
            if (itemW1.Contains("Scythe"))
            {
                itemPriceW1 += 5;
            }
            else if (itemW1.Contains("Dagger"))
            {
                itemPriceW1 -= 5;
            }
            if (itemW2.Contains("Scythe"))
            {
                itemPriceW2 += 5;
            }
            else if (itemW2.Contains("Dagger"))
            {
                itemPriceW2 -= 5;
            }

            // SETTING DEFAULT VALUES (Dmg, armor)
            if (itemW1.Contains("Sword") || itemW1.Contains("Axe") || itemW1.Contains("Dagger") || itemW1.Contains("Mace") || itemW1.Contains("Hammer") || itemW1.Contains("Scythe") || itemW1.Contains("Spear"))
            {
                if (itemW1.Contains("Sword"))
                {
                    itemStatValueW1 = Convert.ToInt32((Items.BaseDmgCalc("Sword") + Program.currentPlayer.addShopValue)*Player.GetDiffMod(Program.currentPlayer));
                }
                else if (itemW1.Contains("Axe"))
                {
                    itemStatValueW1 = Convert.ToInt32((Items.BaseDmgCalc("Axe") + Program.currentPlayer.addShopValue) * Player.GetDiffMod(Program.currentPlayer));
                }
                else if (itemW1.Contains("Dagger"))
                {
                    itemStatValueW1 = Convert.ToInt32((Items.BaseDmgCalc("Dagger") + Program.currentPlayer.addShopValue) * Player.GetDiffMod(Program.currentPlayer));
                }
                else if (itemW1.Contains("Mace"))
                {
                    itemStatValueW1 = Convert.ToInt32((Items.BaseDmgCalc("Mace") + Program.currentPlayer.addShopValue) * Player.GetDiffMod(Program.currentPlayer));
                }
                else if (itemW1.Contains("Hammer"))
                {
                    itemStatValueW1 = Convert.ToInt32((Items.BaseDmgCalc("Hammer") + Program.currentPlayer.addShopValue) * Player.GetDiffMod(Program.currentPlayer));
                }
                else if (itemW1.Contains("Scythe"))
                {
                    itemStatValueW1 = Convert.ToInt32((Items.BaseDmgCalc("Scythe") + Program.currentPlayer.addShopValue) * Player.GetDiffMod(Program.currentPlayer));
                }
                else if (itemW1.Contains("Spear"))
                {
                    itemStatValueW1 = Convert.ToInt32((Items.BaseDmgCalc("Spear") + Program.currentPlayer.addShopValue) * Player.GetDiffMod(Program.currentPlayer));
                }
            }
            if (itemW2.Contains("Sword") || itemW2.Contains("Axe") || itemW2.Contains("Dagger") || itemW2.Contains("Mace") || itemW2.Contains("Hammer") || itemW2.Contains("Scythe") || itemW2.Contains("Spear"))
            {
                if (itemW2.Contains("Sword"))
                {
                    itemStatValueW2 = Items.BaseDmgCalc("Sword");
                }
                else if (itemW2.Contains("Axe"))
                {
                    itemStatValueW2 = Items.BaseDmgCalc("Axe");
                }
                else if (itemW2.Contains("Dagger"))
                {
                    itemStatValueW2 = Items.BaseDmgCalc("Dagger");
                }
                else if (itemW2.Contains("Mace"))
                {
                    itemStatValueW2 = Items.BaseDmgCalc("Mace");
                }
                else if (itemW2.Contains("Hammer"))
                {
                    itemStatValueW2 = Items.BaseDmgCalc("Hammer");
                }
                else if (itemW2.Contains("Scythe"))
                {
                    itemStatValueW2 = Items.BaseDmgCalc("Scythe");
                }
                else if (itemW2.Contains("Spear"))
                {
                    itemStatValueW2 = Items.BaseDmgCalc("Spear");
                }
            }
            if (itemA1.Contains("Helmet") || itemA1.Contains("Chestpiece") || itemA1.Contains("Chainmail"))
            {
                if (itemA1.Contains("Helmet"))
                {
                    itemStatValueA1 = rand.Next(1, 3);
                }
                if (itemA1.Contains("Chestpiece"))
                {
                    itemStatValueA1 = rand.Next(1, 3);
                }
                if (itemA1.Contains("Chainmail"))
                {
                    itemStatValueA1 = rand.Next(1, 3);
                }
            }
            if (itemA2.Contains("Helmet") || itemA2.Contains("Chestpiece") || itemA2.Contains("Chainmail"))
            {
                if (itemA2.Contains("Helmet"))
                {
                    itemStatValueA2 = rand.Next(1, 3);
                }
                if (itemA1.Contains("Chestpiece"))
                {
                    itemStatValueA2 = rand.Next(1, 3);
                }
                if (itemA1.Contains("Chainmail"))
                {
                    itemStatValueA2 = rand.Next(1, 3);
                }
            }

            // BOOSTING DEAFULT VALUES based on rarity
            if (itemW1.Contains("[M] ") || itemW1.Contains("[R] ") || itemW1.Contains("[U] "))
            {
                if (itemW1.Contains("[M] "))
                {
                    itemStatValueW1 = Convert.ToInt32(itemStatValueW1 * 1.2);
                    itemPriceW1 = Convert.ToInt32(itemPriceW1 * 1.33);
                }
                else if (itemW1.Contains("[R] "))
                {
                    itemStatValueW1 = Convert.ToInt32(itemStatValueW1 * 1.4);
                    itemPriceW1 = Convert.ToInt32(itemPriceW1 * 1.66);
                }
                else if (itemW1.Contains("[U] "))
                {
                    itemStatValueW1 = Convert.ToInt32(itemStatValueW1 * 1.6);
                    itemPriceW1 = Convert.ToInt32(itemPriceW1 * 2);
                }
            }
            if (itemW2.Contains("[M] ") || itemW2.Contains("[R] ") || itemW2.Contains("[U] "))
            {
                if (itemW2.Contains("[M] "))
                {
                    itemStatValueW2 = Convert.ToInt32(itemStatValueW2 * 1.2);
                    itemPriceW2 = Convert.ToInt32(itemPriceW2 * 1.33);
                }
                else if (itemW2.Contains("[R] "))
                {
                    itemStatValueW2 = Convert.ToInt32(itemStatValueW2 * 1.4);
                    itemPriceW2 = Convert.ToInt32(itemPriceW2 * 1.66);
                }
                else if (itemW2.Contains("[U] "))
                {
                    itemStatValueW2 = Convert.ToInt32(itemStatValueW2 * 1.6);
                    itemPriceW2 = Convert.ToInt32(itemPriceW2 * 2);
                }
            }
            if (itemA1.Contains("[M] ") || itemA1.Contains("[R] ") || itemA1.Contains("[U] "))
            {
                if (itemA1.Contains("[M] "))
                {
                    itemStatValueA1 = Convert.ToInt32(itemStatValueA1 * 1.2);
                    itemPriceA1 = Convert.ToInt32(itemPriceA1 * 1.33);
                }
                else if (itemA1.Contains("[R] "))
                {
                    itemStatValueA1 = Convert.ToInt32(itemStatValueA1 * 1.4);
                    itemPriceA1 = Convert.ToInt32(itemPriceA1 * 1.66);
                }
                else if (itemW1.Contains("[U] "))
                {
                    itemStatValueA1 = Convert.ToInt32(itemStatValueA1 * 1.6);
                    itemPriceA1 = Convert.ToInt32(itemPriceA1 * 2);
                }
            }
            if (itemA2.Contains("[M] ") || itemA2.Contains("[R] ") || itemA2.Contains("[U] "))
            {
                if (itemA2.Contains("[M] "))
                {
                    itemStatValueA2 = Convert.ToInt32(itemStatValueA2 * 1.2);
                    itemPriceA2 = Convert.ToInt32(itemPriceA2 * 1.33);
                }
                else if (itemA1.Contains("[R] "))
                {
                    itemStatValueA2 = Convert.ToInt32(itemStatValueA2 * 1.4);
                    itemPriceA2 = Convert.ToInt32(itemPriceA2 * 1.66);
                }
                else if (itemW1.Contains("[U] "))
                {
                    itemStatValueA2 = Convert.ToInt32(itemStatValueA2 * 1.6);
                    itemPriceA2 = Convert.ToInt32(itemPriceA2 * 2);
                }
            }




            int licznikUzyc = 0;
            while (licznikUzyc < 2 && Program.currentPlayer.coins >= 0)
            {

                // SHOP USER INTERFACE
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"             Magical Shop   {licznikUzyc}/2       ");
                Console.ResetColor();
                Console.WriteLine("==========Item List============");
                // 1.
                Console.Write("\n1. ");
                if (itemW1.Contains("[M] "))
                { 
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (itemW1.Contains("[R] "))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (itemW1.Contains("[U] "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(itemW1);
                Console.ResetColor();
                if (itemW1 != "")
                {
                    Console.Write(" for " + itemPriceW1 + " gold coins");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("    (+" + itemStatValueW1 + " attack)");
                    Console.ResetColor();
                }
               
                // 2.
                Console.Write("\n2. ");
                if (itemW2.Contains("[M] "))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (itemW2.Contains("[R] "))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (itemW2.Contains("[U] "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(itemW2);
                Console.ResetColor();
                if (itemW2 != "")
                {
                    Console.Write(" for " + itemPriceW2 + " gold coins");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("    (+" + itemStatValueW2 + " attack)");
                    Console.ResetColor();
                }
                

                // 3.
                Console.Write("\n3. ");
                if (itemA1.Contains("[M] "))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (itemA1.Contains("[R] "))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (itemA1.Contains("[U] "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(itemA1);
                Console.ResetColor();
                if (itemA1 != "")
                {
                    Console.Write(" for " + itemPriceA1 + " gold coins");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("    (+" + itemStatValueA1 + " armour)");
                    Console.ResetColor();
                }
               

                // 4.
                Console.Write("\n4. ");
                if (itemA2.Contains("[M] "))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (itemA2.Contains("[R] "))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (itemA2.Contains("[U] "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(itemA2);
                Console.ResetColor();
                if (itemA2 != "")
                {
                    Console.Write(" for " + itemPriceA2 + " gold coins");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("    (+" + itemStatValueA2 + " armour)");
                    Console.ResetColor();
                }


                // 5. POTIONS
                if (potionNumber > 0)
                {
                    Console.WriteLine($"\n5. Potions: {potionNumber} / 2");
                }

                // 6. Save & Quit
                Console.WriteLine("6. Save & Quit");

                // 7. LEAVE
                Console.WriteLine("7. Quit the shop");

                // Player's choice 
                Console.WriteLine($"\n\n{Program.currentPlayer.name}");
                Console.WriteLine("Coins: " + Program.currentPlayer.coins);
                Console.WriteLine($"Healing potions: {Program.currentPlayer.potion}");


                // ======================LISTING PLAYER'S EQUIPMENT START=======================
                Console.Write("Weapon: ");
                if (Program.currentPlayer.playerCurrentWeapon.Contains("[M] "))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Program.currentPlayer.playerCurrentWeapon +" "+Program.currentPlayer.weaponPower+ "       ");
                    Console.ResetColor();
                }
                else if (Program.currentPlayer.playerCurrentWeapon.Contains("[R] "))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Program.currentPlayer.playerCurrentWeapon + " " + Program.currentPlayer.weaponPower + "       ");
                    Console.ResetColor();
                }
                else if (Program.currentPlayer.playerCurrentWeapon.Contains("[U] "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Program.currentPlayer.playerCurrentWeapon + " " + Program.currentPlayer.weaponPower + "       ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Program.currentPlayer.playerCurrentWeapon + " " + Program.currentPlayer.weaponPower + "       ");
                }
                Console.Write("Armour: ");
                if (Program.currentPlayer.playerCurrentArmor.Contains("[M] "))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(Program.currentPlayer.playerCurrentArmor + " " + Program.currentPlayer.armorValue);
                    Console.ResetColor();
                }
                else if (Program.currentPlayer.playerCurrentArmor.Contains("[R] "))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Program.currentPlayer.playerCurrentArmor + " " + Program.currentPlayer.armorValue);
                    Console.ResetColor();
                }
                else if (Program.currentPlayer.playerCurrentArmor.Contains("[U] "))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Program.currentPlayer.playerCurrentArmor + " " + Program.currentPlayer.armorValue);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Program.currentPlayer.playerCurrentArmor + " " + Program.currentPlayer.armorValue);
                }
                //===================== LISTING PLAYER'S EQUIPMENT END=========================




                Console.Write("\nItem number:");
                /*string input;
                input = Convert.ToString(Console.ReadKey());*/
                char input = Console.ReadKey().KeyChar;

                //ITEM 1
                if (input == '1')
                {
                    if (Program.currentPlayer.coins >= itemPriceW1)
                    {
                        Program.currentPlayer.playerCurrentWeapon = itemW1;
                        ++Program.currentPlayer.addShopValue;
                        licznikUzyc++;
                        Program.currentPlayer.coins -= itemPriceW1;
                        p.weaponPower = itemStatValueW1;
                        Console.WriteLine("\n\nYou bought: " + itemW1 + " for " + itemPriceW1 + " gold coins");
                        Console.WriteLine("You gain: " + itemStatValueW1 + " damage");
                        Console.WriteLine("Press any button.");
                        itemW1 = "";
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n\nNie stać cię.");
                        Console.WriteLine("Wciśnij dowolny przycisk.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    
                    
                }

                // ITEM 2
                else if(input == '2')
                {
                    if (Program.currentPlayer.coins >= itemPriceW2)
                    {
                        Program.currentPlayer.playerCurrentWeapon = itemW2;
                        ++Program.currentPlayer.addShopValue;
                        licznikUzyc++;
                        Program.currentPlayer.coins -= itemPriceW2;
                        Program.currentPlayer.weaponPower = itemStatValueW2;
                        Console.WriteLine("\n\n You bought: " + itemW2 + " for " + itemPriceW2 + " gold coins");
                        Console.WriteLine("You gain: " + itemStatValueW2 + " damage");
                        Console.WriteLine("Press any button.");
                        itemW2 = "";
                        Console.ReadKey();
                        Console.Clear();
                        
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou cannot afford that.");
                        Console.ReadLine();
                    }
                    
                }
                
                // ITEM 3
                else if (input == '3')
                {
                    if(Program.currentPlayer.coins >= itemPriceA1)
                    {
                        Program.currentPlayer.playerCurrentArmor = itemA1;
                        ++Program.currentPlayer.addShopValue;
                        licznikUzyc++;
                        Program.currentPlayer.coins -= itemPriceA1;
                        Program.currentPlayer.armorValue = itemStatValueA1;
                        Console.WriteLine("\n\nYou Bought: " + itemA1 + " for " + itemPriceA1 + " gold coins.");
                        Console.WriteLine("You gain: " + itemStatValueA1 + " damage");
                        Console.WriteLine("Press any button.");
                        itemA1 = "";
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou cannot afford that.");
                        Console.WriteLine("Press any button.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    
                }


                // ITEM 4
                else if (input == '4')
                {
                    if (Program.currentPlayer.coins >= itemPriceA2)
                    {
                        Program.currentPlayer.playerCurrentArmor = itemA2;
                        ++Program.currentPlayer.addShopValue;
                        licznikUzyc++;
                        Program.currentPlayer.coins -= itemPriceA2;
                        Program.currentPlayer.armorValue = itemStatValueA2;
                        Console.WriteLine("\n\nYou bought: " + itemA2 + " for " + itemPriceA2 + " gold coins");
                        Console.WriteLine("You gain: " + itemStatValueA2 + " damage");
                        itemA2 = "";
                        Console.WriteLine("Press any button.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou cannot afford that.");
                        Console.WriteLine("Press any button.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                 
                }
                // 5. BUY POTION
                else if (input == '5')
                {
                    if (Program.currentPlayer.coins >= potionPrice)
                    {
                        potionNumber--;
                        Program.currentPlayer.potion++;
                        Program.currentPlayer.coins -= potionPrice;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\n\nYou bought healing potion for {potionPrice}");
                        Console.ResetColor();
                        Console.WriteLine("Press any button.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou cannot afford that.");
                        Console.WriteLine("Press any button.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                // 6. SAVE & QUIT
                else if (input == '6')
                {
                    Console.WriteLine("Leaving the incubator... for now.");
                    Console.ReadKey();
                    Program.Quit();
                }
                // 7. LEAVE  THE SHOP
                else if (input == '7')
                {
                    Console.WriteLine("\n\nYou are leaving the shop.");
                    Console.WriteLine("Press any button.");
                    Console.ReadKey();
                    break;
                }
            }


        }





        //


        
    }
}
