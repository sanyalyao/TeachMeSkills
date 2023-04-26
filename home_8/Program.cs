namespace home_8
{
    class Program
    {
        static void Main()
        {
            Person person1 = new Person("Igor", 2000);
            Person person2 = new Person("Alex",1800);
            Person person3 = new Person("Masha",2500);
            Person person4 = new Person("Rita",1100);

            List<Person> persons = new List<Person>() { person1, person2, person3, person4 };

            foreach (Person person in persons)
            {
                person.CheckRation(person);
            }
        }
    }
}