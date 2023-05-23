namespace home_11.Tests
{
    class TestsAddition : BaseTest
    {
        [Test, Description("Test for simple addition"), Category("Category of AddingTest")]
        [TestCase(8,2)]
        public void AddingTest(int i, int j)
        {
            Assert.AreEqual(new Calculator().Adding(i, j), 10);
        }
    }
}
