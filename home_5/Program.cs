namespace home_5
{
    class Program
    {
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
            StudentsCreator creater = new StudentsCreator();
            List<Student> students = creater.CreateStudents();
            StudingProgress studingProgress = new StudingProgress();

            // Three groups of students
            Student[] group1 = students.Where(student => student.Group == "Group1").ToArray();
            Student[] group2 = students.Where(student => student.Group == "Group2").ToArray();
            Student[] group3 = students.Where(student => student.Group == "Group3").ToArray();

            // Show the student with the best Math mark from each group
            // Give a reward
            studingProgress.ShowProgressInMath(group1, group2, group3);
            studingProgress.ShowProgressInPhysicalEducation(group1, group2, group3);
            studingProgress.ShowProgressInBiology(group1, group2, group3);

            // Get the average mark from each group with subjects
            studingProgress.GetAverageMark(group1, group2, group3);

            // Get average mark of disciplines from each group
            double averageMarkGroup1 = studingProgress.GetAverageMarkOfDisciplines(group1);
            double averageMarkGroup2 = studingProgress.GetAverageMarkOfDisciplines(group2);
            double averageMarkGroup3 = studingProgress.GetAverageMarkOfDisciplines(group3);

            Console.WriteLine();

            // Give some reward if average mark of student is more than average mark of group with all disciples 
            studingProgress.GiveStudentSomeReward(group1, averageMarkGroup1);
            studingProgress.GiveStudentSomeReward(group2, averageMarkGroup2);
            studingProgress.GiveStudentSomeReward(group3, averageMarkGroup3);

            Console.WriteLine();

            // Show student/students with the highest reward
            studingProgress.ShowStudentWithHighestReward(group1, group2, group3);
        }
    }
}