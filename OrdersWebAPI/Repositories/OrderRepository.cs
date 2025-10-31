using OrdersWebAPI.Models;

namespace OrdersWebAPI.Repositories
{
    public class OrderRepository
    {
        private static readonly List<Order> _orders = new();

        public Order Create(Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
            return order;
        }

        public IEnumerable<Order> GetByUser(int userId) =>
            _orders.Where(o => o.UserId == userId);

        public bool Delete(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return false;
            _orders.Remove(order);
            return true;
        }
    }
}
