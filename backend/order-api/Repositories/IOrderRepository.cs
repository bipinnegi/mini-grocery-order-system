using order_api.Models;

namespace order_api.Repositories;

public interface IOrderRepository
{
    Task AddAsync(Order order);
}
