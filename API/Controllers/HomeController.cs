using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using API.Models;
using MySqlConnector;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(  )
        {
            var model = new IndexViewModel
            {
                Ids = new List<int>()
            };
            
            try
            {
                var connection = new MySqlConnection("Server=localhost,8889;UserID=root;Password=root;Database=aspnet");
                connection.Open();

                var command = new MySqlCommand("SELECT * FROM Applications;", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    model.Ids.Add(reader.GetInt32(0));
                }

                Console.WriteLine(model.Ids.Count);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));

            }
            return View("Index", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}