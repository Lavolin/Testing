namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        [TestCasSource("TestCaseConstructorData")]

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

            Assert.AreEqual(expectedCount, data.Count);
        }

        [TestCasSource("TestCaseAddInvalidData")]
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
        [TestCasSource("TestCaseRemoveData")]
        public void Remove_ShouldRemoveWithValidData_PositiveTest(
            Person[] peopleForCtor,
            Person[] peopleToAdd,
            int toRemove,
            int expectedCount)
        {
            Database database = new Database(peopleForCtor);
            oreach (var person in peopleToAdd)
            {
                database.Add(person);
            }
            
            for (var i = 0; i < toRemove; i++)
            {
            database.Remove();
                
            }
            Assert.AreEqual(expectedCount, data.Count);

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
                new Person[0] people 
                {
                   
                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                3);
            }

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
                new Person(17, "Adi45")),
                new TestCaseData(
                new Person[0] people 
                {
                   
                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                new Person(7, "Eli3"),
                new TestCaseData(
                new Person[0] people 
                {
                   
                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                new Person(6, "Eli35555")
                );
                );
            }

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
                new Person[0] people 
                {
                   
                },
                new Person[]
                {
                    new Person(4, "Todor1"),
                    new Person(5, "Eli2"),
                    new Person(6, "Eli3")
                },
                3);
            }

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