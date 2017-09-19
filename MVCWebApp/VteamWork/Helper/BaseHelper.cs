using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Reflection;
using Model.DataResponse;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VteamWork.Helper
{
    public class BaseHelper
    {

        //public static VTeamWorkDB db { get { return new VTeamWorkDB(); } }
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
                        if (obj.GetType().GetProperty("Text") != null)
                            objinput.GetType().GetProperty(oPropertyInfo.Name).SetValue(objinput, obj.GetType().GetProperty("Text").GetValue(obj, null), null);
                        //else if (obj.GetType().GetProperty("checked") != null)
                        //        userinfo.GetType().GetProperty(oPropertyInfo.Name).SetValue(userinfo, obj.GetType().GetProperty("checked").GetValue(obj, null), null);
                        else if (obj.GetType().GetProperty("SelectedValue") != null)
                            objinput.GetType().GetProperty(oPropertyInfo.Name).SetValue(objinput, obj.GetType().GetProperty("Text").GetValue(obj, null), null);

                    }
                }
            }

            return objinput;
        }

        public static void ShowAlert(Response resp, Object obj)
        {
            global::System.Web.UI.HtmlControls.HtmlGenericControl Alert = (global::System.Web.UI.HtmlControls.HtmlGenericControl)obj;
            if (Alert != null)
            {
                if (resp.IsError)
                {

                    Alert.InnerHtml = "<div class=\"alert alert-danger\">" + resp.Message + "</div>";
                }
                else
                {
                    Alert.InnerHtml = "<div class=\"alert alert-success\">" + resp.Message + "</div>";

                }
            }

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

            return new Response() { IsError = false, Message = "Success" };
        }


        public static void SendEmail(string to, string subject, string msg)
        {

            MailMessage msgeme = new MailMessage("vteamwork@hotmail.com", to, subject, msg);
            SmtpClient smtpclient = new SmtpClient("smtp.live.com", 587);
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = new NetworkCredential("vteamwork@hotmail.com", "Team@123");
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.Send(msgeme);


        }

        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
        }
    }
}