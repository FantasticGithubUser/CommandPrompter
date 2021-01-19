using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Helpers
{
    public static class RouteHelper
    {
        public static string Address => GlobalConfiguration.ServiceAddress;
        public static string GetAllUsers => Address + @"User/GetAllUsers";

        public static string Login => Address + @"Login/Login";

        #region Plateform
        public static string GetAllPlateforms => Address + @"Plateform/GetAllPlateforms";
        public static string GetPlateforms => Address + @"Plateform/GetEntities";

        #endregion Plateform
        /// <summary>
        /// 0 => name,
        /// 1 => count
        /// </summary>
        public static string GetRelatedNames => Address + @"Common/GetRelatedNames/{0}/{1}";

        #region Command
        public static string GetCommandsByFilter => Address + @"Command/GetCommandsByFilter";

        public static string GetCommandById => Address + @"Command/GetCommandById";

        public static string GetAllCommands => Address + @"Command/GetAllCommands";

        public static string GetCommands => Address + @"Command/GetEntities";
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
