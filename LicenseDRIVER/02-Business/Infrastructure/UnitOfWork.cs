using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        public void Commit()
        {
            databaseFactory.Get().SaveChanges();
        }
    }
}
