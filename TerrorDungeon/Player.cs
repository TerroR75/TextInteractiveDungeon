using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorDungeon
{
    public class Player
    {
        public string name;
        public int coins = 0;
        public double health = 100;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponPower = 5;
        public double weaponCritDmgMult = 0;
        public double weaponCritChance = 0;


        // Difficulty calc
        //public static double diffMod = (Program.currentPlayer.health) + Program.currentPlayer.armorValue + Program.currentPlayer.weaponPower + Program.currentPlayer.weaponCritChance + Program.currentPlayer.weaponCritDmgMult;
    }
}
