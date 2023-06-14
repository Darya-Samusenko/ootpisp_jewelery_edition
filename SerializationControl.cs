using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_crud.SerializedJew;
using System.Reflection;
using System.Security.Claims;

namespace oop_crud
{
    /*public enum ser_types//просто чтобы помнить
    {
        BINARY, 
        JSON,
        TEXT,
    }*/

    public class SerializationControl
    {
        private readonly Dictionary<string, Common_serializer> all_serializers;

        public SerializationControl()
        {
            all_serializers = new Dictionary<string, Common_serializer>();
            foreach (var serializer in GetSerializers())
            {
                all_serializers.Add(serializer.GetExtension(), serializer);
            }
        }

        public Common_serializer? GetRequiredSerializer(string fileExtension)
        {
            return !all_serializers.ContainsKey(fileExtension) ? null : all_serializers[fileExtension];
        }

        public List<string> GetAllFileExtensions()
        {
            return all_serializers.Select(x => x.Value.GetExtension()).ToList();
        }

        private List<Common_serializer> GetSerializers()
        {
            var implemented = new List<Common_serializer>();
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t != typeof(Common_serializer) && typeof(Common_serializer).IsAssignableFrom(t))
                .ToList()
                .ForEach(x => implemented.Add((Common_serializer)Activator.CreateInstance(x)));
            return implemented;
        }

        public static List<SBaseJew> SerializeList(List<BaseJew> jew)
        {
            var serialized_list = new List<SBaseJew>();

            foreach(var product in jew)
            {
                switch (product)
                {
                    case Necklace necklace:
                        serialized_list.Add(new SNecklace(necklace));
                        break;
                    case Chain chain:
                        serialized_list.Add(new SChain(chain));
                        break;
                    case Earings earing:
                        serialized_list.Add(new SEarings(earing));
                        break;                    
                    case Ring ring:
                        serialized_list.Add(new SRing(ring));
                        break;
                        //еще можно добавить default для исключений?
                }
            }
            return serialized_list;
        }

        public static List<BaseJew> UnserializeList(List<SBaseJew> serialized) {
            var jew = new List<BaseJew>();
            foreach(var product in serialized)
            {
                switch (product)
                {
                    case SNecklace necklace:
                        jew.Add(new Necklace(necklace));
                        break;
                    case SChain chain:
                        jew.Add(new Chain(chain));
                        break;
                    case SEarings earing:
                        jew.Add(new Earings(earing));
                        break;
                    case SRing ring:
                        jew.Add(new Ring(ring));
                        break;
                }
            }
            return jew;
        }
    }
}
