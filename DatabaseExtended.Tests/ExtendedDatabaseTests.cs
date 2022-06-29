namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {

        [TestCasSource("TestCaseSourceData")]

        public void Constructor_Should_Create_Database_PositiveTest(
            Person[] people,
            int expectedCount)        
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, data.Count);
        }

        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            yield return new TestCaseData(
                new Person[] people 
                {
                    new Person(1, "Todor")
                    new Person(2, "Eli")
                   
                },
                1);
        }
    }
}