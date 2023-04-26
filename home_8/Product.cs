namespace home_8
{
    class Product
    {
        public string Name { get; set; }
        public int NumberOfCalories { get; set; }

        public Product(string name, int numberOfCalories)
        {
            Name = name;
            NumberOfCalories = numberOfCalories;
        }
    }
}
