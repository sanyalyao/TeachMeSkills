namespace home_11.Tests
{
    class TestsDivition : BaseTest
    {
        [Test, Description("Test for simple divition"), Category("Category of DivideTest")]
        [Retry(5)]
        public void DivideTest([Values(6)] int i, [Random(1, 5, 1)] int j)
        {
            Assert.AreEqual(new Calculator().Divide(i, j), 2);
        }
    }
}
