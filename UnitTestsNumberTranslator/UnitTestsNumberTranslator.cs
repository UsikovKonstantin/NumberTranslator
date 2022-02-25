using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryNumberTranslator;

namespace UnitTestsNumberTranslator {
    [TestClass]
    public class UnitTestsNumberTranslator {
        [TestMethod]
        public void FromPto10Int_ReturnsIntNumberInBase10() {
            Assert.IsTrue(NumberTranslator.FromPto10Int("101", 2) == "5");
            Assert.IsTrue(NumberTranslator.FromPto10Int("10", 2) == "2");
        }

        [TestMethod]
        public void From10toQInt_ReturnIntNumberInBaseQ() {
            Assert.IsTrue(NumberTranslator.From10toQInt("5", 2) == "101");
            Assert.IsTrue(NumberTranslator.From10toQInt("2", 2) == "10");
        }

        [TestMethod]
        public void FromPto10Frac_ReturnFracNumberInBase10() {
            Assert.IsTrue(NumberTranslator.FromPto10Frac("1101", 2) == "0,8125");
            Assert.IsTrue(NumberTranslator.FromPto10Frac("53", 8) == "0,671875");
        }

        [TestMethod]
        public void From10toQFrac_ReturnsFracNumberInBaseQ() {
            Assert.IsTrue(NumberTranslator.From10toQFrac("0,8125", 2, 10) == "1101");
            Assert.IsTrue(NumberTranslator.From10toQFrac("0,671875", 8, 10) == "53");
        }

        [TestMethod]
        public void FromPtoQInt_ReturnsIntNumInBaseQ() {
            Assert.IsTrue(NumberTranslator.FromPtoQInt("101001", 2, 16) == "29");
            Assert.IsTrue(NumberTranslator.FromPtoQInt("1101", 2, 16) == "D");
        }

        [TestMethod]
        public void FromPtoQFrac_ReturnsFracNumInBaseQ() {
            Assert.IsTrue(NumberTranslator.FromPtoQFrac("321312", 10, 8, 6) == "244406");
            Assert.IsTrue(NumberTranslator.FromPtoQFrac("123214", 8, 6, 6) == "055044");
        }

        [TestMethod]
        public void FromCharToInt_ReturnsIntNum() {
            Assert.IsTrue(NumberTranslator.FromCharToInt('F') == 15);
            Assert.IsTrue(NumberTranslator.FromCharToInt('f') == 15);
            Assert.IsTrue(NumberTranslator.FromCharToInt('Z') == 35);
            Assert.IsTrue(NumberTranslator.FromCharToInt('4') == 4);
        }

        [TestMethod]
        public void FromIntToChar_ReturnsStringNum() {
            Assert.IsTrue(NumberTranslator.FromIntToChar(15) == 'F');
            Assert.IsTrue(NumberTranslator.FromIntToChar(35) == 'Z');
            Assert.IsTrue(NumberTranslator.FromIntToChar(4) == '4');
            Assert.IsTrue(NumberTranslator.FromIntToChar(19) == 'J');
        }
    }
}
