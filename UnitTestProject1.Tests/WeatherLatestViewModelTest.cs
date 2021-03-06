﻿using System;
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
        public void データベース接続に関する値の確認()
        {
            var viewModel = new WeatherLatestViewModel(new WeatherMock());
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
            Assert.AreEqual("2", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);
        }
    }

    internal class WeatherMock : IWeatherRepository
    {
        public DataTable GetLatest(int areaId)
        {
            var dt = new DataTable();
            dt.Columns.Add("AreaId", typeof(int));
            dt.Columns.Add("DataDate", typeof(DateTime));
            dt.Columns.Add("Condition", typeof(int));
            dt.Columns.Add("Temperature", typeof(float));

            var newRow = dt.NewRow();
            newRow["AreaId"] = 1;
            newRow["DataDate"] = Convert.ToDateTime("2018/01/01 12:34:56");
            newRow["Condition"] = 2;
            newRow["Temperature"] = 12.3f;

            dt.Rows.Add(newRow);
            return dt;
        }
    }
}
