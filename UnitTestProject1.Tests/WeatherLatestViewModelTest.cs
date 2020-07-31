using System;
using System.Data;
using Domain.Repositories;
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

            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);
        }
    }

    internal class WeatherMock : IWeatherRepository
    {
        public DataTable GetLatest(int areaId)
        {
            throw new NotImplementedException();
        }
    }
}
