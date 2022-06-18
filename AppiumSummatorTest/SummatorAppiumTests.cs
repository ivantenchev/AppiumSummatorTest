using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTest.Tests
{
    namespace AppiumSumatorTest
    {
        public class SummatorAppiumTests
        {
            private WindowsDriver<WindowsElement> driver;
            private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
            private AppiumOptions options;

            [OneTimeSetUp]
            public void OpenApp()
            {
                this.options = new AppiumOptions();
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
                options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Summator.exe");

                this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
            }

            [OneTimeTearDown]
            public void ShutDownApp()
            {
                this.driver.Quit();
            }

            [Test]
            public void Test_Sum_Two_PositiveNumber()
            {
                //Find first click it and fill value 5
                var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
                //var num1 = driver.FindElement("textBoxFirstNum");
                num1.Clear();
                num1.SendKeys("5");

                var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
                num2.Clear();
                num2.SendKeys("5");

                var calculateButton = driver.FindElementByAccessibilityId("buttonCalc");
                calculateButton.Click();

                var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

                var expectedValue = "10";

                Assert.That(result, Is.EqualTo(expectedValue));

            }
            [Test]
            public void Test_InvalidNum()
            {
                //Find first click it and fill value 5
                var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
                //var num1 = driver.FindElement("textBoxFirstNum");
                num1.Click();
                num1.SendKeys("Invalid1");

                var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
                num2.Click();
                num2.SendKeys("Invalid2");

                var calculateButton = driver.FindElementByAccessibilityId("buttonCalc");
                calculateButton.Click();

                var result = driver.FindElementByAccessibilityId("textBoxSum").Text;

                var expectedValue = "error";

                Assert.That(result, Is.EqualTo(expectedValue));

            }
        }
    }
}