using E_commerce.Dal;
using E_commerce.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Services;

public class ProductRepository : IProductRepository
{
    private readonly MainContext MainContext;

    public ProductRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public Task<long> InsertProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> SelectProductByIdAsync(long productId)
    {
        var product = await MainContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
        return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
        MainContext.Products.Update(product);
        await MainContext.SaveChangesAsync();
    }
}
