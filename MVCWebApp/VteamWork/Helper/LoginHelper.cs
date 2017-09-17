using Model.DataResponse;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace VteamWork.Helper
{
    public class LoginHelper : BaseHelper
    {
        public static Response Auth(tbl_USER user = null)
        {
            try
            {
                var userinfo = db.tbl_USER.Where(c => c.LOGIN_ID == user.LOGIN_ID && c.PASSWORD == user.PASSWORD && c.IS_ACTIVE == "1" && c.IS_DELETED == "0").FirstOrDefault();
                if (userinfo != null)
                {

                    return new Response { IsError = false, Message = "Success", data = userinfo };
                }
                else
                {
                    return new Response { IsError = true, Message = "Invalid Credentials" };
                }
            }
            catch (Exception e)
            {
                return new Response { IsError = true, Message = e.Message };


            }

        }

        public static Response GetMenuList(int? role_id,tbl_USER user = null)
        {
            try
            {
                List<tbl_MENU_GROUP> menuinfo = null;
                var pageinfo = db.tbl_ROLE_PAGE.Where(c =>  c.tbl_ROLE.ROLE_ID == role_id).ToList();
                if(pageinfo.Count>0)
                 menuinfo = db.tbl_MENU_GROUP.ToList();
              
               // var menuinfo = db.tbl_ROLE_PAGE.Where(w => w.tbl_PAGE != null && w.ROLE_ID == role_id).Select(m => m.tbl_PAGE.tbl_MENU_GROUP).ToList();


               // var pageinfo = db.tbl_PAGE.Where(c => c.PAGE_ID != null && c.tbl_ROLE_PAGE. == role_id).OrderBy(x => x.tbl_PAGE.PAGE_SEQ).Select(s => s.tbl_PAGE).ToList();
                if (menuinfo.Count>0)
                {

                    return new Response { IsError = false, Message = "Success", data = menuinfo };
                }
                else
                {
                    return new Response { IsError = true, Message = "Error" };
                }
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsError = true,
                    Message = e.Message
                };
            }

        }

        public static Response GetPageList(int? menu_group_id,int? role_id)
        {
            try
            {
                var pageinfo = db.tbl_ROLE_PAGE.Where(c => c.tbl_PAGE.MENU_GROUP_ID == menu_group_id  && c.tbl_ROLE.ROLE_ID==role_id).OrderBy(x=>x.tbl_PAGE.PAGE_SEQ).Select(s=>s.tbl_PAGE).ToList();
                if (pageinfo != null)
                {

                    return new Response { IsError = false, Message = "Success", data = pageinfo };
                }
                else
                {
                    return new Response { IsError = true, Message = "Error" };
                }
            }
            catch (Exception e)
            {
                return new Response { IsError = true, Message = e.Message };
            }

        }

        //internal static void ShowAlert(Response resp, object alert)
        //{
        //    throw new NotImplementedException();
        //}

        public static Response GetUserTypeList()
        {
            try
            {
                var userTYPEinfo = db.tbl_USER_TYPE.Where(c => c.USER_TYPE != "Admin").ToList();
                if (userTYPEinfo != null)
                {

                    return new Response { IsError = false, Message = "Success", data = userTYPEinfo };
                }
                else
                {
                    return new Response { IsError = true, Message = "Error" };
                }
            }
            catch (Exception e)
            {
                return new Response { IsError = true, Message = e.Message };
            }
        }

        public static Exception getExceptionMessage(Exception excep)
        {
            LoginHelper.db = new VTeamWorkDB();
            if (excep.InnerException != null)
            {
                return getExceptionMessage(excep.InnerException);
            }
            else
            {

                return excep;
            }

        }



    }
}