namespace home_1
{
    class Program
    {
        /// <summary>
        /// Написать программу для вывода «Hello <user>» на консоль. Пусть <user> вводиться с консоли, программа должна потребовать ввод<user>. Для чтения с консоли используйте Console.ReadLine().
        /// </summary>
        static void Main()
        {
            Console.Write("Please, enter a name: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello, {userName}");
        }
    }
}