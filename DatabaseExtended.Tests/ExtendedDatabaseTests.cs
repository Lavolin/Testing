namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        [TestCasSource("TestCaseConstructorData")]

        public void Constructor_Should_Create_Database_PositiveTest(
            Person[] people,
            int expectedCount)        
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, data.Count);
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(
                new Person[]
                {
                    new Person(1, "Todor")
                    new Person(2, "Eli")
                   
                },
                2),
                new TestCaseData(
                new Person[0] people 
                {
                   
                },
                0);
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