﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using VteamWork.Helper;
using Model.DataResponse;

namespace VteamWork
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VTeamWorkDB db = new VTeamWorkDB();
            //   List<tbl_USER> users = db.tbl_USER.ToList();
            if (Session["userinfo"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {

                lblUserName.Text = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                lblEmail.Text = ((tbl_USER)Session["userinfo"]).EMAIL.ToString();

                innerHtml.Text = dynamicMenu(((tbl_USER)Session["userinfo"]));
            }

            if (Session["Response"] != null)
            {
                Model.DataResponse.Response resp = (Model.DataResponse.Response)Session["Response"];
                LoginHelper.ShowAlert(resp, this.Alert);
                Session["Response"] = null;
            }

        }
            public string dynamicMenu(tbl_USER user)
        {
            string txtHTML = "";

            Response resp = LoginHelper.GetMenuList( user.USER_TYPE_ID,user);
            if(resp.IsError==false)
            { 
            List<tbl_MENU_GROUP> menuList = (List<tbl_MENU_GROUP>)resp.data;
                if (menuList.Count > 0)
                {
                    txtHTML += @"<li>";
                    foreach (var lst in menuList)
                    {
                        int m_id = 0;
                        var lstMenu = LoginHelper.db.tbl_MENU_GROUP.Where(c => c.PARENT_MENU_GROUP_ID == lst.MENU_GROUP_ID).ToList();
                        if (lstMenu.Count > 0)
                        {
                            m_id = lstMenu[0].MENU_GROUP_ID;
                        }
                           
                        var lstparentMenu = LoginHelper.db.tbl_ROLE_PAGE.Where(c => c.tbl_PAGE.MENU_GROUP_ID == m_id  && c.tbl_ROLE.ROLE_ID == user.USER_TYPE_ID).ToList();
                        if (lst.PARENT_MENU_GROUP_ID == 0 && lstparentMenu.Count>0)
                        {
                            txtHTML += " <a href = \"javascript:void(0);\" class=\"menu-toggle\"><span>" + lst.MENU_GROUP_NAME + "</span></a> ";
                        }
                        else
                        {

                             resp = LoginHelper.GetPageList((int)lst.MENU_GROUP_ID,user.USER_TYPE_ID);
                            if (resp.IsError == false)
                            {
                                List<tbl_PAGE> pageList = (List<tbl_PAGE>)resp.data;
                                if(pageList.Count>0)
                                {
                                    txtHTML += "<ul class=\"ml-menu\" style=\"display:block\"><li>";
                                    txtHTML += " <a href = \"javascript:void(0);\" class=\"menu-toggle waves-effect waves-block\"><span>" + lst.MENU_GROUP_NAME + "</span></a> ";
                                    txtHTML += "<ul class=\"ml-menu \" style=\"display:block\">";
                                    foreach (var lst2 in pageList)
                                    {
                                     string currentpage = Request.Url.ToString().Split('/')[Request.Url.ToString().Split('/').Length-1];
                                        if(currentpage== lst2.PAGE_PATH)
                                        { txtHTML += "<li class='active' style=\"dislay:block\">"; }
                                        else
                                        {

                                            txtHTML += "<li>";
                                        }
                                        txtHTML += "<a href = \"" + lst2.PAGE_PATH + "\" > " + lst2.PAGE_NAME + "</a></ li >";
                                     }
                                    txtHTML += "</ul>";
                                    txtHTML += "</li>"; 
                                }
                            }
                        }
                    }
                    txtHTML += @"</ul></li>";
                }
            }

            return txtHTML;
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["userinfo"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}