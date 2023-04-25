namespace home_8
{
    class Person
    {
        public string Name { get; set; }
        public int MaxNumberOfCalories { get; set; }

        public Person(string name, int maxNumberOfCalories)
        {
            Name = name;
            MaxNumberOfCalories = maxNumberOfCalories;
        }

        public void CheckRation(Person person)
        {
            ListRationWithPerson<List<KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>>, Person> rationForPerson = new RationCreater().GetRationForPerson(person);

            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine($"{person.Name} has maxNumberOfCalories = {person.MaxNumberOfCalories}");

            foreach (KeyValuePair < DietSchedule.ScheduleFoodDays, List < Product >> pair in rationForPerson.Value)
            {
                int sumOfCalories = 0;
                int index = 0;

                foreach (Product product in pair.Value)
                {
                    sumOfCalories += product.NumberOfCalories;
                }

                while (sumOfCalories > person.MaxNumberOfCalories)
                {
                    pair.Value.RemoveAt(index);
                    sumOfCalories -= pair.Value[index].NumberOfCalories;
                    index++;
                }

                Console.WriteLine($"\n{pair.Key}");
                pair.Value.ForEach(product => Console.WriteLine($"\t{product.Name} has calories {product.NumberOfCalories}"));
                Console.WriteLine($"Amount of calories for {pair.Key} is {sumOfCalories}");
            }
        }
    }
}
