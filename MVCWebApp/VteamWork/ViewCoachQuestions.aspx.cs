﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VteamWork.Helper;

namespace VteamWork
{
    public partial class ViewCoachQuestions : System.Web.UI.Page
    {


        public List<Model.tbl_MODULE> GetViewStudent(int? TeamID = null)
        {
            if (TeamID == null)
                return LoginHelper.db.tbl_MODULE.Where(c => c.PARENT_MODULE_ID == null).OrderBy(x => x.MODULE_NAME).ToList();
            else
                return LoginHelper.db.tbl_TEAM_MODULE.Where(c => c.team_id == TeamID && c.tbl_MODULE.PARENT_MODULE_ID == null).Select(c => c.tbl_MODULE).OrderBy(x => x.MODULE_NAME).ToList();
            //return LoginHelper.db.tbl_TEAM_MODULE.AsQueryable();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTeamList();

                if (string.IsNullOrEmpty(TeamList.SelectedValue))
                {
                    Binddata();

                }
                else
                {
                    int? TeamID = Convert.ToInt32(TeamList.SelectedValue);
                    Binddata(TeamID);
                }
            }

        }

        private void BindTeamList()
        {


            try
            {
                TeamList.DataSource = LoginHelper.db.tbl_TEAM.Select(s => s).OrderBy(x => x.TEAM_NAME).ToList();
                TeamList.DataTextField = "TEAM_NAME";
                TeamList.DataValueField = "TEAM_ID";
                TeamList.DataBind();
                try
                {
                    TeamList.SelectedValue = LoginHelper.db.tbl_TEAM.Select(s => s.TEAM_ID).ToList().LastOrDefault().ToString();
                }
                catch (Exception)
                {
                }
            }
            catch (Exception ex)
            { }

        }
        private void Binddata(int? TeamID = null)
        {
            List<Model.tbl_MODULE> list = new List<Model.tbl_MODULE>();
            if (TeamID == null)
            {
                list = GetViewStudent();

            }
            else
            {
                list = GetViewStudent(TeamID);

            }


            foreach (var mainmodule in list)
            {
                HtmlGenericControl myDiv = new HtmlGenericControl("div");
                myDiv.ID = "MainModule" + mainmodule.MODULE_ID;
                HtmlGenericControl maincontrol = new HtmlGenericControl("h3");
                maincontrol.InnerHtml = mainmodule.MODULE_NAME;
                myDiv.Controls.Add(maincontrol);
                char Alpha = 'A';
                DataShow.Controls.Add(myDiv);
                HtmlGenericControl listsbmod = new HtmlGenericControl("ul");

                foreach (var questions in mainmodule.tbl_QUESTION)
                {

                    HtmlGenericControl listitem = new HtmlGenericControl("li");
                    if (questions.IsRequired == true)
                    {
                        listitem.Attributes.Add("class", "RequiredQuestion");
                    }
                    listitem.InnerHtml = questions.QUESTION_NAME;
                    listsbmod.Controls.Add(listitem);
                    //myDiv.Controls.Add(new Label() { Text = questions.QUESTION_NAME });

                }
                
                myDiv.Controls.Add(listsbmod);


            }

        }


        protected void Search_Click(object sender, EventArgs e)
        {
            DataShow.InnerHtml = "";
            if (String.IsNullOrEmpty(TeamList.SelectedValue))
            {
                Binddata(null);
            }
            else
            {
                int TeamID = Convert.ToInt32(TeamList.SelectedValue);
                Binddata(TeamID);
            }
        }
    }
}