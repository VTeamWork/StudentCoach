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
    public partial class Module : System.Web.UI.Page
    {
        Model.tbl_MODULE module;
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }


        public IQueryable<Model.tbl_MODULE> GetModule()
        {

            return LoginHelper.db.tbl_MODULE.Select(s => s);
        }

        

        protected void SaveModule_Click(object sender, EventArgs e)
        {
            try
            {
                // string ID = e.CommandArgument.ToString();
                //   int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                //  var Module = LoginHelper.db.tbl_MODULE.FirstOrDefault(u => u.MODULE_ID == ID);

                //LoginHelper.db.SaveChanges();
                //  LoginHelper.SendEmail(user.EMAIL, "Activate Coach", "Welcome");

                if(string.IsNullOrEmpty(ModuleID.Value))
                { 
                 module = new Model.tbl_MODULE();
                    module.MODULE_NAME = ModuleName.Text;
                    module.MODULE_DESCRITION = Description.Text;
                    LoginHelper.db.tbl_MODULE.Add(module);

                }
                else
                {

                    module = LoginHelper.db.tbl_MODULE.FirstOrDefault(u => u.MODULE_ID.ToString() == ModuleID.Value);

                    module.MODULE_NAME = ModuleName.Text;
                    module.MODULE_DESCRITION = Description.Text;

                }
                LoginHelper.db.SaveChanges();
                ModuleID.Value = null;
                Session["response"] = new Response() { IsError = false, Message = "Success" };
//                 Response.Redirect(Request.Url.ToString());
            }
            catch (Exception ex)
            {
                Session["response"] = new Response() { IsError = true, Message = ex.Message };
            }
            Response.Redirect(Request.Url.ToString());

        }

        protected void EDITMODULE_Click(object sender, EventArgs e)
        {
            try
            {
                // string ID = e.CommandArgument.ToString();
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                module = LoginHelper.db.tbl_MODULE.FirstOrDefault(u => u.MODULE_ID == ID);
                ModuleID.Value = ID.ToString();
                ModuleName.Text = module.MODULE_NAME;
                Description.Text = module.MODULE_DESCRITION;
                
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
    }
}