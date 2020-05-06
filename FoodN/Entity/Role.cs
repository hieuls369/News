using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FoodN.Entity
{
    public class Role
    {
        public int roleID { get; set; }
        public string roleName { get; set; }

        public Role(int roleID, string roleName)
        {
            this.roleID = roleID;
            this.roleName = roleName;
        }
    }
    public class RoleDisplay
    {
        public static List<Role> getAllRole()
        {
            List<Role> list = new List<Role>();
            DataTable dt = DAO.ManageDetail.getRole();
            foreach(DataRow dr in dt.Rows)
            {
                Role role = new Role(Convert.ToInt32(dr["RoleID"]),
                    dr["RoleName"].ToString());
                list.Add(role);
            }
            return list;
        }
    }
}
