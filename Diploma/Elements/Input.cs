﻿using OpenQA.Selenium;

namespace Diploma.Elements
{
    public class Input : BaseElement
    {
        public Input(By locator) : base(locator) { }
        public Input(string tag, string attribute, string value) : base($"{tag}[{attribute}='{value}']") { }
    }
}