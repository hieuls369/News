using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FoodN.DAO
{
    public class DBContext
    {
        public static SqlConnection GetConnection()
        {
            string ConnectString = ConfigurationManager.ConnectionStrings["FoodN"].ToString();
            SqlConnection connection = new SqlConnection(ConnectString);
            return connection;
        }


        public static DataTable GetDataBySQL(string sql)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            DataTable dt = new DataTable();
            Command.Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            dt.Load(Reader);
            Command.Connection.Close();
            return dt;
        }

        public static DataTable GetDataBySQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            DataTable dt = new DataTable();
            Command.Parameters.AddRange(parameters);
            Command.Connection.Open();

            SqlDataReader Reader = Command.ExecuteReader();

            dt.Load(Reader);
            Command.Connection.Close();
            return dt;
        }

        public static int ExecuteSQL(string sql)
        {
            SqlCommand Commad = new SqlCommand(sql, GetConnection());
            Commad.Connection.Open();
            int k = Commad.ExecuteNonQuery();
            Commad.Connection.Close();
            return k;
        }

        public static int ExecuteSQLWithParameters(string sql, params SqlParameter[] parameters)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection());
            Command.Connection.Open();
            Command.Parameters.AddRange(parameters);
            int k = Command.ExecuteNonQuery();
            Command.Connection.Close();
            return k;
        }
    }

    public class LoginDAO
    {
        public static DataTable getAdminLogin(string accountName, string accountPass)
        {
            string sql = "select * from Account" +
                         " where AccountName = @adminName and AccountPass = @adminPass";
            SqlParameter param1 = new SqlParameter("@adminName", SqlDbType.NVarChar);
            param1.Value = accountName;
            SqlParameter param2 = new SqlParameter("@adminPass", SqlDbType.NVarChar);
            param2.Value = accountPass;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1, param2);
        }
    }


    public class ManageDAO
    {
        public static DataTable getManageUser()
        {
            string sql = "select u.*, a.AccountName, a.RoleID, a.AccountPass, r.RoleName"+
                         " from[User] as u, Account as a, Role as r"+
                         " where u.AccountID = a.AccountID and a.RoleID = r.RoleID";
            return DAO.DBContext.GetDataBySQL(sql);
        }

        public static DataTable getManageNews()
        {
            string sql = "select f.*, t.typeName, c.countryName, a.AccountName"+
                         " from FoodN as f, Type as t, Country as c, Account as a"+
                         " where f.AccountID = a.AccountID and f.typeID = t.typeID and f.countryID = c.countryID"+
                         " order by f.datePub desc";
            return DAO.DBContext.GetDataBySQL(sql);
        }


        public static DataTable getRequest()
        {
            string sql = "select f.*, a.AccountName from [Food'er] as f, Account as a" +
                         " where f.AccountID = a.AccountID" +
                         " order by f.date desc";
            return DAO.DBContext.GetDataBySQL(sql);
        }

        public static DataTable getRequestByAccID(int accID)
        {
            string sql = "select f.*, a.AccountName from [Food'er] as f, Account as a" +
                         " where f.AccountID = a.AccountID and a.AccountID = @accID" +
                         " order by f.date desc";
            SqlParameter param1 = new SqlParameter("@accID", SqlDbType.Int);
            param1.Value = accID;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1);
        }
    }

    public class ManageDetail
    {
        public static DataTable getRole()
        {
            string sql = "select * from Role";
            return DAO.DBContext.GetDataBySQL(sql);
        }

        public static DataTable getType()
        {
            string sql = "select * from type";
            return DAO.DBContext.GetDataBySQL(sql);
        }

        public static DataTable getCountry()
        {
            string sql = "select * from country";
            return DAO.DBContext.GetDataBySQL(sql);
        }

        public static DataTable getNewsByID(int accountID)
        {
            string sql = "select f.*, t.typeName, c.countryName, a.AccountName"+
                         " from FoodN as f, Type as t, Country as c, Account as a"+
                         " where f.AccountID = a.AccountID and f.typeID = t.typeID and f.countryID = c.countryID"+
                         " and f.AccountID = @accountID order by f.datePub desc";
            SqlParameter param = new SqlParameter("@accountID", SqlDbType.Int);
            param.Value = accountID;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param);
        }

        public static DataTable getNewsByIDWeb(int accountID)
        {
            string sql = "select f.title, f.shortDes, f.datePub, t.typeName, c.countryName" +
                " from FoodN as f, Type as t, Country as c, Account as a" +
                " where f.AccountID = a.AccountID and f.typeID = t.typeID and f.countryID = c.countryID" +
                " and f.AccountID = @accountID order by f.datePub desc";
            SqlParameter param = new SqlParameter("@accountID", SqlDbType.Int);
            param.Value = accountID;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param);
        }
    }


    public class Search
    {
        public static DataTable searchUser(string searchFind)
        {
            string sql = "select u.*, a.AccountName, a.RoleID, a.AccountPass" +
                         " from [User] as u, Account as a" +
                         " where u.AccountID = a.AccountID and u.UserName like @searchText ";
            SqlParameter param = new SqlParameter("@searchText", SqlDbType.NVarChar);
            param.Value = "%" + searchFind + "%";
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param);

        }


        public static DataTable searchNews(string searchFind)
        {
            string sql = "select f.*, t.typeName, c.countryName, a.AccountName"+
                         " from FoodN as f, Type as t, Country as c, Account as a"+
                         " where f.AccountID = a.AccountID and f.typeID = t.typeID and f.countryID = c.countryID"+
                         " and f.title like @searchText";
            SqlParameter param = new SqlParameter("@searchText", SqlDbType.NVarChar);
            param.Value = "%" + searchFind + "%";
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param);
        }

        public static DataTable searchRequest(string searchFind)
        {
            string sql = "select f.*, a.AccountName from [Food'er] as f, Account as a"+
                         " where f.AccountID = a.AccountID and f.title like @searchText";
            SqlParameter param = new SqlParameter("@searchText", SqlDbType.NVarChar);
            param.Value = "%" + searchFind + "%";
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param);
        }
        
    }

    public class UserView
    {
        public static DataTable getInfoAccountByID(int id)
        {
            string sql = "select * from Account"+ 
                         " where AccountID = @id";
            SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = id;

            return DAO.DBContext.GetDataBySQLWithParameters(sql, param);
        }

        public static DataTable getInfoUserByAccountID(int accID)
        {
            string sql = "select u.*, a.AccountName, a.RoleID, a.AccountPass"+ 
                         " from[User] as u, Account as a"+ 
                         " where u.AccountID = a.AccountID and a.AccountID = @id";
            SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
            param.Value = accID;

            return DAO.DBContext.GetDataBySQLWithParameters(sql, param);
        }

    }

    public class AddDAO
    {
        public static int fillInformation(string userName, string email, string address, int phone, DateTime dob, int accID, string imgLink, string accPass)
        {
            string sql = "insert into [User] (UserName, Email, Address, Phone, Dob, AccountID, imgLink)" +
                         " values(@userName, @email,@address,@phone,@dob,@accID1,@img)" +
                         " update Account set RoleID = 2, AccountPass = @accPass where AccountID = @accID2";
            SqlParameter param1 = new SqlParameter("@userName", SqlDbType.NVarChar);
            param1.Value = userName;
            SqlParameter param2 = new SqlParameter("@email", SqlDbType.NVarChar);
            param2.Value = email;
            SqlParameter param3 = new SqlParameter("@address", SqlDbType.NVarChar);
            param3.Value = address;
            SqlParameter param4 = new SqlParameter("@phone", SqlDbType.Int);
            param4.Value = phone;
            SqlParameter param5 = new SqlParameter("@dob", SqlDbType.Date);
            param5.Value = dob;
            SqlParameter param6 = new SqlParameter("@accID1", SqlDbType.Int);
            param6.Value = accID;
            SqlParameter param7 = new SqlParameter("@img", SqlDbType.NVarChar);
            param7.Value = imgLink;
            SqlParameter param8 = new SqlParameter("@accID2", SqlDbType.Int);
            param8.Value = accID;
            SqlParameter param9 = new SqlParameter("@accPass", SqlDbType.NVarChar);
            param9.Value = accPass;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5, param6, param7, param8, param9);

        }

        public static int addFoodNew(string title, string shortDes, string longDes, DateTime date, int typeID, int countryID, string imgLink, int accID)
        {
            string sql = "insert into [FoodN]"+ 
                         " (title, shortDes, longDes, datePub, typeID, countryID, imgLink, AccountID)"+
                         " values"+
                         " (@title, @shortDes, @longDes, @date, @typeID, @countryID, @imgLink, @accID)";
            SqlParameter param1 = new SqlParameter("@title", SqlDbType.NVarChar);
            param1.Value = title;
            SqlParameter param2 = new SqlParameter("@shortDes", SqlDbType.NVarChar);
            param2.Value = shortDes;
            SqlParameter param3 = new SqlParameter("@longDes", SqlDbType.NVarChar);
            param3.Value = longDes;
            SqlParameter param4 = new SqlParameter("@date", SqlDbType.Date);
            param4.Value = date;
            SqlParameter param5 = new SqlParameter("@typeID", SqlDbType.Int);
            param5.Value = typeID;
            SqlParameter param6 = new SqlParameter("@countryID", SqlDbType.Int);
            param6.Value = countryID;
            SqlParameter param7 = new SqlParameter("@imgLink", SqlDbType.NVarChar);
            param7.Value = imgLink;
            SqlParameter param8 = new SqlParameter("@accID", SqlDbType.Int);
            param8.Value = accID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5, param6, param7, param8);
        }

        public static int AddNewAccount(string userName, string userPass)
        {
            string sql = "insert into [Account]"+
                         " (AccountName, AccountPass, RoleID)"+
                         " values"+
                         " (@accName, @accPass, 3)";
            SqlParameter param1 = new SqlParameter("@accName", SqlDbType.NVarChar);
            param1.Value = userName;
            SqlParameter param2 = new SqlParameter("@accPass", SqlDbType.NVarChar);
            param2.Value = userPass;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2);
        }

        public static DataTable listUserName()
        {
            string sql = "select AccountName from Account";
            return DAO.DBContext.GetDataBySQL(sql);
        }

        public static int makeRequest(string title, DateTime date, string description, string imgLink, int accID)
        {
            string sql = "insert into [Food'er]"+
                         " (title, date, description, imgLink, AccountID)"+
                         " values"+
                         " (@title, @date, @description, @imgLink, @accID)";
            SqlParameter param1 = new SqlParameter("@title", SqlDbType.NVarChar);
            param1.Value = title;
            SqlParameter param2 = new SqlParameter("@date", SqlDbType.NVarChar);
            param2.Value = date;
            SqlParameter param3 = new SqlParameter("@description", SqlDbType.NVarChar);
            param3.Value = description;
            SqlParameter param4 = new SqlParameter("@imgLink", SqlDbType.NVarChar);
            param4.Value = imgLink;
            SqlParameter param5 = new SqlParameter("@accID", SqlDbType.NVarChar);
            param5.Value = accID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5);
        }
    }

    public class UpdateDAO
    {
        public static int updateInformation(string userName, string email, string address, int phone, DateTime dob, int accID, string imgLink, string accPass, int roleID)
        {
            string sql = "update [User]"+
                         " set UserName = @userName, Email = @email, Address = @address, Phone = @phone, Dob = @dob, imgLink = @img" +
                         " where AccountID = @accID1" +
                         " update[Account]"+
                         " set AccountPass = @accPass, RoleID = @roleID" +
                         " where AccountID = @accID2";
            SqlParameter param1 = new SqlParameter("@userName", SqlDbType.NVarChar);
            param1.Value = userName;
            SqlParameter param2 = new SqlParameter("@email", SqlDbType.NVarChar);
            param2.Value = email;
            SqlParameter param3 = new SqlParameter("@address", SqlDbType.NVarChar);
            param3.Value = address;
            SqlParameter param4 = new SqlParameter("@phone", SqlDbType.Int);
            param4.Value = phone;
            SqlParameter param5 = new SqlParameter("@dob", SqlDbType.Date);
            param5.Value = dob;
            SqlParameter param6 = new SqlParameter("@img", SqlDbType.NVarChar);
            param6.Value = imgLink;
            SqlParameter param7 = new SqlParameter("@accID1", SqlDbType.Int);
            param7.Value = accID;
            SqlParameter param8 = new SqlParameter("@accPass", SqlDbType.NVarChar);
            param8.Value = accPass;
            SqlParameter param9 = new SqlParameter("@roleID", SqlDbType.Int);
            param9.Value = roleID;
            SqlParameter param10 = new SqlParameter("@accID2", SqlDbType.Int);
            param10.Value = accID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
        }

        public static int updateInformationWeb(string userName, string email, string address, int phone, DateTime dob, int accID, string imgLink)
        {
            string sql = "update [User]" +
                         " set UserName = @userName, Email = @email, Address = @address, Phone = @phone, Dob = @dob, imgLink = @img" +
                         " where AccountID = @accID1";
            SqlParameter param1 = new SqlParameter("@userName", SqlDbType.NVarChar);
            param1.Value = userName;
            SqlParameter param2 = new SqlParameter("@email", SqlDbType.NVarChar);
            param2.Value = email;
            SqlParameter param3 = new SqlParameter("@address", SqlDbType.NVarChar);
            param3.Value = address;
            SqlParameter param4 = new SqlParameter("@phone", SqlDbType.Int);
            param4.Value = phone;
            SqlParameter param5 = new SqlParameter("@dob", SqlDbType.Date);
            param5.Value = dob;
            SqlParameter param6 = new SqlParameter("@img", SqlDbType.NVarChar);
            param6.Value = imgLink;
            SqlParameter param7 = new SqlParameter("@accID1", SqlDbType.Int);
            param7.Value = accID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5, param6, param7);
        }

        public static int updateFoodNews(string title, string shortDes, string longDes, DateTime date, int typeID, int countryID, string imgLink, int accID, int foodID)
        {
            string sql = "update [FoodN]"+
                         " set title = @title, shortDes = @shortDes, longDes = @longDes, datePub = @date, typeID = @typeID, countryID = @countryID, imgLink = @imgLink" +
                         " where AccountID = @accID and FID = @foodID";
            SqlParameter param1 = new SqlParameter("@title", SqlDbType.NVarChar);
            param1.Value = title;
            SqlParameter param2 = new SqlParameter("@shortDes", SqlDbType.NVarChar);
            param2.Value = shortDes;
            SqlParameter param3 = new SqlParameter("@longDes", SqlDbType.NVarChar);
            param3.Value = longDes;
            SqlParameter param4 = new SqlParameter("@date", SqlDbType.Date);
            param4.Value = date;
            SqlParameter param5 = new SqlParameter("@typeID", SqlDbType.Int);
            param5.Value = typeID;
            SqlParameter param6 = new SqlParameter("@countryID", SqlDbType.Int);
            param6.Value = countryID;
            SqlParameter param7 = new SqlParameter("@imgLink", SqlDbType.NVarChar);
            param7.Value = imgLink;
            SqlParameter param8 = new SqlParameter("@accID", SqlDbType.Int);
            param8.Value = accID;
            SqlParameter param9 = new SqlParameter("@foodID", SqlDbType.Int);
            param9.Value = foodID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2, param3, param4, param5, param6, param7, param8, param9);
        }
    }

    public class DeleteDAO
    {
        public static int delUserByID(int userID, int accID)
        {
            string sql = "delete from [User]"+
                         " where UserID = @userID"+
                         " delete from Account"+
                         " where AccountID = @accID" +
                         " delete from FoodN" +
                         " where AccountID = @accID";
            SqlParameter param1 = new SqlParameter("@userID", SqlDbType.Int);
            param1.Value = userID;
            SqlParameter param2 = new SqlParameter("@accID", SqlDbType.Int);
            param2.Value = accID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1, param2);
        }

        public static int delFood(int fooID)
        {
            string sql = "delete from FoodN"+
                         " where FID = @fooID";
            SqlParameter param1 = new SqlParameter("@fooID", SqlDbType.Int);
            param1.Value = fooID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1);
        }

        public static int delRequest(int requestID)
        {
            string sql = "delete from [Food'er]"+
                         " where id = @requestID ";
            SqlParameter param1 = new SqlParameter("@requestID", SqlDbType.Int);
            param1.Value = requestID;
            return DAO.DBContext.ExecuteSQLWithParameters(sql, param1);
        }
    }

    public class IntroNews
    {
        public static DataTable getTopNews()
        {
            string sql = "select top 1 * from FoodN order by datePub desc";
            return DAO.DBContext.GetDataBySQL(sql);

        }

        public static DataTable get6TopRecentNews()
        {
            string sql = "select top 6 * from FoodN where datePub not in" +
                " (select max(datePub) from FoodN) order by datePub desc";
            return DAO.DBContext.GetDataBySQL(sql);
        }
    }

    public class FoodNews 
    {
        public static DataTable getAllNewsAndPaging(int start, int end)
        {
            string sql = "select * from (select ROW_NUMBER() over (order by FID ASC) as rn, * from FoodN) as x"+
                         " where rn between @start and @end";
            SqlParameter param1 = new SqlParameter("@start", SqlDbType.Int);
            param1.Value = start;
            SqlParameter param2 = new SqlParameter("@end", SqlDbType.Int);
            param2.Value = end;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1, param2);

        }
        public static DataTable getTotal()
        {
            string sql = "select count(*) from FoodN";
            return DAO.DBContext.GetDataBySQL(sql);
        }

        public static DataTable searchNews(int typeID, int countryID, string searchFind, int start, int end)
        {
            string sql = "select * from (select ROW_NUMBER() over (order by f.FID ASC) as rn, f.*" +
                         " from FoodN as f, Type as t, Country as c" +
                         " where f.countryID = c.countryID and f.typeID = t.typeID";
                         if(typeID != 0) { sql += " and t.typeID = @typeID "; }
                         if(countryID != 0) { sql += " and c.countryID = @countryID"; }
                         if(!searchFind.Equals("All Food")) { sql += " and f.title like @searchText"; }
                         sql += " ) as x where rn between @start and @end";
            SqlParameter param1 = new SqlParameter("@typeID", SqlDbType.Int);
            param1.Value = typeID;
            SqlParameter param2 = new SqlParameter("@countryID", SqlDbType.Int);
            param2.Value = countryID;
            SqlParameter param3 = new SqlParameter("@searchText", SqlDbType.NVarChar);
            param3.Value = "%" + searchFind + "%";
            SqlParameter param4 = new SqlParameter("@start", SqlDbType.Int);
            param4.Value = start;
            SqlParameter param5 = new SqlParameter("@end", SqlDbType.Int);
            param5.Value = end;

            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1, param2, param3, param4, param5);
        }

        public static DataTable countNews(int typeID, int countryID, string searchFind)
        {
            string sql = "select count(*)" +
                         " from FoodN as f, Type as t, Country as c" +
                         " where f.countryID = c.countryID and f.typeID = t.typeID";
                         if (typeID != 0) { sql += " and t.typeID = @typeID "; }
                         if (countryID != 0) { sql += " and c.countryID = @countryID"; }
                         if (!searchFind.Equals("All Food")) { sql += " and f.title like @searchText"; }
            SqlParameter param1 = new SqlParameter("@typeID", SqlDbType.Int);
            param1.Value = typeID;
            SqlParameter param2 = new SqlParameter("@countryID", SqlDbType.Int);
            param2.Value = countryID;
            SqlParameter param3 = new SqlParameter("@searchText", SqlDbType.NVarChar);
            param3.Value = "%" + searchFind + "%";
            
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1, param2, param3);
        }

        public static DataTable getNewsByID(int foodID)
        {
            string sql = "select f.*, t.*, c.*, a.*, u.UserName" +
                         " from FoodN as f, Type as t, Country as c, Account as a, [User] as u" +
                         " where f.countryID = c.countryID and f.typeID = t.typeID and a.AccountID = f.AccountID and u.AccountID = a.AccountID" +
                         " and f.FID = @fid";
            SqlParameter param1 = new SqlParameter("@fid", SqlDbType.Int);
            param1.Value = foodID;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1);
        }

        public static DataTable getNewsByAccID(int accID, int start, int end)
        {
            string sql = "select * from (select ROW_NUMBER() over (order by f.FID ASC) as rn, f.*, t.typeName, c.countryName"+ 
                         " from FoodN as f, [Type] as t, Country as c"+
                         " where f.countryID = c.countryID and f.typeID = t.typeID and f.AccountID = @accID) as x"+
                         " where rn between @start and @end";
            SqlParameter param1 = new SqlParameter("@accID", SqlDbType.Int);
            param1.Value = accID;
            SqlParameter param2 = new SqlParameter("@start", SqlDbType.Int);
            param2.Value = start;
            SqlParameter param3 = new SqlParameter("@end", SqlDbType.Int);
            param3.Value = end;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1, param2, param3);
        }

        public static DataTable getCountNewsWeb(int accID)
        {
            string sql = "select count(*) from FoodN where AccountID = @accID";
            SqlParameter param1 = new SqlParameter("@accID", SqlDbType.Int);
            param1.Value = accID;
            return DAO.DBContext.GetDataBySQLWithParameters(sql, param1);
        }
    }
}
