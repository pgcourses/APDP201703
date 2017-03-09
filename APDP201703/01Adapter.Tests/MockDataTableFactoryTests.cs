using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01Adapter.Resource;
using System.Data;
using FluentAssertions;

namespace _01Adapter.Tests
{
    [TestClass]
    public class MockDataTableFactoryTests
    {
        [TestMethod]
        public void MockDataTableFactorySholdReturnData()
        {
            //Arrange
            //Act
            var sut = MockDataTableFactory.GetCreateDataTable();

            //Assert
            MockDataTableFactory.CheckDataTable(sut);
        }
    }
}
