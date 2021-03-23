using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteController.Services
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string to, string from)
        {
            // sendgrid service
            return true;
        }

        public Boolean SendSMS(string content, string to, string from)
        {
            // twillio service
            return true;
        }
    }
}
