using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteModel.DbModel
{
    public class DbModelBase
    {
        private DateTime currentDate;

        public DateTime CurrentDate
        {
            get { return DateTime.Now; }
        }

        private int userInSessionId;

        public int UserInSessionId
        {
            get { return userInSessionId; }
            set { userInSessionId = value; }
        }

    }
}
