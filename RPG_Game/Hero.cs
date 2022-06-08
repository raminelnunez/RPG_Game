using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG_Game.WeaponUpgrades;
using RPG_Game.ArmorUpgrades;

namespace RPG_Game
{
    internal class Hero
    {
        public Game Game { get; set; }
        public readonly string Name;

        public readonly int BaseHealth = 25;
        public readonly int BaseStrength = 5;
        public readonly int BaseDefense = 5;
        public readonly int BaseSpeed = 10;

        public int Health;
        public int Strength;
        public int Defense;
        public int Speed;

        public Weapon? EquippedWeapon;
        public Armor? EquippedArmor;

        public List<Weapon> WeaponsBag = new List<Weapon>();
        public List<Armor> ArmorsBag = new List<Armor>();

        public List<WeaponUpgrade> WeaponUpgrades = new List<WeaponUpgrade>();
        public List<ArmorUpgrade> ArmorUpgrades = new List<ArmorUpgrade>();

        public Hero(Game game, string name)
        {
            Game = game;
            Name = name;

            Health = BaseHealth;
            Strength = BaseStrength;
            Defense = BaseDefense;
            Speed = BaseSpeed;
        }

        public void ResetStats()
        {
            this.Health = this.BaseHealth;
            if (EquippedWeapon != null && !WeaponsBag.Contains(EquippedWeapon))
                WeaponsBag.Add(EquippedWeapon);
            if (EquippedArmor != null && !ArmorsBag.Contains(EquippedArmor))
                ArmorsBag.Add(EquippedArmor);

            EquippedWeapon = null;
            EquippedArmor = null;

            CalcStats();
        }
        public void CalcStats()
        {
            Strength = BaseStrength;
            Defense = BaseDefense;
            Speed = BaseSpeed;

            if (EquippedWeapon != null)
            {
                Strength += EquippedWeapon.GetPower();
                Speed -= EquippedWeapon.GetWeight() / 10;
            }
            if (EquippedArmor != null)
            {
                Defense += EquippedArmor.GetDefense();
                Speed -= EquippedArmor.GetWeight() / 10;

            }
        }

        public void PlayerOptions()
        {
            Console.WriteLine(" ");
            Console.WriteLine("| S: Hero Stats | I: Inventory | W: Equip Weapon | A: Equip Armor | M: Main Menu | T: Next Turn |");
            Console.WriteLine("| U: Upgrades | z: Upgrade Weapon | x: Upgrade Armor |");
            switch (Console.ReadKey(true).KeyChar)
            {
                case 's':
                    {
                        ShowStats();
                        break;
                    }
                case 'i':
                    {
                        ShowInventory();
                        break;
                    }
                case 'w':
                    {
                        EquipWeapon();
                        break;
                    }
                case 'a':
                    {
                        EquipArmor();
                        break;
                    }
                case 'u':
                    {
                        ShowUpgrades();
                        break;
                    }
                case 'z':
                    {
                        UpgradeWeapon();
                        break;
                    }
                case 'x':
                    {
                        UpgradeArmor();
                        break;
                    }
                case 'm':
                    {
                        Game.Menu();
                        break;
                    }
                case 't':
                    {
                        return;
                    }
            }
        }

        public void ShowStats()
        {
            CalcStats();
            Console.WriteLine(" ");
            Console.WriteLine($"|{Name}'s STATS: |");
            Console.WriteLine($"| HEALTH: {Health}/{BaseHealth}hp | STRENGTH: {Strength}p | DEFENSE: {Defense}d | SPEED: {Speed}s |");
            if (EquippedWeapon != null)
                Console.WriteLine($"| EQUIPPED WEAPON: {EquippedWeapon.GetName()} ({EquippedWeapon.GetPower()}p) ({EquippedWeapon.GetWeight() / 2}kg) |");
            else
                Console.WriteLine($"| EQUIPPED WEAPON: None |");

            if (EquippedArmor != null)
                Console.Write($"| ARMOR: {EquippedArmor.GetName()} ({ EquippedArmor.GetDefense()}d)({ EquippedArmor.GetWeight() / 2}kg) | ");
            else
                Console.Write($"| ARMOR: None. | ");
            PlayerOptions();
        }

        public void ShowInventory()
        {
            Console.WriteLine(" ");
            Console.Write("WEAPONS: | ");
            int i = 0;
            foreach(Weapon weapon in WeaponsBag)
            {
                Console.Write($"[{i}]{weapon.GetName()}({weapon.GetPower()}p)({weapon.GetWeight() / 2}kg) | ");
                i++;
            }
            Console.WriteLine(" ");
            Console.Write("ARMOR: | ");
            i = 0;
            foreach (Armor armor in ArmorsBag)
            {
                Console.Write($"[{i}]{armor.GetName()}({armor.GetDefense()}d)({armor.GetWeight() / 2}kg)| ");
                i++;
            }
            Console.WriteLine(" ");
            
            PlayerOptions();
        }

