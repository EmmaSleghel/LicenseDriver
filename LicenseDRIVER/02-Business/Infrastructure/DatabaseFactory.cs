using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using System.Text;

namespace Business.Infrastructure
{
    public class DatabaseFactory:IDatabaseFactory
    {
        private DbContext dataContext;
        private DbContextOptions<DatabaseContext> options;
        private static string ConnectionStringName;

        private static string GetConnectionString()
        {
            return ConnectionStringName;
        }

        public DbContext Get()
        {
            return dataContext ?? (dataContext = new DatabaseContext(options));
        }

        public void Dispose()
        {
            dataContext?.Dispose();
        }
    }
}

