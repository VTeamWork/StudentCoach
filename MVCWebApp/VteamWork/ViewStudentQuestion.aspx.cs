using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VteamWork.Helper;

namespace VteamWork
{



    public partial class ViewStudentQuestion : System.Web.UI.Page
    {
       

        public List<Model.tbl_MODULE> GetViewStudent()
        {
            return LoginHelper.db.tbl_MODULE.ToList();
            //return LoginHelper.db.tbl_TEAM_MODULE.AsQueryable();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Model.tbl_MODULE> list = GetViewStudent();

            foreach (var mainmodule in list)
            {
                Label maincontrol = new Label() { Text = mainmodule.MODULE_NAME };
                DataShow.Controls.Add(maincontrol);
                foreach (var item in mainmodule.tbl_MODULE1)
                {
                    maincontrol.Controls.Add(new Label() { Text = item.MODULE_NAME });
                }

            }
        }
    }
}