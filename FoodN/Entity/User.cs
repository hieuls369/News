using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FoodN.Entity
{
    public class User
    {
        public User(int userID, string userName, string email, string address, int phone, DateTime date, string accountName, string imgLink, int roleID, string accountPass, int accountID)
        {
            this.userID = userID;
            this.userName = userName;
            this.email = email;
            this.address = address;
            this.phone = phone;
            this.date = date;
            this.accountName = accountName;
            this.imgLink = imgLink;
            this.roleID = roleID;
            this.accountPass = accountPass;
            this.accountID = accountID;
        }

        public User(int userID, string userName, string email, string address, int phone, DateTime date, string accountName, string imgLink, int roleID, string accountPass, int accountID, string roleName)
        {
            this.userID = userID;
            this.userName = userName;
            this.email = email;
            this.address = address;
            this.phone = phone;
            this.date = date;
            this.accountName = accountName;
            this.imgLink = imgLink;
            this.roleID = roleID;
            this.accountPass = accountPass;
            this.accountID = accountID;
            this.roleName = roleName;
        }

        public int userID { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        public DateTime date { get; set; }
        public string accountName { get; set; }
        public string imgLink { get; set; }

        public int roleID { get; set; }

        public string accountPass { get; set; }

        public int accountID { get; set; }

        public string roleName { get; set; }
        
    }

    public class UserDisplay
    {
        public static List<User> getAllUser()
        {
            List<User> list = new List<User>();
            DataTable dt = DAO.ManageDAO.getManageUser();
            foreach(DataRow dr in dt.Rows)
            {
                User user = new User(Convert.ToInt32(dr["UserID"]),
                    dr["UserName"].ToString(),
                    dr["Email"].ToString(),
                    dr["Address"].ToString(),
                    Convert.ToInt32(dr["Phone"]),
                    Convert.ToDateTime(dr["Dob"]),
                    dr["AccountName"].ToString(),
                    dr["imgLink"].ToString(),
                    Convert.ToInt32(dr["RoleID"]),
                    dr["AccountPass"].ToString(),
                    Convert.ToInt32(dr["AccountID"]),
                    dr["RoleName"].ToString());
                list.Add(user);
            }
            return list;

        }
        public static List<User> getAllUserBySearch(string searchText)
        {
            List<User> list = new List<User>();
            DataTable dt = DAO.Search.searchUser(searchText);
            foreach (DataRow dr in dt.Rows)
            {
                User user = new User(Convert.ToInt32(dr["UserID"]),
                    dr["UserName"].ToString(),
                    dr["Email"].ToString(),
                    dr["Address"].ToString(),
                    Convert.ToInt32(dr["Phone"]),
                    Convert.ToDateTime(dr["Dob"]),
                    dr["AccountName"].ToString(),
                    dr["imgLink"].ToString(),
                    Convert.ToInt32(dr["RoleID"]),
                    dr["AccountPass"].ToString(),
                    Convert.ToInt32(dr["AccountID"]));
                list.Add(user);
            }
            return list;

        }

       public static User getUserByAccountID(int account)
        {
            DataTable dt = DAO.UserView.getInfoUserByAccountID(account);
            foreach (DataRow dr in dt.Rows)
            {
                User user = new User(Convert.ToInt32(dr["UserID"]),
                    dr["UserName"].ToString(),
                    dr["Email"].ToString(),
                    dr["Address"].ToString(),
                    Convert.ToInt32(dr["Phone"]),
                    Convert.ToDateTime(dr["Dob"]),
                    dr["AccountName"].ToString(),
                    dr["imgLink"].ToString(),
                    Convert.ToInt32(dr["RoleID"]),
                    dr["AccountPass"].ToString(),
                    Convert.ToInt32(dr["AccountID"]));
                return user;
            }
            return null;
        }
    }
}
