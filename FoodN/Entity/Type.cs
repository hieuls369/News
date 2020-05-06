using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FoodN.Entity
{
    public class Type
    {
        public int typeID { get; set; }
        public string typeName { get; set; }

        public Type(int typeID, string typeName)
        {
            this.typeID = typeID;
            this.typeName = typeName;
        }
    }

    public class TypeDisplay
    {
        public static List<Type> getAllType()
        {
            List<Type> list = new List<Type>();
            DataTable dt = DAO.ManageDetail.getType();
            foreach(DataRow dr in dt.Rows)
            {
                Type type = new Type(Convert.ToInt32(dr["typeID"]),
                    dr["typeName"].ToString());
                list.Add(type);
            }
            return list;
        }

        public static List<Type> getAllTypeWeb()
        {
            List<Type> list = new List<Type>();
            DataTable dt = DAO.ManageDetail.getType();
            list.Add(new Type(0, "None"));
            foreach (DataRow dr in dt.Rows)
            {
                Type type = new Type(Convert.ToInt32(dr["typeID"]),
                    dr["typeName"].ToString());
                list.Add(type);
            }
            return list;
        }
    }
}
