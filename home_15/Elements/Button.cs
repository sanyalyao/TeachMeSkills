using OpenQA.Selenium;

namespace home_15.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator) { }
        public Button(string tag, string attribute, string value) : base($"{tag}[{attribute}='{value}']") { }
    }
}
