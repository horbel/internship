using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            FurnitureBissnessFacade bissness = new FurnitureBissnessFacade(new Woodman(), new FurnitureFactory(), new Seller());
            bissness.SaleChair();
            Console.WriteLine("******************");
            bissness.SaleTable();
        }
    }

    class Woodman
    {
        public void FindTree()
        {
            Console.WriteLine("Woodman find a good tree");
        }
        public void CutTree()
        {
            Console.WriteLine("Woodman cut the tree");
        }
        public void DeliverTree()
        {
            Console.WriteLine("Woodman deliver the tree to furniture factory");
        }
    }
    class FurnitureFactory
    {
        public void WoodCleaning()
        {
            Console.WriteLine("Factory workers clean the wood");
        }
        public void MakeChair()
        {
            Console.WriteLine("Factory workers make the chair");
        }
        public void MakeTable()
        {
            Console.WriteLine("Factory workers make the table");
        }

    }
    class Seller
    {
        public void SearchCustomer()
        {
            Console.WriteLine("Seller searching for customer");
        }
        public void saleProduct()
        {
            Console.WriteLine("Seller sale the product");
        }
        public void GetCash()
        {
            Console.WriteLine("Saller get cash");
        }
    }
    class FurnitureBissnessFacade
    {
        Woodman woodman;
        FurnitureFactory factory;
        Seller seller;
        public FurnitureBissnessFacade(Woodman w, FurnitureFactory f, Seller s)
        {
            woodman = w;
            factory = f;
            seller = s;
        }
        public void SaleChair()
        {
            woodman.FindTree();
            woodman.CutTree();
            woodman.DeliverTree();
            factory.WoodCleaning();
            factory.MakeChair();
            seller.SearchCustomer();
            seller.saleProduct();
            seller.GetCash();
        }
        public void SaleTable()
        {
            woodman.FindTree();
            woodman.CutTree();
            woodman.DeliverTree();
            factory.WoodCleaning();
            factory.MakeTable();
            seller.SearchCustomer();
            seller.saleProduct();
            seller.GetCash();
        }
    }
}
