using OpenQA.Selenium;
using QaMarsCompetition.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaMarsCompetition.PageObjects
{
    public class EditSkill : CommonDriver
    {
        public IWebElement manageListing = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/section[1]/div/a[3]"));
        public IWebElement findEdit = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
        public IWebElement titlebox => driver.FindElement(By.Name("title"));
        public IWebElement descriptionbox => driver.FindElement(By.Name("description"));

        public IWebElement tagstab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement tagsedittab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span"));
        public IWebElement editservice => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
        public IWebElement editlocation => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));

        public IWebElement fri => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input"));

        public IWebElement editstarttime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[7]/div[2]/input"));
        public IWebElement editendtime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[7]/div[3]/input"));
        public IWebElement editskilltrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
        public IWebElement editskillexchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div[1]/div/div/div/div/input"));
        public IWebElement editskillechangeApi => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/span"));
        public IWebElement editcredit => driver.FindElement(By.Name("charge"));
        public IWebElement edithidden => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        public IWebElement editsave => driver.FindElement(By.XPath(" //*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        public void EditSkills()
        {
            // Identify manage listing button
            manageListing.Click();
            //identify edit button
            findEdit.Click();
            // edit title details
            titlebox.Clear();
            titlebox.SendKeys("Test Analyst");

            // edit description details
            descriptionbox.Clear();
            descriptionbox.SendKeys("Automation Testing Engineer");


            //edit tagstab details
            tagsedittab.Click();
            tagstab.SendKeys("API");
            tagstab.SendKeys(Keys.Enter);

            //edit service 

            editservice.Click();

            //edit available days
            fri.Click();
            //edit start time
            editstarttime.SendKeys("500");
            //edit end time
            editendtime.SendKeys("530");

            // edit skilltrade
            editskilltrade.Click();

            //edit skillexchange
            editskillechangeApi.Click();
            editskillexchange.SendKeys("NewMan");
            editskillexchange.SendKeys(Keys.Enter);
            //edit credit
            editcredit.Click();

            // edit active to hidden 
            edithidden.Click();
            //save edited details
            editsave.Click();

        }
    }
}
