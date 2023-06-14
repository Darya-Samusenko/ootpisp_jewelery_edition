using oop_crud.SerializedJew;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace oop_crud
{
    internal class TEXTSerializer:Common_serializer
    {
        private readonly char _specialChar = '\'';

        private readonly string _specialCharString = "'";
        public MemoryStream Serialize(List<BaseJew> jewelry)
        {
            var serializableList = SerializationControl.SerializeList(jewelry);
            var animalsString = new StringBuilder();

            animalsString.Append('{');
            foreach (var serializableObject in serializableList)
            {
                SerializeObject(serializableObject, animalsString);
            }
            animalsString.Append('}');

            return new MemoryStream(Encoding.UTF8.GetBytes(animalsString.ToString()));
        }

        public void Serialize(List<BaseJew> jewelry, string fileName)
        {
            var serializableList = SerializationControl.SerializeList(jewelry);
            var jewString = new StringBuilder();

            jewString.Append('{');
            foreach (var serializableObject in serializableList)
            {
                SerializeObject(serializableObject, jewString);
            }
            jewString.Append('}');

            File.WriteAllText(fileName, jewString.ToString());
        }

        private void SerializeObject(object obj, StringBuilder stringBuilder)
        {
            stringBuilder.Append(obj.GetType().Name + '[');

            foreach (var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj);

                if (value is null) continue;

                stringBuilder.Append("'" + property.Name + "':");
                var type = property.PropertyType;
                if (value is string stringValue)
                {
                    stringBuilder.Append(_specialChar + stringValue.Replace(_specialCharString,
                                        _specialCharString + _specialCharString) + _specialChar);
                }
                if (type.IsClass && type.Name != "String")
                {
                    SerializeObject(value, stringBuilder);
                }
                else
                {
                    if(type.Name != "String")
                        stringBuilder.Append(_specialCharString + value + _specialCharString);
                }

                stringBuilder.Append(';');
            }

            stringBuilder.Append(']');
        }

        public List<BaseJew> Deserialize(string fileName)
        {
            var jew_serializable = new List<SBaseJew>();
            var reader = new StreamReader(fileName);

            if (reader.Read() != '{')
            {
                throw new Exception("Wrong file format.");
            }

            while (reader.Peek() != '}')
            {
                jew_serializable.Add((SBaseJew)DeserializeObject(reader));
            }
            reader.Close();

            return SerializationControl.UnserializeList(jew_serializable);
        }

        public List<BaseJew> Deserialize(MemoryStream serializedStream)
        {
            var serializableJew = new List<SBaseJew>();
            var reader = new StreamReader(serializedStream);

            if (reader.Read() != '{')
            {
                throw new Exception("Wrong file format.");
            }

            while (reader.Peek() != '}')
            {
                serializableJew.Add((SBaseJew)DeserializeObject(reader));
            }
            reader.Close();

            return SerializationControl.UnserializeList(serializableJew);
        }

        private object DeserializeObject(StreamReader reader)
        {
            var className = string.Empty;
            while (reader.Peek() != '[')
            {
                if (reader.Peek() == -1)
                {
                    throw new Exception("Wrong file format.");
                }
                className += (char)reader.Read();
            }

            var type = GetTypeByString(className);
            var instance = GetNewInstanceByType(type);

            if (reader.Read() != '[')
            {
                throw new Exception("Wrong file format.");
            }
            while (reader.Peek() != ']')
            {
                var propertyName = ReadValue(reader);
                var property = GetProperty(type, propertyName);

                if (reader.Read() != ':')
                {
                    throw new Exception("Wrong file format.");
                }

                object value;
                var nextChar = (char)reader.Peek();
                if (nextChar == _specialChar)
                {
                    value = ReadValue(reader);
                }
                else
                {
                    value = DeserializeObject(reader);
                }

                SetProperty(instance, property, value);

                if (reader.Read() != ';')
                {
                    throw new Exception("Wrong file format.");
                }
            }
            reader.Read();
            return instance;
        }
        private string ReadValue(StreamReader reader)
        {
            var valuesString = string.Empty;
            int readChar;
            reader.Read();

            while ((readChar = reader.Read()) != _specialChar || reader.Peek() == _specialChar)
            {
                if (readChar == -1)
                {
                    throw new Exception("Wrong file format.");
                }
                if (readChar == _specialChar)
                {
                    reader.Read();
                }
                valuesString += (char)readChar;
            }
            return valuesString;
        }

        private void SetProperty(object obj, PropertyInfo property, object value)
        {
            var type = property.PropertyType;

            if (type.IsClass)
            {
                property.SetValue(obj, value);
                return;
            }
            if (value is not string valueString)
            {
                throw new Exception("Wrong property type.");
            }
            if (type == typeof(string))
            {
                property.SetValue(obj, valueString);
                return;
            }
            if (type == typeof(double))
            {
                property.SetValue(obj, Convert.ToDouble(valueString));
                return;
            }
            if (type == typeof(int))
            {
                property.SetValue(obj, Convert.ToInt32(valueString));
                return;
            }
            if (type == typeof(bool))
            {
                property.SetValue(obj, Convert.ToBoolean(valueString));
                return;
            }
            if (type.IsEnum)
            {
                property.SetValue(obj, Enum.Parse(type, valueString));
                return;
            }
            throw new Exception("Wrong property type.");
        }

        public static Type GetTypeByString(string name)
        {
            var type = Type.GetType(typeof(TEXTSerializer).Namespace + ".SerializedJew." + name);
            if (type == null)
            {
                throw new Exception("Wrong file format.");
            }
            return type;
        }

        public static object GetNewInstanceByType(Type type)
        {
            var instance = Activator.CreateInstance(type);

            if (instance == null)
            {
                throw new Exception("Wrong file format.");
            }
            return instance;
        }

        public static PropertyInfo GetProperty(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName);

            if (property == null)
            {
                throw new Exception("Wrong file format.");
            }
            return property;
        }

        public string GetExtension()
        {
            return ".jew";
        }
    }
}
