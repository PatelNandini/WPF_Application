using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTNandiniPatel
{
    abstract class Vehicle
    {

        public int id { get; set; }
        public string name { get; set; }
        public string rentalPrice { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public bool isReserved { get; set; }


        public abstract void vehicleData();

        protected Vehicle(int id, string name, string rentalPrice, string category, string type, bool isReserved)
        {
            this.id = id;
            this.name = name;
            this.rentalPrice = rentalPrice;
            this.category = category;
            this.type = type;
            this.isReserved = isReserved;
        }

        

       

    }

}
