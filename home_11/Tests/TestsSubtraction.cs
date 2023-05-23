namespace home_11.Tests
{
    class TestsSubtraction : BaseTest
    {
        [Test, Description("Test for simple subtraction"), Category("Category of SubstcractTest")]
        public void SubstcractTest([Range(1, 3, 1)] int j)
        {
            Assert.AreEqual(new Calculator().Subtract(x, j), 3);
        }
    }
}
