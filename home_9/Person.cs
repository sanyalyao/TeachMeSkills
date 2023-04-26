namespace home_9
{
    class Person
    {
        private int age;
        private int salary;

        public string Name { get; set; }

        public int Age 
        { 
            get
            {
                return age;
            }
            set
            {
                if (value < 18)
                {
                    throw new AgeException($"Age of {Name} is {value}. It is lower 18");
                }
                else
                {
                    age = value;
                }
            }
        }

        public int Salary 
        { 
            get
            {
                return salary;
            }
            set
            {
                if (value < 100)
                {
                    throw new SalaryException($"Salary of {Name} is {value}. It is less 100");
                }
                else
                {
                    salary = value;
                }
            }
        }

        public Person(string name, int age, int salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
    }
}
