namespace home_3
{
    class Program
    {
        static void Main()
        {
            Task_0();
            //Task_1();
            //Task_2();
            //Task_3();
            //Task_4();
            //Task_5();
            //Task_6();
            //Task_7();
        }

        /// <summary>
        /// Создайте массив целых чисел. Напишете программу, которая выводит сообщение о том, входит ли заданное число в массив или нет.  Пусть число для поиска задается с консоли.
        /// </summary>
        private static void Task_0()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            Console.Write("Write a number: ");
            int inputNumber = Int32.Parse(Console.ReadLine().Trim());
            GetResult(numbers, inputNumber);
        }
        private static void GetResult(int[] numbers, int inputNumber)
        {
            if (numbers.Contains(inputNumber))
            {
                Console.WriteLine($"Your number {inputNumber} exists in the array");
            }
            else
            {
                Console.WriteLine($"Your number {inputNumber} does not exist in the array");
            }
        }
        /// <summary>
        /// Создайте массив целых чисел. Удалите все вхождения заданного числа из массива. Пусть число задается с консоли.Если такого числа нет - выведите сообщения об этом. В результате должен быть новый массив без указанного числа.  
        /// </summary>
        private static void Task_1()
        {
            int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("Write a number to remove: ");
            int numberToDelete = Int32.Parse(Console.ReadLine().Trim());
            Console.WriteLine($"New array");
            DeleteNumber(numberToDelete, numbers);
        }
        private static void DeleteNumber(int numberToDelete, int[] numbers)
        {
            if (numbers.Contains(numberToDelete))
            {
                int[] newNumbers = numbers.Where(number => number != numberToDelete).ToArray();
                newNumbers.ToList().ForEach(number => Console.Write($"{number} "));
            }
            else
            {
                Console.WriteLine($"Your number {numberToDelete} does not exist in the array");
            }
        }
        /// <summary>
        /// Создайте и заполните массив случайным числами и выведете максимальное, минимальное и среднее значение. Для генерации случайного числа используйте метод Random() .  Пусть будет возможность создавать массив произвольного размера.Пусть размер массива вводится с консоли.
        /// </summary>
        private static void Task_2()
        {
            Console.Write("Write the size of the array: ");
            int length = Int32.Parse(Console.ReadLine().Trim());
            int[] arrayNumbers = GetRandomArray(length);
            Console.WriteLine($"Max number from the array - {arrayNumbers.Max()}");
            Console.WriteLine($"Min number from the array - {arrayNumbers.Min()}");
            Console.WriteLine($"Average number from the array - {arrayNumbers.Average()}");
        }
        private static int[] GetRandomArray(int length)
        {
            int[] numbers = new int[length];
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next();
            }
            return numbers;
        }
        /// <summary>
        /// Создайте 2 массива из 5 чисел. Выведите массивы на консоль в двух отдельных строках. Посчитайте среднее арифметическое элементов каждого массива и сообщите, для какого из массивов это значение оказалось больше (либо сообщите, что их средние арифметические равны).  
        /// </summary>
        private static void Task_3()
        {
            int[] firstArray = new int[] { 1, 2, 3, 4, 5 };
            int[] secondArray = new int[] { 6, 7, 8, 9, 10 };
            firstArray.ToList().ForEach(number => Console.Write($"{number} "));
            Console.WriteLine();
            secondArray.ToList().ForEach(number => Console.Write($"{number} "));
            GetResult(firstArray, secondArray);
        }
        private static void GetResult(int[] firstArray, int[] secondArray)
        {
            double averageFirstArray = firstArray.Average();
            double averageSecondArray = secondArray.Average();
            if (averageFirstArray > averageSecondArray)
            {
                Console.WriteLine($"\nThe average result of the second array = {averageSecondArray}");
                Console.WriteLine($"The first array has a large average result = {averageFirstArray}");
            }
            else if (averageFirstArray < averageSecondArray)
            {
                Console.WriteLine($"\nThe average result of the first array = {averageFirstArray}");
                Console.WriteLine($"The second array has a large average result = {averageSecondArray}");
            }
            else
            {
                Console.WriteLine($"\nThe average results of both arrays are equal");
            }
        }
        /// <summary>
        /// Создайте массив и заполните массив. Выведите массив на экран в строку. Замените каждый элемент с нечётным индексом на ноль. Снова выведете массив на экран на отдельной строке. 
        /// </summary>
        private static void Task_4()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
            numbers.ToList().ForEach(number => Console.Write($"{number} "));
            Console.WriteLine();
            ChangeArray(numbers).ToList().ForEach(number => Console.Write($"{number} "));
        }
        private static int[] ChangeArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 != 0)
                {
                    numbers[i] = 0;
                }
            }
            return numbers;
        }
        /// <summary>
        /// Создайте массив строк. Заполните его произвольными именами людей. Отсортируйте массив. Результат выведите на консоль.
        /// </summary>
        private static void Task_5()
        {
            string[] names = new string[] { "Liam", "Noah", "Oliver", "Elijah", "James", "William", "Benjamin", "Lucas" };
            Array.Sort(names);
            names.ToList().ForEach(name => Console.Write($"{name} "));
        }
        /// <summary>
        /// Реализуйте алгоритм сортировки массива пузырьком.
        /// </summary>
        private static void Task_6()
        {
            int[] numbers = new int[] { 30, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            numbers.ToList().ForEach(number => Console.Write($"{number} "));
            Console.WriteLine();
            BubbleSort(numbers).ToList().ForEach(number => Console.Write($"{number} "));
        }
        private static int[] BubbleSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int value = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = value;
                    }
                }
            }
            return numbers;
        }
        /// <summary>
        /// Создайте двумерный массив целых чисел. Выведите на консоль сумму всех элементов массива.
        /// </summary>
        private static void Task_7()
        {
            int[,] numbers = new int[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum of multidimensional arrays are {sum}");
        }
    }
}