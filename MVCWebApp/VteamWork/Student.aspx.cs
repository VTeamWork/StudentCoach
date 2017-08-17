using Model.DataResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VteamWork.Helper;

namespace VteamWork
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Model.tbl_USER> GetUser()
        {
            return LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID == 2).Select(s => s);
        }

        protected void Deactivate_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                var user = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == ID);
                user.USER_TYPE = "";
                user.USER_TYPE_ID = null;
                user.IS_ACTIVE = "0";
                LoginHelper.db.SaveChanges();
                LoginHelper.SendEmail(user.EMAIL, "De-Activate Student", "De Activate");
                Session["response"] = new Response() { IsError = false, Message = "Success" };
                Response.Redirect("Default.aspx");

            }
            catch (Exception ex)
            {
                Session["response"] = new Response() { IsError = true, Message = ex.Message };
                Response.Redirect("Default.aspx");

            }
        }

        protected void ResetPwd_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                var user = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == ID);
                LoginHelper.db.SaveChanges();
                LoginHelper.SendEmail(user.EMAIL, "Reset Password", "Your Password is " + user.PASSWORD);
                Session["response"] = new Response() { IsError = false, Message = "Success" };

            }
            catch (Exception ex)
            {
                Session["response"] = new Response() { IsError = true, Message = ex.Message };

            }
            Response.Redirect("Default.aspx");

        }

    }
}