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
    public partial class TeamReview : System.Web.UI.Page
    {
        Model.TeamReview ReviewObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
   
                BindTeamList();
            }
        }
        public List<Model.TeamReview> GetTeamModules()
        {
            return LoginHelper.db.TeamReviews.ToList();
            //return LoginHelper.db.tbl_TEAM_MODULE.AsQueryable();
        }
        

        protected void EDITASSIGN_Click(object sender, EventArgs e)
        {
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(ReviewID.Value))
                {
                    ReviewObj = new Model.TeamReview();
                    ReviewObj.TeamReviewComment = Comments.Text;
                    ReviewObj.TeamID = Convert.ToInt32(TeamList.SelectedValue);
                    ReviewObj.CoachID= Convert.ToInt32(ModuleList.SelectedValue);
                    LoginHelper.db.TeamReviews.Add(ReviewObj);

                }
                else
                {

                    ReviewObj = LoginHelper.db.TeamReviews.FirstOrDefault(u => u.TeamReviewID.ToString() == ReviewID.Value);
                    ReviewObj.TeamReviewComment = Comments.Text;
                    ReviewObj.TeamID = Convert.ToInt32(TeamList.SelectedValue);
                    ReviewObj.CoachID = Convert.ToInt32(ModuleList.SelectedValue);

                }
                LoginHelper.db.SaveChanges();
                ReviewID.Value = null;
                Session["response"] = new Response() { IsError = false, Message = "Success" };
                //                 Response.Redirect(Request.Url.ToString());
            }

            catch (Exception ex)
            {
            }




            Response.Redirect(Request.Url.ToString());


        }

        protected void EDITMODULE_Click(object sender, EventArgs e)
        {
            try
            {
                // string ID = e.CommandArgument.ToString();
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                edit(ID);


            }
            catch (Exception ex)
            {
                //              Session["response"] = new Response() { IsError = true, Message = ex.Message };
                //                Response.Redirect("Default.aspx");

            }
        }
        private void BindTeamList()
        {


            try
            {
                TeamList.DataSource = LoginHelper.db.tbl_TEAM.Select(s => s).ToList();
               
                TeamList.DataTextField = "TEAM_NAME";
                TeamList.DataValueField = "TEAM_ID";
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Please Select");
            }
            catch (Exception ex)
            { }

        }

        private void edit (int id)
        {
            ReviewObj = LoginHelper.db.TeamReviews.FirstOrDefault(u => u.TeamReviewID == id);
            ReviewID.Value = id.ToString();
            Comments.Text = ReviewObj.TeamReviewComment;
            TeamList.SelectedValue = ReviewObj.TeamID.ToString();
            ModuleList.SelectedValue = ReviewObj.CoachID.ToString() ;

        }

        protected void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
           int teamid = Convert.ToInt32(TeamList.SelectedValue);
            //var  teamobj=LoginHelper.db.TeamReviews.FirstOrDefault(u => u.TeamID == teamid);
            //  edit(teamobj.TeamReviewID);
            BindModuleList(teamid);


        }

        private void BindModuleList(int parentModuleID)
        {
            try
            {
                var lst = LoginHelper.db.tbl_TEAM_MODULE.Where(u => u.team_id == parentModuleID).Select(s => s.tbl_MODULE).OrderBy(x => x.MODULE_NAME).ToList();
                var lstQuery = lst.Select(p => new { MODULE_ID = p.MODULE_ID, DisplayText = p.MODULE_NAME.ToString() + " " + p.MODULE_DESCRITION });
                ModuleList.DataSource = lstQuery;
                ModuleList.DataTextField = "DisplayText";
                ModuleList.DataValueField = "MODULE_ID";
                ModuleList.DataBind();
            }
            catch (Exception ex)
            { }

        }
    }
}