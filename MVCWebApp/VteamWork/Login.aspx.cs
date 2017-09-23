using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Model;
using System.Web.UI.WebControls;
using VteamWork.Helper;
using Model.DataResponse;

namespace VteamWork
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            string User_name = string.Empty;
            string User_color = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                LOGIN_ID.Text = reqCookies["UserName"].ToString();
                PASSWORD.Attributes.Add("value", reqCookies["Password"].ToString());
                rememberme.Checked = true;
            }
                else
                {
                    LOGIN_ID.Text = null;
                    PASSWORD.Attributes.Add("value", null);
                    rememberme.Checked = false;

                }
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
           
            Response resp =  LoginHelper.Auth((tbl_USER)LoginHelper.BindData<tbl_USER>(this));
            if(!resp.IsError)
            {
                Session["userinfo"] = resp.data;
                
                if(rememberme.Checked)
                {
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["UserName"] = LOGIN_ID.Text;
                    userInfo["Password"] = PASSWORD.Text;
                    Response.Cookies.Add(userInfo);


                    
                   // Response.Cookies["username"] = LOGIN_ID.Text;
                }
                else
                {
                    HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies["userInfo"];
                    HttpContext.Current.Response.Cookies.Remove("userInfo");
                    currentUserCookie.Expires = DateTime.Now.AddDays(-10);
                    currentUserCookie.Value = null;
                    HttpContext.Current.Response.SetCookie(currentUserCookie);
                   


                }

                Response.Redirect("/");
            }
            LoginHelper.ShowAlert(resp, this.Alert);
        }
    }
}