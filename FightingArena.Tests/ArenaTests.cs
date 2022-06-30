namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Constructor_Should_Create_DataProperly()
        {
            Warrior warrior = new Warrior("Tosho", 100, 100);

            Assert.AreEqual(warrior.Name, "tosho");
            Assert.AreEqual(warrior.HP, 100);
            Assert.AreEqual(warrior.Damage, 100);

            Warrior warrior = new Warrior("Tosho", 1, 0);

            Assert.AreEqual(warrior.Name, "tosho");
            Assert.AreEqual(warrior.HP, 0);
            Assert.AreEqual(warrior.Damage, 1);

        }

        public void Constructor_Should_ThrowExcepion_On_InvalidData()
        {

                Assert.Throws<ArgumentException>(
                () => new Warrior(null, 100, 100));

                 Assert.Throws<ArgumentException>(
                () => new Warrior("", 100, 100));

                Assert.Throws<ArgumentException>(
                () => new Warrior(" ", 100, 100));

                Assert.Throws<ArgumentException>(
                () => new Warrior("Tosho", 0, 100));

                Assert.Throws<ArgumentException>(
                () => new Warrior("Tosho", -1, 100));

                Assert.Throws<ArgumentException>(
                () => new Warrior("Tosho", 50, -1));

        }

        public void Fight_ShouldThrowExcepion_InvalidData()
        {
            Warrior attacker = new Warrior("Tosho", 50, 5);
            Warrior defender = new Warrior("Tosho", 50, 50);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));

            Warrior attacker = new Warrior("Tosho", 50, 50);
            Warrior defender = new Warrior("Tosho", 50, 5);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));

            Warrior attacker = new Warrior("Tosho", 50, 50);
            Warrior defender = new Warrior("Tosho", 100, 100);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }
    }
}
