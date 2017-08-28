﻿using Model;
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
        Model.tbl_TEAM team;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        
        }
        public IQueryable<Model.tbl_TEAM> GetUser()
        {
            return LoginHelper.db.tbl_TEAM.Select(s => s);
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // string ID = e.CommandArgument.ToString();
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                team = LoginHelper.db.tbl_TEAM.FirstOrDefault(u => u.TEAM_ID == ID);
                TeamID.Value = ID.ToString();
                txtTeamName.Text = team.TEAM_NAME;
                txtDescription.Text = team.TEAM_DESCRITION;

                List<tbl_USER> studentLst = LoginHelper.db.tbl_USER.Where(u => u.TEAM_ID == ID).Select(s => s).ToList();
                foreach (tbl_USER item in studentLst)
                {
                    lstStudents.Items.FindByValue(item.USER_ID.ToString()).Selected=true;
                }

            }
            catch (Exception ex)
            {
                Session["response"] = new Response() { IsError = true, Message = ex.Message };
            }
  
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TeamID.Value))
                {
                    team = new Model.tbl_TEAM();
                    team.TEAM_NAME = txtTeamName.Text;
                    team.TEAM_DESCRITION = txtDescription.Text;
                    team.CREATED_ON = DateTime.Now;
                    team.CREATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    team.UPDATED_ON = DateTime.Now;
                    team.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    LoginHelper.db.tbl_TEAM.Add(team);
                    LoginHelper.db.SaveChanges();


                    foreach (ListItem item in lstStudents.Items)
                    {
                        int itemid = 0;
                        if (item.Selected)
                        {
                            itemid = Convert.ToInt32(item.Value);
                            var Studentlst = LoginHelper.db.tbl_USER.Where(u => u.USER_ID==itemid && u.USER_TYPE_ID == 2 && u.TEAM_ID != null).Select(s => s).ToList();

                            if (Studentlst.Count == 0)
                            {
                                tbl_USER tbluser = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == itemid);
                                tbluser.TEAM_ID = team.TEAM_ID;
                                tbluser.UPDATED_ON = DateTime.Now;
                                tbluser.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                                LoginHelper.db.SaveChanges();
                            }
                            else
                            {
                                Session["response"] = new Response() { IsError = true, Message = item.Text + "This student alredy assigned" };
                                break;
                            }

                        }
                    }
                }
                else
                {

                    team = LoginHelper.db.tbl_TEAM.FirstOrDefault(u => u.TEAM_ID.ToString() == TeamID.Value);
                    team.TEAM_NAME = txtTeamName.Text;
                    team.TEAM_DESCRITION = txtDescription.Text;
                    team.CREATED_ON = DateTime.Now;
                    team.CREATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    team.UPDATED_ON = DateTime.Now;
                    team.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    LoginHelper.db.tbl_TEAM.Add(team);
                    LoginHelper.db.SaveChanges();

                    int teamID = Convert.ToInt32(TeamID.Value);
                   var Studentlst= LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID == 2 && u.TEAM_ID == teamID).Select(s => s).ToList();

                    foreach (tbl_USER item in lstStudents.Items)
                    {
                        int itemid = 0;
                            itemid = Convert.ToInt32(item.USER_ID);
                            tbl_USER tbluser = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == itemid);
                            tbluser.TEAM_ID = null;
                            tbluser.UPDATED_ON = DateTime.Now;
                            tbluser.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                            LoginHelper.db.SaveChanges();
                        
                    }


                    foreach (ListItem item in lstStudents.Items)
                    {
                        int itemid = 0;
                        if (item.Selected)
                        {
                            itemid = Convert.ToInt32(item.Value);
                            tbl_USER tbluser = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == itemid);
                            tbluser.TEAM_ID = team.TEAM_ID;
                            tbluser.UPDATED_ON = DateTime.Now;
                            tbluser.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                            LoginHelper.db.SaveChanges();
                        }
                    }

                }
                Session["response"] = new Response() { IsError = false, Message = "Success" };


            }
            catch (Exception ex)
            {

                Session["response"] = new Response() { IsError = true, Message = ex.Message };

            }
            Response.Redirect("Default.aspx");


        }
        public void BindList()
        {
            try
            {
                lstStudents.DataSource = LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID == 2).Select(s => s).ToList();
                lstStudents.DataTextField = "FIRST_NAME";
                lstStudents.DataValueField = "USER_ID";
                lstStudents.DataBind();
            }
            catch( Exception ex)
            { }

            


        }
    }
}