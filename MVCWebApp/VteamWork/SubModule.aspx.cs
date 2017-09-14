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
using Model;

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

            return LoginHelper.db.tbl_MODULE.Where(u => u.PARENT_MODULE_ID != null).Select(s => s);
        }

        

        protected void SaveModule_Click(object sender, EventArgs e)
        {
            try
            {

                if(string.IsNullOrEmpty(ModuleID.Value))
                {
                    JArray array = JArray.Parse(table.Value);
                    List<Sub_Module> ranges = array.ToObject<List<Sub_Module>>();
                    ranges.ToList().ForEach(u =>
                    {
                        module = new Model.tbl_MODULE();
                        module.MODULE_NAME = u.mdlName;
                        module.MODULE_DESCRITION = u.mdlDesc;
                        module.PARENT_MODULE_ID = Convert.ToInt32(ModuleList.SelectedValue);
                        module.CREATED_ON = DateTime.Now;
                        module.CREATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                        module.UPDATED_ON = DateTime.Now;
                        module.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                        LoginHelper.db.tbl_MODULE.Add(module);
                    });

                }
                else
                {
                    
                    module = LoginHelper.db.tbl_MODULE.FirstOrDefault(u => u.MODULE_ID.ToString() == ModuleID.Value);
                    module.MODULE_NAME = ModuleName.Text;
                    module.MODULE_DESCRITION = Description.Text;
                    module.CREATED_ON = DateTime.Now;
                    module.CREATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();
                    module.UPDATED_ON = DateTime.Now;
                    module.UPDATED_BY = ((tbl_USER)Session["userinfo"]).LOGIN_ID.ToString();

                }
                LoginHelper.db.SaveChanges();
                ModuleID.Value = null;
                Session["response"] = new Response() { IsError = false, Message = "Success" };
            }
            catch (Exception ex)
            {
                Response resp;
                Exception Excep = LoginHelper.getExceptionMessage(ex);
                if (Excep != null && Excep.Message.ToLower().Contains("unique"))
                {
                    resp = new Response() { IsError = true, Message = "Sub Module is Already Exist" };
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
                btnAdd.Visible = false;
                int ID = Convert.ToInt32(((LinkButton)sender).CommandArgument);
                module = LoginHelper.db.tbl_MODULE.FirstOrDefault(u => u.MODULE_ID == ID);
                ModuleID.Value = ID.ToString();
                ModuleName.Text = module.MODULE_NAME;
                Description.Text = module.MODULE_DESCRITION;
                ModuleList.SelectedValue = module.PARENT_MODULE_ID.ToString();

            }
            catch (Exception ex)
            {

            }
        }


        public class Sub_Module
        {
            public string mdlName;
            public string mdlDesc;
            public string IsMndtry;
        }

        private void BindModuleList()
        {
            try
            {
                ModuleList.DataSource = LoginHelper.db.tbl_MODULE.Where(u => u.PARENT_MODULE_ID == null).Select(s => s).ToList();
                ModuleList.DataTextField = "MODULE_NAME";
                ModuleList.DataValueField = "MODULE_ID";
                ModuleList.DataBind();
            }
            catch (Exception ex)
            { }

        }


    }
}