using exec_cap09.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace exec_cap09.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
        public Client client { get; set; }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            this.client = client;
        }

        public void AddItem(OrderItem item)
        {
            OrderItem.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItem.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem order in OrderItem)
            {
                sum += order.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment);
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + client.Name + " " + client.BirthDate.ToString("dd/MM/yyyy") + " - " + client.Email);
            sb.AppendLine("Order items:");
            foreach (OrderItem obj in OrderItem)
            {
                sb.Append(obj.product.Name);
                sb.Append(", $" + obj.product.Price);
                sb.Append(", Quantity: " + obj.Quantity);
                sb.Append(", Subtotal: " + obj.SubTotal().ToString("F2"));
                sb.AppendLine("");
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2"));
            return sb.ToString();
        }
    }
}
