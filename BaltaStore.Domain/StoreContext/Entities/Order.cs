using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities {
    public class Order :Notifiable {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order (Customer customer) {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem> ();
            _deliveries = new List<Delivery> ();

        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray ();
        public IReadOnlyCollection<Delivery> Deliverys => _deliveries.ToArray ();
        public EOrderStatus Status { get; private set; }

        public void AddItem(Product product, decimal quantity){
            if (quantity > product.QuantityOnHand)
            AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");

            var item = new OrderItem(product,quantity);
            _items.Add (item);

        }

        public void AddDelivery (Delivery delivery) {
            _deliveries.Add (delivery);
        }

        //Criar o pedido
        public void Place () {
            //GEra o numero do pedido
            Number = Guid.NewGuid ().ToString ().Replace ("-", "").Substring (0, 8).ToUpper ();
            if(_items.Count == 0){
                AddNotification("Order", "Este pedido não possui items.");
            }
        }

        //Pagar o Pedido
        public void Pay () {

            Status = EOrderStatus.Paid;

        }

        //Enviar um Pedido
        public void Ship () {
            //A cada 5 produtos e uma entrega
            var deliveries = new List<Delivery> ();
            deliveries.Add (new Delivery (DateTime.Now.AddDays (5)));

            var count = 1;
            foreach (var item in _items) {
                if (count == 5) {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Envia todas as entregas
            deliveries.ToList().ForEach(x => x.Ship());
            deliveries.ToList().ForEach(x => _deliveries.Add(x));
        }

        //Cancelar um Pedido
        public void Cancel(){
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}