using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Test
{
    public class CarsTests
    {                                           // 1:00

        private Car car;

        [SetUp] 
        public void SetUp()
        {
            this.car = new Car();

            for (int i = 0; i < 5; i++)
            {
                car.Drive(100);
            }

        }

        [TearDown]
        public void CleanUp()
        {
            car.Mileage = 0;
        }

        [Test]
        //[Ignore("test is dumb")] // пропуска теста
        public void Test_Drive_Car_Should_Increase_Mileage()
        {

            Assert.That(car.Mileage, Is.EqualTo(500));

            //car.Drive(100);

            //Assert.AreEqual(100, car.Mileage);
            //Assert.Equals(100, car.Mileage);
            //Assert.That(car.Mileage , Is.EqualTo(100));
            //Assert.That(100 == car.Mileage);
        }

        [Test]
        public void Test_Drive_Car_Should_Throw_Error_With_Negative_kms()
        {
            

            Assert.Throws<ArgumentException>(() =>
            {
                car.Drive(-100);
            });
        }
    }
}
