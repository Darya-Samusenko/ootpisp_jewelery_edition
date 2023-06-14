using oop_crud.SerializedJew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_crud
{
    public class Stone
    {
        public String name;
        public double size;

        public Stone()//на всякий случай
        {
            this.name = "none";
            this.size = 0;
        }

        public Stone(string st_name, double st_size)
        {
            this.name = st_name;
            this.size = st_size;
        }

        public Stone(SStone src)
        {
            this.name = src.name;
            this.size = src.size;
        }
    }
}
