using OpenQA.Selenium;
using QaMarsCompetition.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaMarsCompetition.PageObjects
{
    public class DeleteSkill : CommonDriver
    {
        public IWebElement manageListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/section[1]/div/a[3]"));
        public IWebElement findDel = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
        public void DeleteSkills()
        {
            // identify manage listing button
            manageListing.Click();

            // identify delete button
             findDel.Click();
        }
    }
}
