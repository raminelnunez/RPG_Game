using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal abstract class WeaponUpgrade : Weapon
    {
        public string UpgradeName;
        public int UpgradePower;
        public int UpgradeWeight;
        public Weapon Weapon { get; set; }
        public abstract override string GetName();
        public abstract override int GetPower();
        public abstract override int GetWeight();
        public WeaponUpgrade() { }
        public WeaponUpgrade(Weapon weapon)
        {
            Weapon = weapon;
        }
        public virtual Weapon Upgrade(Weapon selectedWeapon)
        {
            return selectedWeapon;
        }

    }
}
