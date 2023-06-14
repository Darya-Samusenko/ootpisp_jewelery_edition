using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace oop_crud.SerializedJew
{
    [Serializable]
    public class SStone
    {
        public String name { get; set; }
        public double size { get; set; }

        public SStone(){ }
        public SStone(Stone incr)
        {
            this.size = incr.size;
            this.name = incr.name;
        }
    }
}
