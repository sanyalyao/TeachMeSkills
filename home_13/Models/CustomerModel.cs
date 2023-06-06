namespace home_13.Models
{
    class CustomerModel
    {
        public string FirstName;
        public string LastName;
        public string ZipCode;

        public CustomerModel(string firstname, string lastname, string zipCode)
        {
            FirstName = firstname;
            LastName = lastname;
            ZipCode = zipCode;
        }
    }
}
