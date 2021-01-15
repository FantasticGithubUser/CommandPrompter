using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Helpers
{
    public static class RouteHelper
    {
        public static string GetAllUsers => GlobalConfiguration.ServiceAddress + @"User/GetAllUsers";

        public static string Login => GlobalConfiguration.ServiceAddress + @"Login/Login";

        public static string GetAllPlateforms => GlobalConfiguration.ServiceAddress + @"Plateform/GetAllPlateforms";

        /// <summary>
        /// 0 => name,
        /// 1 => count
        /// </summary>
        public static string GetRelatedNames => GlobalConfiguration.ServiceAddress + @"Common/GetRelatedNames/{0}/{1}";

        #region Command
        public static string GetCommandsByFilter => GlobalConfiguration.ServiceAddress + @"Command/GetCommandsByFilter";

        public static string GetCommandById => GlobalConfiguration.ServiceAddress + @"Command/GetCommandById";

        public static string GetAllCommands => GlobalConfiguration.ServiceAddress + @"Command/GetAllCommands";
        #endregion Command
        public static string ReplaceParam(string route, params string[] parameters)
        {
            var ret = route;
            for(int i = 0; i < parameters.Length; i++)
            {
                ret = ret.Replace("{" + i + "}", parameters[i]);
            }
            return ret;
        }

    }
}
