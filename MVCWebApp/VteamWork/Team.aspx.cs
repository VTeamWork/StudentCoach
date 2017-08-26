using Model;
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
            if (!IsPostBack)
            {
                BindList();
            }
        
        }

        public IQueryable<Model.tbl_TEAM> GetUser()
        {
            return LoginHelper.db.tbl_TEAM.Select(s => s);
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
            try
            {
                tbl_TEAM tblTeam = new tbl_TEAM();
                tblTeam.TEAM_NAME = txtTeamName.Text;
                tblTeam.TEAM_DESCRITION = txtDescription.Text;
                tblTeam.CREATED_ON = DateTime.Now;
                tblTeam.CREATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                tblTeam.UPDATED_ON = DateTime.Now;
                tblTeam.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                LoginHelper.db.tbl_TEAM.Add(tblTeam);
                LoginHelper.db.SaveChanges();
    
                    foreach (ListItem item in lstStudents.Items)
                    {
                    int itemid = 0;
                        if (item.Selected)
                        {
                        itemid = Convert.ToInt32(item.Value);
                           tbl_USER tbluser= LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == itemid);
                            tbluser.TEAM_ID = tblTeam.TEAM_ID;
                            tbluser.UPDATED_ON = DateTime.Now;
                            tbluser.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                            LoginHelper.db.SaveChanges();
                        }
                    }
                

                Session["response"] = new Response() { IsError = false, Message = "Success" };
                Response.Redirect("Default.aspx");


            }
            catch (Exception ex)
            {

                Session["response"] = new Response() { IsError = true, Message = ex.Message };
                Response.Redirect("Default.aspx");

            }
           
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