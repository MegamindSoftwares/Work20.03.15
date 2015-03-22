using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CountryCityApp.Models
{
    public class CountryGateway
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["countryStr"].ConnectionString;
        SqlConnection aSqlConnection = new SqlConnection(connectionString);
        private SqlCommand aSqlCommand;
        private string query;

        public void Save(Country aCountry)
        {
            query = "INSERT INTO t_Country VALUES('" + aCountry.Name + "','" + aCountry.About + "','" + aCountry.Picture +
                    "')";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }
        public List<Country> GetAllCountry()
        {
            query = "SELECT * FROM t_Country;";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<Country> countries = new List<Country>();
            while (aSqlDataReader.Read())
            {
                Country aCountry = new Country();
                aCountry.Id = Convert.ToInt16(aSqlDataReader["id"]);
                aCountry.Name = aSqlDataReader["name"].ToString();
                aCountry.About = aSqlDataReader["about"].ToString();
                aCountry.Picture = aSqlDataReader["picture"].ToString();
                countries.Add(aCountry);
            }
            aSqlConnection.Close();
            return countries;
        }
    }
}