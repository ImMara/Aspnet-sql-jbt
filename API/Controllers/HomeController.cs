using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MySqlConnector;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var ids = new List<int>();
            try
            {
                // TOFIX: Connection string is hardcoded
                var connection = new MySqlConnection("Server=localhost,8889;UserID=root;Password=root;Database=aspnet");
                await connection.OpenAsync();
                
                var command = new MySqlCommand("SELECT * FROM Applications;", connection);
                var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    ids.Add(reader.GetInt32(0));
                }
                Console.WriteLine(ids.Count);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            // TOFIX: Index view is not found
            return View("Index", ids);
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