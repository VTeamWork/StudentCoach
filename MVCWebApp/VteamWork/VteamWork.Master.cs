using System;
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

        }
            public string dynamicMenu(tbl_USER user)
        {
            string txtHTML = "";

            Response resp = LoginHelper.GetMenuList(user);
            if(resp.IsError==false)
            { 
            List<tbl_MENU_GROUP> menuList = (List<tbl_MENU_GROUP>)resp.data;
                if (menuList.Count > 0)
                {
                    txtHTML += @"<li>";
                    foreach (var lst in menuList)
                    {
                       
                        if (lst.PARENT_MENU_GROUP_ID == 0)
                        {
                            txtHTML += " <a href = \"javascript:void(0);\" class=\"menu-toggle\"><span>" + lst.MENU_GROUP_NAME + "</span></a> ";
                        }
                        else
                        {

                             resp = LoginHelper.GetPageList((int)lst.MENU_GROUP_ID);
                            if (resp.IsError == false)
                            {
                                List<tbl_PAGE> pageList = (List<tbl_PAGE>)resp.data;
                                if(pageList.Count>0)
                                {
                                    txtHTML += "<ul class=\"ml-menu\"><li>";
                                    txtHTML += " <a href = \"javascript:void(0);\" class=\"menu-toggle\"><span>" + lst.MENU_GROUP_NAME + "</span></a> ";
                                    txtHTML += "<ul class=\"ml-menu\">";
                                    foreach (var lst2 in pageList)
                                    {
                                        txtHTML += "<li><a href = \"" + lst2.PAGE_PATH + "\" > " + lst2.PAGE_NAME + "</a></ li >";
                                     }
                                    txtHTML += "</ul>";
                                    txtHTML += "</li></ul>";
                                }
                            }
                        }
                    }
                    txtHTML += @"</li>";
                }
            }

            return txtHTML;
        }
    }
}