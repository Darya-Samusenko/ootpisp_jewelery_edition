using oop_crud.SerializedJew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace oop_crud
{
    
    public class Chain:BaseJew
    {
        public double solo_length;
        public double width;

        public Chain() : base() { }
        public Chain(string me_name, double weigt, int cost_val, double len, double wid):base(me_name, weigt, cost_val)
        {
            this.solo_length = len; 
            this.width = wid;
        }

        public Chain(string me_name, double weigt, int cost_val, double len, double wid, string stone_name, double stone_size) : base(me_name, weigt, cost_val, stone_name, stone_size)
        {
            this.solo_length = len;
            this.width = wid;
        }

        public Chain(SChain src) : base()
        {
            this.solo_length=src.solo_length;
            this.width = src.width;
        }
    }
}
