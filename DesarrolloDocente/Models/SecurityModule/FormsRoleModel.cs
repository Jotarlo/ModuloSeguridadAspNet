using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesarrolloDocente.Models.SecurityModule
{
    public class FormsRoleModel
    {
        private int roleId;

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        private IEnumerable<FormModel> formsList;

        public IEnumerable<FormModel> FormsList
        {
            get { return formsList; }
            set { formsList = value; }
        }

        private string selectedForms;

        public string SelectedForms
        {
            get { return selectedForms; }
            set { selectedForms = value; }
        }


    }
}