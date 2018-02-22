using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Send_Card
{
    class BlagoCard
    {
        public IWebDriver driver { get; set; }
        public string nmail { get; set; }
        public string Text { get; set; }
        TimeSpan timeout = new TimeSpan(00, 00, 15);
        Random rand = new Random();

        public BlagoCard(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Action()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://new2.wwf.ru/help/send-card/you-need-no-reason");
            driver.Navigate().Refresh();

            for (int v = 0; v < 4; v++)
            {
                nmail += Convert.ToChar(rand.Next(97, 122));
            }

            var click = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("gcl-card-item")));
            click.Click();

            var email = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("email_to")));
            email.SendKeys(nmail + "@send22u.info");

            var greeting = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("greeting")));
            greeting.SendKeys("Тест");

            var text = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"is-donation-form-parent\"]/div[1]/form/div[4]/label")));
            text.SendKeys("Тестовый текст");

            var sign = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("sign")));
            sign.SendKeys("подпись");

            var email1 = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("email_from")));
            email1.SendKeys(nmail + "@send22u.info");

            var date = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("date")));
            date.SendKeys("21.02.2018");
            date.Submit();
        }
    }
}
