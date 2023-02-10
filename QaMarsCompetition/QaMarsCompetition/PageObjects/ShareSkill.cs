using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QaMarsCompetition.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoIt;
using static System.Collections.Specialized.BitVector32;
using System.Security.Cryptography.X509Certificates;

namespace QaMarsCompetition.PageObjects
{
    public class ShareSkill : CommonDriver
    {
        public bool skillAdded = false;

        public IWebElement shareskillbutton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
        public IWebElement titlebox => driver.FindElement(By.Name("title"));
       public IWebElement descriptionbox => driver.FindElement(By.Name("description"));

       public IWebElement tagstab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement service => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input"));
        public IWebElement location => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));

        public IWebElement thu => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input"));

        public IWebElement starttime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[2]/input"));
        public IWebElement endtime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input"));
        public IWebElement skilltrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
       public IWebElement skillexchange => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input"));
      public IWebElement exchangecredit => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/input"));
        public IWebElement active => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));

        public IWebElement save => driver.FindElement(By.XPath(" //*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));

        //AutoItScript
        

        public void ShareSkills(string title, string description, string credit)

        {

            // click on share skill button
            shareskillbutton.Click();
        

            // identify  title tool box
            titlebox.SendKeys(title);

            //identify description
            descriptionbox.SendKeys(description);
            
            //identify category
            SelectElement categoryBox = new SelectElement(driver.FindElement(By.Name("categoryId")));
            categoryBox.SelectByText("Programming & Tech");
           
            //identify subcategory
            SelectElement subcategoryBox = new SelectElement(driver.FindElement(By.Name("subcategoryId")));
            subcategoryBox.SelectByText("QA");

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

            // identify skill exchange  and select credit
            skillexchange.Click();
            exchangecredit.SendKeys(credit);
         

            ////click on worksample btton. 
               IWebElement Worksample = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
                Worksample.Click();
         
            AutoItX.WinActivate("[CLASS:#32770");
            
            AutoItX.ControlFocus("[CLASS:#32770]", "", "Edit1");
            Thread.Sleep(1000);
            
            AutoItX.Send(@"D:\My Testing resume\Sample_Upload_File.txt");
            Thread.Sleep(1000);
            
            AutoItX.Send("{ENTER}");
       
            //identify active and click active
            active.Click();

            // identify save button
             save.Click();
            skillAdded = true;
        }
    }
}
