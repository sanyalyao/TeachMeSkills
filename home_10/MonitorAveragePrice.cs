namespace home_10
{
    class MonitorAveragePrice
    {
        public delegate void ShowPrice(List<House> houses, Customer customer);
        public event Action<List<House>> notify;
        public Action<List<House>> secondNotify;

        public void ShowAveragePrice(Customer customer, List<House> houses)
        {
            ShowPrice showPrice = SelectOption(customer.OperationType);
            showPrice(houses, customer);
            notify(houses);
            secondNotify?.Invoke(houses);
        }

        private ShowPrice SelectOption(OperationTypes.Operations operations)
        {
            switch (operations)
            {
                case OperationTypes.Operations.First:
                    {
                        return FirstOptionOfPrice;
                    }
                case OperationTypes.Operations.Second:
                    {
                        return SecondOptionOfPrice;
                    }
                default: return ThirdOptionOfPrice;
            }
                
        }

        private void FirstOptionOfPrice(List<House> houses, Customer customer)
        {
            Console.WriteLine($"Prices for customer {customer.Name}");
            houses.ForEach(house => Console.WriteLine($"House \"{house.Name}\" costs {house.Price}. Address is {house.Address}"));
            Console.WriteLine("____________________________\n");
        }

        private void SecondOptionOfPrice(List<House> houses, Customer customer)
        {
            Console.WriteLine($"Prices for customer {customer.Name}");
            houses.ForEach(house => Console.WriteLine($"House name: \"{house.Name}\"\n" +
                $"Price: {house.Price}\n" +
                $"Address: {house.Address}\n"));
            Console.WriteLine("____________________________\n");
        }

        private void ThirdOptionOfPrice(List<House> houses, Customer customer)
        {
            Console.WriteLine($"Prices for customer {customer.Name}");
            houses.ForEach(house => Console.WriteLine($"House \"{house.Name}\" is located at {house.Address}. It costs {house.Price}"));
            Console.WriteLine("____________________________\n");
        }
    }
}
