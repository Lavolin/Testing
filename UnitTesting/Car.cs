using System;
using System.Collections.Generic;
using System.Text;

namespace Car
{
    public class Car
    {

        public int Mileage { get; set; }
        public void Drive(int kms)
        {
            if (kms < 0)
            {
                throw new ArgumentException("Ne si dobre!");    
            }
            Mileage += kms;
            
        }
    }
}
