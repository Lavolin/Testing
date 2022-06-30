namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Constructor_Should_Create_Data()
        {
        Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Count, arena.Warriors.Count);
            Assert.AreEqual(0, arena.Count);

        }

        [Test]
        public void Enroll_ShouldAddWarriors_ValidData()
        {
            var arena = new Arena();
            Warrior warrior = new Warrior("Tosho", 100, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
            Assert.True(arena.Warriors.Any(x => x.Name == "Tosho"));
        }

        [Test]
        public void Enroll_ShouldThrowException_InvalidData()
        {
            var arena = new Arena();
            Warrior warrior = new Warrior("Tosho", 100, 100);

            arena.Enroll(warrior);
          

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior));
            
        }

        [Test]
        public void Fight_Should_DecreseHP_WithValidData()
        {
            var arena = new Arena();

            Warrior attacker = new Warrior("Tosho", 101, 100);
            Warrior defender = new Warrior("Gosho", 60, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Tosho", "Gosho");

            Assert.AreEqual(40, attacker.HP);
            Assert.AreEqual(0, defender.HP);

        }

        [Test]
        public void Fight_ShouldThrowException_WhenWArrionDoesntExist_InvalidData()
        {
            var arena = new Arena();

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Tosho", "Gosho"));

            arena.Enroll(new Warrior("Tosho", 100, 100));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Tosho", "Gosho"));
        }
    }
}
