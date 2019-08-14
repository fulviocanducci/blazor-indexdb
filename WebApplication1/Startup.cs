using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using TG.Blazor.IndexedDB;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddIndexedDB(options =>
            {
                options.DbName = "testdb";
                options.Version = 1;                
                options.Stores.Add(new StoreSchema
                {
                    Name = "job",
                    PrimaryKey = new IndexSpec{Name = "id", KeyPath = "id", Unique = true, Auto = true},
                    Indexes = new System.Collections.Generic.List<IndexSpec>
                    {
                        new IndexSpec{ Name = "description", KeyPath = "description", Unique = false, Auto = false},
                        new IndexSpec{ Name = "done", KeyPath = "done", Unique = false, Auto = false}
                    }
                });
            });
            services.AddSingleton<Repository<Job>, RepositoryJob>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
