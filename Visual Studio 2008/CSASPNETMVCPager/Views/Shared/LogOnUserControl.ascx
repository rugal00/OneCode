﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        欢迎<b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("登出", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("登入", "LogOn", "Account") %> ]
<%
    }
%>
