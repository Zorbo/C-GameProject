using WarriorWars.Enum;
using WarriorWars.Equipment;
using System;


namespace WarriorWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 30;
        private const int BAD_GUY_STARTING_HEALTH = 30;

        public readonly Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;

        private Weapon weapon;
        private Armor armor;

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;

            // We give the faction in the constructor
            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;


            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;
            enemy.health -= damage;

            AttackResult(enemy, damage);
        }


        private void AttackResult(Warrior enemy, int damage)
        {
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Tools.ColorfullWriteline($"{enemy.name} is dead!", ConsoleColor.Red);
                Tools.ColorfullWriteline($"{ name} is victorious!", ConsoleColor.Green);


            }
            else
            {
                Console.WriteLine($"{name} atacked {enemy.name}. {damage} damage was inflicted to {enemy.name}, remaining health of {enemy.name} is {enemy.health}");

            }
        }


        public bool IsAlive { get { return isAlive; } }
    }
}
