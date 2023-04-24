using home_7.Workers;

namespace home_7
{
    class OpenRestaurant
    {
        public void OpenMcDonalds(BaseWorker[] workers)
        {
            foreach (BaseWorker worker in workers)
            {
                Console.WriteLine($"{worker.Name} is {worker.Profession}");

                if (worker.GetType() == typeof(Cleaner))
                {
                    workers.Where(worker => worker.GetType() == typeof(Cleaner)).Cast<Cleaner>().First().Clean();
                }
                else if (worker.GetType() == typeof(Cook))
                {
                    workers.Where(worker => worker.GetType() == typeof(Cook)).Cast<Cook>().First().Clean();
                    workers.Where(worker => worker.GetType() == typeof(Cook)).Cast<Cook>().First().ToCook();
                }
                else if (worker.GetType() == typeof(Manager))
                {
                    workers.Where(worker => worker.GetType() == typeof(Manager)).Cast<Manager>().First().ToCook();
                    workers.Where(worker => worker.GetType() == typeof(Manager)).Cast<Manager>().First().SolveConflicts();
                    workers.Where(worker => worker.GetType() == typeof(Manager)).Cast<Manager>().First().ManagePeople();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
