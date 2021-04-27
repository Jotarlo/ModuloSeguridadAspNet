using DesarrolloDocente.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesarrolloDocente.Controllers
{
    public class BaseController : Controller
    {
        public bool VerifySession()
        {
            return Session.Count > 0;
        }

        public bool VerifyUserInForm()
        {
            try
            {
                string actionName = this.RouteData.Values["action"].ToString();
                if (!actionName.Equals("Login"))
                {
                    int userId = Int32.Parse(Session["userId"].ToString());
                    return Menu.ValidateUserInForm(userId, 1);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}