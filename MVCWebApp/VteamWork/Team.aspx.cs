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
    public partial class Team : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Model.tbl_USER> GetUser()
        {
            return LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID == 2).Select(s => s);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DivAdd.Visible = true;

            }
            catch (Exception ex)
            {
                Session["response"] = new Response() { IsError = true, Message = ex.Message };

            }
      

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GridDiv.Visible = true;
     

            }
            catch (Exception ex)
            {
     

            }
            

        }


        protected void lnkEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
        }
    }
}