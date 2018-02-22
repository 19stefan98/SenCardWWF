using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Send_Card
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        //[TearDown] // вызывается после каждого теста
        //public void TearDown()
        //{
        //    driver.Quit();
        //}

        [Test]
        public void FreeCard()
        {
            string actual = "post@wwf.ru";

            FreeCard fo = new FreeCard(driver);
            fo.Action();

            TempMail mail = new TempMail(driver, fo.nmail);
            mail.Action();
            Assert.AreEqual(mail.pruf, actual);
        }

        [Test]
        public void BlagoCard()
        {
            BlagoCard fo = new BlagoCard(driver);
            fo.Action();
        }
    }
}