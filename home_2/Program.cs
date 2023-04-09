namespace home_2
{
    class Program
    {
        static void Main()
        {
            Calculator();
            PredictNumber();
            Translator();
            EvenNumber();
        }

        /// <summary>
        /// Напишите программу - консольный калькулятор. Создайте две переменные с именами operand1 и operand2. Задайте переменным некоторые произвольные значения. Предложите пользователю ввести знак арифметической операции. Примите значение, введенное пользователем, и поместите его в строковую переменную sign. Для организации выбора алгоритма вычислительного процесса, используйте переключатель switch. Выведите на экран результат выполнения арифметической операции. ** В случае использования операции деления, организуйте проверку попытки деления на ноль. И если таковая имеется, то отмените выполнение арифметической операции и уведомите об ошибке пользователя.
        /// </summary>
        private static void Calculator()
        {
            Random random = new Random();
            double operand1 = random.Next(10);
            double operand2 = random.Next(10);
            Console.Write("Write the arithmetic sign: ");
            string sign = Console.ReadLine().Trim();
            switch (sign)
            {
                case "+":
                    {
                        Console.WriteLine($"{operand1} + {operand2} = {operand1 + operand2}");
                        break;
                    }
                case "-":
                    {
                        Console.WriteLine($"{operand1} - {operand2} = {operand1 - operand2}");
                        break;
                    }
                case "*":
                    {
                        Console.WriteLine($"{operand1} * {operand2} = {operand1 * operand2}");
                        break;
                    }
                case "/":
                    {
                        if (operand2 == 0)
                        {
                            Console.WriteLine("You cannot divide by zero");
                            break;
                        }
                        Console.WriteLine($"{operand1} / {operand2} = {operand1 / operand2}");
                        break;
                    }
                case "%":
                    {
                        Console.WriteLine($"{operand1} % {operand2} = {operand1 % operand2}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unknown arithmetic sign");
                        break;
                    }
            }
        }

        /// <summary>
        /// Напишите программу определения, попадает ли указанное пользователем число от 0 до 100 в числовой промежуток [0 - 14] [15 - 35] [36 - 50][50 - 100]. Если да, то укажите, в какой именно промежуток. Если пользователь указывает число, не входящее ни в один из имеющихся числовых промежутков, то выводится соответствующее сообщение.
        /// </summary>
        private static void PredictNumber()
        {
            Console.Write($"Enter your number from 0 to 100: ");
            int number = Int32.Parse(Console.ReadLine());
            if (number >= 0 && number <= 14)
            {
                Console.WriteLine($"Your number {number} exists in [0-14]");
            }
            else if (number >= 15 && number <= 35)
            {
                Console.WriteLine($"Your number {number} exists in [15-35]");
            }
            else if (number >= 36 && number <= 50)
            {
                Console.WriteLine($"Your number {number} exists in [36-50]");
            }
            else if (number >= 51 && number <= 100)
            {
                Console.WriteLine($"Your number {number} exists in [51-100]");
            }
            else
            {
                Console.WriteLine($"Your number {number} does not exists in any of periods");
            }
        }

        /// <summary>
        /// Напишите программу русско-английский переводчик. Программа знает 10 слов о погоде. Требуется, чтобы пользователь вводил слово на русском языке, а программа давала ему перевод этого слова на английском языке. Если пользователь ввел слово, для которого отсутствует перевод, то следует вывести сообщение, что такого слова нет.
        /// </summary>
        private static void Translator()
        {
            List<KeyValuePair<string, string>> listOfWordsInRussian = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("погода","weather"),
                new KeyValuePair<string, string>("холодно","cold"),
                new KeyValuePair<string, string>("жарко","hot"),
                new KeyValuePair<string, string>("солнечно","sunny"),
                new KeyValuePair<string, string>("дождливо","rainy"),
                new KeyValuePair<string, string>("облачно","cloudy"),
                new KeyValuePair<string, string>("ветрено","windy"),
                new KeyValuePair<string, string>("снежно","snowy"),
                new KeyValuePair<string, string>("туманно","foggy"),
                new KeyValuePair<string, string>("пасмурно","overcast")
            };
            Console.Write($"Write a word about the weather in Russian: ");
            string wordInRussian = Console.ReadLine().ToLower().Trim();
            if (listOfWordsInRussian.Exists(item => item.Key == wordInRussian))
            {
                string wordInEnglish = listOfWordsInRussian.Where(item => item.Key == wordInRussian).First().Value;
                Console.WriteLine($"{wordInRussian} - {wordInEnglish}");
            }
            else
            {
                Console.WriteLine($"Unknown word {wordInRussian}");
            }
        }

        /// <summary>
        /// Напишите программу, которая будет выполнять проверку чисел на четность.
        /// </summary>
        private static void EvenNumber()
        {
            Console.Write("Write a number: ");
            int number = Int32.Parse(Console.ReadLine().Trim());
            if (number % 2 == 0)
            {
                Console.WriteLine($"This {number} is an even number");
            }
            else
            {
                Console.WriteLine($"This {number} is not an even number");
            }
        }
    }
}
