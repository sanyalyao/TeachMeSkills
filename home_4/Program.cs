using System.Text.RegularExpressions;

namespace home_4
{
    class Program
    {
        static void Main()
        {
            //Task_1();
            //Task_2();
            //Task_3();
            //Task_4();
            //Task_5();
            Task_6();
        }

        /// <summary>
        /// Задать строку содержащую внутри цифры и несколько повторений слова test, Заменить в строке все вхождения 'test' на 'testing'.
        /// </summary>
        private static void Task_1()
        {
            string text = "1 2 3 4 test 5 6 7 test";
            string newText = text.Replace("test", "testing");
            Console.WriteLine($"Current text: {text}");
            Console.WriteLine($"New text: {newText}");
        }

        /// <summary>
        /// Создайте переменные, которые будут хранить следующие слова: (Welcome, to, the, TMS, lessons)выполните конкатенацию слов и выведите на экран следующую фразу:
        /// Каждое слово должно быть записано отдельно и взято в кавычки, например "Welcome". Не забывайте о пробелах после каждого слова
        /// </summary>
        private static void Task_2()
        {
            string firstWord = "Welcome";
            string secondWord = "to";
            string thirdWord = "the";
            string fourthWord = "TMS";
            string fifth = "lessons";
            Console.WriteLine('"' + firstWord + '"' + " " 
                + '"' + secondWord + '"' + " " 
                + '"' + thirdWord + '"' + " " 
                + '"' + fourthWord + '"' + " " 
                + '"' + fifth + '"');
        }

        /// <summary>
        /// Дана строка: teamwithsomeofexcersicesabcwanttomakeitbetter.
        /// Необходимо найти в данной строке "abc", записав всё что до этих символов в переменную firstPart, а также всё, что после них во вторую secondPart.
        /// Результат вывести в консоль.
        /// </summary>
        private static void Task_3()
        {
            string text = "teamwithsomeofexcersicesabcwanttomakeitbetter.";
            string str = "abc";
            string firstPart = text.Remove(text.IndexOf(str));
            string secondPart = text.Substring(text.IndexOf(str) + str.Length);
            Console.WriteLine($"Current text: {text}");
            Console.WriteLine($"First part: {firstPart}");
            Console.WriteLine($"Second part: {secondPart}");
        }

        /// <summary>
        /// Дана строка: Good day 
        ///Необходимо с помощью метода substring удалить слово "Good". После чего необходимо используя команду insert создать строку со значением: The best day!!!!!!!!!.
        ///Заменить последний "!" на "?" и вывести результат на консоль.
        /// </summary>
        private static void Task_4()
        {
            string text = "Good day";
            string word = "Good";
            string secondPartOfText = text.Substring(text.IndexOf(word) + word.Length).Trim();
            string firstWord = "The";
            string secondWord = "best";
            string thirdWord = "!!!!!!!!!";
            string newText = secondPartOfText.Insert(0, $"{firstWord} ")
                .Insert(firstWord.Length + 1, $"{secondWord} ")
                .Insert(firstWord.Length + secondWord.Length + secondPartOfText.Length + 2, thirdWord);
            string result = $"{newText.Remove(newText.Length - 1)}?";
            Console.WriteLine(result);
        }

        /// <summary>
        /// Введите с консоли строку, которая будет содержать буквы и цифры. Удалите из исходной строки все цифры и выведите их на экран.(Использовать метод Char.IsDigit(), его не разбирали на уроке, посмотрите, пожалуйста, документацию этого метода самостоятельно)
        /// </summary>
        private static void Task_5()
        {
            Console.Write("Write some text with numbers and letters: ");
            string inputText = Console.ReadLine();
            string newText = String.Join(" ", inputText.Where(letter => Char.IsDigit(letter)).ToList());
            Console.WriteLine(newText);
        }

        /// <summary>
        /// Задайте 2 предложения из консоли. Для каждого слова первого предложения определите количество его вхождений во второе предложение.
        /// </summary>
        private static void Task_6()
        {
            Console.Write("Write first sentence: ");
            string[] firstText = Regex.Replace(Console.ReadLine(), "[.,?!]", "").Split(" ");
            Console.Write("Write second sentence: ");
            string[] secondText = Regex.Replace(Console.ReadLine(), "[.,?!]", "").Split(" ");
            List<KeyValuePair<string, int>>  words = new List<KeyValuePair<string, int>>();

            foreach (string wordFromFirstText in firstText)
            {
                try
                {
                    string wordFromText = secondText.Where(word => word.ToLower() == wordFromFirstText.ToLower()).First().ToLower();
                    int count = secondText.Where(word => word.ToLower() == wordFromFirstText.ToLower()).Count();
                    KeyValuePair<string, int> pair = new KeyValuePair<string, int>(wordFromText, count);
                    words.Add(pair);
                }
                catch { }
            }

            words.ForEach(pair => Console.WriteLine($"{pair.Key} - {pair.Value}"));
        }
    }
}