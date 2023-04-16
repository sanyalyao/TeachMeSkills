namespace home_5
{
    class StudentsCreator
    {
        private Random random = new Random();
        private List<int> numbers = new List<int>();

        private void GenerateUniqueId()
        {
            int randomNumber = random.Next(0,1000);
            if ( ! numbers.Contains(randomNumber))
            {
                numbers.Add(randomNumber);
            }
        }

        public List<Student> CreateStudents()
        {
            string[] names = new string[] { "Sasha", "Dima", "Katya", "Rita", "Polina", "Kolya", "Igor", "Anton", "Masha", "Lena", "Miguel", "Billy", "Van", "Steve", "Ricardo" };

            List<Student> students = new List<Student>();

            for (int i = 0; i < 15; i++)
            {
                GenerateUniqueId();
                students.Add( new Student(i, names[i], random.Next(13, 19), random.Next(1, 11), random.Next(1, 11), random.Next(1, 11)) );                
            }

            // Give each student the group's name
            SetGroupName(students);

            return students;
        }

        private void SetGroupName(List<Student> students)
        {
            while (students.Where(student => !string.IsNullOrEmpty(student.Group)).ToArray().Count() != students.Count)
            {
                List<Student> randomStudents = GetElements(students, 5);

                foreach (Student student in randomStudents)
                {
                    if (students.Where(student => !string.IsNullOrEmpty(student.Group)).ToArray().Count() < 5 )
                    {
                        student.Group = "Group1";
                    }
                    else if (students.Where(student => !string.IsNullOrEmpty(student.Group)).ToArray().Count() > 4 && students.Where(student => !string.IsNullOrEmpty(student.Group)).ToArray().Count() < 10)
                    {
                        student.Group = "Group2";
                    }
                    else
                    {
                        student.Group = "Group3";
                    }
                }
            }
        }

        private static List<Student> GetElements(List<Student> list, int elementsCount)
        {
            return list.Where(student => string.IsNullOrEmpty(student.Group)).Take(elementsCount).ToList();
        }
    }
}
