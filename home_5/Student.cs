namespace home_5
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int MathMark { get; set; }
        public int PhysicalEducationMark { get; set; }
        public int BiologyMark { get; set; }
        public int Reward { get; set; }

        public Student(int id, string name, int age, int mathMark, int physicalEducationMark, int biologyMark)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.MathMark = mathMark;
            this.PhysicalEducationMark = physicalEducationMark;
            this.BiologyMark = biologyMark;
        }

        public void GetTheBestMathMark()
        {
            Console.WriteLine($"{Name}, Math mark: {MathMark}");
        }

        public void GetTheBestPhysicalEducationMark()
        {
            Console.WriteLine($"{Name}, Physical Education mark: {PhysicalEducationMark}");
        }

        public void GetTheBestBiologyMark()
        {
            Console.WriteLine($"{Name}, Biology mark: {BiologyMark}");
        }

        public void GiveReward(int reward)
        {
            this.Reward = reward;
        }
    }
}
