using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero warrior = new Hero(new WarriorFactory());
            Console.WriteLine(warrior.Class);
            warrior.Armor.ShowArmorInfo();
            warrior.Ability.UseAbility();
            Console.WriteLine("**************************************************");
            Hero rogue = new Hero(new RogueFactory());
            Console.WriteLine(rogue.Class);
            rogue.Armor.ShowArmorInfo();
            rogue.Ability.UseAbility();

        }
    }

    abstract class Armor
    {
        protected int armorVal;
        public abstract void ShowArmorInfo();
    }
    class HeavyArmor : Armor
    {
        public HeavyArmor()
        {
            armorVal = 100;
        }
        public override void ShowArmorInfo()
        {
            Console.WriteLine($"Герой носит тяжёлую броню c уровнем защиты: {armorVal}");
        }
    }
    class LightArmor : Armor
    {
        public LightArmor()
        {
            armorVal = 50;
        }
        public override void ShowArmorInfo()
        {
            Console.WriteLine($"Герой носит лёгкую броню c уровнем защиты: {armorVal}");
        }
    }
    abstract class Ability
    {
        public abstract void UseAbility();
    }
    class DeadlyStrike : Ability
    {
        public override void UseAbility()
        {
            Console.WriteLine("Герой использует смертельный удар!");
        }
    }
    class PowerStorm : Ability
    {
        public override void UseAbility()
        {
            Console.WriteLine("Герой использует силовой шторм!");
        }
    }

    
    abstract class HeroFactory{
        public abstract Armor CreateArmor();
        public abstract Ability CreateAbility();
        public abstract string Class { get; }
    }
    class WarriorFactory : HeroFactory
    {
        public override string Class
        {
            get
            {
                return "Warrior";
            }
        }
        public override Ability CreateAbility()
        {
            return new PowerStorm();
        }

        public override Armor CreateArmor()
        {
            return new HeavyArmor();
        }
    }
    class RogueFactory : HeroFactory
    {
        public override string Class
        {
            get
            {
                return "Rogue";
            }
        }
        public override Ability CreateAbility()
        {
            return new DeadlyStrike();
        }

        public override Armor CreateArmor()
        {
            return new LightArmor();
        }
    }
    class Hero
    {
        public string Class { get; }
        public Armor Armor { get; }
        public Ability Ability { get;}
        public Hero(HeroFactory herofact)
        {
            Armor = herofact.CreateArmor();
            Ability = herofact.CreateAbility();
            Class = herofact.Class;
        }
        
    }
}
