using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.ArmorUpgrades
{
    internal class MagicForceField : ArmorUpgrade
    {
        public MagicForceField(Armor armor) : base(armor)
        {
            UpgradeName = "Magic Force Field";
            UpgradeDefense = 999;
            UpgradeWeight = 0;
            Armor = armor;
        }

        public MagicForceField()
        {
            UpgradeName = "Magic Force Field";
            UpgradeDefense = 999;
            UpgradeWeight = 0;
        }

        public override Armor Upgrade(Armor selectedArmor)
        {
            return new MagicForceField(selectedArmor);
        }
        public override string GetName()
        {
            return Armor.GetName() + ", " + UpgradeName;
        }
        public override int GetDefense()
        {
            return Armor.GetDefense() + UpgradeDefense;
        }
        public override int GetWeight()
        {
            return Armor.GetDefense() + UpgradeWeight;
        }
    }
}
