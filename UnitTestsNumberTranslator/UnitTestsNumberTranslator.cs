using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryNumberTranslator;

namespace UnitTestsNumberTranslator {
    [TestClass]
    public class UnitTestsNumberTranslator {
        [TestMethod]
        public void FromPto10Int_ReturnsNumberInBase10() {
            bool test1 = NumberTranslator.FromPto10Int("101", 2) == "5";
            bool test2 = NumberTranslator.FromPto10Int("10", 2) == "2";
            Assert.IsTrue(test1 && test2);
        }
    }
}
