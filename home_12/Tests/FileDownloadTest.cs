using NUnit.Framework;
using OpenQA.Selenium;
using home_12.Helpers;
using System;
using System.IO;

namespace home_12.Tests
{
    class FileDownloadTest : TestBase
    {
        [Test]
        [Description("File Download (задание со звездочкой)" +
            "i. Изучить https://www.swtestacademy.com/download-file-in-selenium/ " +
            "ii. Скачать файл " +
            "iii. Проверить наличие файла на файловой системе")]
        public void DownloadFile()
        {
            string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string downloadPath = Path.Combine(userPath, "Downloads");
            DirectoryInfo downloadDirectory = new DirectoryInfo(downloadPath);

            driver.FindElement(By.LinkText("File Download")).Click();

            WaitHelper.WaitElementWithTitle(driver, By.TagName("h3"), "File Downloader");

            IWebElement element = driver.FindElements(By.CssSelector("a[href^='download']"))[1];
            string filenameFromElement = element.Text;

            element.Click();

            FileInfo[] files = downloadDirectory.GetFiles(filenameFromElement);
            string downloadFileName = Path.GetFileName(files[0].FullName);

            Assert.AreEqual(filenameFromElement, downloadFileName);
        }
    }
}
