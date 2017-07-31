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

        public static Response Save(object obj)
        {
            string class_name = obj.GetType().Name;
            object class_object = db.GetType().GetProperty(class_name).GetType();
            //MethodInfo method = class_object.GetType().GetMethod("Add");
            //object[] list = { obj };

            //method.Invoke(class_object.GetType(), list);


            //dynamic dbSet = db.GetType().GetProperty(class_name, BindingFlags.Public | BindingFlags.Instance).GetValue(db, null);
            //dbSet.Add(class_object);
            //dbSet.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance).Invoke(new object[] { class_object });

            db.tbl_USER.Add((tbl_USER)obj);
            db.SaveChanges();

            return new Response() { IsError=false,Message="Success"};
        }
    }
}