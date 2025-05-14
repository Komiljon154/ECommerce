using E_commerce.Dal.Entities;

namespace E_commerce.Repository.Services;

public interface IOrederProductRepository
{
    Task InsertOrderProducts(List<OrderProduct> orderProducts);
}   