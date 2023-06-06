namespace home_13.Models
{
    class ProductModel
    {
        public string Name;
        public string Description;
        public double Price;

        public ProductModel(string name, string description, double price)
        {
            Name = name.ToLower();
            Description = description.ToLower();
            Price = price;
        }

        public ProductModel(string name)
        {
            Name = name.ToLower();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            ProductModel product = obj as ProductModel;
            return Name == product.Name
                && Description == product.Description
                && Price == product.Price;
        }

        public override int GetHashCode()
        {
            return $"{Name}{Description}{Price}".GetHashCode();
        }
    }
}