        public void ShowUpgrades()
        {
            Console.WriteLine(" ");
            Console.Write("WEAPONS: | ");
            int i = 0;
            foreach (WeaponUpgrade weaponUpgrade in WeaponUpgrades)
            {
                Console.Write($"[{i}]{weaponUpgrade.UpgradeName}({weaponUpgrade.UpgradePower}p)({weaponUpgrade.UpgradeWeight / 2}kg) | ");
                i++;
            }
            Console.WriteLine(" ");
            Console.Write("ARMOR: | ");
            i = 0;
            foreach (ArmorUpgrade armorUpgrade in ArmorUpgrades)
            {
                Console.Write($"[{i}]{armorUpgrade.UpgradeName}({armorUpgrade.UpgradeDefense}d)({armorUpgrade.UpgradeWeight / 2}kg)| ");
                i++;
            }
            Console.WriteLine(" ");
            PlayerOptions();
        }


        public void EquipWeapon()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter Index To Select Weapon:");
            int i = Game.GetInt(false, true, (WeaponsBag.Count - 1));
            Console.WriteLine($"You Selected {WeaponsBag[i].GetName()}, Equip This Weapon?");

            switch(Console.ReadKey(true).KeyChar)
            {
                case 'y':
                    {
                        Console.WriteLine($"You've Equipped {WeaponsBag[i].GetName()}.");
                        if (!WeaponsBag.Contains(EquippedWeapon))
                            WeaponsBag.Add(EquippedWeapon);
                        EquippedWeapon = WeaponsBag[i];
                        WeaponsBag.RemoveAt(i);
                        CalcStats();
                        PlayerOptions();
                        break;
                    }
                case 'n':
                    {
                        Console.WriteLine("Equip Another Weapon?");
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case 'y':
                                {
                                    EquipWeapon();
                                    break;
                                }
                            case 'n':
                                {
                                    PlayerOptions();
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        public void EquipArmor()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter Index To Select Armor:");
            int i = Game.GetInt(false, true, (ArmorsBag.Count - 1));
            Console.WriteLine($"You Selected {ArmorsBag[i].GetName()}, Equip This Armor?");

            switch (Console.ReadKey(true).KeyChar)
            {
                case 'y':
                    {
                        Console.WriteLine($"You've Equipped {ArmorsBag[i].GetName()}.");
                        if (!ArmorsBag.Contains(EquippedArmor))
                            ArmorsBag.Add(EquippedArmor);
                        EquippedArmor = ArmorsBag[i];
                        ArmorsBag.RemoveAt(i);
                        CalcStats();
                        PlayerOptions();
                        break;
                    }
                case 'n':
                    {
                        Console.WriteLine("Equip Another Armor?");
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case 'y':
                                {
                                    EquipArmor();
                                    break;
                                }
                            case 'n':
                                {
                                    PlayerOptions();
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        public void UpgradeWeapon()
        {
            Console.WriteLine(" ");
            if (EquippedWeapon != null)
            {
                Console.WriteLine("Enter Index To Select Upgrade:");
                int i = Game.GetInt(false, true, (WeaponUpgrades.Count - 1));
                Console.WriteLine($"You Selected {WeaponUpgrades[i].UpgradeName}, Add This Upgrade?");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'y':
                        {
                            EquippedWeapon = WeaponUpgrades[i].Upgrade(EquippedWeapon);
                            CalcStats();
                            PlayerOptions();
                            break;
                        }
                    case 'n':
                        {
                            Console.WriteLine("Select Another Upgrade?");
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case 'y':
                                    {
                                        UpgradeWeapon();
                                        break;
                                    }
                                case 'n':
                                    {
                                        PlayerOptions();
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            Console.WriteLine("Can't Upgrade - No Weapon Equipped");
            Console.WriteLine(" ");
            PlayerOptions();
        }

        public void UpgradeArmor()
        {
            Console.WriteLine(" ");
            if (EquippedArmor != null)
            {
                Console.WriteLine("Enter Index To Select Upgrade:");
                int i = Game.GetInt(false, true, (ArmorUpgrades.Count - 1));
                Console.WriteLine($"You Selected {ArmorUpgrades[i].UpgradeName}, Add This Upgrade?");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'y':
                        {
                            EquippedArmor = ArmorUpgrades[i].Upgrade(EquippedArmor);
                            CalcStats();
                            PlayerOptions();
                            break;
                        }
                    case 'n':
                        {
                            Console.WriteLine("Select Another Upgrade?");
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case 'y':
                                    {
                                        UpgradeArmor();
                                        break;
                                    }
                                case 'n':
                                    {
                                        PlayerOptions();
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            Console.WriteLine("Can't Upgrade - No Armor Equipped");
            Console.WriteLine(" ");
            PlayerOptions();
        }

    }
}
