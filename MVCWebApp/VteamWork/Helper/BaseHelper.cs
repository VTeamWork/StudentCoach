using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Reflection;
using Model.DataResponse;

namespace VteamWork.Helper
{
    public class BaseHelper
    {
        public static VTeamWorkDB db = new VTeamWorkDB();

        public static object BindData<T>(Object Page)
        {
           // Type objinput = typeof(T);
            T objinput = (T)Activator.CreateInstance(typeof(T)); 
            //T objinput = T.GetType().;
            foreach (PropertyInfo oPropertyInfo in objinput.GetType().GetProperties())
            {
                //Check the method is not static
                if (!oPropertyInfo.GetGetMethod().IsStatic)
                {
                    //Check this property can write
                    if (Page.GetType().GetProperty(oPropertyInfo.Name) != null)
                    {

                        //Update the properties on this object
                        var obj = Page.GetType().GetProperty(oPropertyInfo.Name).GetValue(Page, null);
                        //Page.GetType().GetProperty(oPropertyInfo.Name).GetValue(Page, null).GetType().GetProperty("Text").GetValue(Page.GetType().GetProperty(oPropertyInfo.Name).GetValue(Page, null), null)
                        if(obj.GetType().GetProperty("Text")!=null)
                            objinput.GetType().GetProperty(oPropertyInfo.Name).SetValue(objinput, obj.GetType().GetProperty("Text").GetValue(obj,null), null);
                        //else if (obj.GetType().GetProperty("checked") != null)
                        //        userinfo.GetType().GetProperty(oPropertyInfo.Name).SetValue(userinfo, obj.GetType().GetProperty("checked").GetValue(obj, null), null);
                        //else if (obj.GetType().GetProperty("SelectedValue") != null)
                        //    userinfo.GetType().GetProperty(oPropertyInfo.Name).SetValue(userinfo, obj.GetType().GetProperty("checked").GetValue(obj, null), null);

                    }
                }
            }

            return objinput;
        }
     
        public static void ShowAlert(Response resp,Object obj)
        {
      global::System.Web.UI.HtmlControls.HtmlGenericControl Alert = (global::System.Web.UI.HtmlControls.HtmlGenericControl)obj;
            if (Alert!=null)
            {
                Alert.InnerHtml = resp.Message;
                if (resp.IsError)
                {
                    Alert.Style.Add("color", "#fb483a !important");
                  
                }
                else
                {
                    Alert.Style.Add("color", "#2b982b");
                }
            }
           
        }   
    }
}