﻿using AppiumSummatorTest.Windows;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSummatorTest.Tests
{
    internal class SummatorTestsAppium
    {
        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [OneTimeSetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Windows" };

            //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Summator.exe");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }

        [OneTimeTearDown]
        public void ShutDownApp()
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers_POM()
        {
            var window = new SummatorWindow(driver);
            string value1 = "5";
            string value2 = "15";

            string result = window.Calculate(value1, value2);

            Assert.That(result, Is.EqualTo("20"));
        }
    }
}
