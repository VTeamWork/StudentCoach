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
    public partial class ViewModelStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Binddata();

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

            int i = 0, j = 0, level = 1,allowlevel = 2 ;

            foreach (var mainmodule in list)
            {
                i++;
                level = 1;
                j = 1;

                if (level == 1)
                {
                    var space = new HtmlGenericControl("div");

                    space.Attributes.Add("class","space");
                    accordion_4.Controls.Add(space);

                }
                accordion_4.Controls.Add(GetPannel(mainmodule,ref i,ref j, ref level,ref allowlevel));
            }

        }


        private HtmlGenericControl GetPannel(Model.tbl_MODULE module,ref int i , ref int j,ref int level,ref int allowlevel) {
            HtmlGenericControl pannel = new HtmlGenericControl("div");
            pannel.Attributes.Add("class", "panel panel-danger");


           

            pannel.Controls.Add(GetModulePannelHeader(module,ref i,ref j,ref level));

            if(allowlevel!=level)
            {
                ++level;
                foreach (var item in module.tbl_MODULE1)
                {
                    j++; 
                    pannel.Controls.Add(GetPannel(item, ref i, ref j, ref level, ref allowlevel));

                }
            }
            else
            {
             

                pannel.Controls.Add(GetModulePannelLowerDiv(module.tbl_QUESTION.ToList(), ref i, ref j, ref level));

            }

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
            pannelheader.Attributes.Add("id", "headingOne_"+concat);

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
        private HtmlGenericControl GetModulePannelLowerDiv(List<Model.tbl_QUESTION> questions, ref int i, ref int j, ref int level)
        {
            HtmlGenericControl pannelDiv = new HtmlGenericControl("div");
            string concat = "";
            if (level == 1)
                concat = concat + i;
            else
                concat = concat + i + j;

            pannelDiv.Attributes.Add("id", "collapseOne_"+ concat);
            pannelDiv.Attributes.Add("class", "panel-collapse collapse");
            pannelDiv.Attributes.Add("role", "tabpanel");
            pannelDiv.Attributes.Add("aria-labelledby", "headingOne" + concat);
            pannelDiv.Attributes.Add("aria-expanded", "false");

            HtmlGenericControl pannelbody = new HtmlGenericControl("div");
            pannelbody.Attributes.Add("class", "panel-body");
            int k = 1;
            foreach (var item in questions)
            {
                pannelbody.InnerHtml += k +" "+ item.QUESTION_NAME + "<br/>";
                k++;
            }
            pannelDiv.Controls.Add(pannelbody);
            return pannelDiv;

        }


        public List<Model.tbl_MODULE> GetViewStudent(int? TeamID = null)
        {
            if (TeamID == null)
                return LoginHelper.db.tbl_MODULE.Where(c => c.PARENT_MODULE_ID == null).ToList();
            else
                return LoginHelper.db.tbl_TEAM_MODULE.Where(c => c.team_id == TeamID && c.tbl_MODULE.PARENT_MODULE_ID == null).Select(c => c.tbl_MODULE).ToList();
            //return LoginHelper.db.tbl_TEAM_MODULE.AsQueryable();
        }
    }
    }