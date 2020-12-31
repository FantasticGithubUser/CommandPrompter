using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Helpers
{
    public static class RouteHelper
    {
        public static string GetAllUsers => GlobalConfiguration.ServiceAddress + @"User/GetAllUsers";

        public static string Login => GlobalConfiguration.ServiceAddress + @"Login/Login";

    }
}
