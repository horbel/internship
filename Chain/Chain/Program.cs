using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            VacancyHandler SeniorHand = new SeniorHandler();
            VacancyHandler MiddleHand = new MiddleHandler();
            VacancyHandler JuniorHand = new JuniorHandler();
            SeniorHand.Succsessor = MiddleHand;
            MiddleHand.Succsessor = JuniorHand;

            List<Applicant> applicants = new List<Applicant>
            {
                new Applicant("lexa")
                {
                    isHardworking = true,
                    isSmart = true
                },
                new Applicant("sasha")
                {
                    isHardworking = false,
                    isSmart = true
                },
                new Applicant("joe")
                {
                    isSmart = false,
                    isHardworking = true
                },
                new Applicant("jack")
                {
                    isHardworking = false,
                    isSmart = false
                }
            };

            foreach (var app in applicants)
            {
                SeniorHand.Handle(app);
            }

        }
    }
    class Applicant
    {
        public string Name { get; set; }
        public Applicant() { }
        public Applicant(string n)
        {
            Name = n;
        }
        public bool isSmart { get; set; }
        public bool isHardworking { get; set; }
    }
    abstract class VacancyHandler
    {
        public VacancyHandler Succsessor { get; set; }
        public abstract void Handle(Applicant applicant);
    }
    class SeniorHandler : VacancyHandler
    {
        public override void Handle(Applicant applicant)
        {
            if (applicant.isHardworking && applicant.isSmart)
            {
                Console.WriteLine($"{applicant.Name} get a job as Senior!");
            }
            else if (this.Succsessor != null)
            {
                Succsessor.Handle(applicant);
            }
            else
            {
                Console.WriteLine($"{applicant.Name} didn't get a job");
            }
        }
    }
    class MiddleHandler : VacancyHandler
    {
        public override void Handle(Applicant applicant)
        {
            if (!applicant.isHardworking && applicant.isSmart)
            {
                Console.WriteLine($"{applicant.Name} get a job as Middle!");
            }
            else if (this.Succsessor != null)
            {
                Succsessor.Handle(applicant);
            }
            else
            {
                Console.WriteLine($"{applicant.Name} didn't get a job");
            }
        }
    }
    class JuniorHandler : VacancyHandler
    {
        public override void Handle(Applicant applicant)
        {
            if (applicant.isHardworking && !applicant.isSmart)
            {
                Console.WriteLine($"{applicant.Name} get a job as Junior!");
            }
            else if (this.Succsessor != null)
            {
                Succsessor.Handle(applicant);
            }
            else
            {
                Console.WriteLine($"{applicant.Name} didn't get a job");
            }
        }
    }

}