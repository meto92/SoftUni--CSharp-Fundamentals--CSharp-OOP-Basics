namespace WinterIsComing.Core
{
    using System;

    using Contracts;
    using Models;
    using WinterIsComing.Models.CombatHandlers;
    using WinterIsComing.Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case UnitType.Warrior:
                    Warrior warrior = new Warrior(name, x, y);
                    ICombatHandler warriorCombatHandler = new WarriorCombatHandler(warrior);

                    warrior.CombatHandler = warriorCombatHandler;

                    return warrior;
                case UnitType.Mage:
                    Mage mage = new Mage(name, x, y);
                    ICombatHandler mageCombatHandler = new MageCombatHandler(mage);

                    mage.CombatHandler = mageCombatHandler;

                    return mage;
                case UnitType.IceGiant:
                    IceGiant iceGiant = new IceGiant(name, x, y);
                    ICombatHandler iceGiantCombatHandler = new IceGiantCombatHandler(iceGiant);

                    iceGiant.CombatHandler = iceGiantCombatHandler;

                    return iceGiant;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}