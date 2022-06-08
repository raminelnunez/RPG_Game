using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Fight
    {
        public Game Game;
        public Hero Player;
        public Monster Monster;
        public int Turn;
        public string Winner;

        public Fight(Game game, Hero player, Monster monster)
        {
            Game = game;
            Player = player;
            Monster = monster;
        }
        public void ResetFight()
        {
            Winner = "None, yet...";
        }
        public void StartFight()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"| TURN: #{Turn} |");
            Random rnd = new Random();
            int roll = rnd.Next(0, 10);
            Game.InFight = true;
            Game.GamesPlayed++;

            if (Player.Speed > Monster.Speed)
            {
                Console.WriteLine("While entering a cave, you encounter a monster...");
                HeroTurn(rnd);
            }
            else
            {
                Console.WriteLine("While entering a cave, you're suddenly attacked by a monster (!)");
                MonsterTurn(rnd);
            }
            

        }
        public void HeroTurn(Random rnd)
        {
            int roll = rnd.Next(0, 10);

            bool AttackEvaded = false;
            if (Monster.Speed - Player.Speed > roll)
                AttackEvaded = true;

            Turn++;
            Console.WriteLine("------------------------");
            Console.WriteLine($"| TURN: #{Turn} |");

            Player.PlayerOptions();
            Player.CalcStats();

            if (Player.EquippedWeapon != null)
                Console.WriteLine($"{Player.Name} uses {Player.EquippedWeapon.GetName()} against {Monster.Name}");
            else
                Console.WriteLine($"{Player.Name} slaps {Monster.Name}");

            int Damage = Player.Strength - Monster.Defense;
            if (AttackEvaded)
            {
                Console.WriteLine($"{Monster.Name} was fast enough, they've evaded the attack...");
            }
            else
            {
                if (Player.Speed < 0)
                {
                    Damage += Player.Speed;
                    Console.WriteLine($"Due To Encumbrance, You Face A {Player.Speed} Penalty To The Damage You Deal");
                }
                if (Damage > 0)
                {
                    Monster.Health -= Damage;
                    Console.WriteLine($"{Player.Name} caused {Damage} damage!");
                    Console.WriteLine($"{Monster.Name}'s Health is now {Monster.Health}");
                }
                else
                {
                    Console.WriteLine("No damage...");
                }
            }
            
            if (Monster.Health <= 0)
            {
                Console.WriteLine($"{Monster.Name}'s dead...");
                Console.WriteLine($"{Player.Name} wins the battle!");
                Winner = Player.Name;
                Game.InFight = false;
                Game.GamesWon++;
                Console.WriteLine(" ");
                Console.WriteLine("------------------------");
                Game.Menu();
            }
            else
                MonsterTurn(rnd);
            

        }
        public void MonsterTurn(Random rnd)
        {

            int roll = rnd.Next(0, 10);

            bool AttackEvaded = false;
            if (Player.Speed - Monster.Speed > roll)
                AttackEvaded = true;

            Console.WriteLine($"{Monster.Name} attacks {Player.Name}");
            int Damage = Monster.Strength - Player.Defense;

            if (AttackEvaded)
            {
                Console.WriteLine($"{Player.Name} was fast enough, they've evaded the attack...");
            }
            else
            {
                if (Monster.Speed < 0)
                {
                    Damage += Monster.Speed;
                    Console.WriteLine($"Due To Encumbrance, {Monster.Name} Faces A {Monster.Speed} Penalty To The Damage They Deal");
                }
                if (Damage > 0)
                {
                    Player.Health -= Damage;
                    Console.WriteLine($"{Monster.Name} deals {Damage} damage!");
                    Console.WriteLine($"{Player.Name}'s Health is now {Player.Health}");
                }
                else
                {
                    Console.WriteLine("No damage...");
                }
            }
            if (Player.Health <= 0)
            {
                Console.WriteLine($"Ouch, {Player.Name} is dead... ");
                Winner = Monster.Name;
                Game.InFight = false;
                Console.WriteLine(" ");
                Console.WriteLine("------------------------");
                Game.Menu();
            }
            else
                HeroTurn(rnd);
        }
    }
}
