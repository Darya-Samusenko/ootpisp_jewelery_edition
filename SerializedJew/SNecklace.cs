using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace oop_crud.SerializedJew
{
    [Serializable]
    public class SNecklace:SChain
    {
        public hold_type fasteners { get; set; }
        public Boolean hasNonMeInclusions { get; set; }
        public int common_length { get; set; }//отдельно длина металлической цепи и всего колье

        public SNecklace() : base() { }
        public SNecklace(Necklace src) : base(src)
        {
            this.fasteners = src.fasteners;
            this.hasNonMeInclusions = src.hasNonMeInclusions;
            this.common_length = src.common_length;
        }
    }
}
