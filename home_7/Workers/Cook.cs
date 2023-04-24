using home_7.Interfaces;

namespace home_7.Workers
{
    class Cook : BaseWorker, ICleanable, ICookable
    {
        public Cook(string name, string profession) : base(name, profession)
        {
            this.Name = name;
            this.Profession = profession;
        }

        public void Clean()
        {
            Console.WriteLine("Cook is cleaning");
        }

        public void ToCook()
        {
            Console.WriteLine("Cook is cooking");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
