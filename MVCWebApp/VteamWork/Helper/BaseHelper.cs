using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Reflection;

namespace VteamWork.Helper
{
    public class BaseHelper
    {
        public static VTeamWorkDB db = new VTeamWorkDB();

        public static tbl_USER BindData(Object Page)
        {
            tbl_USER userinfo = new tbl_USER();
            foreach (PropertyInfo oPropertyInfo in userinfo.GetType().GetProperties())
            {
                //Check the method is not static
                if (!oPropertyInfo.GetGetMethod().IsStatic)
                {
                    //Check this property can write
                    if (Page.GetType().GetMember(oPropertyInfo.Name) != null)
                    {
                       
                            //Update the properties on this object
                            userinfo.GetType().GetProperty(oPropertyInfo.Name).SetValue(userinfo, Page.GetType().GetProperty(oPropertyInfo.Name).GetValue(Page, null), null);
                        
                    }
                }
            }

            return userinfo;
        }
        
    }
}