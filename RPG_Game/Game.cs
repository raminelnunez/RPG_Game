using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG_Game.WeaponUpgrades;
using RPG_Game.ArmorUpgrades;
//raminel nunez
namespace RPG_Game
{
    internal class Game
    {
        public List<Fight> Fights = new List<Fight>();
        public int GamesPlayed = 0;
        public int GamesWon = 0;
        public bool InFight = false;
        
        public void Start()
        {
            Monster Goblin = new Monster("The Goblin", 15, 7, 0, 10);
            Monster Knight = new Monster("The Dark Knight", 30, 15, 5, 5);
            Monster Orc = new Monster("The American Ogre", 50, 23, 10, 2);

            Weapon Dagger = new Weapon("Dagger", 7, 5);
            Weapon Sword = new Weapon("Sword", 15, 7);
            Weapon Hammer = new Weapon("Hammer", 50, 20);

            Console.WriteLine("What's Your Name?");
            string PlayerName = Console.ReadLine().Trim();
            Hero Player = new Hero(this, PlayerName);

            Player.WeaponsBag.Add(Sword);
            Player.WeaponsBag.Add(Hammer);
            Player.WeaponsBag.Add(Dagger);

            WeaponUpgrade OPSpell = new OPMagicSpell();
            WeaponUpgrade Sharpener = new Sharpen();

            Player.WeaponUpgrades.Add(OPSpell);
            Player.WeaponUpgrades.Add(Sharpener);

            Armor NormalClothes = new Armor("Cloth Uniform", 0, 3);
            Armor LeatherArmor = new Armor("Leather Armor", 10, 10);
            Armor IronArmor = new Armor("Iron Armor", 25, 60);
            Armor DiamondArmor = new Armor("Diamond Armor", 50, 100);

            Player.ArmorsBag.Add(NormalClothes);
            Player.ArmorsBag.Add(LeatherArmor);
            Player.ArmorsBag.Add(IronArmor);
            Player.ArmorsBag.Add(DiamondArmor);

            ArmorUpgrade LeatherWraps = new LeatherWraps();
            ArmorUpgrade SteelReinforcement = new SteelReinforcement();
            ArmorUpgrade MagicForceField = new MagicForceField();
            ArmorUpgrade LevitationSpell = new LevitationSpell();

            Player.ArmorUpgrades.Add(LeatherWraps);
            Player.ArmorUpgrades.Add(SteelReinforcement);
            Player.ArmorUpgrades.Add(MagicForceField);
            Player.ArmorUpgrades.Add(LevitationSpell);

            Fight beginner = new Fight(this, Player, Goblin);
            Fight second = new Fight(this, Player, Knight);
            Fight last = new Fight(this, Player, Orc);

            Fights.Add(beginner);
            Fights.Add(second);
            Fights.Add(last);
            Fight();

        }

        public void Fight()
        {
            int NextFight = GamesPlayed;
            int PlayerHealth;
            if (GamesPlayed > 0)
                PlayerHealth = Fights[NextFight - 1].Player.Health;
            else
                PlayerHealth = Fights[0].Player.Health;
            if (GamesPlayed == 0)
                Fights[0].StartFight();
            if (NextFight < Fights.Count && PlayerHealth > 0)
            {
                Fights[NextFight].StartFight();
            }
            else
            {
                if (PlayerHealth <= 0)
                    Console.WriteLine("You're Dead.");
                Console.WriteLine("No More Fights Left");
                Menu();
            }
        }

        public void NewGame()
        {
            Console.WriteLine(" ");
            Console.WriteLine("OPTION IS WORK IN PROGRESS");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(" ");
            }
            Menu();
        }

        public void ResetGame()
        {
            InFight = false;
            GamesPlayed = 0;
            GamesWon = 0;
            foreach(Fight fight in Fights)
            {
                fight.Winner = "None, Yet...";
                fight.Player.ResetStats();
                fight.Monster.ResetStats();
            }
            Menu();
        }

        public void ShowGameStats()
        {
           Console.WriteLine($"| Games Played: {GamesPlayed} | Games Won: {GamesWon} |");
            Menu();
        }

        public void Menu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("| N: New Game | R: Reset Game | S: Show Game Stats | F: Next Fight |");
            switch(Console.ReadKey().KeyChar)
            {
                case 'n':
                    {
                        NewGame();
                        break;
                    }
                case 'r':
                    {
                        ResetGame();
                        break;
                    }
                case 's':
                    {
                        ShowGameStats();
                        break;
                    }
                case 'f':
                    {
                        if (!InFight)
                            Fight();
                        else
                        {
                            Console.WriteLine("Cannot Start New Fight While In A Fight.");
                            Menu();
                        }
                        break;
                    }
                    if (!InFight)
                        Fight();
                    else
                        return;
            }
        }

        public bool YesOrNo(string answer)
        {
            if (answer == null)
                return false;
            char[] Letters = answer.Trim().ToUpper().ToCharArray();
            if (Letters.Length == 0)
                return false;
            if (Letters[0].ToString() == "Y")
                return true;
            else 
                return false;
        }

        public int GetInt(bool NegativeAllowed, bool Limited, int Limit)
        {
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (!NegativeAllowed && input < 0)
                {
                    Console.WriteLine("Enter Positive Integer:");
                    input = GetInt(NegativeAllowed, Limited, Limit);

                }
                if (Limited && input > Limit)
                {
                    Console.WriteLine($"Enter Int Lower Than {Limit}:");
                    input = GetInt(NegativeAllowed, Limited, Limit);
                }
            }
            else
            {
                Console.WriteLine("Enter Integer:");
                input = GetInt(NegativeAllowed, Limited, Limit);
            }
            return input;
        }

        public int InputAnswerS(string answer, string[] options)
        {
            if (answer == null)
                return -1;
            string str = answer.Trim().ToUpper();
            int i = 0;
            if (str.Length == 0)
                return -1;
            foreach (string option in options)
            {
                if (str == option)
                    return i;
                i++;
            }
            return -1;
        }

        public int InputAnswerC(string answer, char[] options)
        {
            if (answer == null)
                return -1;
            char[] letters = answer.Trim().ToUpper().ToCharArray();
            int i = 0;
            if (letters.Length == 0)
                return -1;
            foreach (char option in options)
            {
                if (letters[0] == option)
                    return i;
                i++;
            }
            return -1;
        }
    }
}
