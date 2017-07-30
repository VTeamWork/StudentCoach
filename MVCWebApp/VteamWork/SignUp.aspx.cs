using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VteamWork.Helper;
using Model.DataResponse;
using Model;

namespace VteamWork
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Rigestered_Click(object sender, EventArgs e)
        {
            Response resp = LoginHelper.Save((tbl_USER)LoginHelper.BindData<tbl_USER>(this));
            if (!resp.IsError)
            {
                Session["userinfo"] = resp.data;
                Response.Redirect("/");
            }
        }
    }
}