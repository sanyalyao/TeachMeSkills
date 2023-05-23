namespace home_10
{
    class Program
    {
        static void Main()
        {
            // 1. Cоздать класс мониторинга средней цен на жилье, цена будет генерироваться с помощью класса рандом и выдавать случайное значение в определенном диапазоне. Для того чтобы вывод цены был удобен пользователю в классе мониторинга создать поле делегат, обьект которого будет создаваться в классе мониторинга. Пользователь указывает метод для отображения цены в удобном ему формате путем передачи метода в конструктор класса мониторинга.
            List<House> houses = new List<House>()
            {
                new House("Red", new RandomPrice().GetRandomPrice(), "address 1"),
                new House("Blue", new RandomPrice().GetRandomPrice(), "address 2"),
                new House("Yellow", new RandomPrice().GetRandomPrice(), "address 3")
            };

            List<Customer> customers = new List<Customer>()
            {
                new Customer("Alex", true, OperationTypes.Operations.Second),
                new Customer("Igor", false, OperationTypes.Operations.First),
                new Customer("Rita", false, OperationTypes.Operations.Third),
            };

            MonitorAveragePrice monitor = new MonitorAveragePrice();

            // 2. Реализовать паттерн наблюдатель в случае если цена на жилье опустилась ниже определенного значения, и сообщить всем кто на это событие подписался. *реализовать как через событие так и через паттерн наблюдатель без событи
            customers.ForEach(customer => monitor.notify += customer.FirstNotifySubscriber);

            customers.ForEach(customer => monitor.ShowAveragePrice(customer, houses));

            customers.ForEach(customer => monitor.secondNotify += customer.SecondNotifySubscriber);
            monitor.secondNotify(houses);

            // третья части домашки
            Console.WriteLine();
            new HomeworkLINQ().FirstMethod();
            new HomeworkLINQ().SecondMethod();
            new HomeworkLINQ().ThirdMethod();
            new HomeworkLINQ().FourthMethod();
            new HomeworkLINQ().FifthMethod();
            new HomeworkLINQ().SixthMethod();
            new HomeworkLINQ().SeventhMethod();

            // четвёртая часть домашки
            User user1 = new User("first", "", "last");
            User user2 = new User("first", "middle", "last");
            Console.WriteLine("\nНапишите метод, который возвращает \" < FirstName > < MiddleName > < LastName > \", если отчество присутствует Или \" < FirstName > < LastName > \", если отчество отсутствует.");
            Console.WriteLine(new HomeworkWithNames().FirstMethod(user1));
            Console.WriteLine(new HomeworkWithNames().FirstMethod(user2));

            List<User> users = new List<User>()
            {
                new User("FirstName", "MiddleName", "Bfdgerg"),
                new User("FirstName", "MiddleName", "Cergerg"),
                new User("FirstName", "MiddleName", "Drgehg"),
                new User("FirstName", "MiddleName", "Aergerg"),
            };
            Console.WriteLine("\nНапишите метод, который возвращает предоставленный список пользователей, упорядоченный по LastName в порядке убывания.");
            new HomeworkWithNames().SecondMethod(users).ForEach(user => Console.WriteLine($"{user.FirstName} {user.MiddleName} {user.LastName}"));
        }
    }
}