using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Rocky.Models;

namespace Rocky.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Server=AWS-SQL\\OPUS;Database=OPUS;Integrated Security=False;User Id=OpusUser;Password=E3kT*KSSa#ZGa^4c7Cr#wZ6k4;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;"))
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Email FROM dbo.UserAccount WHERE FullName = 'Simon Youles';";
                        con.Open();

                        string userEmail = (string)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {

           
            }

           


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
