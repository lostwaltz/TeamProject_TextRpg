using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roronoa_TXT_RPG
{
    internal class Monster
    {
        public string Name { get; set; }
        public int HealthPoint { get; set; }
        public int AttackDemage { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public Monster(string name, int healthpoint, int attackdemage, int defense, int speed)
        {
            Name = name;
            HealthPoint = healthpoint;
            AttackDemage = attackdemage;
            Defense = defense;
            Speed = speed;
        }
    }
}
