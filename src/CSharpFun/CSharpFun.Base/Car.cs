using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Base
{
    public class Car : Vehicle
    {
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string FullMakeModel { get { return $"{CarMake} {CarModel}"; } }
        public string FullMakeModelExprBody() => $"{CarMake} {CarModel}";
        public OtherTypes.CarType CarType { get; set; }
        public override void MakeNoise()
        {
            Console.WriteLine("Vrooooom");
        }

    }
}
