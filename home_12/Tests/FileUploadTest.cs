using NUnit.Framework;
using OpenQA.Selenium;
using home_12.Helpers;
using System;

namespace home_12.Tests
{
    class FileUploadTest : TestBase
    {
        [Test]
        [Description("File Upload " +
            "i. Загрузить файл " +
            "ii. Проверить, что имя файла на странице совпадает с именем загруженного файла")]
        public void UploadFile()
        {
            By square = By.Id("drag-drop-upload");
            By fileName = By.Id("uploaded-files");
            string fileInput = "Red Fox Samurai Japanese Painting.jpg";
            var path = Environment.CurrentDirectory;

            driver.FindElement(By.LinkText("File Upload")).Click();

            WaitHelper.WaitElement(driver, square);

            driver.FindElement(By.Id("file-upload")).SendKeys($"{path}\\TestData\\{fileInput}");
            driver.FindElement(By.Id("file-submit")).Click();

            WaitHelper.WaitElement(driver, fileName);

            string name = driver.FindElement(fileName).Text;

            Assert.AreEqual(fileInput, name);
        }
    }
}
