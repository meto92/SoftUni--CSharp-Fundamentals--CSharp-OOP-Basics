using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public class IceGiant : Unit, IUnit
    {
        private const int IceGiantAttackPower = 150;
        private const int IceGiantHealthPoints = 300;
        private const int IceGiantkDefensePoints = 60;
        private const int IceGiantEnergyPoints = 50;
        private const int IceGiantRange = 1;

        public IceGiant(string name, int x, int y) 
            : base(
                  name, 
                  x, 
                  y,
                  IceGiantAttackPower,
                  IceGiantHealthPoints, 
                  IceGiantkDefensePoints, 
                  IceGiantEnergyPoints, 
                  IceGiantRange)
        { }
    }
}