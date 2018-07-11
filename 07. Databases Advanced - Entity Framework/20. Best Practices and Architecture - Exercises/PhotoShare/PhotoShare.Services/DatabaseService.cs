using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Services.Contracts;

namespace PhotoShare.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly PhotoShareContext context;

        public DatabaseService(PhotoShareContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            context.Database.Migrate();
        }
    }
}