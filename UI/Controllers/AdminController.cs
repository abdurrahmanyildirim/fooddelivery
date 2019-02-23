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

        public AdminController()
        {
            _companyApplyDal = InstanceFactory.GetInstance<ICompanyApplyDal>();
        }

        public ActionResult Index()
        {
            return View(_companyApplyDal.GetAll());
        }

        public ActionResult Add(int id)
        {
            if (_companyApplyDal.GetByID(id) != null)
            {
                CompanyApply companyApply = _companyApplyDal.GetByID(id);
                ICompanyDal companyDal = InstanceFactory.GetInstance<ICompanyDal>();
                Company company = new Company();
                company.CompanyName = companyApply.CompanyName;
                company.Email = companyApply.EmailAddress;
                company.Password = companyApply.Password;
                company.PhotoPath = companyApply.PhotoPath;
                company.IsActive = true;
                companyDal.Add(company);
                companyApply.IsActive = false;
                _companyApplyDal.Update(companyApply);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error404", "Error");
            }
        }

    }
}