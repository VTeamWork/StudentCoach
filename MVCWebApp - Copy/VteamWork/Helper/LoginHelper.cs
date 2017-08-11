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

        public static Response GetMenuList(tbl_USER user = null)
        {
            try
            {
                var menuinfo = db.tbl_MENU_GROUP.ToList();
                if (menuinfo != null)
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

        public static Response GetPageList(int menu_group_id)
        {
            try
            {
                var pageinfo = db.tbl_PAGE.Where(c => c.MENU_GROUP_ID == menu_group_id).ToList();
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



    }
}