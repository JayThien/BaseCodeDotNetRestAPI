namespace ApplicationDomain.Entities
{
    public class OrderProduct: EntityBase<int>
    {
        public int OrderId { set; get; }
        public Order Order { set; get; }
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int Quantity { set; get; }
        public double TotalPriceOfProduct { set; get; }
        public string Additions { set; get; }
    }
}
