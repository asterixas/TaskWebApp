using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq;

namespace TaskWebApp.Repository
{
    public class DataInitialization : DropCreateDatabaseIfModelChanges<TaxTransactionContext>
    {
        protected override void Seed(TaxTransactionContext context)
        {
            var taxes= new List<TaxTransaction>
            {
                new TaxTransaction()
                {
                     Account="1003", CurrencyCode="EUR", Description="tax 1003", Amount= (decimal)1212.00, DocumentName="File 1003"

                },

                new TaxTransaction()
                {
                    Account="1004", CurrencyCode="GBP", Description="tax 1004", Amount= (decimal)1214.03, DocumentName="File 1003"

                },


                 new TaxTransaction()
                {
                    Account="1005", CurrencyCode="EUR", Description="tax 1005", Amount= (decimal)1216.22, DocumentName="File 1003"

                },


                  new TaxTransaction()
                {
                     Account="1006", CurrencyCode="EUR", Description="tax 1003", Amount= (decimal)1212.00, DocumentName="File 1003"

                },

                new TaxTransaction()
                {
                    Account="1007", CurrencyCode="GBP", Description="tax 1004", Amount= (decimal)1214.03, DocumentName="File 1003"

                },


                 new TaxTransaction()
                {
                    Account="1008", CurrencyCode="EUR", Description="tax 1008", Amount= (decimal)1236.22, DocumentName="File 1003"

                }

            };
            taxes.ForEach(t=> context.TaxTransactions.Add(t));
            context.SaveChanges();
        }

    }
}