using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            FurnitureFactory tableFactory = new TableFactory();
            FurnitureFactory chairFactiry = new ChairFactory();
            Furniture table =  tableFactory.Create();
            Furniture chair = chairFactiry.Create();

        }
    }
    abstract class Furniture
    {
        
    }
    class Table:Furniture
    {
        public Table()
        {
            Console.WriteLine("Table has been implemented");
        }
    }
    class Chair:Furniture
    {   
        public Chair()
        {
            Console.WriteLine("Chair has been implemented");
        }
    }
    abstract class FurnitureFactory
    {
        public abstract Furniture Create();
    }
    class ChairFactory : FurnitureFactory
    {
        public override Furniture Create()
        {
            return new Chair();
        }
    }

    class TableFactory : FurnitureFactory
    {
        public override Furniture Create()
        {
            return new Table();
        }
    }
}
