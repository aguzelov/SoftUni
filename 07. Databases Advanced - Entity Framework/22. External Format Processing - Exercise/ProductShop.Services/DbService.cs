using ProductShop.Data;
using ProductShop.Services.Contracts;

namespace ProductShop.Services
{
    public class DbService : IDbService
    {
        private ProductShopContext context;

        public DbService(ProductShopContext context)
        {
            this.context = context;
        }

        public void InitDatabase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}