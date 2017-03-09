using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Data;
using _01Adapter.Resource;

namespace _01Adapter.Tests
{
    [TestClass]
    public class MockDbDataAdapterTests
    {
        [TestMethod]
        public void MockDbDataAdapterRepositoryShouldThrowIfCtorArgumentNull()
        {
            //Arrange
            MockDbDataAdapter sut;

            //Act
            Action todo = () => sut = new MockDbDataAdapter(null);

            //Assert
            todo.ShouldThrow<ArgumentNullException>();

        }


        [TestMethod]
        public void MockDbDataAdapterRepositoryShouldThrowIfFillArgumentNull()
        {
            //Arrange
            var sut = new MockDbDataAdapter(MockDataTableFactory.GetCreateDataTable());

            //Act
            Action todo = () => sut.Fill(null);

            //Assert
            todo.ShouldThrow<ArgumentNullException>();

        }

        [TestMethod]
        public void MockDbDataAdapterShouldReturnOneTable()
        {
            //Arrange
            var sut = new MockDbDataAdapter(MockDataTableFactory.GetCreateDataTable());
            var dataSet = new DataSet();
            //Act
            sut.Fill(dataSet);

            //Assert
            dataSet.Tables.Should().HaveCount(1);
        }

        [TestMethod]
        public void MockDbDataAdapterShouldReturnData()
        {
            //Arrange
            var sut = new MockDbDataAdapter(MockDataTableFactory.GetCreateDataTable());
            var dataSet = new DataSet();
            //Act
            sut.Fill(dataSet);

            //Assert
            dataSet.Tables.Should().HaveCount(1, "Mivel egy táblával kell visszatérni");

            var table = dataSet.Tables[0];
            MockDataTableFactory.CheckDataTable(table);

        }

    }
}
