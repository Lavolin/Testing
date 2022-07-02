namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        [TestCaseSource("TestCaseConstructorData")]

        public void Constructor_Should_Create_Database_PositiveTest(
            Person[] peopleForCtor,
            Person[] peopleToAdd,
            int expectedCount)
        {
            Database database = new Database(peopleForCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddInvalidData")]
        public void Add_ShouldThrowInvalidException_With_InvalidData_NegativeTest(
            Person[] peopleForCtor,
            Person[] peopleToAdd,
            Person intPerson)
        {
            Database database = new Database(peopleForCtor);

            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(intPerson));

        }
        [TestCaseSource("TestCaseRemoveData")]
        public void Remove_ShouldRemoveWithValidData_PositiveTest(
            Person[] peopleForCtor,
            Person[] peopleToAdd,
            int toRemove,
            int expectedCount)
        {
            Database database = new Database(peopleForCtor);
            foreach (var person in peopleToAdd)
            {
                database.Add(person);
            }

            for (var i = 0; i < toRemove; i++)
            {
                database.Remove();

            }
            Assert.AreEqual(expectedCount, database.Count);

        }

        [Test]
        public void AddRange_Should_Return_Correct_Data()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Todor1"),
                new Person(2, "Todor2"),
                new Person(3, "Todor3"),
                new Person(4, "Todor4"),
                new Person(5, "Todor5"),
                new Person(6, "Todor6"),
                new Person(7, "Todor7"),
                new Person(8, "Todor8"),
                new Person(9, "Todor9"),
                new Person(10, "Todor10"),
                new Person(11, "Todor11"),
                new Person(12, "Todor12"),
                new Person(13, "Todor13"),
                new Person(14, "Todor14"),
                new Person(15, "Todor15"),
                new Person(16, "Todor16"),
                new Person(17, "Todor17"),
            };

            Assert.That(() => new Database(people), Throws.ArgumentException);
        }

       
        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            var expected = new Person[] { new Person(1, "gosho") };

            var db = new Database(expected);

            var actual = expected;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindUsername_Should_Return_Correct_Person()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Todor1"),
                new Person(2, "Todor2"),
                new Person(3, "Todor3"),
                new Person(4, "Todor4"),
                new Person(5, "Todor5"),
                new Person(6, "Todor6"),
                new Person(7, "Todor7"),
                new Person(8, "Todor8"),
                new Person(9, "Todor9"),
                new Person(10, "Todor10")
            };

            Database database = new Database(people);

            Assert.That(people[8], Is.EqualTo(database.FindByUsername("Todor9")));
        }

        [Test]
        public void Find_UsernameWithEmptyString_Should_Throw_Argument_Null_Exception()
        {
            Database database = new Database();

            Assert.That(() => database.FindByUsername(string.Empty), Throws.ArgumentNullException, "Find by username should throw when given an empty string as an argument.");
        }

        [Test]
        public void Find_UsernameWithNullString_Should_Throw_Argument_Null_Exception()
        {
            Database database = new Database();

            Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException, "Find by username should throw when given null as an argument.");
        }

        [Test]
        public void Find_UsernameWithNotExistantName_Should_Throw_Invalid_Operation_Exception()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Todor1"),
                new Person(2, "Todor2"),
                new Person(3, "Todor3"),
                new Person(4, "Todor4"),
                new Person(5, "Todor5"),
                new Person(6, "Todor6"),
                new Person(7, "Todor7"),
                new Person(8, "Todor8"),
                new Person(9, "Todor9"),
                new Person(10, "Todor10")
            };

            Database database = new Database();

            Assert.That(() => database.FindByUsername("Michael"), Throws.InvalidOperationException, "Find by username should throw when given a name which does not exist in the database as an argument.");
        }

        [Test]
        public void Find_Id_Should_Return_Correct_Person()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Todor1"),
                new Person(2, "Todor2"),
                new Person(3, "Todor3"),
                new Person(4, "Todor4"),
                new Person(5, "Todor5"),
                new Person(6, "Todor6"),
                new Person(7, "Todor7"),
                new Person(899, "Todor8"),
                new Person(9, "Todor9"),
                new Person(10, "Todor10")
            };

            Database database = new Database(people);

            Assert.That(people[7], Is.EqualTo(database.FindById(899)));
        }

        [Test]
        public void Find_Id_WithNegativeNumber_Should_Throw_Argument_OutOfRangeException()
        {
            Database database = new Database();

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-50), "Find by id should throw when given a negative number as an argument.");
        }

        [Test]
        public void Find_Id_WithNotExistant_Id_Should_ThrowInvalidOperationException()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Todor1"),
                new Person(2, "Todor2"),
                new Person(3, "Todor3"),
                new Person(4, "Todor4"),
                new Person(5, "Todor5"),
                new Person(6, "Todor6"),
                new Person(7, "Todor7"),
                new Person(8, "Todor8"),
                new Person(9, "Todor9"),
                new Person(10, "Todor10")
            };

            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.FindById(11), "Find by id should throw when given an id which does not exist in the database as an argument.");
        }
        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Todor"),
                    new Person(2, "Eli"),
                    new Person(3, "Eli1")
                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                3,
                3),
                new TestCaseData(
                new Person[0]
                {

                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                3,
                0)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }


        }

        public static IEnumerable<TestCaseData> TestCaseAddInvalidData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Todor"),
                    new Person(2, "Eli1"),
                    new Person(3, "Eli2"),
                    new Person(4, "Eli3"),
                    new Person(5, "Eli4"),
                    new Person(6, "Eli5"),
                    new Person(7, "Eli6"),
                    new Person(8, "Eli7"),
                    new Person(9, "Eli8"),
                    new Person(10, "El9"),
                    new Person(11, "Eli10"),
                    new Person(12, "Eli11"),
                    new Person(13, "Eli12"),

                },
                new Person[]
                {
                    new Person(14, "Tod1"),
                    new Person(15, "E2"),
                    new Person(16, "E3")
                },
                new Person(16, "Zeleto")),
                new TestCaseData(
                new Person[0]
                {

                },
                new Person[]
                {
                    new Person(42, "Todor133"),
                    new Person(52, "Eli233"),
                    new Person(62, "Eli333")
                },
                new Person(62, "kakwoto")),
                new TestCaseData(
                new Person[0]
                {

                },
                new Person[]
                {
                    new Person(43, "Todor15"),
                    new Person(53, "Eli22"),
                    new Person(63, "Eli32")
                },
                new Person(67, "Eli32")
                )

            };

            foreach (var item in testCases)
            {
                yield return item;
            }


        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Todor"),
                    new Person(2, "Eli"),
                    new Person(3, "Eli1")
                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                6),
                new TestCaseData(
                new Person[0]
                {

                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                3)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }

            // yield return new TestCaseData(
            //     new Person[] people 
            //     {
            //         new Person(1, "Todor")
            //         new Person(2, "Eli")

            //     },
            //     2);
            //  yield return new TestCaseData(
            //     new Person[0] people 
            //     {

            //     },
            //     0);


        }

        
    }
}