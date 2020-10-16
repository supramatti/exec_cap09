
namespace exec_cap09.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public Product product { get; set; }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            this.product = product;
        }

        public double SubTotal()
        {
            return product.Price * Quantity;
        }
    }
}
