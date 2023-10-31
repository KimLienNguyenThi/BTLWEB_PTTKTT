using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuanLyThuVien.Areas.Admin.Data
{
    public class DAO
    {
        private static DAO instance;

        internal static DAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DAO();
                return instance;
            }
        }

        //Phiếu mượn


    }
}