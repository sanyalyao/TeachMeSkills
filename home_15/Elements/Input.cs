using OpenQA.Selenium;

namespace home_15.Elements
{
    class Input : BaseElement
    {
        public Input(By locator) : base(locator) { }
        public Input(string tag, string attribute, string value) : base($"{tag}[{attribute}='{value}']") { }
    }
}