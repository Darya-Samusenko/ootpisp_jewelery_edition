using oop_crud.SerializedJew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_crud
{
    public enum hold_type
    {
        SINGLE_RING,
        FUSION,
        DESIGNED
    }
    public class Necklace:Chain
    {
        public hold_type fasteners;
        public Boolean hasNonMeInclusions;
        public int common_length;//отдельно длина металлической цепи и всего колье

        public Necklace() : base() { }
        public Necklace(string me_name, double weigt, int cost_val, double len, double wid, bool nonME, hold_type holdings, int cmn_len) :base(me_name, weigt, cost_val, len, wid)
        {
            fasteners = holdings;
            hasNonMeInclusions = nonME;
            common_length = cmn_len;
        }

        public Necklace(string me_name, double weigt, int cost_val, string st_name, double st_size, double len, double wid, bool nonME, hold_type holdings, int cmn_len) : base(me_name, weigt, cost_val, len, wid, st_name, st_size)
        {
            fasteners = holdings;
            hasNonMeInclusions = nonME;
            common_length = cmn_len;
        }

        public Necklace(SNecklace src) : base()
        {
            fasteners = src.fasteners;
            hasNonMeInclusions |= src.hasNonMeInclusions;
            common_length = src.common_length;
        }
    }
}
