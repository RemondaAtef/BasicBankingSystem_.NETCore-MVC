﻿using Basic_Banking_System.DAL.Database;
using Basic_Banking_System.Models;
using Basic_Banking_System.Services;
using Basic_Banking_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService mailService;
        private DbContainer db = new DbContainer();

        public HomeController(IMailService mailService)
        {
            this.mailService = mailService;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Customers()
        {
            ViewBag.x = "Transfer Money";

            //CustomersVM dpt1 = new CustomersVM() { Account_Num = "2155-4126-7894-1235", Name = "Ahmed", Current_Balance = "15$", Email = "Ahmed25@gmail.com"};
            //CustomersVM dpt2 = new CustomersVM() { Account_Num = "2148-9878-4567-1234", Name = "Mohamed", Current_Balance = "100$", Email = "Mohamed87@gmail.com" };
            //CustomersVM dpt3 = new CustomersVM() { Account_Num = "2172-4518-7857-1423", Name = "Farid", Current_Balance = "1578$", Email = "Farid76@gmail.com" };

            //List<CustomersVM> DptData = new List<CustomersVM>();
            //DptData.Add(dpt1);
            //DptData.Add(dpt2);
            //DptData.Add(dpt3);

            var data = db.Customers.Select(a => new CustomersVM { Account_Num = a.Account_Num, Name = a.Name, Email = a.Email , Current_Balance = a.Current_Balance});

            return View(data);
        }

        public IActionResult History()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult ContactUs(ContactVM model)
        {
            if (ModelState.IsValid)
            {
                //send the email
                this.mailService.SendMessage("Remondaa94@gmail.com", model.Subject, $"Form: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserManager = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //show errors
            }
            return View();
           
        }
    }
}
