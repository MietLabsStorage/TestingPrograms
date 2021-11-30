using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace WebTesting
{
    class VideoTests
    {
        [SetUp]
        public void Setup()
        {
            WebDriver.SetUp("https://www.youtube.com/");
        }

        private static By VideoSelect(int row, int num) => By.XPath($"/html/body/ytd-app/div/ytd-page-manager/ytd-browse/ytd-two-column-browse-results-renderer/div[1]/ytd-rich-grid-renderer/div[6]/ytd-rich-grid-row[{row}]/div/ytd-rich-item-renderer[{num}]/div/ytd-rich-grid-media/div[1]/ytd-thumbnail/a");
        private static By VideoTimer => By.CssSelector("#movie_player > div.ytp-chrome-bottom > div.ytp-progress-bar-container > div.ytp-progress-bar");

        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        public void Video_OpenVideo_VideoPlaying(int row, int num)
        {
            WebDriver.GetWaitedElement(VideoSelect(row, num)).Click();

            var timer = WebDriver.GetWaitedElement(VideoTimer);

            var time1 = timer.GetAttribute("aria-valueText");

            Thread.Sleep(3000);

            var time2 = timer.GetAttribute("aria-valueText");

            Assert.AreNotEqual(time1, time2);
        }
    }
}