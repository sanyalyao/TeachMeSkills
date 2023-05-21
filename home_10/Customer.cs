
namespace home_10
{
    class Customer
    {
        public string Name;
        public bool IsSubscribed;
        public OperationTypes.Operations OperationType;
        private bool FirstSentNotification = false;
        private bool SecondSentNotification = false;

        public Customer(string name, bool isSubscribed, OperationTypes.Operations operationType)
        {
            Name = name;
            IsSubscribed = isSubscribed;
            OperationType = operationType;
        }

        public void FirstNotifySubscriber(List<House> houses)
        {
            foreach (House house in houses)
            {
                if (house.Price < 70000 && IsSubscribed == true && FirstSentNotification == false)
                {
                    Console.WriteLine("First notification");
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine($"Dear {Name}. The price of \"{house.Name}\" house is {house.Price}");
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
                    FirstSentNotification = true;
                }
            }
        }

        public void SecondNotifySubscriber(List<House> houses)
        {
            foreach (House house in houses)
            {
                if (house.Price < 70000 && IsSubscribed == true && SecondSentNotification == false)
                {
                    Console.WriteLine("Second notification");
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine($"Dear {Name}. The price of \"{house.Name}\" house is {house.Price}");
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
                    SecondSentNotification = true;
                }
            }
        }
    }
}
