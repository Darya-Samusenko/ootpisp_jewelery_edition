using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace oop_crud.SerializedJew
{
    [Serializable]
    public class SRing:SBaseJew
    {
        public double diameter { get; set; }
        public double thickness { get; set; }

        public SRing() : base() { }
        public SRing(Ring src) : base(src)
        {
            this.diameter = src.diameter;
            this.thickness = src.thickness;
        }
    }
}
