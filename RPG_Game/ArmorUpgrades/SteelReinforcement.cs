using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.ArmorUpgrades
{
    internal class SteelReinforcement : ArmorUpgrade
    {
        public SteelReinforcement(Armor armor) :base(armor)
        {
            UpgradeName = "Steel Reinforcement";
            UpgradeDefense = 15;
            UpgradeWeight = 10;
            Armor = armor;
        }

        public SteelReinforcement()
        {
            UpgradeName = "Steel Reinforcement";
            UpgradeDefense = 15;
            UpgradeWeight = 10;
        }

        public override Armor Upgrade(Armor selectedArmor)
        {
            return new SteelReinforcement(selectedArmor);
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
