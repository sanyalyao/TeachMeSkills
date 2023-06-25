namespace home_19.BusinessObject.Models
{
    public class TestCase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TestCase testCase &&
                   Title == testCase.Title &&
                   Description == testCase.Description;
        }
    }
}
