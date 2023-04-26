using home_7.Interfaces;

namespace home_7.Workers
{
    class Cleaner : BaseWorker, ICleanable
    {
        public Cleaner(string name, string profession) : base(name, profession)
        {
            this.Name = name;
            this.Profession = profession;
        }

        public void Clean()
        {
            Console.WriteLine("Cleaner is cleaning");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
