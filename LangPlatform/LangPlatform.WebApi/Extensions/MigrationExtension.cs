using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LangPlatform.Extensions
{
    public static class MigrationExtension
    {
    

        public static void ApplyMigrations(this IApplicationBuilder app){
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using DataContext dbc = scope.ServiceProvider.GetService<DataContext>();
            dbc?.Database.Migrate();
        }
    }
}