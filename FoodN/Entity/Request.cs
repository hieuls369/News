using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FoodN.Entity
{
    public class Request
    {
       
        public int requestID { get; set; }
        public string title { get; set; }

        public DateTime date { get; set; }
        public string description { get; set; }
        public string imgLink { get; set; }
        public string accountName { get; set; }

        public Request(int requestID, string title, DateTime date, string description, string imgLink, string accountName)
        {
            this.requestID = requestID;
            this.title = title;
            this.date = date;
            this.description = description;
            this.imgLink = imgLink;
            this.accountName = accountName;
        }

    }

    public class requestDisplay
    {
        public static List<Request> getAllRequest()
        {
            List<Request> list = new List<Request>();
            DataTable dt = DAO.ManageDAO.getRequest();
            foreach(DataRow dr in dt.Rows)
            {
                Request request = new Request(
                    Convert.ToInt32(dr["id"]),
                    dr["title"].ToString(),
                    Convert.ToDateTime(dr["date"]),
                    dr["description"].ToString(),
                    dr["imgLink"].ToString(),
                    dr["AccountName"].ToString());
                list.Add(request);
            }
            return list;
        }

        public static List<Request> getRequestBySearch(string searchText)
        {
            List<Request> list = new List<Request>();
            DataTable dt = DAO.Search.searchRequest(searchText);
            foreach (DataRow dr in dt.Rows)
            {
                Request request = new Request(
                    Convert.ToInt32(dr["id"]),
                    dr["title"].ToString(),
                    Convert.ToDateTime(dr["date"]),
                    dr["description"].ToString(),
                    dr["imgLink"].ToString(),
                    dr["AccountName"].ToString());
                list.Add(request);
            }
            return list;
        }
    }
}
