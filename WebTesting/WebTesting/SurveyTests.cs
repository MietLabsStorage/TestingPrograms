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

        private static string GetAnswerRatioInListPath(int answerNum) => $"#pollservice_poll_0_answer_11593{answerNum}";

        private static string GetButtonPath => 
            "body > div.ps-layout > div.ps-layout-center.clearfix > div > div.ps-content > div.poll-vote > div.pollservice-poll > div > div:nth-child(2) > div > div.pollservice-ru_actions > div > span > div";

        private static string GetTableAnswersPath => "body > div.ps-layout > div.ps-layout-center.clearfix > div > div.ps-content > div.poll-results > div.tabed.clearfix";

        [TestCase(0, "Только польза", "/results")]
        [TestCase(1, "Один вред", "/results")]
        [TestCase(2, "Когда польза, когда вред", "/results")]
        [TestCase(3, "Это полезно, только не надо много в нём сидеть.", "/results")]
        public void Survey_ChoisedAns_GoToResults(int answerNum, string excpectedAnswer, string excpectedAddedUrl)
        {
            var excpectedUrl = $"{WebDriver.Driver.Url}{excpectedAddedUrl}";

            var actualAnswer = WebDriver.GetWaitedElement(By.CssSelector($"{GetAnswerListPath} > {GetAnswerTextInListPath(answerNum + 1)}")).Text;

            WebDriver.GetWaitedElement(By.CssSelector(GetAnswerRatioInListPath(answerNum))).Click();
            WebDriver.GetWaitedElement(By.CssSelector(GetButtonPath)).Click();

            WebDriver.GetWaitedElement(By.CssSelector(GetTableAnswersPath));
            var actualUrl = WebDriver.Driver.Url;

            Assert.AreEqual((excpectedAnswer, excpectedUrl), (actualAnswer, actualUrl));
        }

        [TestCase("Не указан вариант ответа")]
        public void Survey_NonChoisedAns_AlertWarning(string excpected)
        {
            WebDriver.GetWaitedElement(By.CssSelector(GetButtonPath)).Click();
            var actual = WebDriver.Driver.SwitchTo().Alert().Text;

            Assert.AreEqual(excpected, actual);
        }
    }
}
