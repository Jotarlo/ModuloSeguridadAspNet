using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesarrolloDocente.Models.SecurityModule
{
    public class UserRoleModel
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private IEnumerable<RoleModel> roleList;

        public IEnumerable<RoleModel> RoleList
        {
            get { return roleList; }
            set { roleList = value; }
        }

        private string selectedRoles;

        public string SelectedRoles
        {
            get { return selectedRoles; }
            set { selectedRoles = value; }
        }


    }
}