using System.Text.RegularExpressions;

namespace home_10
{
    public class HomeworkLINQ
    {
        /// <summary>
        /// Метод возвращает первое слово из последовательности слов, содержащее только одну букву.
        /// </summary>
        public void FirstMethod()
        {
            string text = "ewef243 erg4356 wef34 r456 234 345345re";
            string[] splitedText = text.Split(' ');
            string word = splitedText.Where(word => CheckWord(word)).First();
            Console.WriteLine("Метод возвращает первое слово из последовательности слов, содержащее только одну букву.");
            Console.WriteLine($"Answer is {word}\n");
        }

        private bool CheckWord(string word)
        {
            int countLetters = word.Where(letter => char.IsLetter(letter)).Count();
            bool answer = countLetters == 1 ? true : false;
            return answer;
        }

        /// <summary>
        /// метод, возвращающий последнее слово, содержащее в себе подстроку «ее». Реализовать, используя только 1 метод LINQ.
        /// </summary>
        public void SecondMethod()
        {
            string text = "метод, возвращающий последнее слово, содержащее в себе подстроку «ее». Реализовать, используя только 1 метод LINQ";
            string[] splitedText = Regex.Replace(text, "[«».,]", "").ToLower().Split(' ');
            string answer = splitedText.Where(word => word.Contains("ее") && word != "ее").Last();
            Console.WriteLine("метод, возвращающий последнее слово, содержащее в себе подстроку «ее». Реализовать, используя только 1 метод LINQ.");
            Console.WriteLine($"Answer is {answer}\n");
        }

        /// <summary>
        /// Реализовать метод для возврата последнего слова, соответствующего условию: длина слова не меньше min и не больше max.Если нет слов, соответствующих условию, метод возвращает null.
        /// </summary>
        public void ThirdMethod()
        {
            string text = "Реализовать метод для возврата последнего слова, соответствующего условию: длина слова не меньше min и не больше max.Если нет слов, соответствующих условию, метод возвращает null.";
            string[] splitedText = Regex.Replace(text, "[.,]", "").ToLower().Split(' ');
            int minLength = 4;
            int maxLength = 7;
            string? answer = splitedText.Where(word => word.Length > minLength && word.Length < maxLength).LastOrDefault();
            Console.WriteLine("Реализовать метод для возврата последнего слова, соответствующего условию: длина слова не меньше min и не больше max.Если нет слов, соответствующих условию, метод возвращает null.");
            Console.WriteLine($"Answer is {answer}\n");
        }

        /// <summary>
        /// Напишите метод, который возвращает количество уникальных значений в массиве.
        /// </summary>
        public void FourthMethod()
        {
            string[] arrayValues = new string[] { "123", "qwerty", "123", "gerq", "reth"};
            int uniqueValues = arrayValues.GroupBy(group => group).Where(values => values.Count() == 1).Select(value => value.Key).Count();
            Console.WriteLine("Напишите метод, который возвращает количество уникальных значений в массиве.");
            Console.WriteLine($"Answer is {uniqueValues}\n");
        }

        /// <summary>
        /// Напишите метод, который принимает список и извлекает значения с 5  элемента(включительно)  те значение которые содержат 3
        /// </summary>
        public void FifthMethod()
        {
            List<int> listOfNumbers = new List<int>() { 234, 4325, 345, 435, 123, 213, 345, 13, 33, 45, 56 };
            List<int> newList = listOfNumbers.Where((numbers, located) => located >= 5 && numbers.ToString().Contains("3")).ToList();
            Console.WriteLine("Напишите метод, который принимает список и извлекает значения с 5  элемента(включительно)  те значение которые содержат 3");
            newList.ForEach(numbers => Console.WriteLine(numbers));
            Console.WriteLine();
        }

        /// <summary>
        /// Метод возвращает длину самого короткого слова
        /// </summary>
        public void SixthMethod()
        {
            string text = "Метод возвращает длину самого короткого слова";
            int shortestWord = text.Split(' ').Min(word => word.Length);
            Console.WriteLine("Метод возвращает длину самого короткого слова");
            Console.WriteLine($"Answer is {shortestWord}\n");
        }

        /// <summary>
        /// Напишите метод, который преобразует словарь в список и меняет местами каждый ключ и значение
        /// </summary>
        public void SeventhMethod()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                { "first key", "first value" },
                { "second key", "second value" },
                { "third key", "third value" },
            };
            List<KeyValuePair<string,string>> listFromDictionary = dictionary.Select(pairs => new { pairs.Key, pairs.Value } ).ToDictionary(pair => pair.Value, pair => pair.Key).ToList();
            Console.WriteLine("Напишите метод, который преобразует словарь в список и меняет местами каждый ключ и значение");
            listFromDictionary.ForEach(pair => Console.WriteLine($"{pair.Key} - {pair.Value}"));
        }
    }
}
