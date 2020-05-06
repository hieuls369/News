using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FoodN.Entity
{
    public class Country
    {
        public int countryID { get; set; }
        public string countryName { get; set; }

        public Country(int countryID, string countryName)
        {
            this.countryID = countryID;
            this.countryName = countryName;
        }
    }

    public class CountryDisplay
    {
        public static List<Country> getAllCountry()
        {
            List<Country> list = new List<Country>();
            DataTable dt = DAO.ManageDetail.getCountry();
            foreach(DataRow dr in dt.Rows)
            {
                Country country = new Country(Convert.ToInt32(dr["countryID"]),
                    dr["countryName"].ToString());
                list.Add(country);
            }
            return list;
        }

        public static List<Country> getAllCountryWeb()
        {
            List<Country> list = new List<Country>();
            DataTable dt = DAO.ManageDetail.getCountry();
            list.Add(new Country(0, "None"));
            foreach (DataRow dr in dt.Rows)
            {
                Country country = new Country(Convert.ToInt32(dr["countryID"]),
                    dr["countryName"].ToString());
                list.Add(country);
            }
            return list;
        }
    }
}
