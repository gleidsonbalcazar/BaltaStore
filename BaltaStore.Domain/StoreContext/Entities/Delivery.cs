using System;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable
    {
    
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //Se a data estimada de entrega for no passado não entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel(){
            //Se o status
            Status = EDeliveryStatus.Canceled;
        }
    }
}