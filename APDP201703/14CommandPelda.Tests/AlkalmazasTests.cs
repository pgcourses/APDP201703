using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _13CommandPelda;

namespace _14CommandPelda.Tests
{
    ///  - új megrendelés felvitele
    ///  - meglévő törlése
    ///  - meglévő módosítása
    ///  - ha nem adunk meg semmit, akkor kiírja a használati útmutatót
    ///  - ha pedig rossz parancsot adunk meg, akkor jelzi, hogy ismeretlen a parancs
    
    [TestClass]
    public class AlkalmazasTests
    {
        [TestMethod]
        public void _CommandHaUjMegrendelestAdunkMegAkkorAFelvitelrolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextNew });

            Console.WriteLine(eredmeny);

            //Assert
            Assert.AreEqual(MagicValues.CommandResponseNew, eredmeny);
        }

        [TestMethod]
        public void _CommandHaMeglevotAkarunkTorolniAkkorATorlesrolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextDelete, "2" }); //adunk valami paramétert, egyelőre az érték nem számít

            Console.WriteLine(eredmeny);

            //Assert
            Assert.AreEqual(MagicValues.CommandResponseDelete, eredmeny);
        }

        //[TestMethod]
        //public void _CommandHaOlyatAkarunkTorolniAmiNincsAkkorAHibarolKellKapnunkErtesitest()
        //{
        //}

        [TestMethod]
        public void _CommandHaMeglevotAkarunkModositaniAkkorAModositasrolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextModify, "2" }); //adunk valami paramétert, egyelőre az érték nem számít

            Console.WriteLine(eredmeny);

            //Assert
            Assert.AreEqual(MagicValues.CommandResponseModify, eredmeny);
        }

        //[TestMethod]
        //public void _CommandHaOlyatAkarunkModositaniAmiNincsAkkorAHibarolKellKapnunkErtesitest()
        //{
        //}

        [TestMethod]
        public void _CommandHaIsmeretlenParancsotAdunkAHibarolKellKapnunkErtesitest()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { MagicValues.CommandTextInvalid });

            Console.WriteLine(eredmeny);

            //Assert
            Assert.AreEqual(MagicValues.CommandResponseInvalid, eredmeny);
        }

        [TestMethod]
        public void _CommandHaNemAdunkMegSemmitAkkorMegKellKapnunkAHasznalatiLeirast()
        {
            //Arrange
            var sut = new Alkalmazas();

            //Act
            var eredmeny = sut.Bevitel(new string[] { });

            Console.WriteLine(eredmeny);

            //Assert
            Assert.AreEqual(MagicValues.CommandResponseUsage, eredmeny);
        }
    }
}
