namespace home_5
{
    class Program
    {
        static Random random = new Random();

        /// <summary>
        /// Coздайте класс Student, в классе используйте поля Id, Name, Age, Group, MathMark (Оценка по математике от 1 до 10 включительно), PhysicalEducationMark (Оценка по физкультуре от 1 до 10), BiologyMark (Оценка по биологии от 1 до 10), Reward (денежное вознаграждение за хорошую учебу)
        /// Допустим есть 3 группы(Group1, Group2, Group3). Создайте 3 массива студентов по 5 в каждой группе.Оценки по дисциплинам задайте с использованием Random
        ///Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Математике.Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них. (ex: Anton, Math mark: 10)
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Физкультуре.Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них.
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Биологии. Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них.
        /// Установите каждому из лучших студентов выше - денежное вознаграждение в рублях - reward (rand: 0 - 100) (предусмотрите, чтобы нельзя было установить значение reward< 1 рубля)
        /// Создайте методы подсчета и вывода среднего балла группы студентов по каждой из дисциплин и вывода этой информации в консоль (разные методы) (ex: Group1, avarage mark math: 8.3)
        /// Создайте метод расчета среднего балла группы студентов по всем 3 дисциплинам(средняя оценка группы по каждой дисциплине / количество дисциплин) и выведите эту информацию в консоль. (Avearage mark of Group1 - Math, PhysicalEducation, Biology - 8.3)
        /// Добавьте каждому студенту из группы с наибольшим средним баллом по всем дисциплинам произвольный reward.
        /// Выведите на экран студента с наибольшим reward. Если таких студентов несколько - выведите их всех.
        /// </summary>
        static void Main()
        {
            Student studentSasha = new Student(213, "Sasha", 14, "Group1", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentDima = new Student(54, "Dima", 13, "Group1", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentKatya = new Student(567, "Katya", 13, "Group1", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentRita = new Student(56, "Rita", 14, "Group1", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentPolina = new Student(12, "Polina", 13, "Group1", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentKolya = new Student(987, "Kolya", 14, "Group2", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentIgor = new Student(65, "Igor", 14, "Group2", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentAnton = new Student(09, "Anton", 14, "Group2", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentMasha = new Student(543, "Masha", 14, "Group2", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentLena = new Student(1234, "Lena", 14, "Group2", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentMiguel = new Student(8567, "Miguel", 13, "Group3", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentBilly = new Student(857, "Billy", 13, "Group3", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentVan = new Student(5643, "Van", 13, "Group3", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentSteve = new Student(5123, "Steve", 13, "Group3", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            Student studentRicardo = new Student(456, "Ricardo", 13, "Group3", random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

            // Three groups of students
            Student[] group1 = new Student[] { studentSasha, studentPolina, studentRita, studentKatya, studentDima };
            Student[] group2 = new Student[] { studentKolya, studentIgor, studentAnton, studentMasha, studentLena };
            Student[] group3 = new Student[] { studentMiguel, studentBilly, studentVan, studentSteve, studentRicardo };

            // Show the student with the best Math mark from each group
            // Give a reward
            ShowProgressInMath(group1, group2, group3);
            ShowProgressInPhysicalEducation(group1, group2, group3);
            ShowProgressInBiology(group1, group2, group3);

            // Get the average mark from each group with subjects
            GetAverageMark(group1, group2, group3);

            // Get average mark of disciplines from each group
            double averageMarkGroup1 = GetAverageMarkOfDisciplines(group1);
            double averageMarkGroup2 = GetAverageMarkOfDisciplines(group2);
            double averageMarkGroup3 = GetAverageMarkOfDisciplines(group3);

            Console.WriteLine();

            // Give some reward if average mark of student is more than average mark of group with all disciples 
            GiveStudentSomeReward(group1, averageMarkGroup1);
            GiveStudentSomeReward(group2, averageMarkGroup2);
            GiveStudentSomeReward(group3, averageMarkGroup3);

            Console.WriteLine();

            // Show student/students with the highest reward
            ShowStudentWithHighestReward(group1, group2, group3);
        }

        /// <summary>
        /// Создайте метод вывода в консоль студента из каждой группы с наилучшей оценкой по Математике.Если существуют студенты с одинаковыми наилучшими оценками - выведите любого из них. (ex: Anton, Math mark: 10)
        /// Установите каждому из лучших студентов выше - денежное вознаграждение в рублях - reward (rand: 0 - 100) (предусмотрите, чтобы нельзя было установить значение reward< 1 рубля)
        /// </summary>
        private static void ShowProgressInMath(Student[] group1, Student[] group2, Student[] group3)
        {
            Student firstStudentMathMark = group1.MaxBy(student => student.mathMark);
            Student secondStudentMathMark = group2.MaxBy(student => student.mathMark);
            Student thirdStudentMathMark = group3.MaxBy(student => student.mathMark);

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
        private static void ShowProgressInPhysicalEducation(Student[] group1, Student[] group2, Student[] group3)
        {
            Student firstStudentPhysicalEducationMark = group1.MaxBy(student => student.physicalEducationMark);
            Student secondStudentPhysicalEducationMark = group2.MaxBy(student => student.physicalEducationMark);
            Student thirdStudentPhysicalEducationMark = group3.MaxBy(student => student.physicalEducationMark);

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
        private static void ShowProgressInBiology(Student[] group1, Student[] group2, Student[] group3)
        {
            Student firstStudentBiologyMark = group1.MaxBy(student => student.biologyMark);
            Student secondStudentBiologyMark = group2.MaxBy(student => student.biologyMark);
            Student thirdStudentBiologyMark = group3.MaxBy(student => student.biologyMark);

            // Show the student with the best Biology mark from each group
            firstStudentBiologyMark.GetTheBestBiologyMark();
            secondStudentBiologyMark.GetTheBestBiologyMark();
            thirdStudentBiologyMark.GetTheBestBiologyMark();

            // Give a reward
            new Student[] { firstStudentBiologyMark, secondStudentBiologyMark, thirdStudentBiologyMark }.ToList().ForEach(student => student.GiveReward(random.Next(2, 101)));

            Console.WriteLine();
        }

        private static void GetAverageMarkOfMath(Student[] students)
        {
            double averageMark = students.Select(student => student.mathMark).ToArray().Average();
            string groupName = students.Select(student => student.group).First();
            Console.WriteLine($"{groupName}, average mark of Math: {averageMark}");
        }

        private static void GetAverageMarkOfPhysicalEducation(Student[] students)
        {
            double averageMark = students.Select(student => student.physicalEducationMark).ToArray().Average();
            string groupName = students.Select(student => student.group).First();
            Console.WriteLine($"{groupName}, average mark of Physical Education: {averageMark}");
        }

        private static void GetAverageMarkOfBiology(Student[] students)
        {
            double averageMark = students.Select(student => student.biologyMark).ToArray().Average();
            string groupName = students.Select(student => student.group).First();
            Console.WriteLine($"{groupName}, average mark of Biology: {averageMark}");
        }

        /// <summary>
        /// Создайте методы подсчета и вывода среднего балла группы студентов по каждой из дисциплин и вывода этой информации в консоль (разные методы) (ex: Group1, avarage mark math: 8.3)
        /// </summary>
        private static void GetAverageMark(Student[] group1, Student[] group2, Student[] group3)
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
        private static double GetAverageMarkOfDisciplines(Student[] students)
        {
            int[] mathMarks = students.Select(student => student.mathMark).ToArray();
            int[] physicalEducationMarks = students.Select(student => student.physicalEducationMark).ToArray();
            int[] biologyMarks = students.Select(student => student.biologyMark).ToArray();
            double averageMark = Math.Round(mathMarks.Concat(physicalEducationMarks).ToArray().Concat(biologyMarks).ToArray().Average(), 1);
            string groupName = students.Select(student => student.group).First();

            Console.WriteLine($"Avearage mark of {groupName} - Math, Physical Education and Biology - {averageMark}");

            return averageMark;
        }

        /// <summary>
        /// Добавьте каждому студенту из группы с наибольшим средним баллом по всем дисциплинам произвольный reward.
        /// </summary>
        private static void GiveStudentSomeReward(Student[] students, double averageMarkOfGroup)
        {
            Student[] studentsWithHighMark = students.Where(student => (double) (student.mathMark + student.physicalEducationMark + student.biologyMark) > averageMarkOfGroup).ToArray();
            studentsWithHighMark.ToList().ForEach(student => student.reward = student.reward + random.Next(2, 101));
        }

        /// <summary>
        /// Выведите на экран студента с наибольшим reward. Если таких студентов несколько - выведите их всех.
        /// </summary>
        private static void ShowStudentWithHighestReward(Student[] group1, Student[] group2, Student[] group3)
        {
            Student[] students = group1.Concat(group2).ToArray().Concat(group3).ToArray();
            int highestMark = students.MaxBy(student => student.reward).reward;
            Student[] studentsWithHighestMark = students.Where(student => student.reward == highestMark).ToArray();
            studentsWithHighestMark.ToList().ForEach(student => Console.WriteLine($"Student\\students with the highest reward: {student.name} - {student.reward}"));
        }
    }
}