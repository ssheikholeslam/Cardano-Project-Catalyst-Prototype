using Cardano_Catalyst.Interfaces;
using Cardano_Catalyst.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardano_Catalyst.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _context;

        public EmployeeController(IEmployee context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.GetAllEmployees());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Employee employee)
        {
            _context.Create(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var empDetails = _context.GetEmployeeDetails(Id);
            return View(empDetails);
        }

        [HttpPost]
        public IActionResult EditPost(string Id, Employee employee)
        {
            _context.Update(Id, employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string Id)
        {
            var empDetails = _context.GetEmployeeDetails(Id);
            return View(empDetails);
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var empDetails = _context.GetEmployeeDetails(Id);
            return View(empDetails);
        }

        [HttpPost]
        public IActionResult DeletePost(string Id)
        {
            _context.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
