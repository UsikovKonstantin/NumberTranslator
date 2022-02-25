﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryNumberTranslator;

namespace UnitTestsNumberTranslator {
    [TestClass]
    public class UnitTestsNumberTranslator {
        [TestMethod]
        public void FromPto10Int_ReturnsIntNumberInBase10() {
            bool test1 = NumberTranslator.FromPto10Int("101", 2) == "5";
            bool test2 = NumberTranslator.FromPto10Int("10", 2) == "2";
            Assert.IsTrue(test1 && test2);
        }

        [TestMethod]
        public void From10toQInt_ReturnIntNumberInBaseQ() {
            bool test1 = NumberTranslator.From10toQInt("5", 2) == "101";
            bool test2 = NumberTranslator.From10toQInt("2", 2) == "10";
            Assert.IsTrue(test1 && test2);
        }

        [TestMethod]
        public void FromPto10Frac_ReturnFracNumberInBase10() {
            bool test1 = NumberTranslator.FromPto10Frac("1101", 2) == "0,8125";
            bool test2 = NumberTranslator.FromPto10Frac("53", 8) == "0,671875";
            Assert.IsTrue(test1 && test2);
        }

        [TestMethod]
        public void From10toQFrac_ReturnsFracNumberInBaseQ() {
            bool test1 = NumberTranslator.From10toQFrac("0,8125", 2, 10) == "1101";
            bool test2 = NumberTranslator.From10toQFrac("0,671875", 8, 10) == "53";
            Assert.IsTrue(test1 && test2);
        }

        [TestMethod]
        public void FromPtoQInt_ReturnsIntNumInBaseQ() {
            bool test1 = NumberTranslator.FromPtoQInt("101001", 2, 16) == "29";
            bool test2 = NumberTranslator.FromPtoQInt("1101", 2, 16) == "D";
            Assert.IsTrue(test1 && test2);
        }

        [TestMethod]
        public void FromPtoQFrac_ReturnsFracNumInBaseQ() {
            bool test1 = NumberTranslator.FromPtoQFrac("321312", 10, 8, 6) == "244406";
            bool test2 = NumberTranslator.FromPtoQFrac("123214", 8, 6, 6) == "055044";
            Assert.IsTrue(test1 && test2);
        }

        [TestMethod]
        public void FromCharToInt_ReturnsIntNum() {
            bool test1 =(NumberTranslator.FromCharToInt('F') == 15);
            bool test2 =(NumberTranslator.FromCharToInt('f') == 15);
            bool test3 =(NumberTranslator.FromCharToInt('Z') == 35);
            bool test4 =(NumberTranslator.FromCharToInt('4') == 4);
            Assert.IsTrue(test1 && test2 && test3 && test4);
        }

        [TestMethod]
        public void FromIntToChar_ReturnsStringNum() {
            bool test1 =(NumberTranslator.FromIntToChar(15) == 'F');
            bool test2 =(NumberTranslator.FromIntToChar(35) == 'Z');
            bool test3 =(NumberTranslator.FromIntToChar(4) == '4');
            bool test4 = (NumberTranslator.FromIntToChar(19) == 'J');
            Assert.IsTrue(test1 && test2 && test3);
        }
    }
}
