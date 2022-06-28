namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {

        [TestCase(new int[] {1})]
        [TestCase(new int[] {5, 16, 20 ,234})]
        [TestCase(new int[] {int.MinValue, int.MaxValue, 4456})]
        [TestCase(new int[0])]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
        public void Contructor_With_Valid_Data_Should_Pass(int[] parameters)
        {
            //Arrange and Act
            Database database = new Database(parameters);

            //Assert

            Assert.AreEqual(parameters.Length, database.Count);

        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 5, 16, 20, 234 })]
        [TestCase(new int[] { int.MinValue, int.MaxValue, 4456 })]
        public void AddMethod_WithValid_Date_Should_Pass(
            int[] ctorParameters,
            int[] paramsToAdd,
            int expectedCount)
        {

        }
    }
}
