using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.ArmorUpgrades
{
    internal class LevitationSpell : ArmorUpgrade
    {
        public LevitationSpell(Armor armor) : base(armor)
        {
            UpgradeName = "Levitation Spell";
            UpgradeDefense = 0;
            UpgradeWeight = -999;
            Armor = armor;
        }

        public LevitationSpell()
        {
            UpgradeName = "Levitation Spell";
            UpgradeDefense = 0;
            UpgradeWeight = -999;
        }

        public override Armor Upgrade(Armor selectedArmor)
        {
            return new LevitationSpell(selectedArmor);
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
            return 0;
        }
    }
}
