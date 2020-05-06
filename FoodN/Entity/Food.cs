using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FoodN.Entity
{
    public class Food
    {
        public Food(int foodID, string title, string shortDes, string longDes, DateTime datePub, string typeName, string countryName, string imgLink, string accountName, int accountID)
        {
            this.foodID = foodID;
            this.title = title;
            this.shortDes = shortDes;
            this.longDes = longDes;
            this.datePub = datePub;
            this.typeName = typeName;
            this.countryName = countryName;
            this.imgLink = imgLink;
            this.accountName = accountName;
            this.accountID = accountID;
        }

        public int foodID { get; set; }
        public string title { get; set; }
        public string shortDes { get; set; }
        public string longDes { get; set; }
        public DateTime datePub { get; set; }
        public string typeName { get; set; }
        public string countryName { get; set; }
        public string imgLink { get; set; }
        public string accountName { get; set; }
        public int accountID { get; set; }

       

    }

    public class FoodDisplay
    {
        public static List<Food> getAllFood()
        {
            List<Food> list = new List<Food>();
            DataTable dt = FoodN.DAO.ManageDAO.getManageNews();
            foreach(DataRow dr in dt.Rows)
            {
                Food food = new Food(Convert.ToInt32(dr["FID"]),
                    dr["title"].ToString(),
                    dr["shortDes"].ToString(),
                    dr["longDes"].ToString(),
                    Convert.ToDateTime(dr["datePub"]),
                    dr["typeName"].ToString(),
                    dr["countryName"].ToString(),
                    dr["imgLink"].ToString(),
                    dr["AccountName"].ToString(),
                    Convert.ToInt32(dr["AccountID"]));
                list.Add(food);
            }
            return list;
        }

        public static List<Food> getAllFoodByID(int id)
        {
            List<Food> list = new List<Food>();
            DataTable dt = FoodN.DAO.ManageDetail.getNewsByID(id);
            foreach (DataRow dr in dt.Rows)
            {
                Food food = new Food(Convert.ToInt32(dr["FID"]),
                    dr["title"].ToString(),
                    dr["shortDes"].ToString(),
                    dr["longDes"].ToString(),
                    Convert.ToDateTime(dr["datePub"]),
                    dr["typeName"].ToString(),
                    dr["countryName"].ToString(),
                    dr["imgLink"].ToString(),
                    dr["AccountName"].ToString(),
                    Convert.ToInt32(dr["AccountID"]));
                list.Add(food);
            }
            return list;
        }


        public static List<Food> getAllFoodBySearch(string searchText)
        {
            List<Food> list = new List<Food>();
            DataTable dt = FoodN.DAO.Search.searchNews(searchText);
            foreach (DataRow dr in dt.Rows)
            {
                Food food = new Food(Convert.ToInt32(dr["FID"]),
                    dr["title"].ToString(),
                    dr["shortDes"].ToString(),
                    dr["longDes"].ToString(),
                    Convert.ToDateTime(dr["datePub"]),
                    dr["typeName"].ToString(),
                    dr["countryName"].ToString(),
                    dr["imgLink"].ToString(),
                    dr["AccountName"].ToString(),
                    Convert.ToInt32(dr["AccountID"]));
                list.Add(food);
            }
            return list;
        }

        public static Food getFoodByID(int FID)
        {
            DataTable dt = FoodN.DAO.FoodNews.getNewsByID(FID);
            foreach (DataRow dr in dt.Rows)
            {
                Food food = new Food(Convert.ToInt32(dr["FID"]),
                    dr["title"].ToString(),
                    dr["shortDes"].ToString(),
                    dr["longDes"].ToString(),
                    Convert.ToDateTime(dr["datePub"]),
                    dr["typeName"].ToString(),
                    dr["countryName"].ToString(),
                    dr["imgLink"].ToString(),
                    dr["AccountName"].ToString(),
                    Convert.ToInt32(dr["AccountID"]));
                return food;
            }
            return null;
        }

    }
}
