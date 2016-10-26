using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskWebApp.Models;
using System.Transactions;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework;
using PagedList;
using PagedList.Mvc;

namespace TaskWebApp.Repository
{
    public class TaxRepository : IRepository
    {
       public IPagedList<TaxViewModel> GetApprovedRecords(int  ? pageNumber, int  pageSize)
        {
              TaxTransactionContext ttx = new TaxTransactionContext();



              IPagedList<TaxViewModel> model = (from transaction in ttx.TaxTransactions
                            select new TaxViewModel
                               {
                                    
                                 Amount = transaction.Amount.ToString(),
                                 Account = transaction.Account,
                                 DocumentName = transaction.DocumentName,
                                 Description = transaction.Description,
                                 CurrencyCode = transaction.CurrencyCode,
                                 ID=transaction.ID
                              }).OrderBy(c=>c.ID).ToPagedList(pageNumber.Value, pageSize);
            
          







          return model;





        }

       public IPagedList<ErrorModel> GetRejectedRecords(int? pageNumber, int pageSize)
       {
           TaxTransactionContext ttx = new TaxTransactionContext();



           IPagedList<ErrorModel> model = (from transaction in ttx.ErrorTransactionss
                                             select new ErrorModel
                                             {

                                             DocumentName=transaction.DocumentName,
                                             Message=transaction.Message,
                                             ID=transaction.ID
                                             }).OrderBy(c => c.ID).ToPagedList(pageNumber.Value, pageSize);









           return model;

       }
        public void SaveToDB(List<TaxViewModel> taxViewModel, List<ErrorModel> errorsViewModel)
        {

            AutoMapper.Mapper.CreateMap<TaxViewModel,TaxTransaction>().ForMember(dest => dest.Amount, 
                                                                       opt => opt.MapFrom(src => decimal.Parse(src.Amount)));
            AutoMapper.Mapper.CreateMap<ErrorModel, ErrorTransaction>();
            var results = AutoMapper.Mapper.Map<List<TaxViewModel>, List<TaxTransaction>>(taxViewModel);
            var errors = AutoMapper.Mapper.Map<List<ErrorModel>, List<ErrorTransaction>>(errorsViewModel);
            using(TaxTransactionContext ttx=new TaxTransactionContext())
            {
                using (var scope =  ttx.Database.BeginTransaction())
                {
                   // ttx.TaxTransactions.AddRange(results);
                    ttx.BulkInsert(errors);
                    ttx.BulkInsert(results);
                    ttx.SaveChanges();
                    scope.Commit();
                   


                }

            }



        }
    }
}
