using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebTesting
{
    public class SearchTests
    {
        [SetUp]
        public void Setup()
        {
            WebDriver.SetUp("https://yandex.ru/");
        }
        private static By SearchInput => By.Id("text");
        private static By SearchButton => By.XPath("body > div.body__wrapper > div.container.rows > div.row.rows__row.rows__row_main > div > div.container.container__search.container__line > aqwf > div > div > div > div.home-arrow__search > form > div.search2__button > button");
        private static By NotFound => By.CssSelector("/html/body/div[1]/div[2]/div[3]/div/div[3]/dqs/div/div/div[1]/div[2]/form/div[2]/button");

        [TestCase("`", "По вашему запросу ничего не нашлось")]
        public void Search_BadRequest_NotFound(string input ,string excpected)
        {
            WebDriver.GetWaitedElement(SearchInput).SendKeys(input);
            WebDriver.GetWaitedElement(SearchButton).Click();
            var actual = WebDriver.GetWaitedElement(NotFound).Text;

            Assert.AreEqual(excpected, actual);
        }
    }
}
