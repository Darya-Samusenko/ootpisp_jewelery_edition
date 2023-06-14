using oop_crud.SerializedJew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_crud
{
    public enum clasp_type
    {
        SIMPLE,
        SNUD,
        CLIPS,
        NONE
    }
    public class Earings:BaseJew
    {
        public Boolean pair;
        public clasp_type clasp;

        public Earings() : base() { }
        public Earings(string me_name, double weigt, int cost_val, bool is_pair, clasp_type claspes):base(me_name, weigt, cost_val)
        {
            pair = is_pair;
            clasp = claspes;
        }

        public Earings(string me_name, double weigt, int cost_val, string st_name, double st_size, bool is_pair, clasp_type claspes) : base(me_name, weigt, cost_val, st_name, st_size)
        {
            pair = is_pair;
            clasp = claspes;
        }

        public Earings(SEarings src) : base(src)
        {
            pair = src.pair;
            clasp = src.clasp;
        }
    }
}
