using Model.DataResponse;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace VteamWork.Helper
{
    public class LoginHelper:BaseHelper
    {
        public static Response Auth(tbl_USER user = null)
        {
            var userinfo = db.tbl_USER.Where(c => c.LOGIN_ID == user.LOGIN_ID && c.PASSWORD == user.PASSWORD && c.IS_ACTIVE=="1" && c.IS_DELETED=="0").FirstOrDefault();
            if (userinfo!=null)
            {

                return new Response { IsError = false, Message = "Success", data = userinfo };
            }
            else
            {
                return new Response { IsError = true, Message = "Error" };
            }

        }

       

    }
}