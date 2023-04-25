namespace home_8
{
    class ListOfProducts
    {
        public List<Product> GetListOfProducts()
        {
            Random random = new Random();

            List<Product> products = new List<Product>()
            {
                new Product( "Banana", 105),
                new Product( "Apple", 81),
                new Product( "Applesauce", 232),
                new Product( "Apple juice", 111),
                new Product( "Cantaloupe", 57),
                new Product( "Grapes", 114),
                new Product( "Orange", 65),
                new Product( "Pear", 98),
                new Product( "Pineapple", 77),
                new Product( "Prunes", 201),
                new Product( "Raisins", 302),
                new Product( "Raspberries", 61),
                new Product( "Potato", 220),
                new Product( "Bagel", 165),
                new Product( "Cornbread", 178),
                new Product( "Noodles", 159),
                new Product( "Pizza", 290),
                new Product( "Brown rice", 232),
                new Product( "White rice", 223),
                new Product( "Waffles", 130),
                new Product( "Sweet Potato", 118),
                new Product( "Carrot", 31),
                new Product( "Corn", 89),
                new Product( "Black eye peas", 134),
                new Product( "Garbanzo beans", 269),
                new Product( "Navy beans", 259),
                new Product( "Pinto beans", 235),
                new Product( "Refried beans", 142),
                new Product( "White beans", 249)
            };

            List<Product> newListOfProducts = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                newListOfProducts.Add(products[random.Next(products.Count())]);
            }

            return newListOfProducts;
        }
    }
}
