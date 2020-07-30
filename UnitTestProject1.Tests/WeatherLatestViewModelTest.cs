using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1.ViewModels;

namespace UnitTestProject1.Tests
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var viewModel = new WeatherLatestViewModel();
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);
        }
    }
}
