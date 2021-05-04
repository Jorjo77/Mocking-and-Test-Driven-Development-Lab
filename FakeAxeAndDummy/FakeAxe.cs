
using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy
{
    public class FakeAxe : IWeapon
    {
        public int AttackPoints => 20;

        public int DurabilityPoints => 10;

        public void Attack(ITarget target)
        {
            target.TakeAttack(AttackPoints);
        }
    }
}
