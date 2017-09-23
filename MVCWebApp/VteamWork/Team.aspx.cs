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
                tbl_USER coachlist = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.TEAM_ID == ID && u.USER_TYPE_ID == 3);

                CoachList.SelectedValue = coachlist.USER_ID.ToString();

                List<tbl_USER> studentLst = LoginHelper.db.tbl_USER.Where(u => u.TEAM_ID == ID && u.USER_TYPE_ID==2).Select(s => s).ToList();

                foreach (ListItem item in lstStudents.Items)
                {
                    item.Selected = false;
                }
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
            Response Saveresp = new Response();
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
            int CoachID = Convert.ToInt32(CoachList.SelectedValue);
                    var user = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == CoachID && u.USER_TYPE_ID == 3 && u.TEAM_ID != null);
                    if(user==null)
                    {
                        var cuser = LoginHelper.db.tbl_USER.FirstOrDefault(u =>u.USER_ID==CoachID &&  u.USER_TYPE_ID == 3);
                        cuser.TEAM_ID = team.TEAM_ID;
                        LoginHelper.db.SaveChanges();
                        Session["response"] = new Response() { IsError = false, Message = "Success" };
                    }
                    else
                    {
                        Session["response"] = new Response() { IsError = true, Message = CoachList.SelectedItem.Text + " alredy assigned to another team!" };
                    }

                    if(!((Response)(Session["response"])).IsError)
                    { 
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
                                Session["response"] = new Response() { IsError = false, Message = "Success" };
                            }
                            else
                            {
                                Session["response"] = new Response() { IsError = true, Message = item.Text + " alredy assigned to another team!" };
                                tbl_TEAM tblteam = LoginHelper.db.tbl_TEAM.FirstOrDefault(u => u.TEAM_ID == team.TEAM_ID);
                                LoginHelper.db.tbl_TEAM.Remove(tblteam);
                                LoginHelper.db.SaveChanges();

                                break;
                            }

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
                    LoginHelper.db.SaveChanges();
                    int teamID = Convert.ToInt32(TeamID.Value);
                                        int CoachID = Convert.ToInt32(CoachList.SelectedValue);
                    var oldcoach = LoginHelper.db.tbl_USER.FirstOrDefault(u =>  u.USER_TYPE_ID == 3 && u.TEAM_ID == teamID);
                    if(oldcoach==null || oldcoach.USER_ID!=CoachID)
                    {
                    if(oldcoach != null)
                    { 
                    oldcoach.TEAM_ID = null;
                    LoginHelper.db.SaveChanges();
                     }
                        var user = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID==CoachID && u.USER_TYPE_ID == 3 && u.TEAM_ID != null);
                    if (user == null)
                    {
                        var cuser = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == CoachID && u.USER_TYPE_ID == 3);
                        cuser.TEAM_ID = team.TEAM_ID;
                        Session["response"] = new Response() { IsError = false, Message = "Success" };

                    }
                    else
                    {
                        oldcoach.TEAM_ID = teamID;
                        LoginHelper.db.SaveChanges();
                        Session["response"] = new Response() { IsError = true, Message = CoachList.SelectedItem.Text + " alredy assigned to another team!" };
                    }
                    }
else
                    {
                        Session["response"] = new Response() { IsError = false, Message = "Success" };

                    }
                    if (!((Response)(Session["response"])).IsError)
                    {
                       
                        List<tbl_USER> Studentlst = LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID == 2 && u.TEAM_ID == teamID).Select(s => s).ToList();

                        foreach (tbl_USER item in Studentlst)
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
                                Studentlst = LoginHelper.db.tbl_USER.Where(u => u.USER_ID == itemid && u.USER_TYPE_ID == 2 && u.TEAM_ID != null).Select(s => s).ToList();

                                if (Studentlst.Count == 0)
                                {
                                    tbl_USER tbluser = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == itemid);
                                    tbluser.TEAM_ID = team.TEAM_ID;
                                    tbluser.UPDATED_ON = DateTime.Now;
                                    tbluser.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                                    LoginHelper.db.SaveChanges();
                                    Session["response"] = new Response() { IsError = false, Message = "Success" };
                                }
                                else
                                {

                                    foreach (tbl_USER item2 in Studentlst)
                                    {
                                        
                                        itemid = Convert.ToInt32(item2.USER_ID);
                                        tbl_USER tbluser = LoginHelper.db.tbl_USER.FirstOrDefault(u => u.USER_ID == itemid);
                                        tbluser.TEAM_ID = teamID;
                                        tbluser.UPDATED_ON = DateTime.Now;
                                        tbluser.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                                        LoginHelper.db.SaveChanges();

                                    }

                                    Session["response"] = new Response() { IsError = true, Message = item.Text + " alredy assigned to another team!" };
                                    break;
                                }
                            }
                        }

                    }
                }
                Model.DataResponse.Response resp = (Model.DataResponse.Response)Session["Response"];
                if (!resp.IsError)
                {
                    Session["response"] = new Response() { IsError = false, Message = "Success" };
                }

            }
            catch (Exception ex)
            {
                

                //    var sqlException = ex.InnerException as System.Data.SqlClient.SqlException;
                //if(sqlException.)
                Exception Excep = LoginHelper.getExceptionMessage(ex);
                //if (sqlException.Number == 2601 || sqlException.Number == 2627)
                if (Excep != null && Excep.Message.ToLower().Contains("unique"))
                {
                    Saveresp = new Response() { IsError = true, Message = "Team Name is Already Exist" };
                    //        ErrorMessage = "Cannot insert duplicate values.";
                }
                else
                {
                    Saveresp = new Response() { IsError = true, Message = "Error while saving data" };

                    //      ErrorMessage = "Error while saving data.";
                }

                LoginHelper.db = new VTeamWorkDB();
            Session["response"] = Saveresp;

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
                CoachList.DataSource =  LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID == 3).Select(s => s).ToList();
                CoachList.DataTextField = "FIRST_NAME";
                CoachList.DataValueField = "USER_ID";
                CoachList.DataBind();
            }
            catch( Exception ex)
            { }

            


        }
    }
}