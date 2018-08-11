using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1 () {
            var name = new Name("Gleidson", "Balcazar");
            var document = new Document("52308090278");
            var email = new Email("gleidsonsbalcazar@gmail.com");
            var c = new Customer(name, document, email, "5235235235");

            var mouse = new Product("Mouse", "Rato", "image.png", 59.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.png", 159.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "image.png", 9.90M, 10);
            var cadeira = new Product("Cadeira", "Cadeira", "image.png", 359.90M, 10);
           

            var order = new Order (c);
            // order.AddItem(new OrderItem(mouse, 5));
            // order.AddItem(new OrderItem(teclado, 5));
            // order.AddItem(new OrderItem(cadeira, 5));
            // order.AddItem(new OrderItem(impressora, 5));

           /* order.Place(); //Realiza pedido
            order.Pay(); //Simular Pagamento
            order.Ship(); //Simular envio
            order.Cancel(); //Simular Cancelamento*/

        }
    }
}
