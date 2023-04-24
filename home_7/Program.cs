using home_7.Workers;

namespace home_7
{
    class Program
    {
        static void Main()
        {
            Cleaner cleaner = new Cleaner("Igor", "cleaner");
            Cook cook = new Cook("Sasha", "cook");
            Manager manager = new Manager("Pasha", "manager");

            BaseWorker[] workers = new BaseWorker[] { cleaner, cook, manager};

            new OpenRestaurant().OpenMcDonalds(workers);
        }
    }
}