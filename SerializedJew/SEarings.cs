using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace oop_crud.SerializedJew
{
    [Serializable]
    public class SEarings:SBaseJew
    {
        public Boolean pair { get; set; }
        public clasp_type clasp { get; set; }

        public SEarings() : base() { }
        public SEarings(Earings src) : base(src)
        {
            this.clasp = src.clasp;
            this.pair = src.pair;
        }
    }
}
