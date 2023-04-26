namespace home_9
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();

            List<Person> people = new List<Person>()
            {
                new Person("Alex", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Igor", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Pasha", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Pasha", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Pasha", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Pasha", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Pasha", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Pasha", random.Next(17, 55), random.Next(50, 1500)),
                new Person("Pasha", random.Next(17, 55), random.Next(50, 1500)),
            };

            InfoAboutPerson check = new InfoAboutPerson();
            check.GetNameStartsA(people);
            check.ShowSalaryAndAge(people);
            check.ShowPersonHighestAge(people);
        }
    }
}