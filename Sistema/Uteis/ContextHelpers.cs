using Microsoft.EntityFrameworkCore;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Uteis
{
    public static class ContextHelpers
    {
        private static string instanceName = @"localhost\SQLEXPRESS";
        private static string databaseName = "sistema_facens";
        private static string databaseUserName = "sa";
        private static string databasePassword = "!usr000@";

        public static string connectionString
        {
            get
            {
                return $"Data Source={instanceName};" +
                        $"Initial Catalog={databaseName};" +
                        $"Trusted_Connection=True";
            }
        }

        public static DbContextOptions<sistema_facensContext> options
        {
            get
            {
                DbContextOptionsBuilder<sistema_facensContext> builder = new DbContextOptionsBuilder<sistema_facensContext>();
                builder.UseSqlServer(connectionString);

                return builder.Options;
            }
        }
    }
}