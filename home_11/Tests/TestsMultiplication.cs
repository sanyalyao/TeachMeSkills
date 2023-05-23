namespace home_11.Tests
{
    class TestsMultiplication : BaseTest
    {
        [Test, Description("Test for simple multiplication"), Category("Category of MultiplyTest")]
        public void MultiplyTest([Values(2)] int i, [Values(2)] int j)
        {
            Assert.AreEqual(new Calculator().Multiply(i, j), 4);
        }
    }
}
