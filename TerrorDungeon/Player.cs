using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorDungeon
{
    [Serializable]
    public class Player
    {
        public string name;
        public int id;
        public int coins = 0;
        public double health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponPower = 5;
        public double weaponCritDmgMult = 0;
        public double weaponCritChance = 0;
        public double playerXP = 0;
        public int playerLEVEL = 1;
        public int killCount = 0;



        // CURRENT ITEMS
        public string playerCurrentWeapon = "";
        public string playerCurrentArmor = "";

        // SHOP MODIFIER
        public int addShopValue = 0;





        // EXPERIENCE AND LEVEL CALC

        // Difficulty calc
        public static double GetDiffMod(Player p)
        {
            double diffMod = 1;
            double weaponPower = Convert.ToDouble(p.weaponPower);
            double armorValue = Convert.ToDouble(p.armorValue);
            
            if(p.health > 100)
            {
                diffMod += (p.health / 800);
            }
            if (p.weaponPower > 5)
            {

                diffMod += (weaponPower - 5) / 25;
            }
            if(p.armorValue > 0)
            {
                diffMod += (armorValue / 50);
            }
            if (p.weaponCritDmgMult>0)
            {
                diffMod += (p.weaponCritDmgMult / 200);
            }
            if (p.weaponCritChance > 0)
            {
                diffMod += (p.weaponCritChance / 100);
            }

                return diffMod;
        }

        //public static double diffMod = (Program.currentPlayer.health) + Program.currentPlayer.armorValue + Program.currentPlayer.weaponPower + Program.currentPlayer.weaponCritChance + Program.currentPlayer.weaponCritDmgMult;
    }
}
