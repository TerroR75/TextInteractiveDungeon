using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorDungeon
{
    public class Items
    {
        static Random rand = new Random();
        public static string RandomWeaponGenerator()
        {
            switch (rand.Next(1, 7))
            {
                case 1:
                    return "Spear";
                case 2:
                    return "Axe";
                case 3:
                    return "Dagger";
                case 4:
                    return "Hammer";
                case 5:
                    return "Mace";
                case 6:
                    return "Scythe";
            }
            return "Sword";
        }

        public static string RandomArmorGenerator()
        {
            switch (rand.Next(0, 2))
            {
                case 0:
                    return "Helmet";
                case 1:
                    return "Chestpiece";
            }
            return "Chainmail";
        }

        public static string LosowyItemPreffix()
        {
            double randomNumber = rand.NextDouble();
            if (randomNumber > 0.8)
            {
                return "[M] ";
            }
            else if (randomNumber > 0.9)
            {
                return "[R] ";
            }
            else if (randomNumber > 0.97)
            {
                return "[U] ";
            }
            return "[n] ";
        }



        // DMG CALC
        public static int BaseDmgCalc(string name)
        {
            int Upper = 1;
            int Lower = 1;
            int dmg = 1;
            string n;
            n = name;
            if (n == "Sword")
            {
                Upper = 10;
                Lower = 5;

                dmg = rand.Next(Lower, Upper);
            }
            else if (n == "Axe")
            {
                Upper = 12;
                Lower = 3;

                dmg = rand.Next(Lower, Upper);
            }
            else if (n == "Spear")
            {
                Upper = 9;
                Lower = 6;

                dmg = rand.Next(Lower, Upper);
            }
            else if (n == "Dagger")
            {
                Upper = 8;
                Lower = 1;
                dmg = rand.Next(Lower, Upper);
            }
            else if (n == "Hammer")
            {
                Upper = 13;
                Lower = 3;
                dmg = rand.Next(Lower, Upper);
            }
            else if (n == "Mace")
            {
                Upper = 12;
                Lower = 2;
                dmg = rand.Next(Lower, Upper);
            }
            else if (n == "Scythe")
            {
                Upper = 10;
                Lower = 9;
                dmg = rand.Next(Lower, Upper);
            }
                return dmg;
        }
    }
}
