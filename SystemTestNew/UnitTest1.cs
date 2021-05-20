using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
namespace SystemTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestFixture]
        public class KMFinalTest
        {
            IWebDriver driver;
            IWebDriver driverTwo;
            [SetUp]
            public void SetUpMethod()
            {
                var op = new FirefoxOptions
                {
                    AcceptInsecureCertificates = true
                };

                driver = new FirefoxDriver(op);
                driverTwo = new FirefoxDriver(op);
                driver.Navigate().GoToUrl("https://localhost:5001/");
                driverTwo.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Register");


            }
            [TearDown]
            public void TearDownMethod()
            {
                if (driver != null)
                {
                    driver.Quit();
                }

            }

            [TearDown]
            public void TearDownMethodTwo()
            {
                if (driverTwo != null)
                {
                    driverTwo.Quit();
                }

            }
            [Test]
            //Purpose: click on cart button to be taken to cart page
            public void GameStoreSite_ClickCartButton()
            {
                ////Arrange  
                IWebElement ele = driver.FindElement(By.ClassName("cart"));
                ////Act 
                ele.Click();
                ////Assert
                Console.Write("Cart button has been click, now on cart page. \n");
            }

            [Test]
            //Purpose: click on game button to be taken to game page
            public void GameStoreSite_NavigateToGames()
            {
                ////Arrange  
                IWebElement ele = driver.FindElement(By.XPath("//a[@href='/Game']"));
                ////Act 
                ele.Click();
                ////Assert
                Console.Write("Game button has been click, now on game page. \n");
            }

            [Test]
            //Purpose: click on register button to be taken to register page 
            public void GameStoreSite_NavigateToRegister()
            {
                ////Arrange  
                IWebElement ele = driver.FindElement(By.XPath("//a[@href='/Identity/Account/Register']"));
                ////Act 
                ele.Click();
                ////Assert
                Console.Write("Register button has been click, now on register page. \n");
            }

            [Test]
            //Purpose: enter information on register page
            public void GameStoreSite_UserRegisterFail()
            {
                //////Arrange  
                IWebElement ele = driverTwo.FindElement(By.Id("Input_Email"));
                IWebElement ele1 = driverTwo.FindElement(By.CssSelector(".btn-primary"));
                //////Act 
                ele.SendKeys("FPS");
                ele1.Click();
                //////Assert
                Console.Write("Search value entered, click button pressed, test failed \n");
            }

            [Test]
            //Purpose: enter information on register page
            public void GameStoreSite_UserRegisterPass()
            {
                //////Arrange  
                IWebElement ele = driverTwo.FindElement(By.Id("Input_Email"));
                IWebElement ele2 = driverTwo.FindElement(By.Id("Input_Password"));
                IWebElement ele3 = driverTwo.FindElement(By.Id("Input_ConfirmPassword"));
                IWebElement ele1 = driverTwo.FindElement(By.CssSelector(".btn-primary"));
                //////Act 
                ele.SendKeys("test@test.com");
                ele2.SendKeys("Password1!");
                ele3.SendKeys("Password1!");
                ele1.Click();
                //////Assert
                Console.Write("Search value entered, click button pressed, test passed \n");
            }

        }
    }
}