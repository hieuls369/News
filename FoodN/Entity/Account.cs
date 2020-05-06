using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FoodN.Entity
{
    public class Account
    {
        public int accountID { get; set; }
        public string accountName { get; set; }
        public string accountPass { get; set; }
        public int roleID { get; set; }

        public Account()
        {

        }
        public Account(int accountID, string accountName, string accountPass, int roleID)
        {
            this.accountID = accountID;
            this.accountName = accountName;
            this.accountPass = accountPass;
            this.roleID = roleID;
        }
    }

    public class AdminLogin
    {
        public static Account getAdminLogin(string accountName, string accountPass)
        {
            DataTable dt = FoodN.DAO.LoginDAO.getAdminLogin(accountName, accountPass);
            foreach(DataRow dr in dt.Rows) {
                Account account = new Account(Convert.ToInt32(dr["AccountID"]),
                    dr["AccountName"].ToString(),
                    dr["AccountPass"].ToString(),
                    Convert.ToInt32(dr["RoleID"]));
                return account;
            }
            return null;
        }
        public static Account getAccountByID(int id)
        {
            DataTable dt = FoodN.DAO.UserView.getInfoAccountByID(id);
            foreach (DataRow dr in dt.Rows)
                {
                    Account account = new Account(Convert.ToInt32(dr["AccountID"]),
                        dr["AccountName"].ToString(),
                        dr["AccountPass"].ToString(),
                        Convert.ToInt32(dr["RoleID"]));
                    return account;
                }
                return null;
            }
        }
    }

