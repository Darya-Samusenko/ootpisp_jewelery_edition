using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_crud
{
    
    //запиши, как создаешь конкретные экземпляры
    public abstract class creators
    {
        public abstract BaseJew make_jewelry();
    }

    class EaringCreator: creators
    {
        public override Earings make_jewelry() { return new Earings(); }
    }
    class RingCreator : creators
    {
        public override BaseJew make_jewelry() { return new Ring(); }
    }
    class ChainCreator : creators
    {
        public override BaseJew make_jewelry() { return new Chain(); }
    }
    class NecklaceCreator : creators
    {
        public override BaseJew make_jewelry() { return new Necklace(); }
    }
}
