using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete;
using FoodDelivery.DAL.Concrete.Ninject;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        ICompanyApplyDal _companyApplyDal;
        // GET: Admin
        public ActionResult Index()
        {
            _companyApplyDal = InstanceFactory.GetInstance<ICompanyApplyDal>();
            return View(_companyApplyDal.GetActiveApplies().ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

    }
}