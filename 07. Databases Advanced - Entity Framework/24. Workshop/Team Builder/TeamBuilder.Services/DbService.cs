using TeamBuilder.Data;
using TeamBuilder.Services.Contracts;

namespace TeamBuilder.Services
{
    public class DbService : IDbService
    {
        private readonly TeamBuilderContext context;

        public DbService(TeamBuilderContext context)
        {
            this.context = context;
        }

        public void Initialize()
        {
            this.context.Database.EnsureDeleted();
            this.context.Database.EnsureCreated();
        }
    }
}