using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using oop_crud.SerializedJew;

namespace oop_crud
{
    public class BINSerializer:Common_serializer
    {
        [Obsolete]
        public void Serialize(List<BaseJew> jew, string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fileStream, SerializationControl.SerializeList(jew));
            }
        }

        [Obsolete]
        public MemoryStream Serialize(List<BaseJew> jew)
        {
            var formatter = new BinaryFormatter();
            var serializedStream = new MemoryStream();

            formatter.Serialize(serializedStream, SerializationControl.SerializeList(jew));

            serializedStream.Position = 0;
            return serializedStream;
        }

        [Obsolete]
        public List<BaseJew> Deserialize(string fileName)
        {
            var formatter = new BinaryFormatter();
            using var fileStream = new FileStream(fileName, FileMode.Open);
            return SerializationControl.UnserializeList((List<SBaseJew>)formatter.Deserialize(fileStream));
        }

        [Obsolete]
        public List<BaseJew> Deserialize(MemoryStream serializedStream)
        {
            var formatter = new BinaryFormatter();
            return SerializationControl.UnserializeList((List<SBaseJew>)formatter.Deserialize(serializedStream));
        }

        public string GetExtension()
        {
            return ".bin";
        }
    }
}
