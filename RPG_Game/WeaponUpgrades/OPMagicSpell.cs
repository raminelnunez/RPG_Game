using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.WeaponUpgrades
{
    internal class OPMagicSpell : WeaponUpgrade
    {
        public OPMagicSpell()
        {
            UpgradeName = "Overpowered Magic Spell";
            UpgradePower = 999;
            UpgradeWeight = 0;
        }
        public OPMagicSpell(Weapon weapon) : base(weapon)
        {
            UpgradeName = "Overpowered Magic Spell";
            UpgradePower = 999;
            UpgradeWeight = 0;
            Weapon = weapon;
        }
        public override Weapon Upgrade(Weapon selectedWeapon)
        {
            return new OPMagicSpell(selectedWeapon);
        }
        public override string GetName()
        {
            return "Overpowered Magical " + Weapon.GetName();
        }
        public override int GetPower()
        {
            return Weapon.GetPower() + 999;
        }
        public override int GetWeight()
        {
            return Weapon.GetWeight();
        }
    }
}
