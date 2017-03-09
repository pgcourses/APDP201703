using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace _01Adapter.Tests
{
    [TestClass]
    public class AdapterExampleTests
    {
        [TestMethod]
        public void ShouldAdapterExampleThrowExceptionIfAllArgumentNull()
        {
            //AAA
            //Arrange
            AdapterExample sut;

            //sut: System Under Test
            //ez helyett:
            //var sut = new AdapterExample(null, null);

            //Act
            //rögzítem a műveletet
            Action todo = () => sut = new AdapterExample(null, null);

            //Assert
            todo.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ShouldAdapterExampleThrowExceptionIfFirstArgumentNull()
        {
            //AAA
            //Arrange
            AdapterExample sut;

            //sut: System Under Test
            //ez helyett:
            //var sut = new AdapterExample(null, null);

            //Act
            //rögzítem a műveletet
            Action todo = () => sut = new AdapterExample(null, new MessageTestService());

            //Assert
            todo.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void ShouldAdapterExampleThrowExceptionIfSecondArgumentNull()
        {
            //AAA
            //Arrange
            AdapterExample sut;

            //sut: System Under Test
            //ez helyett:
            //var sut = new AdapterExample(null, null);

            //Act
            //rögzítem a műveletet
            Action todo = () => sut = new AdapterExample(new AddressTestRepository(), null);

            //Assert
            todo.ShouldThrow<ArgumentNullException>();
        }
    }
}
