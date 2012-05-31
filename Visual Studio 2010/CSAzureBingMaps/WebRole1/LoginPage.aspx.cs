﻿/********************************* 模块头 **********************************\
* 模块名:  LoginPage.aspx.cs
* 项目名:  AzureBingMaps
* 版权 (c) Microsoft Corporation.
* 
* LoginPage后台代码.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Web;
using Microsoft.Live;

namespace AzureBingMaps.WebRole
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 保存会话中的返回页面.
            if (Request.QueryString["returnpage"] != null)
            {
                Session["ReturnPage"] = Request.QueryString["returnpage"];
            }
        }

        /// <summary>
        /// Windows Live Messenger Connect会话ID.
        /// </summary>
        public string SessionId
        {
            get
            {
                SessionIdProvider oauth = new SessionIdProvider();
                return "wl_session_id=" + oauth.GetSessionId(HttpContext.Current);
            }
        }
    }
}