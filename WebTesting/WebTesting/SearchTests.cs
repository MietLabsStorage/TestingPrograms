using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebTesting
{
    public class SearchTests
    {
        [SetUp]
        public void Setup()
        {
            WebDriver.SetUp("https://jut.su/");
            (WebDriver.Driver.Manage().Window).Size = new System.Drawing.Size(1200, 1000);
        }
        private static By SearchInput => By.XPath("//*[@id='search_b']/form/input[2]");
        private static By SearchButton => By.CssSelector("#search_b > form > input[type=submit]:nth-child(3)");

        [TestCase("Шаман", "shamanking/")]
        [TestCase("Шаман король", "shamanking/")]
        [TestCase("Шаман кинг", "shamanking/")]
        [TestCase("Король шаманов", "shamanking/")]
        [TestCase("шаман", "shamanking/")]
        [TestCase("шаман король", "shamanking/")]
        [TestCase("шаман кинг", "shamanking/")]
        [TestCase("король шаманов", "shamanking/")]
        [TestCase("shaman king", "shamanking/")]
        [TestCase("shaman", "shamanking/")]
        [TestCase("Shaman king", "shamanking/")]
        [TestCase("Shaman", "shamanking/")]
        [TestCase("Король", "shamanking/")]
        [TestCase("King", "shamanking/")]
        public void Search_AnyNames_FoundPage(string input, string excpectedAddedUrl)
        {
            var excpected = $"{WebDriver.Driver.Url}{excpectedAddedUrl}";
            WebDriver.GetWaitedElement(SearchInput).SendKeys(input);
            WebDriver.GetWaitedElement(SearchButton).Click();
            var actual = WebDriver.Driver.Url;

            Assert.AreEqual(excpected, actual);
        }

        [TestCase("Шаманий король", "search")]
        [TestCase("Король-шаман", "search")]
        public void Search_AnyBadNames_NotFoundPage(string input, string excpectedAddedUrl)
        {
            var excpected = $"{WebDriver.Driver.Url}{excpectedAddedUrl}";
            WebDriver.GetWaitedElement(SearchInput).SendKeys(input);
            WebDriver.GetWaitedElement(SearchButton).Click();
            var actual = WebDriver.Driver.Url.Substring(0, 21);

            Assert.AreEqual(excpected, actual);
        }
    }
}
