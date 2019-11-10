using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public class Warrior : Unit, IUnit
    {
        private const int WarriorAttackPower = 120;
        private const int WarriorHealthPoints = 180;
        private const int WarriorkDefensePoints = 70;
        private const int WarriorEnergyPoints = 60;
        private const int WarriorRange = 1;

        public Warrior(string name, int x, int y)
            : base(
                  name,
                  x, 
                  y, 
                  WarriorAttackPower, 
                  WarriorHealthPoints, 
                  WarriorkDefensePoints, 
                  WarriorEnergyPoints, 
                  WarriorRange)
        { }
    }
}