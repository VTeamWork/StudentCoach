using Model.DataResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using VteamWork.Helper;
using Newtonsoft.Json.Linq;

namespace VteamWork
{
    public partial class SubModule : System.Web.UI.Page
    {
        Model.tbl_MODULE module;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindModuleList();
        }


        public IQueryable<Model.tbl_MODULE> GetModule()
        {

            return LoginHelper.db.tbl_MODULE.Select(s => s);
        }

        

        protected void SaveModule_Click(object sender, EventArgs e)
        {
            try
            {
               

                if(string.IsNullOrEmpty(ModuleID.Value))
                {
                   

                    string xml = "";
                    JArray array = JArray.Parse(table.Value);

                    List<Sub_Module> ranges = array.ToObject<List<Sub_Module>>();
                    ranges.ToList().ForEach(u =>
                    {
                        module = new Model.tbl_MODULE();
                        module.MODULE_NAME = u.mdlName;
                        module.MODULE_DESCRITION = u.mdlDesc;

                        LoginHelper.db.tbl_MODULE.Add(module);
                    });
                  

                  

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
                btnAdd.Visible = false;
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


        public class Sub_Module
        {
            public string mdlName;
            public string mdlDesc;
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