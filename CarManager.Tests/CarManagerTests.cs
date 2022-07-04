namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCaseSource("ConstructorInvalidCases")]
        public void Constructor_With_Invalid_Data_ShouldThrowArgumentException(string make, string model, double consume, double capacity)
        {
            //Car car = new Car(make, model, consume, capacity);
            //TestDelegate act = () => new Car(make, model, consume, capacity);
            //string failureMessage = "Passing in invalid arguments should throw their respective messages.";
            //Assert.Throws<ArgumentException>(act, failureMessage);

            Assert.Throws<ArgumentException>(()=> new Car(make, model, consume, capacity));
        }

        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_With_Invalid_Number_Should_Throw_Argument_Exception(double amount)
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            //TestDelegate act = () => car.Refuel(amount);

            //string failureMessage = "Refueling with a number lower or equal to zero should not be possible and should throw argument exception.";
            //Assert.Throws<ArgumentException>(act, failureMessage);
            Assert.Throws<ArgumentException>(() => car.Refuel(amount));
        }

        [TestCase(15)]
        [TestCase(29.99)]
        public void Refuel_Car_Should_Refuel_Correctly(double amount)
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            car.Refuel(amount);

            double expected = amount;
            double actual = car.FuelAmount;

            string failureMessage = "Refueling should increase cars' fuel capacity correctly.";
            Assert.AreEqual(expected, actual, failureMessage);  
        }

        [Test]
        public void Refuel_Car_Higher_Than_Max_Should_BeSetToMax()
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            car.Refuel(50);

            double expected = car.FuelCapacity;
            double actual = car.FuelAmount;

            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Drive_Car_Without_Enough_Fuel_Should_Throw_InvalidOperationException()
        {
            Car car = new Car("Moskvich", "5", 10, 30);
            double distance = 310;

            //TestDelegate act = () => car.Drive(distance);
            //string failureMessage = "Driving a car X amount of kilometers without enough fuel whould throw an invalid operation exception";
            //Assert.Throws<InvalidOperationException>(act, failureMessage);

            Assert.Throws<InvalidOperationException>(()=> car.Drive(distance));
        }

        [Test]
        public void Drive_Car_With_Enough_Fuel_Should_Subtract_Correctly_From_TotalFuel()
        {
            Car car = new Car("Moskvich", "5", 10, 30);
            double distance = 290;

            car.Refuel(30);
            car.Drive(distance);

            double expected = 1;
            double actual = car.FuelAmount;

            //string failureMessage = "Driving a car X amount of kilometers with enough fuel should subtract that fuel from the total fuel.";
            //Assert.AreEqual(expected, actual, failureMessage);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Make_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            string expected = "Moskvich";
            string actual = car.Make;

            //string failureMessage = "Make should return correct field";
            //Assert.AreEqual(expected, actual, failureMessage);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Model_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            string expected = "5";
            string actual = car.Model;

            //string failureMessage = "Model should return correct field";
            //Assert.AreEqual(expected, actual, failureMessage);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Consume_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            double expected = 4;
            double actual = car.FuelConsumption;
                       

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Capacity_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            double expected = 30;
            double actual = car.FuelCapacity;
                       

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Amount_Getter_Should_Return_Correct_Field()
        {
            Car car = new Car("Moskvich", "5", 4.0, 30);

            double expected = 0;
            double actual = car.FuelAmount;

            
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<TestCaseData> ConstructorInvalidCases()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData("", "Model S", 20, 300),
                new TestCaseData(null, "812 GTS", 100.35, 500.12),
                new TestCaseData("Tesla", "", 20, 300),
                new TestCaseData("Ferrari", null, 100, 500),
                new TestCaseData("Tesla", "Model S", 0, 300),
                new TestCaseData("Ferrari", "812 GTS", -20, 500.57),
                new TestCaseData("Tesla", "Model S", 321, -800),
                new TestCaseData("Ferrari", "812 GTS", 4.0, 0)
            };

            foreach (TestCaseData test in testCases)
            {
                yield return test;
            }


        }
    }
}