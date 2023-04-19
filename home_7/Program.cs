using home_7.Workers;

namespace home_7
{
    class Program
    {
        static void Main()
        {
            Cleaner cleaner = new Cleaner();
            Cook cook = new Cook();
            Manager manager = new Manager();

            BaseWorker[] workers = new BaseWorker[] { cleaner, cook, manager};

            OpenMcDonalds(workers);
        }

        static void OpenMcDonalds(BaseWorker[] workers)
        {
            foreach (BaseWorker worker in workers)
            {
                Console.WriteLine(worker.ToString());
            }
        }
    }
}