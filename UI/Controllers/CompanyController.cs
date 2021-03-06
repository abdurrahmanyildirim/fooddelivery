﻿using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete;
using FoodDelivery.DAL.Concrete.Ninject;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.DTOs;

namespace UI.Controllers
{
    public class CompanyController : Controller
    {
        IMenuDal _menuDal;
        ICompanyDal _companyDal;
        IReviewDal _reviewDal;
        IBranchDal _branchDal;
        IRegionDal _regionDal;
        ICompanyApplyDal _companyApplyDal;

        public CompanyController()
        {
            _regionDal = InstanceFactory.GetInstance<IRegionDal>();
            _companyDal = InstanceFactory.GetInstance<ICompanyDal>();
            _menuDal = InstanceFactory.GetInstance<IMenuDal>();
            _reviewDal = InstanceFactory.GetInstance<IReviewDal>();
            _branchDal = InstanceFactory.GetInstance<IBranchDal>();
            _companyApplyDal = InstanceFactory.GetInstance<ICompanyApplyDal>();
        }

        public ActionResult Admin()
        {
            if (Request.Cookies["company"] != null)
            {
                List<MenuPointDto> menuPointDtos = new List<MenuPointDto>();
                menuPointDtos = MenuleriHesapla(menuPointDtos);
                return View("CompanyLogin", menuPointDtos);
            }
            return View();
        }

        public ActionResult AddCompanyApply(FormCollection frm)
        {
            CompanyApply companyApply = new CompanyApply()
            {
                CompanyName = frm["name"],
                Description = frm["detail"],
                EmailAddress = frm["emailApply"],
                Password = frm["sifre"],
                IsActive = true
            };
            _companyApplyDal.Add(companyApply);

            return RedirectToAction("Admin");
        }

        public ActionResult Logout()
        {
            HttpCookie myCookie = new HttpCookie("company");
            myCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(myCookie);
            return RedirectToAction("Admin", "Company");
        }

        public PartialViewResult _companyPartial()
        {
            string cookie = Request.Cookies["company"].Value;
            return PartialView(_companyDal.GetCompanyByCookie(cookie));
        }

        [HttpPost]
        public ActionResult CompanyLogin(FormCollection frm)
        {
            string email = frm["email"];
            string password = frm["password"];
            Company company = _companyDal.GetCompanyByLogin(email, password);

            if (company != null)
            {
                string cerezKodu = Guid.NewGuid().ToString("n").Substring(0, 12);
                HttpCookie cookie = new HttpCookie("company", cerezKodu);
                cookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Response.Cookies.Add(cookie);
                company.Cookie = cerezKodu;
                _companyDal.Update(company);

                List<MenuPointDto> menuPointDtos = new List<MenuPointDto>();
                menuPointDtos = MenuleriHesapla(menuPointDtos);

                return View(menuPointDtos);
            }
            else
            {
                TempData["Mesaj"] = "Hatalı Şifre veya Email girişi yapıldı.";
                return RedirectToAction("Admin", "Company");
            }
        }

        private List<MenuPointDto> MenuleriHesapla(List<MenuPointDto> menu)
        {
            ICollection<Menu> menus = _menuDal.GetMenusByCompanyCookie(Request.Cookies["company"].Value).ToList();

            foreach (Menu item in menus)
            {
                int puan = 0;
                ICollection<Review> reviews = _reviewDal.GetReviewsByMenu(item.ID).ToList();
                foreach (Review review in reviews)
                {
                    puan += review.Point;
                }

                if (reviews.Count > 0)
                    puan = puan / reviews.Count;

                MenuPointDto menuPointDto = new MenuPointDto()
                {
                    Menu = item,
                    Point = puan
                };
                menu.Add(menuPointDto);
            }
            return menu;
        }

        public ActionResult Branches()
        {
            string cookie = Request.Cookies["company"].Value;
            List<Branch> branches = new List<Branch>();
            branches.AddRange(_branchDal.GetEntitiesByFilter(x => x.Company.Cookie == cookie).ToList());

            List<Region> regions = new List<Region>();
            regions.AddRange(_regionDal.GetAll());
            BranchRegionsDto branchRegionsDto = new BranchRegionsDto()
            {
                Branches = branches,
                Regions = regions
            };
            return View(branchRegionsDto);
        }

        [HttpPost]
        public ActionResult ChangeIsActive(int id)
        {
            Branch branch = _branchDal.GetByID(id);
            if (branch.IsActive)
            {
                branch.IsActive = false;
            }
            else
            {
                branch.IsActive = true;
            }
            _branchDal.Update(branch);

            return RedirectToAction("Branches", "Company");
        }

        [HttpPost]
        public ActionResult AddBranch(FormCollection frm)
        {
            string cookie = Request.Cookies["company"].Value;
            Branch branch = new Branch();
            branch.Address = frm["adres"];
            branch.Phone = frm["phone"];
            branch.RegionID = Convert.ToInt32(frm["region"]);
            branch.CompanyID = _companyDal.GetCompanyByCookie(cookie).ID;
            branch.IsActive = true;
            _branchDal.Add(branch);

            return RedirectToAction("Branches", "Company");
        }

        public ActionResult Menus()
        {
            string cookie = Request.Cookies["company"].Value;
            return View(_menuDal.GetMenusByCompanyCookie(cookie));
        }

        [HttpPost]
        public ActionResult AddMenu(FormCollection form)
        {
            string cookie = Request.Cookies["company"].Value;
            Menu menu = new Menu()
            {
                CompanyID = _companyDal.GetCompanyByCookie(cookie).ID,
                MenuName = form["name"],
                MenuDetail = form["detail"],
                Price = Convert.ToDecimal(form["price"])
            };

            _menuDal.Add(menu);
            return RedirectToAction("Menus");
        }
    }
}