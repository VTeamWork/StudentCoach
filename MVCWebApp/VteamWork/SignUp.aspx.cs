﻿using System;
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
            if(!IsPostBack)
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
            tbl_USER tblUser = new tbl_USER();
            tblUser.CREATED_BY = FIRST_NAME.Text.ToString();
            tblUser.UPDATED_BY = FIRST_NAME.Text.ToString();
            tblUser.CREATED_ON = DateTime.Now;
            tblUser.UPDATED_ON = DateTime.Now;
            tblUser.IS_ACTIVE = "0";
            tblUser.IS_DELETED = "0";
            tblUser.USER_TYPE = USER_TYPE.SelectedValue;
            tblUser.USER_TYPE_ID = Convert.ToInt32( USER_TYPE.SelectedValue);
            tblUser.FIRST_NAME = FIRST_NAME.Text.ToString();
            tblUser.LAST_NAME = LAST_NAME.Text.ToString();
            tblUser.COMMENTS = COMMENTS.Value.ToString();
            tblUser.SKYPE_ID = SKYPE_ID.Text.ToString();
            tblUser.ENROLL_DATE = Convert.ToDateTime(ENROLL_DATE.Text);
            tblUser.PASSWORD = PASSWORD.Text.ToString();
            tblUser.MOBILE_NO = MOBILE_NO.Text.ToString() ;
            tblUser.CITY = CITY.Text.ToString();
            tblUser.EMAIL = EMAIL.Text.ToString();

            Response resp = LoginHelper.Save(tblUser);
            if (!resp.IsError)
            {
              
            }
            //LoginHelper.ShowAlert(resp, this.Alert);
        }
    }
}