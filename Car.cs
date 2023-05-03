using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTNandiniPatel
{
    internal class Car:Vehicle
    {
        public Car(int id, string name, string rentalPrice, string category, string type, bool isReserved) : base(id, name, rentalPrice, category, type, isReserved)
        {
        }

        public override void vehicleData()
        {
            throw new NotImplementedException();
        }
    }
}
