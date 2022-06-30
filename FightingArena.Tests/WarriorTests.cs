namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Constructor_Should_Create_DataProperly()
        {
            Warrior warrior = new Warrior("Tosho", 100, 100);

            Assert.AreEqual(warrior.Name, "Tosho");
            Assert.AreEqual(warrior.HP, 100);
            Assert.AreEqual(warrior.Damage, 100);

            warrior = new Warrior("Tosho", 1, 0);

            Assert.AreEqual(warrior.Name, "Tosho");
            Assert.AreEqual(warrior.HP, 0);
            Assert.AreEqual(warrior.Damage, 1);

        }

        [Test]
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

        [Test]
        public void Fight_ShouldThrowExcepion_InvalidData()
        {
            Warrior attacker = new Warrior("Tosho", 50, 5);
            Warrior defender = new Warrior("Tosho", 50, 50);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));

            attacker = new Warrior("Tosho", 50, 50);
            defender = new Warrior("Tosho", 50, 5);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));

            attacker = new Warrior("Tosho", 50, 50);
            defender = new Warrior("Tosho", 100, 100);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender));
        }

        [Test]
        public void Fight_ShouldFight_WithValidData()
        {
            Warrior attacker = new Warrior("Tosho", 101, 100);
            Warrior defender = new Warrior("Tosho", 60, 100);

            attacker.Attack(defender);

            Assert.AreEqual(40, attacker.HP);
            Assert.AreEqual(0, defender.HP);

             attacker = new Warrior("Tosho", 50, 100);
             defender = new Warrior("Tosho", 50, 100);

            attacker.Attack(defender);

            Assert.AreEqual(50, attacker.HP);
            Assert.AreEqual(50, defender.HP);

        }
    }
}