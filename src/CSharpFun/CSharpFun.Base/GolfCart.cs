using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Base
{
    public class GolfCart : Vehicle
    {

        public string ModelName { get; set; }

        public override void MakeNoise()
        {
            Console.WriteLine("neeeeeeennnnnnnnnn");
        }

    }
}
