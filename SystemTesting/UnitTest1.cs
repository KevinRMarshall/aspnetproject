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

            [SetUp]
            public void SetUpMethod()
            {
                driver = new FirefoxDriver();

                driver.Navigate().GoToUrl("https://www.calculator.net/triangle-calculator.html");

            }

            [TearDown]
            public void TearDownMethod()
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }

            [Test]
            //Purpose: to find the clear inputs button and click it, to clear any values
            public void TestCalculatorSite_ClearInputs()
            {
                //Arrange  
                IWebElement ele = driver.FindElement(By.ClassName("clearbtn"));
                //Act 
                ele.Click();
                //Assert
                Console.Write("Clear button is clicked \n");
            }

            [Test]
            //Purpose: to find the dropdown to be able to select a new calculation 
            public void TestCalculatorSite_UnitsDropdownSelected()
            {
                //Arrange
                IWebElement ele = driver.FindElement(By.Name("angleunits"));
                //Act 
                ele.Click();
                //Assert
                Console.Write("Units dropdown selected \n");
            }

            [Test]
            //Purpose: to find a textbox and enter a value to be calculated 
            public void TestCalculatorSite_EnterValues()
            {
                //Arrange  
                IWebElement ele = driver.FindElement(By.Name("vc"));
                //Act 
                ele.SendKeys("60");
                //Assert
                Console.Write("Values have been entered \n");
            }

            [Test]
            //Purpose: to find the search bar and enter values, then search
            public void TestCalculatorSite_SearchbarTextTest()
            {
                //Arrange  
                IWebElement ele = driver.FindElement(By.Id("calcSearchTerm"));
                IWebElement ele1 = driver.FindElement(By.Id("bluebtn"));
                //Act 
                ele.SendKeys("Square");
                ele1.Click();
                //Assert
                Console.Write("Search value entered, click button pressed \n");
            }

            [Test]
            //Purpose: to find the calculate button and click it to submit values
            public void TestCalculatorSite_CalculateButtonClicked()
            {
                // Arrange
                IWebElement ele = driver.FindElement(By.TagName("input"));
                //Act 
                ele.Click();
                //Assert
                Console.Write("Calculate button has been clicked \n");
            }
        }
    }
}
