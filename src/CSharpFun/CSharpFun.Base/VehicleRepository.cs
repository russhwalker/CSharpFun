using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFun.Base
{
    public class VehicleRepository
    {

        public List<Vehicle> GetLongRunningVehicles(int millisecondsDelay)
        {
            Thread.Sleep(millisecondsDelay);
            return new List<Vehicle>
            {
                new Car(),
                new Car()
            };
        }

        public async Task<List<Vehicle>> GetLongRunningVehiclesAsync(int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            return new List<Vehicle>
            {
                new Car(),
                new Car()
            };
        }

        public async Task<List<Vehicle>> GetLongRunningVehiclesAsync(int millisecondsDelay, CancellationToken cancellationToken)
        {
            await Task.Delay(millisecondsDelay, cancellationToken);
            return new List<Vehicle>
            {
                new Car(),
                new Car()
            };
        }

    }
}
