using Model;
using Model.DataResponse;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VteamWork.Helper;
using static VteamWork.SubModule;

namespace VteamWork
{
    public partial class Question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindModuleList();

        }
        public IQueryable<Model.tbl_QUESTION> GetQuestions()
        {

            return LoginHelper.db.tbl_QUESTION.Where(u => u.USER_TYPE_ID == 2).Select(s => s);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(QuestionID.Value))
                {

                  
                    int ID = Convert.ToInt32(QuestionID.Value);
                    tbl_QUESTION tbl_QUESTION = LoginHelper.db.tbl_QUESTION.FirstOrDefault(c => c.QUESTION_ID == ID);
                    tbl_QUESTION.QUESTION_NAME = Name.Value;
                    tbl_QUESTION.QUESTION_DESCRITION = Description.Value;
                    tbl_QUESTION.MODULE_ID = Convert.ToInt32(ModuleList.SelectedValue);
                    tbl_QUESTION.UPDATED_ON = DateTime.Now;
                    tbl_QUESTION.USER_TYPE_ID = 2;
                    tbl_QUESTION.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    tbl_QUESTION.IsRequired = chkIs_Mendatory.Checked;
                    LoginHelper.db.SaveChanges();
                }
                else
                {
                    JArray array = JArray.Parse(table.Value);
                    List<Sub_Module> ranges = array.ToObject<List<Sub_Module>>();
                    ranges.ToList().ForEach(u =>
                    {
                        
                        tbl_QUESTION tbl_QUESTION = new tbl_QUESTION();
                        tbl_QUESTION.QUESTION_NAME = u.mdlName;
                        tbl_QUESTION.QUESTION_DESCRITION = u.mdlDesc;
                        tbl_QUESTION.MODULE_ID = Convert.ToInt32(ModuleList.SelectedValue);
                        tbl_QUESTION.CREATED_ON = DateTime.Now;
                        tbl_QUESTION.CREATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                        tbl_QUESTION.USER_TYPE_ID = 2;
                        tbl_QUESTION.UPDATED_ON = DateTime.Now;
                        tbl_QUESTION.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                        tbl_QUESTION.IsRequired = u.IsMndtry=="True"?true:false;
                        LoginHelper.db.tbl_QUESTION.Add(tbl_QUESTION);

                    });

                }
                LoginHelper.db.SaveChanges();
                QuestionID.Value = null;
                Session["response"] = new Response() { IsError = false, Message = "Success" };


            }
            catch (Exception ex)
            {
                Response resp;
                Exception Excep = LoginHelper.getExceptionMessage(ex);
                if (Excep != null && Excep.Message.ToLower().Contains("unique"))
                {
                    resp = new Response() { IsError = true, Message = "Question is Already Exist" };
                }

                else
                {
                    resp = new Response() { IsError = true, Message = "Error while saving data" };
                }
            }

            Response.Redirect(Request.Url.ToString());


        }
        protected void EDITQUESTION_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Visible = false;
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                var question = LoginHelper.db.tbl_QUESTION.FirstOrDefault(u => u.QUESTION_ID == ID);
                QuestionID.Value = ID.ToString();
                Name.Value = question.QUESTION_NAME;
                Description.Value = question.QUESTION_DESCRITION;
                ModuleList.SelectedValue = question.MODULE_ID.ToString();
                chkIs_Mendatory.Checked = (bool) question.IsRequired;
            }
            catch (Exception ex)
            {
            }
        }

        private void BindModuleList()
        {
            try
            {
                ModuleList.DataSource = LoginHelper.db.tbl_MODULE.Where(u => u.PARENT_MODULE_ID != null).Select(s => s).ToList();
                ModuleList.DataTextField = "MODULE_NAME";
                ModuleList.DataValueField = "MODULE_ID";
                ModuleList.DataBind();
            }
            catch (Exception ex)
            { }

        }
    }

}