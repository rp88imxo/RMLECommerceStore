using Microsoft.EntityFrameworkCore;
using RMLECommerceStore.Database;
using RMLECommerceStore.Models;
using RMLECommerceStore.Repository;

namespace RMLECommerceStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region SERVICES_SETUP

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StoreDbContext>(options => 
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:RMLECommerceStore"]);
            });
            builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

            #endregion

            var app = builder.Build();

            SeedData.EnsurePopulated(app);

            app.UseStaticFiles();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}