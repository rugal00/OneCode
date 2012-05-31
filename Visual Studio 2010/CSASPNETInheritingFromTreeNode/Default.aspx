﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSASPNETInheritingFromTreeNode.Default" %>

<%@ Register Assembly="CSASPNETInheritingFromTreeNode" Namespace="CSASPNETInheritingFromTreeNode"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>继承TreeNode的演示页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <p>
       每个树节点被关联到一个自定义对象.请选择一个节点以显示其值.</p>
    <!-- TreeView 控件 -->
    <cc1:CustomTreeView ID="CustomTreeView1" runat="server" OnSelectedNodeChanged="CustomTreeView1_SelectedNodeChanged">
        <SelectedNodeStyle Font-Bold="True" />
    </cc1:CustomTreeView>
    <br />
    <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
