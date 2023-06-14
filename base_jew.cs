using oop_crud.SerializedJew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oop_crud
{
    public abstract class BaseJew
    {
        public String metal_name;
        public bool has_stones;
        public Stone incr;
        public double weight;
        public int cost;

        public BaseJew() {
            has_stones = false;
            incr = null;
        }
        public BaseJew(String me_name, double wght, int cost_value)
        {
            this.metal_name = me_name;
            this.weight = wght;
            this.cost = cost_value;
            this.has_stones = false;
            this.incr = null;
        }

        public BaseJew(String me_name, double wght, int cost_value, String stone_name, double stone_size)
        {
            this.metal_name = me_name;
            this.weight = wght;
            this.cost = cost_value;
            has_stones = true;
            Stone new_incrustation = new Stone(stone_name, stone_size);
            this.incr = new_incrustation;
            
        }

        public BaseJew(SBaseJew src)
        {
            this.metal_name = src.metal_name;
            this.weight = src.weight;
            this.cost = src.cost;
            this.has_stones = src.has_stones;
            if (has_stones)
            {
                this.incr = new Stone(src.incr);
            }
            else
                this.incr = null;
        }
    }
}
