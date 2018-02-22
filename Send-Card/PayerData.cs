using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Send_Card
{
    class PayerData
    {
        public IWebDriver driver { get; set; }
        public string text { get; set; }
        TimeSpan timeout = new TimeSpan(00, 00, 15);

        public PayerData(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Action()

        {
            var name = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
            name.SendKeys("Тест");
            var lname = driver.FindElement(By.Name("surname"));
            lname.SendKeys("Тест");

            var femail = driver.FindElement(By.Name("email"));
            femail.SendKeys("Test@mail.ru");
            var phone = driver.FindElement(By.Name("phone"));
            phone.SendKeys("9298985645");
            var payment_adress = driver.FindElement(By.Name("payment_adress"));
            payment_adress.SendKeys("г Ульяновск");
            payment_adress.Submit();
            text = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("sum-font"))).Text;
        }
    }
}
