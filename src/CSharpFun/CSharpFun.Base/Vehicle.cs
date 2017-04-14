using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Base
{
    public abstract class Vehicle : INoisy, IVehicle
    {
        public int VehicleId { get; set; }
        public abstract void MakeNoise();
    }
}
