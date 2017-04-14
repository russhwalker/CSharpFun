using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Base
{
    public class Garage
    {

        public List<Vehicle> Vehicles { get; private set; }

        public Garage(List<Vehicle> vehicles)
        {
            this.Vehicles = vehicles;
        }


        public Vehicle this[int index]
        {
            get
            {
                return this.Vehicles[index];
            }
            set
            {
                this.Vehicles[index] = value;
            }
        }


    }
}
