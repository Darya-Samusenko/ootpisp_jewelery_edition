using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace oop_crud.SerializedJew
{
    [Serializable]
    [JsonDerivedType(typeof(Necklace))]
    public class SChain:SBaseJew
    {
        public double solo_length { get; set; }
        public double width { get; set; }

        public SChain() : base() { }
        public SChain(Chain src):base(src)
        {
            this.solo_length = src.solo_length;
            this.width = src.width;
        }
    }
}
