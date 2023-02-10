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
        public bool skilledited = false;
        //public IWebElement editshareskillbutton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
        public IWebElement manageListing => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        public IWebElement findEdit => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]/i"));
        public IWebElement edittitlebox => driver.FindElement(By.Name("title"));
        public IWebElement editdescriptionbox => driver.FindElement(By.Name("description"));

        public IWebElement edittagstab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement tagsedittab => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/span"));
        public IWebElement editservice => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
        public IWebElement editlocation => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input"));

        public IWebElement thu1 => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[1]/div/input"));

        public IWebElement editstarttime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[2]/input"));
        public IWebElement editendtime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[6]/div[3]/input"));
        public IWebElement editskilltrade => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
       
        public IWebElement editskillechangeApi => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
      
        public IWebElement edithidden => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        public IWebElement editsave => driver.FindElement(By.XPath(" //*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        public void EditSkills(string edittitle, string editdescription, string skillexchange)
        {
            //share skillbutton
            //editshareskillbutton.Click();
            
            // Identify manage listing button
            manageListing.Click();
            
            //identify edit button
            findEdit.Click();
            
            // edit title details
            edittitlebox.Clear();
            edittitlebox.SendKeys(edittitle);

            
            // edit description details
            editdescriptionbox.Clear();
            editdescriptionbox.SendKeys(editdescription);


            //edit tagstab details
            tagsedittab.Click();
            edittagstab.SendKeys("API");
            edittagstab.SendKeys(Keys.Enter);

            //edit service 

            editservice.Click();

            //edit available days
            thu1.Click();
            //edit start time
            editstarttime.SendKeys("500");
            //edit end time
            editendtime.SendKeys("530");

            // edit skilltrade
            editskilltrade.Click();

            //edit skillexchange
            editskillechangeApi.Click();
            editskillechangeApi.SendKeys(skillexchange);
            editskillechangeApi.SendKeys(Keys.Enter);
          

            // edit active to hidden 
            edithidden.Click();
            //save edited details
            editsave.Click();
             skilledited = true;
    }
    }
}
