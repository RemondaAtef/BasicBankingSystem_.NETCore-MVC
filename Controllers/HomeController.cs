using Basic_Banking_System.DAL.Database;
using Basic_Banking_System.DAL.Entities;
using Basic_Banking_System.Services;
using Basic_Banking_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Services;

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

        public IActionResult Index()   // view home page
        {
            return View();
        }

        public IActionResult Customers()   // view customers page
        {
            ViewBag.x = "Transfer Money";

            var data = db.Customers.Select(a => new Customers { Account_Num = a.Account_Num, Name = a.Name, Email = a.Email , Current_Balance = a.Current_Balance});

            return View(data);
        }

        public IActionResult History()  // view transfer history page
        {
            ViewBag.x = "Transfer History";

            var data = db.History.Select(a => new History { Senderid = a.Senderid, receiverid = a.receiverid, ReceiverName = a.ReceiverName, SenderName = a.SenderName, Date = a.Date, amount = a.amount });
            
            return View(data);
        }

        [HttpGet("contact")]
        public IActionResult ContactUs()
        {

            return View();
        }

        [HttpPost("contact")]
        public IActionResult ContactUs(ContactVM model)   // view Contact Us page
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
               
            }
            return View();
           
        }
     
        public IActionResult SelectedUserDetail(string id)   // view transaction page to transfer money
        {
            ViewBag.x = "Transaction";

            var data = db.Customers.Where(a => a.Account_Num == id)   // view account info by user id
                .Select(a => new Customers { Account_Num = a.Account_Num, Name = a.Name, Email = a.Email, Current_Balance = a.Current_Balance }).FirstOrDefault();

            ViewBag.names = db.Customers.Where(a => a.Account_Num != id)   // to view the users in the DropDownList
                .Select(a => new Customers { Name = a.Name }).ToList();  

            return View(data);
        }
       
        [HttpPost]
        public IActionResult TransferMoney(string senderid, int amount, string recivername)   // transfer money operation
        {
            try
            {

                var receiverData = db.Customers.Where(a => a.Name == recivername)   // view reciever data by name
                    .Select(a => new Customers { Account_Num = a.Account_Num, Name = a.Name, Email = a.Email, Current_Balance = a.Current_Balance }).FirstOrDefault();

                var senderData = db.Customers.Where(a => a.Account_Num == senderid)   // view sender data by id
                    .Select(a => new Customers { Account_Num = a.Account_Num, Name = a.Name, Email = a.Email, Current_Balance = a.Current_Balance }).FirstOrDefault();

                var data = senderData.Current_Balance.Split("$");  // remove $ from current balance of sender
                int senderamount = Int32.Parse(data[0]);           // then convert current balance of sender from string to int

                var data2 = receiverData.Current_Balance.Split("$");   // remove $ from current balance of receiver
                int receiveramount = Int32.Parse(data2[0]);            // then convert current balance of receiver from string to int

                if (amount <= 0)                                      // if the sender enters a value of 0 or < 0
                    return Json("Not valid ammount of money");

                if (senderamount < amount)                            // if the sender enters a value > his current balance
                    return Json("Not enough money in your account");

                senderamount -= amount;                              
                senderData.Current_Balance = senderamount.ToString() + "$";   // convert current balance of sender from int to string
                db.Customers.Update(senderData);                             
                db.SaveChanges();
               
                receiveramount += amount;
                receiverData.Current_Balance = receiveramount.ToString() + "$"; // convert current balance of receiver from int to string
                db.Customers.Update(receiverData);
                db.SaveChanges();

                History h = new History();

                var amount1 = amount.ToString() + "$";      // convert the amount that has been converted from int to string

                h.amount = amount1;
                h.Date = DateTime.Now;
                h.ReceiverName = recivername;
                h.SenderName = senderData.Name;
                h.Senderid = senderid;
                h.receiverid = receiverData.Account_Num;

                db.History.Add(h);

                db.SaveChanges();

                return Json("");
             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
