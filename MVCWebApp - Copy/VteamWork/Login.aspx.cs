﻿using System;
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
           
        }

        protected void Login_Click(object sender, EventArgs e)
        {
           
            Response resp =  LoginHelper.Auth((tbl_USER)LoginHelper.BindData<tbl_USER>(this));
            if(!resp.IsError)
            {
                Session["userinfo"] = resp.data;
            Response.Redirect("/");
            }
            LoginHelper.ShowAlert(resp, this.Alert);
        }
    }
}