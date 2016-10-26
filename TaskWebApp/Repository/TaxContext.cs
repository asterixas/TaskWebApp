using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TaskWebApp.Repository
{
    public class TaxTransactionContext:DbContext
    {
        public TaxTransactionContext():base("TaxTransactionContext")
        {


        }
        public DbSet<TaxTransaction> TaxTransactions { get; set; }
        public DbSet<ErrorTransaction> ErrorTransactionss { get; set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
            base.OnModelCreating(modelBuilder);
        }
    }
}