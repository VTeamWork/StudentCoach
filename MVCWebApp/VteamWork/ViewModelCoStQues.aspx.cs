using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using VteamWork.Helper;

namespace VteamWork
{
    public partial class ViewModelCoStQues : System.Web.UI.Page
    {

        List<TextBox> listtextbox = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                BindTeamList();
            }
            else
            {
                int? teamID = null;
                if (!string.IsNullOrEmpty(TeamList.SelectedValue))
                {
                    teamID = Convert.ToInt32(TeamList.SelectedValue);
                    // teamID = ((Model.tbl_USER)Session["userinfo"]).TEAM_ID;
                }


                if (teamID == null)
                    Binddata();
                else
                    Binddata(teamID);


            }
        }

        private void BindStudentList()
        {
            try
            {
                int teamid = Convert.ToInt32(TeamList.SelectedValue);
                var lst = LoginHelper.db.tbl_USER.Where(u => u.USER_TYPE_ID == 2 && u.TEAM_ID == teamid).Select(s => s).OrderBy(x => x.LOGIN_ID).ToList();
                var lstQuery = lst.Select(p => new { USER_ID = p.USER_ID, DisplayText = p.FIRST_NAME.ToString() });

                studentist.DataSource = lstQuery;
                //ModuleList.DataTextFormatString = "{0} {1}";
                studentist.DataTextField = "DisplayText";
                studentist.DataValueField = "USER_ID";
                studentist.DataBind();
            }
            catch (Exception ex)
            { }

        }
        protected void EDITASSIGN_Click(object sender, EventArgs e)
        {

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int? teamID = null;
            if (!string.IsNullOrEmpty(TeamList.SelectedValue))
            {
                teamID = Convert.ToInt32(teamID);
                // teamID = ((Model.tbl_USER)Session["userinfo"]).TEAM_ID;
            }


            if (teamID == null)
                Binddata();
            else
                Binddata(teamID);


        }
        private void BindTeamList()
        {


            try
            {
                TeamList.DataSource = LoginHelper.db.tbl_TEAM.Select(s => s).OrderBy(x => x.TEAM_NAME).ToList();
                TeamList.DataTextField = "TEAM_NAME";
                TeamList.DataValueField = "TEAM_ID";
                TeamList.DataBind();
            }
            catch (Exception ex)
            { }

        }



        public string GeTTextValue(int questionID)
        {
            string answeer = "";

            listtextbox = (List<TextBox>)Session["textboxList"];


            foreach (var item in listtextbox)
            {
                if (item.ID.ToLower().Contains("text_" + questionID.ToString() + "_" + studentist.SelectedValue))
                {
                    answeer = item.Text;
                    break;
                }

            }

            return answeer;
        }

        private void Binddata(int? TeamID = null)
        {
            List<Model.tbl_MODULE> list = new List<Model.tbl_MODULE>();
            if (TeamID == null)
            {
                list = GetViewCoach();

            }
            else
            {
                list = GetViewCoach(TeamID);

            }

            int i = 0, j = 0, level = 1, allowlevel = 2;

            foreach (var mainmodule in list)
            {
                i++;
                level = 1;
                j = 1;

                if (level == 1)
                {
                    var space = new HtmlGenericControl("div");

                    space.Attributes.Add("class", "space");
                    accordion_4.Controls.Add(space);

                }
                accordion_4.Controls.Add(GetPannel(mainmodule, ref i, ref j, ref level, ref allowlevel));

            }
            Session["textboxList"] = listtextbox;


        }


        private HtmlGenericControl GetPannel(Model.tbl_MODULE module, ref int i, ref int j, ref int level, ref int allowlevel)
        {
            HtmlGenericControl pannel = new HtmlGenericControl("div");
            pannel.Attributes.Add("class", "panel panel-danger");




            pannel.Controls.Add(GetModulePannelHeader(module, ref i, ref j, ref level));




            pannel.Controls.Add(GetModulePannelLowerDiv(module, ref i, ref j, ref level, ref allowlevel));

            // }

            return pannel;
        }

        private HtmlGenericControl GetModulePannelHeader(Model.tbl_MODULE module, ref int i, ref int j, ref int level)
        {

            HtmlGenericControl pannelheader = new HtmlGenericControl("div");
            pannelheader.Attributes.Add("class", "panel-heading");
            pannelheader.Attributes.Add("role", "tab");
            pannelheader.Attributes.Add("role", "tab");


            string concat = "";
            if (level == 1)
                concat = concat + i;
            else
                concat = concat + i + j;
            pannelheader.Attributes.Add("id", "headingOne_" + concat);

            HtmlGenericControl heading = new HtmlGenericControl("h4");
            heading.Attributes.Add("class", "panel-title");

            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("aria-controls", "collapseOne_" + concat);
            anchor.Attributes.Add("aria-expanded", "true");
            anchor.Attributes.Add("href", "#collapseOne_" + concat);

            anchor.Attributes.Add("data-parent", "#accordion_" + concat);

            anchor.Attributes.Add("data-toggle", "collapse");

            anchor.Attributes.Add("role", "button");

            anchor.InnerHtml = module.MODULE_NAME;

            heading.Controls.Add(anchor);

            pannelheader.Controls.Add(heading);

            return heading;
        }
        private HtmlGenericControl GetModulePannelLowerDiv(Model.tbl_MODULE module, ref int i, ref int j, ref int level, ref int allowlevel)
        {
            HtmlGenericControl pannelDiv = new HtmlGenericControl("div");
            string concat = "";
            if (level == 1)
                concat = concat + i;
            else
                concat = concat + i + j;


            pannelDiv.Attributes.Add("id", "collapseOne_" + concat);
            pannelDiv.Attributes.Add("class", "panel-collapse collapse");
            pannelDiv.Attributes.Add("role", "tabpanel");
            pannelDiv.Attributes.Add("aria-labelledby", "headingOne" + concat);
            pannelDiv.Attributes.Add("aria-expanded", "false");

            if (allowlevel != level)
            {
                ++level;
                foreach (var item in module.tbl_MODULE1)
                {

                    j++;
                    pannelDiv.Controls.Add(GetPannel(item, ref i, ref j, ref level, ref allowlevel));

                }
            }
            else
            {
                HtmlGenericControl pannelbody = new HtmlGenericControl("div");
                pannelbody.Attributes.Add("class", "panel-body");
                int k = 1;
                foreach (var item in module.tbl_QUESTION.Where(c => c.USER_TYPE_ID == 2))
                {
                    // pannelbody.InnerHtml += 

                    HtmlGenericControl control = new HtmlGenericControl("div");

                    control.Attributes.Add("class", "col-xs-12 col-sm-12 col-md-12");

                    HtmlGenericControl spanQ = new HtmlGenericControl("div");
                    spanQ.Attributes.Add("class", "col-md-12 col-xs-12 col-sm-12");
                    spanQ.InnerHtml = "<div class='col-md-12 col-xs-12 col-sm-12' ><strong>" + k + "   " + item.QUESTION_NAME + "</strong></div><br/>";
                    control.Controls.Add(spanQ);

                    TextBox asptextbox = new TextBox();
                    asptextbox.ID = "text_" + item.QUESTION_ID + "_" + studentist.SelectedValue;
                    string answer = GetAnswer(item.QUESTION_ID, ((Model.tbl_USER)Session["userinfo"]).USER_ID);
                    asptextbox.Text = answer;
                    asptextbox.CssClass = "form-control";
                    asptextbox.ViewStateMode = ViewStateMode.Disabled;
                    asptextbox.Enabled = false;
                    asptextbox.ReadOnly = true;
                    control.Controls.Add(asptextbox);


                    listtextbox.Add(asptextbox);
                    //pannelbody.Controls.Add(asptextbox);

                    HtmlGenericControl control1 = new HtmlGenericControl("div");

                    control1.Attributes.Add("class", "col-xs-12 col-sm-6 col-md-6");

                    //Button aspbutton = new Button();
                    //aspbutton.ID = "button_" + concat + item.QUESTION_ID;
                    //aspbutton.Text = "Save";
                    //aspbutton.CssClass = "btn btn-block bg-red";
                    //aspbutton.CommandArgument = item.QUESTION_ID.ToString();
                    //aspbutton.Command += new CommandEventHandler(SaveAnswer);

                    //control1.Controls.Add(aspbutton);

                    pannelbody.Controls.Add(control);
                    //pannelbody.Controls.Add(control1);

                    k++;
                }
                pannelDiv.Controls.Add(pannelbody);
            }
            return pannelDiv;

        }


        public List<Model.tbl_MODULE> GetViewCoach(int? TeamID = null)
        {
            if (TeamID == null)
                return LoginHelper.db.tbl_MODULE.Where(c => c.PARENT_MODULE_ID == null).OrderBy(x => x.MODULE_NAME).ToList();
            else
                return LoginHelper.db.tbl_TEAM_MODULE.Where(c => c.team_id == TeamID && c.tbl_MODULE.PARENT_MODULE_ID == null).Select(c => c.tbl_MODULE).OrderBy(x => x.MODULE_NAME).ToList();
            //return LoginHelper.db.tbl_TEAM_MODULE.AsQueryable();
        }


        public string GetAnswer(int QuestionID, int UserID)
        {
            int studentID = Convert.ToInt32(studentist.SelectedValue);
            var answer = LoginHelper.db.tbl_ANSWER.FirstOrDefault(c => c.QUESTION_ID == QuestionID && c.USER_ID == studentID);
            if (answer != null)
            {
                return answer.ANSWER_DESCRITION;

            }
            else
            {
                return "";
            }

        }
        protected void SaveAnswer(object sender, EventArgs e)
        {
            try
            {
                string ID = ((CommandEventArgs)e).CommandArgument.ToString();
                string text = GeTTextValue(Convert.ToInt32(ID));
                int QuestionID = Convert.ToInt32(ID);
                int userID = ((Model.tbl_USER)Session["userinfo"]).USER_ID;
                int studentID = Convert.ToInt32(studentist.SelectedValue);

                var ansuerexist = LoginHelper.db.tbl_ANSWER.FirstOrDefault(c => c.QUESTION_ID == QuestionID && c.COACH_ID == userID && c.USER_ID == studentID);

                if (ansuerexist != null)
                {
                    ansuerexist.ANSWER_DESCRITION = text;
                    ansuerexist.UPDATED_ON = DateTime.Now;
                    ansuerexist.UPDATED_BY = ((Model.tbl_USER)Session["userinfo"]).USER_ID.ToString();

                }
                else
                {

                    Model.tbl_ANSWER answer = new Model.tbl_ANSWER();

                    answer.QUESTION_ID = Convert.ToInt32(ID);
                    answer.COACH_ID = ((Model.tbl_USER)Session["userinfo"]).USER_ID;
                    answer.USER_ID = studentID;



                    answer.CREATED_BY = ((Model.tbl_USER)Session["userinfo"]).USER_ID.ToString();
                    answer.ANSWER_DESCRITION = text;
                    answer.CREATED_ON = DateTime.Now;
                    LoginHelper.db.tbl_ANSWER.Add(answer);
                }
                LoginHelper.db.SaveChanges();

            }
            catch (Exception excep)
            {


            }

        }

        protected void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStudentList();
        }
    }
}