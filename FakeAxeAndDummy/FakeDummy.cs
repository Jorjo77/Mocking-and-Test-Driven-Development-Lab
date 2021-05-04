
using FakeAxeAndDummy.Contracts;
using System;

namespace FakeAxeAndDummy
{
    public class FakeDummy : ITarget
    {
        public int Health => 0;

        public int GiveExperience()
        {
            return 10;
        }

        public bool IsDead()
        => this.Health <= 0;

        public void TakeAttack(int attackPoints)
        {

        }
    }
}
