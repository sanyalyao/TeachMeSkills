namespace home_10
{
    class RandomPrice
    {
        private Random random = new Random();

        public int GetRandomPrice()
        {
            return random.Next(30000, 100000);
        }
    }
}
