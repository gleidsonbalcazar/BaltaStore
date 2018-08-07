using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1 () {
            var c = new Customer (
                "Gleidson",
                "Balcazar",
                "52308090278",
                "gleidsonsbalcazar@gmail.com",
                "84994200909",
                "Estr. CAtre 77");

            var order = new Order (c);

        }
    }
}
