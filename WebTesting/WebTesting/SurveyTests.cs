using NUnit.Framework;
using OpenQA.Selenium;

namespace WebTesting
{
    public class SurveyTests
    {
        [SetUp]
        public void Setup()
        {
            WebDriver.SetUp("https://pollservice.ru/p/5q3mc4w11s");
        }

        private static string GetAnswerListPath => 
            "body > div.ps-layout > div.ps-layout-center.clearfix > div > div.ps-content > div.poll-vote > div.pollservice-poll > div > div:nth-child(2) > div > div.pollservice-ru_question-list > div > div.pollservice-ru_answer-list";
        private static string GetAnswerTextInListPath(int answerNum) => $"div:nth-child({answerNum}) > div.pollservice-ru_answer-label > label";

        private static By GetAnswerRatioInListPath(int answerNum) => By.CssSelector($"#pollservice_poll_0_answer_11593{answerNum}");

        private static By GetButtonPath =>
            By.CssSelector("body > div.ps-layout > div.ps-layout-center.clearfix > div > div.ps-content > div.poll-vote > div.pollservice-poll > div > div:nth-child(2) > div > div.pollservice-ru_actions > div > span > div");

        private static By GetTableAnswersPath => By.CssSelector("body > div.ps-layout > div.ps-layout-center.clearfix > div > div.ps-content > div.poll-results > div.tabed.clearfix");

        [TestCase(0, "Только польза", "/results")]
        [TestCase(1, "Один вред", "/results")]
        [TestCase(2, "Когда польза, когда вред", "/results")]
        [TestCase(3, "Это полезно, только не надо много в нём сидеть.", "/results")]
        public void Survey_ChoisedAns_GoToResults(int answerNum, string excpectedAnswer, string excpectedAddedUrl)
        {
            var excpectedUrl = $"{WebDriver.Driver.Url}{excpectedAddedUrl}";

            var actualAnswer = WebDriver.GetWaitedElement(By.CssSelector($"{GetAnswerListPath} > {GetAnswerTextInListPath(answerNum + 1)}")).Text;

            WebDriver.GetWaitedElement(GetAnswerRatioInListPath(answerNum)).Click();
            WebDriver.GetWaitedElement(GetButtonPath).Click();

            WebDriver.GetWaitedElement(GetTableAnswersPath);
            var actualUrl = WebDriver.Driver.Url;

            Assert.AreEqual((excpectedAnswer, excpectedUrl), (actualAnswer, actualUrl));
        }

        [TestCase("Не указан вариант ответа")]
        public void Survey_NonChoisedAns_AlertWarning(string excpected)
        {
            WebDriver.GetWaitedElement(GetButtonPath).Click();
            var alert = WebDriver.Driver.SwitchTo().Alert();
            var actual = alert.Text;
            alert.Accept();

            Assert.AreEqual(excpected, actual);
        }
    }
}
