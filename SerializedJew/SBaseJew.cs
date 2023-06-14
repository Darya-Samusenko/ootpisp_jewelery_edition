using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.Logging;
using System.Collections;

namespace oop_crud.SerializedJew
{
    [Serializable]
    [JsonDerivedType(typeof(Ring))]
    [JsonDerivedType(typeof(Earings))]
    [JsonDerivedType(typeof(Chain))]
    [JsonDerivedType(typeof(Necklace))]
    public class SBaseJew
    {
        public String metal_name { get; set; }
        public bool has_stones { get; set; }
        public SStone incr { get; set; }
        public double weight { get; set; }
        public int cost { get; set; }

        public SBaseJew() { }
        public SBaseJew(BaseJew src)
        {
            this.weight = src.weight;
            this.cost = src.cost;
            this.has_stones = src.has_stones;
            if (has_stones)
            {
                this.incr = new SStone(src.incr);
            }
            else
                this.incr = null;
            this.metal_name = src.metal_name;
        }
    }
}
