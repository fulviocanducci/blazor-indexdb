using TG.Blazor.IndexedDB;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class RepositoryJob : Repository<Job>
    {
        public RepositoryJob(IndexedDBManager dbManager) 
            : base(dbManager)
        {
        }

        public override string Storename()
        {
            return "job";
        }
    }
}