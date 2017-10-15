using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RecipeBookInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookInterfaces.Configuration
{
    public class DbConfig : IDbContextFactory<RecipeBookContext>
    {
        public RecipeBookContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<RecipeBookContext>();
            builder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=config;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RecipeBookContext(builder.Options);
        }
        
    }
}
