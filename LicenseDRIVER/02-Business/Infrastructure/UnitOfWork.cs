using Data.Persistence;


namespace Business.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DatabaseContext databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Commit()
        {
            databaseContext.SaveChanges();
        }
    }
}
