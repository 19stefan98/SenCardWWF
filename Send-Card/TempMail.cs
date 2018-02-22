using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Send_Card
{
    class TempMail
    {
        public IWebDriver driver { set; get; }
        public string nmail { set; get; }
        public string pruf { set; get; }
        TimeSpan timeout = new TimeSpan(00, 00, 45);

        public TempMail(IWebDriver driver, string nmail)
        {
            this.driver = driver;
            this.nmail = nmail;
        }

        public void Action()
        {
            driver.Navigate().GoToUrl("https://temp-mail.org/ru/option/change");
            var mail = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("mail")));
            mail.SendKeys(nmail);
            var submit = driver.FindElement(By.Id("postbut"));
            submit.Click();

            driver.Navigate().GoToUrl("https://temp-mail.org/");
            var cont = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"mails\"]/tbody/tr/td[1]")));
            pruf = driver.FindElement(By.XPath("//*[@id=\"mails\"]/tbody/tr/td[1]")).Text;
        }
    }
}