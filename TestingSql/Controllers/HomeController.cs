using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSql.Models;

namespace TestingSql.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //CityModel cm = new CityModel(1);
            //return View(cm);
            List<City> customers = new List<City>();
            string constr = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT Name, District FROM city";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new City
                            {
                                //CustomerId = Convert.ToInt32(sdr["CustomerId"]),
                                Name = sdr["Name"].ToString(),
                                District = sdr["District"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return View(customers);
        }
    }
}