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
            BindList();
        }

        public void BindList()
        {
            Response resp = LoginHelper.GetUserTypeList();

            List<tbl_USER_TYPE> List = (List<tbl_USER_TYPE>)resp.data;
            USER_TYPE.DataSource = List;
            USER_TYPE.DataTextField = "USER_TYPE";
            USER_TYPE.DataValueField = "USER_TYPE_ID";
            USER_TYPE.DataBind();
            // db were not successfully loaded
            USER_TYPE.Items.Insert(0, new ListItem("Select User Type", "0"));

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