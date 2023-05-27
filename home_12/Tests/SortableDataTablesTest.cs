using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace home_12.Tests
{
    class SortableDataTablesTest : TestBase
    {
        [Test]
        [Description("Sortable Data Tables - Проверить содержимое нескольких (3-5) ячеек таблицы.Использовать xpath типа //table//tr[1]//td[1] - получение первой ячейки из первого ряда первой таблицы и так далее")]
        public void CheckDataTables()
        {
            List<List<string>> attributes = new List<List<string>>()
            {
                new List<string> { "Smith", "John", "jsmith@gmail.com", "$50.00", "http://www.jsmith.com" },
                new List<string> { "Bach", "Frank", "fbach@yahoo.com", "$51.00", "http://www.frank.com" },
                new List<string> { "Doe", "Jason", "jdoe@hotmail.com", "$100.00", "http://www.jdoe.com" },
                new List<string> { "Conway", "Tim", "tconway@earthlink.net", "$50.00", "http://www.timconway.com" },
            };

            driver.FindElement(By.LinkText("Sortable Data Tables")).Click();

            WaitElementWithTitle(By.TagName("h3"), "Data Tables");

            for (int j = 0; j <= 3; j++)
            {
                for (int i = 0; i <= 4; i++)
                {
                    string attributeFromTable = driver.FindElement(By.XPath($"//table//tbody//tr[{j + 1}]//td[{i + 1}]")).Text;
                    Assert.AreEqual(attributeFromTable, attributes[j][i]);
                }
            }
        }
    }
}
