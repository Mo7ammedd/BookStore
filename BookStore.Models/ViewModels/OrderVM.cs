namespace BookStore.Models.ViewModels;

public class OrderVM
{
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetail> OrderDetail { get; set; }
    
}