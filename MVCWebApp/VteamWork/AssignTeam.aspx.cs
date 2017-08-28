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
        public IQueryable<Model.tbl_TEAM_MODULE> GetTeamModules()
        {

            return LoginHelper.db.tbl_TEAM_MODULE.Select(s => s);
        }
        
        private void BindModuleList()
        {try
            {
                ModuleList.DataSource = LoginHelper.db.tbl_MODULE.Select(s => s).ToList();
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
                ModuleList.DataSource = LoginHelper.db.tbl_TEAM.Select(s => s).ToList();
                ModuleList.DataTextField = "TEAM_NAME";
                ModuleList.DataValueField = "TEAM_ID";
                ModuleList.DataBind();
            }
            catch (Exception ex)
            { }

        }
    }
}