using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace TestingSql.Models
{
    public class City
    {
        public string Name { get; set; }
        public string District { get; set; }
    }
}