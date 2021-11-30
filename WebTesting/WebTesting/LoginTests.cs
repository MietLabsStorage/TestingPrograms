using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebTesting
{
    public class LoginTests
    {
        [SetUp]
        public void Setup()
        {
            WebDriver.SetUp("http://automationpractice.com/index.php");
        }

        private static By SignIn => By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a");
        private static By EmailCreate => By.Id("email_create");
        private static By SubmitCreate => By.Id("SubmitCreate");
        private static By FirstName => By.Id("customer_firstname");
        private static By LastName => By.Id("customer_lastname");
        private static By Password => By.Id("passwd");
        private static By Address => By.Id("address1");
        private static By City => By.Id("city");
        private static By State => By.Id("id_state");
        private static By Postcode => By.Id("postcode");
        private static By Country => By.Id("id_country");
        private static By Phone => By.Id("phone_mobile");
        private static By Alias => By.Id("alias");
        private static By MyAccountLoaded => By.Id("center_column");
        private static By ErrorMes => By.XPath("//*[@id='center_column']/div/ol/li");
        private static By SignOut => By.XPath("//*[@id='header']/div[2]/div/div/nav/div[2]/a");
        private static By SubmitAccount => By.Id("submitAccount");

        private static void TryLogin(string mail)
        {
            WebDriver.GetWaitedElement(SignIn).Click();
            WebDriver.GetWaitedElement(EmailCreate).SendKeys(mail);
            WebDriver.GetWaitedElement(SubmitCreate).Click();
        }

        private static void FillFields()
        {
            WebDriver.GetWaitedElement(FirstName).SendKeys("Fn");
            WebDriver.GetWaitedElement(LastName).SendKeys("Ln");
            WebDriver.GetWaitedElement(Password).SendKeys("passww");
            WebDriver.GetWaitedElement(Address).SendKeys("adr1");
            WebDriver.GetWaitedElement(City).SendKeys("City");
            //WebDriver.GetWaitedElement(new SelectElement(WebDriver.GetWaitedElement(State)).Options[10]).Click();
            var state = new SelectElement(WebDriver.GetWaitedElement(State));
            Thread.Sleep(1000);
            WebDriver.GetWaitedElement(state.Options[1]).Click();
            WebDriver.GetWaitedElement(Postcode).SendKeys("42742");
            //WebDriver.GetWaitedElement(new SelectElement(WebDriver.GetWaitedElement(Country)).Options[10]).Click();
            var country = new SelectElement(WebDriver.GetWaitedElement(Country));
            Thread.Sleep(1000);
            WebDriver.GetWaitedElement(country.Options[1]).Click();
            WebDriver.GetWaitedElement(Phone).SendKeys("88001");
            WebDriver.GetWaitedElement(Alias).SendKeys("adr2");
        }

        [TestCase("mail", "Invalid email address.")]
        [TestCase("mail@ogo", "Invalid email address.")]
        [TestCase("mail@ogo.aga", "An account using this email address has already been registered. Please enter a valid password or request a new one.")]
        public void Login_badEmail_ErrorMes(string mail, string excpected)
        {
            TryLogin(mail);
            var actual = WebDriver.GetWaitedElement(By.XPath("//*[@id='create_account_error']/ol/li")).Text;

            Assert.AreEqual(excpected, actual);
        }

        [TestCase("?controller=my-account")]
        public void Login_goodEmailAllField_GoToAccount(string excpectedAddedUrl)
        {
            var excpected = $"{WebDriver.Driver.Url}{excpectedAddedUrl}";

            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(SubmitAccount).Click();
            WebDriver.GetWaitedElement(MyAccountLoaded);
            var actual = WebDriver.Driver.Url;
            WebDriver.GetWaitedElement(SignOut).Click();
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("firstname is required.")]
        public void Login_goodEmailNonFistName_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(FirstName).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("lastname is required.")]
        public void Login_goodEmailNonLastName_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(LastName).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("passwd is required.")]
        public void Login_goodEmailNonPassword_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(Password).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("address1 is required.")]
        public void Login_goodEmailNonAddress_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(Address).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("city is required.")]
        public void Login_goodEmailNonCity_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(City).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("This country requires you to choose a State.")]
        public void Login_goodEmailNonState_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            var state = new SelectElement(WebDriver.GetWaitedElement(State));
            Thread.Sleep(1000);
            WebDriver.GetWaitedElement(state.Options[0]).Click();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("The Zip/Postal code you've entered is invalid. It must follow this format: 00000")]
        public void Login_goodEmailNonPostcode_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(Postcode).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("id_country is required.")]
        public void Login_goodEmailNonCountry_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            var country = new SelectElement(WebDriver.GetWaitedElement(Country));
            Thread.Sleep(1000);
            WebDriver.GetWaitedElement(country.Options[0]).Click();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("You must register at least one phone number.")]
        public void Login_goodEmailNonPhone_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(Phone).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }

        [TestCase("alias is required.")]
        public void Login_goodEmailNonAlias_ErrorMes(string excpected)
        {
            TryLogin($"{DateTime.Now.Ticks}@ogo.aga");
            FillFields();
            WebDriver.GetWaitedElement(Alias).Clear();

            WebDriver.GetWaitedElement(SubmitAccount).Click();

            var actual = WebDriver.GetWaitedElement(ErrorMes).Text;
            Assert.AreEqual(excpected, actual);
        }
    }
}
