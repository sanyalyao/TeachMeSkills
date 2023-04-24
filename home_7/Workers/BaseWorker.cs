namespace home_7.Workers
{
    abstract class BaseWorker
    {
        public string Name { get; set; }
        public string Profession { get; set; }

        public BaseWorker(string name, string profession)
        {
            Name = name;
            Profession = profession;
        }
    }
}
