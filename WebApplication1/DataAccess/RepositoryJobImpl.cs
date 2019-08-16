using System.Collections.Generic;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public abstract class RepositoryJobImpl : Repository<Job>
    {
        public RepositoryJobImpl(IndexedDBManager dbManager) : base(dbManager)
        {
        }
        public async Task<IList<Job>> AllDoneAsync(int done)
        {
            return await DbManager.GetAllRecordsByIndex<int, Job>(new StoreIndexQuery<int>()
            {
                Storename = Storename(),
                AllMatching = false,
                IndexName = "done",
                QueryValue = done
            });
        }
    }
}
