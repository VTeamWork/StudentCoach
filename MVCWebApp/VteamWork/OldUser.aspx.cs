using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VteamWork.Helper;
using System.Net.Mail;
using System.Net;
using Model.DataResponse;

namespace VteamWork
{
    public partial class OldUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Model.tbl_USER> GetUser()
        {

            return LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID != null && u.IS_ACTIVE=="0").Select(s => s);
        }




        protected void ActivateStu_Click(object sender, EventArgs e)
        {
            try
            {
                // string ID = e.CommandArgument.ToString();
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                var user = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == ID);
                user.USER_TYPE = "Student";
                user.USER_TYPE_ID = 2;
                user.IS_ACTIVE = "1";
                LoginHelper.db.SaveChanges();
                LoginHelper.SendEmail(user.EMAIL, "Activate Coach", "Welcome");
                Session["response"] = new Response() { IsError = false, Message = "Success" };
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                Session["response"] = new Response() { IsError = true, Message = ex.Message };
                Response.Redirect("Default.aspx");

            }
        }

        protected void ActivateCoach_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                var user = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == ID);
                user.USER_TYPE = "Coach";
                user.USER_TYPE_ID = 3;
                user.IS_ACTIVE = "1";
                LoginHelper.db.SaveChanges();
                LoginHelper.SendEmail(user.EMAIL, "Activate Coach", "Welcome");
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