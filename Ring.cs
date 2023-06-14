using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_crud.SerializedJew;

namespace oop_crud
{
    public class Ring : BaseJew
    {
        public double diameter;
        public double thickness;
        // public double st_size;

        public Ring() : base() { }
        public Ring(string me_name, double weigt, int cost_val, double diam, double thick) : base(me_name, weigt, cost_val)
        {
            this.thickness = thick;
            this.diameter = diam;
        }

        public Ring(string me_name, double weigt, int cost_val, double diam, double thick, string stone_name, double stone_size) : base(me_name, weigt, cost_val, stone_name, stone_size)
        {
            this.thickness = thick;
            this.diameter = diam;
        }

        public Ring(SRing src):base(src)
        {
            this.thickness = src.thickness;
            this.diameter = src.diameter;
        }
    }
}
