using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Services;

namespace UserManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService Services;
        public HomeController(UserService _Services)//The Service class add in home controller Constructors it's called  Constructors Injection
        {
            this.Services = _Services;
        }


        /*---------------------UserService class all Method call hear for curd operation logic in different action--------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var ListUsers = Services.AllUsers();
            return View(ListUsers);
        }

        [HttpGet]
        public IActionResult CreatUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                Services.CreatUser(model);
                return RedirectToAction("Index");
            }
            return View(model);
           
        }

        [HttpGet]
        public IActionResult EditUser(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = Services.GetOneUser(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(string id, UserModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Services.EditUser(id, model);
                return RedirectToAction("Index");
            }
                         
            return View(model);
          
        }

      
         
        public ActionResult DeleteUser(string id)
        {
                if (id == null)
                {
                    return NotFound();
                }

                var user = Services.GetOneUser(id);
                if (user == null)
                {
                    return NotFound(); 
                }

                Services.DeleteUser(user);
                return RedirectToAction("Index");
            }
            
        }

    }
