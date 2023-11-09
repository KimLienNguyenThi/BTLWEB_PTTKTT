using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThuVienBTL.Models;

namespace ThuVienBTL.App_Start
{
    public static class SessionConfig
    {
        // 1. Luu user
        public static void SetUser(LOGIN_DG user)
        {
            HttpContext.Current.Session["user"] = user;
        }

        // 2. Lay session
        public static LOGIN_DG GetUser() 
        {
            return (LOGIN_DG)HttpContext.Current.Session["user"];
        }
    }
}