using Model.DataResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VteamWork.Helper;

namespace VteamWork
{
    public partial class AssignTeamMdoule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                BindModuleList();
                BindTeamList();
            }
        }
        public List<Model.tbl_TEAM_MODULE> GetTeamModules()
        {
            return LoginHelper.db.tbl_TEAM_MODULE.ToList();
            //return LoginHelper.db.tbl_TEAM_MODULE.AsQueryable();
        }
        
        private void BindModuleList()
        {try
            {
                var lst = LoginHelper.db.tbl_MODULE.Where(u => u.PARENT_MODULE_ID == null).Select(s => s).ToList();
                ModuleList.DataSource = lst;
                //ModuleList.DataTextFormatString = "{0} {1}";
                ModuleList.DataTextField = "MODULE_NAME";
                ModuleList.DataValueField = "MODULE_ID";
                ModuleList.DataBind();
            }
            catch (Exception ex)
            { }

        }
        protected void EDITASSIGN_Click(object sender, EventArgs e)
        {
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int teamid =  Convert.ToInt32(TeamList.SelectedValue);
                var removedata = LoginHelper.db.tbl_TEAM_MODULE.Where(t => t.team_id == teamid);
                LoginHelper.db.tbl_TEAM_MODULE.RemoveRange(removedata.ToList());
                LoginHelper.db.SaveChanges();
                var query = from ListItem item in ModuleList.Items where item.Selected select item;
                List<Model.tbl_TEAM_MODULE> Insertlist = new List<Model.tbl_TEAM_MODULE>();
                foreach (ListItem item in query)
                {
                    Model.tbl_TEAM_MODULE tm = new Model.tbl_TEAM_MODULE();
                    tm.module_id = Convert.ToInt32(item.Value);
                    tm.team_id = Convert.ToInt32(TeamList.SelectedValue);

                    Insertlist.Add(tm);

                }

                LoginHelper.db.tbl_TEAM_MODULE.AddRange(Insertlist);
                LoginHelper.db.SaveChanges();
                Session["Response"] = new Response() { IsError = false,Message="Success"};
            }
            catch (Exception ex)
            {
                Session["Response"] = new Response() { IsError = false, Message = "Success" };
            }
            Response.Redirect(Request.Url.ToString());


        }
        private void BindTeamList()
        {


            try
            {
                TeamList.DataSource = LoginHelper.db.tbl_TEAM.Select(s => s).ToList();
                TeamList.DataTextField = "TEAM_NAME";
                TeamList.DataValueField = "TEAM_ID";
                TeamList.DataBind();
            }
            catch (Exception ex)
            { }

        }
    }
}