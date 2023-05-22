namespace home_11.Tests
{
    class BaseTest
    {
        protected int x;
        protected int y;

        [SetUp]
        public void Setup()
        {
            x = 6;
            y = 3;
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
