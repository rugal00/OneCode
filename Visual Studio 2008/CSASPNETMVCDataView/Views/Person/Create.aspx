﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CSASPNETMVCDataView.Models.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	新建
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>新建</h2>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Id) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Id )%>
                <%= Html.ValidationMessageFor(model => model.Id) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Age) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Age) %>
                <%= Html.ValidationMessageFor(model => model.Age) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Phone) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Phone)%>
                <%= Html.ValidationMessageFor(model => model.Phone)%>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Email) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Email)%>
                <%= Html.ValidationMessageFor(model => model.Email)%>
            </div>
            
            <p>
                <input type="submit" value="新建" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("返回到列表", "Index") %>
    </div>

</asp:Content>

