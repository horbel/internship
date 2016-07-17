using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Hunter hunter = new Hunter();
            Rifle rifle = new Rifle();
            IFirearms spear = new SpearToRifleAdapter(new Spear());
            hunter.Hunt(rifle);
            hunter.Hunt(spear);
        }
    }

    interface IFirearms
    {
        void Shoot();
    }
    class Rifle : IFirearms
    {
        public void Shoot()
        {
            Console.WriteLine("Rifle shooting");
        }
    }
    class Hunter
    {
        public void Hunt(IFirearms weapon)
        {
            weapon.Shoot();
        }
    }

    interface ITraditionalWeapon
    {
        void Throw();
    }
    class Spear : ITraditionalWeapon
    {
        public void Throw()
        {
            Console.WriteLine("Spear throwing");
        }
    }

    //adapter 
    class SpearToRifleAdapter :IFirearms
    {
        Spear spear;
        public SpearToRifleAdapter(Spear s)
        {
            spear = s;
        }
        public void Shoot()
        {
            spear.Throw();
        }
    }
}
