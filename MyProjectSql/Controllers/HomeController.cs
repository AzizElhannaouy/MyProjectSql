using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProjectSql.Models;
using MyProjectSql.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyProjectSql.ViewModels;

namespace MyProjectSql.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork <Employee> _Employee;
      
        public HomeController(
        IUnitOfWork<Employee> Employee)
        {
            _Employee = Employee;
            
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Employee = _Employee.Entity.GetAll().First(),
              
            };

            return View(homeViewModel);
        }

        public IActionResult About()
        {
            return View();
        }

    }
}