using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            int row = 2;

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            string url = GlobalDefinitions.ExcelLib.ReadData(row, "Url");

            // Launch Mars website
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(url); Thread.Sleep(1000);
            SignIntab.Click();

            string username = GlobalDefinitions.ExcelLib.ReadData(row, "Username");
            Email.SendKeys(username);
            string password = GlobalDefinitions.ExcelLib.ReadData(row, "Password");
            Password.SendKeys(password);
            LoginBtn.Click();   
        }
    }
}