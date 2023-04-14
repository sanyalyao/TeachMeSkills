namespace home_5
{
    class Student
    {
        public int id;
        public string name;
        public int age;
        public string group;
        public int mathMark;
        public int physicalEducationMark;
        public int biologyMark;
        public int reward;

        public Student(int id, string name, int age, string group, int mathMark, int physicalEducationMark, int biologyMark)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.group = group;
            this.mathMark = mathMark;
            this.physicalEducationMark = physicalEducationMark;
            this.biologyMark = biologyMark;
        }

        public void GetTheBestMathMark()
        {
            Console.WriteLine($"{name}, Math mark: {mathMark}");
        }

        public void GetTheBestPhysicalEducationMark()
        {
            Console.WriteLine($"{name}, Physical Education mark: {physicalEducationMark}");
        }

        public void GetTheBestBiologyMark()
        {
            Console.WriteLine($"{name}, Biology mark: {biologyMark}");
        }

        public void GiveReward(int reward)
        {
            this.reward = reward;
        }
    }
}
