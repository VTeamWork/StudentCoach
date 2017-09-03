using Model;
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
    public partial class Question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                BindModuleList();

        }
        public IQueryable<Model.tbl_QUESTION> GetQuestions()
        {

            return LoginHelper.db.tbl_QUESTION.Select(s => s);
        }
        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ListType.SelectedValue.ToString()))

            {
                try

                { 
                if (!string.IsNullOrEmpty(QuestionID.Value))
                {
                    int ID = Convert.ToInt32(QuestionID.Value);
                    tbl_QUESTION tbl_QUESTION = LoginHelper.db.tbl_QUESTION.FirstOrDefault(c=>c.QUESTION_ID==ID);
                    tbl_QUESTION.QUESTION_NAME = Name.Value;
                    tbl_QUESTION.QUESTION_DESCRITION = Description.Value;
                    tbl_QUESTION.MODULE_ID = Convert.ToInt32(ModuleList.SelectedValue);
                    tbl_QUESTION.UPDATED_ON = DateTime.Now;
                    tbl_QUESTION.user_type_id = Convert.ToInt32(ListType.SelectedValue);
                        tbl_QUESTION.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    LoginHelper.db.SaveChanges();
                }
                else { 

                tbl_QUESTION tbl_QUESTION = new tbl_QUESTION();
                tbl_QUESTION.QUESTION_NAME = Name.Value;
                tbl_QUESTION.QUESTION_DESCRITION = Description.Value;
                    tbl_QUESTION.MODULE_ID = Convert.ToInt32(ModuleList.SelectedValue);
                    tbl_QUESTION.CREATED_ON = DateTime.Now;
                tbl_QUESTION.CREATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    tbl_QUESTION.user_type_id = Convert.ToInt32(ListType.SelectedValue);

                    tbl_QUESTION.UPDATED_ON = DateTime.Now;
                tbl_QUESTION.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                LoginHelper.db.tbl_QUESTION.Add(tbl_QUESTION);
                }
                LoginHelper.db.SaveChanges();
                QuestionID.Value = null;
                Session["response"] = new Response() { IsError = false, Message = "Success" };
                

            }
            catch (Exception ex)
            {

                Session["response"] = new Response() { IsError = true, Message = ex.Message };
//                Response.Redirect("Default.aspx");

            }
        }
            else
            {
                Session["response"] = new Response() { IsError = true, Message = "Please Select User Type" };
                //              
            }
            Response.Redirect(Request.Url.ToString());


        }
        protected void EDITQUESTION_Click(object sender, EventArgs e)
        {
            try
            {
                // string ID = e.CommandArgument.ToString();
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                var question = LoginHelper.db.tbl_QUESTION.FirstOrDefault(u => u.QUESTION_ID == ID);
                QuestionID.Value = ID.ToString();
                Name.Value = question.QUESTION_NAME;
                Description.Value = question.QUESTION_DESCRITION;
                ModuleList.SelectedValue = question.MODULE_ID.ToString();
                //LoginHelper.db.SaveChanges();
                //  LoginHelper.SendEmail(user.EMAIL, "Activate Coach", "Welcome");
                // Session["response"] = new Response() { IsError = false, Message = "Success" };
                // Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                //              Session["response"] = new Response() { IsError = true, Message = ex.Message };
                //                Response.Redirect("Default.aspx");

            }
        }

        private void BindModuleList()
        {
        

            try
            {
                ModuleList.DataSource = LoginHelper.db.tbl_MODULE.Select(s => s).ToList();
                ModuleList.DataTextField = "MODULE_NAME";
                ModuleList.DataValueField = "MODULE_ID";
                ModuleList.DataBind();
            }
            catch (Exception ex)
            { }

        }
    }

}