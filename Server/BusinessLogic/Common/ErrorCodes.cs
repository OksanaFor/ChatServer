using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Common
{
    public static class ErrorCodes
    {
        public static string ServerError00001 = "Login used by another user";
        public static string ServerError00002 = "Login lenth can't be more then 10 characters";
        public static string ServerError00003 = "Invalid username or password";
    }
}
