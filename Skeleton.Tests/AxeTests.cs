using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_Attack_Loose_Weapon_Durability()
        {
            Axe axe = new Axe(10, 20);

            axe.Attack(new Dummy(100, 100));

            Assert.AreEqual(axe.DurabilityPoints, 19);
        }

        [Test]
        public void Test_Attack_With_Zero_Durability_Throw_Error()
        {
            Axe axe = new Axe(10, 1);

            axe.Attack(new Dummy(100, 100));

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));
            });
                        
        }

        [Test]
        public void Test_Attack_With_Negative_Durability_Throw_Error()
        {
            Axe axe = new Axe(10, -5);
                      

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(new Dummy(100, 100));
            });

        }
    }
}