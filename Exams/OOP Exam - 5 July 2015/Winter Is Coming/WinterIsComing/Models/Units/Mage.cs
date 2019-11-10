using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public class Mage : Unit, IUnit
    {
        private const int MageAttackPower = 80;
        private const int MageHealthPoints = 80;
        private const int MagekDefensePoints = 40;
        private const int MageEnergyPoints = 120;
        private const int MageRange = 2;

        public Mage(string name, int x, int y) 
            : base(
                  name, 
                  x, 
                  y,
                  MageAttackPower,
                  MageHealthPoints, 
                  MagekDefensePoints, 
                  MageEnergyPoints, 
                  MageRange)
        { }
    }
}