using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebTesting
{
    public static class WebDriver
    {
        public static IWebDriver Driver { get; }

        static WebDriver()
        {
            Driver = new ChromeDriver();
        }

        public static void SetUp(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public static IWebElement GetWaitedElement(By by, int timeSpan = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(timeSpan))
                .Until(w => w.FindElement(by));
        }
    }
}
