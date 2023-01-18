using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DesignPatterns
{
    public class Decorator
    {
        public interface ICar
        {
            string Type { get; }
            double Price { get; }
        }

        public class Car : ICar
        {
            public string Type => "Tesla";
            public double Price => 100000;
        }

        public abstract class VehicleDecorator : ICar
        {
            private ICar vehicle;

            protected VehicleDecorator(ICar vehicle)
            {
                this.vehicle = vehicle;
            }

            public string Type => vehicle.Type;

            public double Price => vehicle.Price;
        }

        public class SpecialOffer : VehicleDecorator
        {
            public SpecialOffer(ICar vehicle) : base(vehicle) { }

            public int DiscountPercentage { get; set; }
            public string Offer { get; set; }

            public double Price
            {
                get
                {
                    double price = base.Price;
                    int percentage = 100 - DiscountPercentage;
                    return Math.Round((price * percentage) / 100, 2);
                }
            }
        }
    }
}
