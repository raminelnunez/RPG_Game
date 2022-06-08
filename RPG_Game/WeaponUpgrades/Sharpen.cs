using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.WeaponUpgrades
{
    internal class Sharpen : WeaponUpgrade
    {
        public Sharpen()
        {
            UpgradeName = "Sharpen";
            UpgradePower = 5;
            UpgradeWeight = -1;
        }
        public Sharpen(Weapon weapon) : base(weapon)
        {
            UpgradeName = "Sharpen";
            UpgradePower = 5;
            UpgradeWeight = -1;
            Weapon = weapon;
        }
        public override Weapon Upgrade(Weapon selectedWeapon)
        {
            return new Sharpen(selectedWeapon);
        }
        public override string GetName()
        {
            return "Sharpened " + Weapon.GetName();
        }
        public override int GetPower()
        {
            return Weapon.GetPower() + UpgradePower;
        }

        public override int GetWeight()
        {
            return Weapon.GetPower() + UpgradeWeight;
        }
    }
}
