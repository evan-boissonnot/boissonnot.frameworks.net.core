using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Boissonnot.Framework.Core.Data.DataContexts
{
    public class BaseDesignerDatabaseFactory<TContext> 
                 where TContext: DbContext, new()
    {
        #region Internal methods
        /// <summary>
        /// Crée un option builder à passer au context entities
        /// </summary>
        /// <returns></returns>
        protected DbContextOptionsBuilder<TContext> CreateOptionBuilder(string configDatabaseName = "DefaultContextDatabase", 
                                            string settingFileName = "appSettings.json")
        {
            string basePath = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                          .SetBasePath(basePath)
                          .AddJsonFile(settingFileName);

            var config = builder.Build();
            string connectionString = config.GetConnectionString(configDatabaseName);

            var optionBuilder = new DbContextOptionsBuilder<TContext>()
                                    .UseSqlServer(connectionString);

            return optionBuilder;
        }
        #endregion
    }
}
