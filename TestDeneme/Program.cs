using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestDeneme
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new EdgeDriver();
            string link = @"https://localhost:44351/Account/Login/";
            driver.Navigate().GoToUrl(link);

            //Login Test

            driver.FindElement(By.ClassName("username")).SendKeys("Okan");
            driver.FindElement(By.ClassName("password")).SendKeys("111");
            driver.FindElement(By.ClassName("form-btn")).Click();
        }
    }
}
