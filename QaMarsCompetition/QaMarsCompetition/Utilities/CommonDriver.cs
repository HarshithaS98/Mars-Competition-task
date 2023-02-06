using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaMarsCompetition.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;

        public static void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            

        }

        public static void Waits()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

        }
    }
}
