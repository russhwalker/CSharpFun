using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Base
{
    public class OtherTypes
    {

        public enum CarType
        {
            None,
            Sedan,
            SUV
        }

        public struct Dog
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}
