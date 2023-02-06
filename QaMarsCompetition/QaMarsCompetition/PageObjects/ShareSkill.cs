using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QaMarsCompetition.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace QaMarsCompetition.PageObjects
{
    public class ShareSkill : CommonDriver
    {
       public IWebElement titlebox => driver.FindElement(By.Name("title"));
       public IWebElement descriptionbox => driver.FindElement(By.Name("description"));

       public IWebElement tagstab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement service => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        public IWebElement location => driver.FindElement(By.XPath("//*[@id=\"service - listing - section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        public IWebElement thu => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input"));

        public IWebElement starttime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[2]/input"));
        public IWebElement endtime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input"));
        public IWebElement skilltrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        public IWebElement credit => driver.FindElement(By.Name("charge"));
        public IWebElement active => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        public IWebElement save => driver.FindElement(By.XPath(" //*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
       
        public void ShareSkills()
        {
            // identify  title tool box
           
            titlebox.SendKeys("Automation engineer");
            //identify description
           
            descriptionbox.SendKeys("Test Analyst");
            //identify category
            SelectElement categoryBox = new SelectElement(driver.FindElement(By.Name("categoryId")));
            categoryBox.SelectByValue("Programming&Tech");
            //identify subcategory
            SelectElement subcategoryBox = new SelectElement(driver.FindElement(By.Name("subcategoryId")));
            subcategoryBox.SelectByValue("QA");
            //identify tags
          
            tagstab.SendKeys("Selenium");
            tagstab.SendKeys(Keys.Enter);

            //identify service type
          
            service.Click();
            //identify location type

            location.Click();
            // identify available days
          
           
            thu.Click();
           
            starttime.SendKeys("300pm");
           
            endtime.SendKeys("400pm");



            //identify skill trade and select skillexchange
           
            skilltrade.Click();

            //identify credit
           
            credit.SendKeys("2");

            //identify active and click active
          
            active.Click();

            // identify save button

            save.Click();
            //IWebElement startdate = driver.FindElement(By.Name("startDate"));
            // IWebElement enddate = driver.FindElement(By.Name("endDate"));
            //startdate.SendKeys("05022023");

            // enddate.SendKeys("26022023");


        }
    }
}
