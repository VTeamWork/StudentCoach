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

            return LoginHelper.db.tbl_MODULE.Where(u => u.PARENT_MODULE_ID == null).Select(s => s);
        }



        protected void SaveModule_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(ModuleID.Value))
                {
                    module = new Model.tbl_MODULE();
                    module.MODULE_NAME = ModuleName.Text;
                    module.MODULE_DESCRITION = Description.Text;
                    module.IS_DEFAULT = chkDefault.Checked == true ? "1" : "0";
                    LoginHelper.db.tbl_MODULE.Add(module);

                }
                else
                {

                    module = LoginHelper.db.tbl_MODULE.FirstOrDefault(u => u.MODULE_ID.ToString() == ModuleID.Value);
                    module.IS_DEFAULT = chkDefault.Checked == true ? "1" : "0";
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
                Response resp;
                Exception Excep = LoginHelper.getExceptionMessage(ex);
                if (Excep != null && Excep.Message.ToLower().Contains("unique"))
                {
                    resp = new Response() { IsError = true, Message = "Module is Already Exist" };
                }

                else
                {
                    resp = new Response() { IsError = true, Message = "Error while saving data" };
                }
                Session["response"] = resp;
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
                if (module.IS_DEFAULT == "1")
                    chkDefault.Checked = true;
                else
                    chkDefault.Checked = false;

            }
            catch (Exception ex)
            {
                //              Session["response"] = new Response() { IsError = true, Message = ex.Message };
                //                Response.Redirect("Default.aspx");

            }
        }
    }
}