namespace home_5
{
    class StudingProgress
    {
        private Random random = new Random();

        /// <summary>
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Математике.Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них. (ex: Anton, Math mark: 10)
        /// Установите каждому из лучших студентов выше - денежное вознаграждение в рублях - reward (rand: 0 - 100) (предусмотрите, чтобы нельзя было установить значение reward< 1 рубля)
        /// </summary>
        public void ShowProgressInMath(Student[] group1, Student[] group2, Student[] group3)
        {
            Student firstStudentMathMark = group1.MaxBy(student => student.MathMark);
            Student secondStudentMathMark = group2.MaxBy(student => student.MathMark);
            Student thirdStudentMathMark = group3.MaxBy(student => student.MathMark);

            // Show the student with the best Math mark from each group
            firstStudentMathMark.GetTheBestMathMark();
            secondStudentMathMark.GetTheBestMathMark();
            thirdStudentMathMark.GetTheBestMathMark();

            // Give a reward
            new Student[] { firstStudentMathMark, secondStudentMathMark, thirdStudentMathMark }.ToList().ForEach(student => student.GiveReward(random.Next(2, 101)));

            Console.WriteLine();
        }

        /// <summary>
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Физкультуре.Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них.
        /// Установите каждому из лучших студентов выше - денежное вознаграждение в рублях - reward (rand: 0 - 100) (предусмотрите, чтобы нельзя было установить значение reward< 1 рубля)
        /// </summary>
        public void ShowProgressInPhysicalEducation(Student[] group1, Student[] group2, Student[] group3)
        {
            Student firstStudentPhysicalEducationMark = group1.MaxBy(student => student.PhysicalEducationMark);
            Student secondStudentPhysicalEducationMark = group2.MaxBy(student => student.PhysicalEducationMark);
            Student thirdStudentPhysicalEducationMark = group3.MaxBy(student => student.PhysicalEducationMark);

            // Show the student with the best Physical Education mark from each group
            firstStudentPhysicalEducationMark.GetTheBestPhysicalEducationMark();
            secondStudentPhysicalEducationMark.GetTheBestPhysicalEducationMark();
            thirdStudentPhysicalEducationMark.GetTheBestPhysicalEducationMark();

            // Give a reward
            new Student[] { firstStudentPhysicalEducationMark, secondStudentPhysicalEducationMark, thirdStudentPhysicalEducationMark }.ToList().ForEach(student => student.GiveReward(random.Next(2, 101)));

            Console.WriteLine();
        }

        /// <summary>
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Биологии. Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них.
        /// Установите каждому из лучших студентов выше - денежное вознаграждение в рублях - reward (rand: 0 - 100) (предусмотрите, чтобы нельзя было установить значение reward< 1 рубля)
        /// </summary>
        public void ShowProgressInBiology(Student[] group1, Student[] group2, Student[] group3)
        {
            Student firstStudentBiologyMark = group1.MaxBy(student => student.BiologyMark);
            Student secondStudentBiologyMark = group2.MaxBy(student => student.BiologyMark);
            Student thirdStudentBiologyMark = group3.MaxBy(student => student.BiologyMark);

            // Show the student with the best Biology mark from each group
            firstStudentBiologyMark.GetTheBestBiologyMark();
            secondStudentBiologyMark.GetTheBestBiologyMark();
            thirdStudentBiologyMark.GetTheBestBiologyMark();

            // Give a reward
            new Student[] { firstStudentBiologyMark, secondStudentBiologyMark, thirdStudentBiologyMark }.ToList().ForEach(student => student.GiveReward(random.Next(2, 101)));

            Console.WriteLine();
        }

        private void GetAverageMarkOfMath(Student[] students)
        {
            double averageMark = students.Select(student => student.MathMark).ToArray().Average();
            string groupName = students.Select(student => student.Group).First();
            Console.WriteLine($"{groupName}, average mark of Math: {averageMark}");
        }

        private void GetAverageMarkOfPhysicalEducation(Student[] students)
        {
            double averageMark = students.Select(student => student.PhysicalEducationMark).ToArray().Average();
            string groupName = students.Select(student => student.Group).First();
            Console.WriteLine($"{groupName}, average mark of Physical Education: {averageMark}");
        }

        private void GetAverageMarkOfBiology(Student[] students)
        {
            double averageMark = students.Select(student => student.BiologyMark).ToArray().Average();
            string groupName = students.Select(student => student.Group).First();
            Console.WriteLine($"{groupName}, average mark of Biology: {averageMark}");
        }

        /// <summary>
        /// Создайте методы подсчета и вывода среднего балла группы студентов по каждой из дисциплин и вывода этой информации в консоль (разные методы) (ex: Group1, avarage mark math: 8.3)
        /// </summary>
        public void GetAverageMark(Student[] group1, Student[] group2, Student[] group3)
        {
            new List<Student[]> { group1, group2, group3 }.ForEach(groups => GetAverageMarkOfMath(groups));
            Console.WriteLine();

            new List<Student[]> { group1, group2, group3 }.ForEach(groups => GetAverageMarkOfPhysicalEducation(groups));
            Console.WriteLine();

            new List<Student[]> { group1, group2, group3 }.ForEach(groups => GetAverageMarkOfBiology(groups));
            Console.WriteLine();
        }

        /// <summary>
        /// Создайте метод расчета среднего балла группы студентов по всем 3 дисциплинам(средняя оценка группы по каждой дисциплине / количество дисциплин) и выведите эту информацию в консоль. (Avearage mark of Group1 - Math, PhysicalEducation, Biology - 8.3)
        /// </summary>
        public double GetAverageMarkOfDisciplines(Student[] students)
        {
            int[] mathMarks = students.Select(student => student.MathMark).ToArray();
            int[] physicalEducationMarks = students.Select(student => student.PhysicalEducationMark).ToArray();
            int[] biologyMarks = students.Select(student => student.BiologyMark).ToArray();
            double averageMark = Math.Round(mathMarks.Concat(physicalEducationMarks).ToArray().Concat(biologyMarks).ToArray().Average(), 1);
            string groupName = students.Select(student => student.Group).First();

            Console.WriteLine($"Avearage mark of {groupName} - Math, Physical Education and Biology - {averageMark}");

            return averageMark;
        }

        /// <summary>
        /// Добавьте каждому студенту из группы с наибольшим средним баллом по всем дисциплинам произвольный reward.
        /// </summary>
        public void GiveStudentSomeReward(Student[] students, double averageMarkOfGroup)
        {
            Student[] studentsWithHighMark = students.Where(student => (double)(student.MathMark + student.PhysicalEducationMark + student.BiologyMark) > averageMarkOfGroup).ToArray();
            studentsWithHighMark.ToList().ForEach(student => student.Reward = student.Reward + random.Next(2, 101));
        }

        /// <summary>
        /// Выведите на экран студента с наибольшим reward. Если таких студентов несколько - выведите их всех.
        /// </summary>
        public void ShowStudentWithHighestReward(Student[] group1, Student[] group2, Student[] group3)
        {
            Student[] students = group1.Concat(group2).ToArray().Concat(group3).ToArray();
            int highestMark = students.MaxBy(student => student.Reward).Reward;
            Student[] studentsWithHighestMark = students.Where(student => student.Reward == highestMark).ToArray();
            studentsWithHighestMark.ToList().ForEach(student => Console.WriteLine($"Student\\students with the highest reward: {student.Name} - {student.Reward}"));
        }

    }
}
