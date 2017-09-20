using WarriorWars.Enum;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace WarriorWars
{
    class EntryPoint
    {

        static Random rng = new Random();
        // madness
        static List<Warrior> warriors = new List<Warrior>();


        static void Main(string[] args)
        {
            Warrior goodGuy = new Warrior("Conan", Faction.GoodGuy);
            Warrior badGuy = new Warrior("Krul", Faction.BadGuy);


            // Code need to inspect




            for (int i = 0; i < 20; i++)
            {
                if (rng.Next(0, 10) < 5)
                {
                   // warriors[i] = new Warrior("Conan" + i, Faction.GoodGuy);
                   warriors.Add (new Warrior("Beast" + i, Faction.GoodGuy));
                }              
                else
                {
                   // warriors[i] = new Warrior("Grull" + i, Faction.BadGuy);
                    warriors.Add(new Warrior("Grull" + i, Faction.BadGuy));
                }

            }

            // IDK some advanced technique to simplify the code
            var goodguya = warriors.Where(w => w.IsAlive && w.FACTION == Faction.GoodGuy).ToList();
            var badguya =
               (from w in warriors
                where w.IsAlive == true && w.FACTION == Faction.BadGuy
                select w).ToList();


            while ((goodGuy.IsAlive && badGuy.IsAlive))
            {
                // Between 0-10, so 50% chance
                if (rng.Next(0, 10) < 5)
                {
                    goodGuy.Attack(badGuy);
                }
                // if its bigger than 5 the bad guy attack
                else
                {
                    badGuy.Attack(goodGuy);
                }

                Thread.Sleep(100);
            }
            System.Console.ReadLine();
        }
    }
}
