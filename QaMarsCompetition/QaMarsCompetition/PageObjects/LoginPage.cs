﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaMarsCompetition.PageObjects
{
    public class LoginPage
    {
        public void CreateLogin(IWebDriver driver)
        {
            driver = new ChromeDriver();
            IWebElement element;
            // Launch Mars portal
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();

            // Identify signin button and click 
            element = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            element.Click();

            // Identify Username textbox and enter valid username
            element = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            element.SendKeys("harshi.s98@gmail.com");


            // Identify Password textbox and enter valid password
            element = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            element.SendKeys("harshitha4");


            // Click login button
            element = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            element.Click();

            // click on share skill button
            element = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
            element.Click();
        }
    }
}