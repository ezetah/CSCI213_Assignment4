<%@ Page Title="About" Language="C#" MasterPageFile="~/MasterInfo/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment_4.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    body { background-color: #DDD0C8 ;}
</style>
    <main aria-labelledby="title">
        <h3 class="heading">Member Page</h3>

        <p class="hello">Hello,
        
        <asp:Label runat="server" Text="Label" ID="memberFirstNameLabel"></asp:Label>
        <asp:Label ID="memberLastNameLabel" runat="server" Text="Label"></asp:Label></p>
            <asp:LoginStatus class="hello" runat="server"></asp:LoginStatus>




        <asp:GridView class="table table-condensed table-hover" ID="memberGridView" runat="server" OnSelectedIndexChanged="memberGridView_SelectedIndexChanged" CellSpacing="10"></asp:GridView>







    </main>
</asp:Content>
