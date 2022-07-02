namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 5, 16, 20, 234 })]
        [TestCase(new int[] { int.MinValue, int.MaxValue, 4456 })]
        [TestCase(new int[0])]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Contructor_With_Valid_Data_Should_Pass(int[] parameters)
        {
            //Arrange and Act
            Database database = new Database(parameters);

            //Assert

            Assert.AreEqual(parameters.Length, database.Count);

        }

        [TestCase(
            new int[] { 1, 2 },
            new int[] { 10, 20 },
            4)]
        [TestCase(
            new int[] { int.MinValue, int.MaxValue, 4456 },
            new int[0],
            3)]

        [TestCase(
            new int[0],
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            16)]

        public void AddMethod_WithValid_Date_Should_Pass(
            int[] ctorParameters,
            int[] paramsToAdd,
            int expectedCount)
        {
            Database database = new Database(ctorParameters);

            foreach (var param in paramsToAdd)
            {
                database.Add(param);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(
            new int[] { 18, 3 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            1)]
        public void Add_With_Invalid_Data(
            int[] ctorParameters,
            int[] paramsToAdd,
            int errorParam)
        {
            Database database = new Database(ctorParameters);

            foreach (var param in paramsToAdd)
            {
                database.Add(param);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(errorParam));
        }

        [TestCase(
            new int[] { 18, 3 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            1,
            15)]
        [TestCase(
            new int[0],
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 },
            4,
            10)]
        public void Remove_Valid_Data_Positive_Test(
            int[] ctorParameters,
            int[] paramsToAdd,
            int removeCount,
            int expectedCount)
        {
            //Arrange
            Database database = new Database(ctorParameters);

            //Act
            foreach (var param in paramsToAdd)
            {
                database.Add(param);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }
            //Assert

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(
            new int[] { 2 },
            1)]
        [TestCase(
            new int[0],
            0)]
        public void Remove_InvalidData_Negative_Test(int[] ctorParams, int removeNum)
        {
            //Arrange
            Database database = new Database(ctorParams);

            //Act

            for (int i = 0; i < removeNum; i++)
            {
                database.Remove();
            }

            //Assert

            Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        [TestCase(
            new int[] { 18, 3 },
            new int[] { 10, 20, 14, 15 },
            2,
            new int[] { 18, 3, 10, 20 })]
        public void Fetch_WithValid_Data_Positive_Test(
            int[] ctorParameters,
            int[] paramsToAdd,
            int removeCount,
            int[] expectedArray)
        {
            //Arrange
            Database database = new Database(ctorParameters);

            foreach (var param in paramsToAdd)
            {
                database.Add(param);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            //Act

            int[] finalResult = database.Fetch();

            CollectionAssert.AreEqual(finalResult, expectedArray);
        }

        [Test]
        public void Test()
        {
            Database[] database1 = { new Database(12) };
            Database[] database2 = { new Database(12) };

            bool AreEqual = database1
                    .All(x => database2
                    .Any(y => y.Count == x.Count));

            Assert.True(AreEqual);

        }
    }
}
