using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskWebApp.ModelBinderHelper;
using TaskWebApp.Models;
using PagedList;
using PagedList.Mvc;
using TaskWebApp.Repository;
namespace TaskWebApp.Controllers
{
    public class HomeController : Controller
    {

        IRepository repo;
        public HomeController(IRepository repository)
        {
            repo = repository;
        }
        
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult PageIndex(int ? page, int ? appr, int ? reject)
        {

         string[] errors =  (string[])Session["Error"];
         int pageSize = 2;
         int pageNumber = (page ?? 1);
         
         ViewBag.Approved = appr;
         ViewBag.Rejected = reject;
         return View("Index", errors.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(List<TaxViewModel> taxViewModelList, int? page)
        {
            string[] errors=new string[]{};
            List<ErrorModel> errorModelList=new List<ErrorModel>();
            Session["Error"] = null;
            int pageSize = 2;
            int pageNumber = (page ?? 1); 
            if (!ModelState.IsValid)
            {
               string fileName=string.Empty;
             
                if(taxViewModelList.Count()>0)
                {
                    fileName = taxViewModelList[0].DocumentName;

                }
                errors= ModelState.Values.SelectMany(ms => ms.Errors, (modelState, error) => error.ErrorMessage).ToArray();
                errorModelList = (from error in errors
                                 select new ErrorModel
                                 {
                                     Message=error,
                                     DocumentName=fileName

                                 }).ToList();
              
            }
            try
            {
                repo.SaveToDB(taxViewModelList.Where(t => t.State == State.Approved).ToList(), errorModelList);
            }

            catch(Exception ex)
            {

                throw new Exception(ex.Message);

            }
           int rejectedCount = taxViewModelList.Where(t => t.State == State.Rejected).Count();
           int approvedCount = taxViewModelList.Where(t => t.State == State.Approved).Count();
           Session["Error"] = errors;
           ViewBag.Rejected = rejectedCount;
           ViewBag.Approved= approvedCount;
        
            return View("Index",errors.ToPagedList(pageNumber, pageSize)); 
        }
        public ActionResult About(int ? page)
        {
           ViewBag.Message = "Approved transactions";
           int pageSize = 4;
           int pageNumber = (page ?? 1);
           return View("About", repo.GetApprovedRecords(pageNumber, pageSize));

        }

        public ActionResult Contact(int ? page)
        {
            ViewBag.Message = "Rejected transactions";
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View("Contact", repo.GetRejectedRecords(pageNumber, pageSize));
        }
    }
}