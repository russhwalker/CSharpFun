using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Base
{
    public class VehicleFactory
    {

        //public static Vehicle Create(OtherTypes.VehicleType vehicleType, int vehicleId)
        //{
        //    switch (vehicleType)
        //    {
        //        case OtherTypes.VehicleType.Car:
        //            return new Car
        //            {
        //                VehicleId = vehicleId,
        //                VehicleType = vehicleType
        //            };
        //        case OtherTypes.VehicleType.GolfCart:
        //            return new GolfCart
        //            {
        //                VehicleId = vehicleId,
        //                VehicleType = vehicleType
        //            };
        //        default:
        //            return null;
        //    }
        //}

        public static T Create<T>(IVehicle vehicle, int vehicleId)
        {
            vehicle.VehicleId = vehicleId;
            return (T)vehicle;
        }

        public static T Create<T>(int vehicleId) where T : IVehicle, new()
        {
            return new T
            {
                VehicleId = vehicleId
            };
        }

    }
}
