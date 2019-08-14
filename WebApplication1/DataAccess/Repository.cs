using System.Collections.Generic;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;

namespace WebApplication1.DataAccess
{
    public abstract class Repository<T> : IRepository<T>
    {
        public abstract string Storename();
        protected IndexedDBManager DbManager { get; }
        public Repository(IndexedDBManager dbManager)
        {
            DbManager = dbManager;
        }        
        protected StoreRecord<T> GetStoreRecord(T model)
        {
            return new StoreRecord<T>()
            {
                Data = model,
                Storename = Storename()
            };
        }
        public T Add(T model)
        {
            DbManager.AddRecord(GetStoreRecord(model));
            return model;
        }

        public T Update(T model)
        {
            DbManager.UpdateRecord(GetStoreRecord(model));            
            return model;
        }

        public async Task<T> FindAsync<TInput>(TInput id)
        {
            return await DbManager.GetRecordById<TInput, T>(Storename(), id);
        }

        public async Task DeleteAsync<TInput>(TInput id)
        {            
            await DbManager.DeleteRecord(Storename(), id);
        }

        public async Task<List<T>> AllAsync()
        {
            return await DbManager.GetRecords<T>(Storename());
        }
    }
}
