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
        private static string instanceName = @"belchior.database.windows.net,1433";
        private static string databaseName = "sistema_facens";
        private static string databaseUserName = "belchior";
        private static string databasePassword = "pk9Su6V3r7KP!db";

        public static string connectionString
        {
            //get
            //{
            //    return $"Data Source={instanceName};" +
            //            $"Initial Catalog={databaseName};" +
            //            $"Trusted_Connection=True";
            //}
            get
            {
                return "Server=tcp:belchior.database.windows.net,1433;Initial Catalog=sistema_facens;Persist Security Info=False;User ID=belchior;Password=pk9Su6V3r7KP!db;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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