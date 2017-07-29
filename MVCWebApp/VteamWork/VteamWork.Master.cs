using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace VteamWork
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VTeamWorkDB db = new VTeamWorkDB();
         //   List<tbl_USER> users = db.tbl_USER.ToList();
            if (Session["userinfo"]==null)
            {
                Response.Redirect("~/Login.aspx");
            }

          
        }
    }
}