using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRİDGE_TASARIM_DESENİ
{
    interface Bridge
    {
        string OperationImp();
    }

    class ImplementationA : Bridge
    {
        public string OperationImp()
        {
            return "Implementation A";
        }
    }

    class ImplementationB : Bridge
    {
        public string OperationImp()
        {
            return "Implementation B";
        }
    }

    class Abstraction
    {
        Bridge bridge;

        public Abstraction(Bridge Implementation)
        { bridge = Implementation; }

        public string Operation()
        {
            return "Abstraction <<bridge>> " + bridge.OperationImp();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bridge Pattern \n");
            Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
            Console.WriteLine(new Abstraction(new ImplementationB()).Operation());

            Console.ReadKey();
        }
    }
}
