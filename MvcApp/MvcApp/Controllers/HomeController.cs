using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;
using System.Data.OleDb;

namespace MvcApp.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        DBHelper helper = new DBHelper();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {
            helper.OpenConnection();
            Boolean CanLogin=false;
            OleDbDataReader reader = helper.ExecuteQuery("select * from Users ");
            while (reader.Read())
            {
                if (model.UserName == reader["UserName"].ToString() && model.PassWord == reader["Password"].ToString())
                {
                    CanLogin = true;
                    break;
                }
            }
            if (CanLogin)
            {
                return RedirectToAction("JqQuery", "Query");
            }
            else
            {
                return View(model);
            }
        }

    }
}
