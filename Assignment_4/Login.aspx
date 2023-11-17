<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_4.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Login</h3>
    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate1"></asp:Login>
    </asp:Content>
