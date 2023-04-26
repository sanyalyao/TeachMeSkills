using home_7.Interfaces;

namespace home_7.Workers
{
    class Manager : BaseWorker, ISolvableConflicts, ICookable, IManagable
    {
        public Manager(string name, string profession) : base(name, profession)
        {
            this.Name = name;
            this.Profession = profession;
        }

        public void SolveConflicts()
        {
            Console.WriteLine("Manager is solving conflicts");
        }

        public void ToCook()
        {
            Console.WriteLine("Manager is cooking");
        }

        public void ManagePeople()
        {
            Console.WriteLine("Manager is managing people");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
