using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using oop_crud.SerializedJew;

namespace oop_crud
{
    internal class JSONSerializer:Common_serializer
    {
        public void Serialize(List<BaseJew> jew, string fileName)
        {
            var animalsToSerialize = SerializationControl.SerializeList(jew);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var json = JsonConvert.SerializeObject(animalsToSerialize, settings);

            var file = File.CreateText(fileName);
            file.Dispose();

            File.WriteAllText(fileName, json);
        }

        public MemoryStream Serialize(List<BaseJew> jew)
        {
            var animalsToSerialize = SerializationControl.SerializeList(jew);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var json = JsonConvert.SerializeObject(animalsToSerialize, settings);

            return new MemoryStream(Encoding.UTF8.GetBytes(json));
        }

        public List<BaseJew> Deserialize(string fileName)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var jsonStrings = File.ReadAllLines(fileName);
            var jsonText = string.Join("", jsonStrings);

            var serializedJew = JsonConvert.DeserializeObject<List<SBaseJew>>(jsonText, settings);

            var jew = SerializationControl.UnserializeList(serializedJew);

            return jew;
        }

        public List<BaseJew> Deserialize(MemoryStream serializedStream)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var jsonText = Encoding.UTF8.GetString(serializedStream.ToArray());

            var serialized = JsonConvert.DeserializeObject<List<SBaseJew>>(jsonText, settings);

            var jew = SerializationControl.UnserializeList(serialized);

            return jew;
        }

        public string GetExtension()
        {
            return ".json";
        }
    }
}
