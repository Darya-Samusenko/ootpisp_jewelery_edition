using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_crud
{
    public interface Common_serializer
    {
        void Serialize(List<BaseJew> jew, string fileName);

        MemoryStream Serialize(List<BaseJew> jew);

        List<BaseJew> Deserialize(string fileName);

        List<BaseJew> Deserialize(MemoryStream serializedStream);

        string GetExtension();
        
    }
}
