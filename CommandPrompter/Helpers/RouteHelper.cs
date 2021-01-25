using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPrompter.Helpers
{
    public static class RouteHelper
    {
        #region Common
        public static string Address => GlobalConfiguration.ServiceAddress;
        public static string GetAllUsers => Address + @"User/GetAllUsers";
        public static string Login => Address + @"Login/Login";
        /// <summary>
        /// 0 => name,
        /// 1 => count
        /// </summary>
        public static string GetRelatedNames => Address + @"Common/GetRelatedNames/{0}/{1}";
        #endregion

        #region Plateform
        public static string GetAllPlateforms => Address + @"Plateform/GetAllPlateforms";
        public static string GetPlateforms => Address + @"Plateform/GetEntities";
        /// <summary>
        /// 0 => id
        /// </summary>
        public static string GetPlateformById => Address + @"Plateform/GetPlateformBy/{0}";
        #endregion
        
        

        #region Command
        public static string GetCommandsByFilter => Address + @"Command/GetCommandsByFilter";
        public static string GetCommandById => Address + @"Command/GetCommandById";
        public static string GetAllCommands => Address + @"Command/GetAllCommands";
        public static string GetCommands => Address + @"Command/GetEntities";
        #endregion

        #region Assist
        public static string ReplaceParam(string route, params string[] parameters)
        {
            var ret = route;
            for(int i = 0; i < parameters.Length; i++)
            {
                ret = ret.Replace("{" + i + "}", parameters[i]);
            }
            return ret;
        }
        #endregion

    }
}
