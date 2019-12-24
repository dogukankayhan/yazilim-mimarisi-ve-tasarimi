using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRATEGY_PATTERN
{
    //Base Interface
    interface ISerializable
    {
        void Serialize(string str);
        void Deserialize(string str);
    }

    //Concrete tip 1
    class XmlSerializer : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine("xml ters serileştirme");
        }

        public void Serialize(string str)
        {
            Console.WriteLine("xml serileştirme");
        }
    }

    //Concrete tip 2
    class BinarySeriazlier : ISerializable
    {
        public void Deserialize(string str)
        {
            Console.WriteLine("binary ters serileştirme");
        }

        public void Serialize(string str)
        {
            Console.WriteLine("binary serileştirme");
        }
    }

    //Context tip
    class Serializer
    {
        ISerializable _serializer;

        public Serializer(ISerializable serializer)
        {
            _serializer = serializer;
        }

        public void Serialize(string str)
        {
            _serializer.Serialize(str);
        }

        public void Deserialize(string str)
        {
            _serializer.Deserialize(str);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Serializer srz = new Serializer(new XmlSerializer());

            srz.Serialize("Stragey");
            srz.Deserialize("Stragey");

            srz = new Serializer(new BinarySeriazlier());

            srz.Serialize("");
            srz.Deserialize("");
        }
    }
}
