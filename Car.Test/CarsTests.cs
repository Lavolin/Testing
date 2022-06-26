using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Test
{
    public class CarsTests  
    {                                           // 1:00
        [Test]
        public void Test_Drive_Car_Should_Increase_Mileage()
        {
            Car car = new Car();
            car.Drive(100);
            
            Assert.AreEqual(car.Mileage, 100);
        }
    }
}
