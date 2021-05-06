using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrorDungeon
{
    class Player
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
    }
}
