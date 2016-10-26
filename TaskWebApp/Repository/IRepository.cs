using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWebApp.Models;

namespace TaskWebApp.Repository
{
   public interface IRepository
    {
       void SaveToDB(List<TaxViewModel> taxViewModelList,List<ErrorModel> errorsModelList);
       IPagedList<TaxViewModel> GetApprovedRecords(int ? pageNumber, int pageSize);
       IPagedList<ErrorModel> GetRejectedRecords(int? pageNumber, int pageSize);
    }
}
