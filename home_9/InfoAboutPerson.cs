namespace home_9
{
    class InfoAboutPerson
    {
        public void GetNameStartsA(List<Person> people)
        {
            foreach (Person person in people)
            {
                if (person.Name.ToLower().StartsWith('a'))
                {
                    Console.WriteLine($"This name {person.Name} starts with A");
                }
            }
        }

        public void ShowSalaryAndAge(List<Person> people)
        {
            foreach (Person person in people)
            {
                if (person.Salary > 1000 && person.Age < 30)
                {
                    Console.WriteLine($"{person.Name} is {person.Age} years old. His/her salary {person.Salary} is more 1000 and age {person.Age} is less 30");
                }
            }
        }

        public void ShowPersonHighestAge(List<Person> people)
        {
            try
            {
                Person person = people.Where(person => person.Age > 50).First();
                Console.WriteLine($"{person.Name} is {person.Age} years old. His/her age is more 50");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is not a person with the age more than 50");
            }
        }
    }
}
