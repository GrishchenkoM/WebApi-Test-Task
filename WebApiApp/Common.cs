using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbLogic;
using Management;
using WMI;

namespace WebApiApp
{
    public static class Common
    {
        public static DataManager DataManager { get; set; }

        public static Manager Manager { get; set; }
    }
}