﻿using System.Web;
using System.Web.Mvc;

namespace _8109_PRG522SA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
