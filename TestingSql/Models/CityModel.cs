using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TestingSql.Models
{
    public class CityModel
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }

        private bool connection_open;
        private MySqlConnection connection;

        public CityModel()
        {

        }

        public CityModel(int arg_id)
        {
            Get_Connection();

            try
            {


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("SELECT Name, CountryCode, District FROM city");

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    reader.Read();

                    if (reader.IsDBNull(0) == false)
                        Name = reader.GetString(0);
                    else
                        Name = null;

                    if (reader.IsDBNull(1) == false)
                        CountryCode = reader.GetString(1);
                    else
                        CountryCode = null;

                    if (reader.IsDBNull(2) == false)
                        District = reader.GetString(2);
                    else
                        District = null;

                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    reader.Close();
                    Name = MessageString;
                    CountryCode = District = null;
                }
            }
            catch (MySqlException e)
            {
                string MessageString = "The following error occurred loading the Column details: "
                    + e.ErrorCode + " - " + e.Message;
                Name = MessageString;
                CountryCode = District = null;
            }
            connection.Close();


        }

        private void Get_Connection()
       {
            connection_open = false;

            connection = new MySqlConnection();

            connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            if (Open_Local_Connection())
            {
                connection_open = true;
            }
            else
            {

            }

        }

        private bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}