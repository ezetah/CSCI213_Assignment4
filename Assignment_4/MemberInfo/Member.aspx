<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment_4.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Member Page</h3>

        <p>Hello,
        
        <asp:Label runat="server" Text="Label" ID="memberFirstNameLabel"></asp:Label>
        <asp:Label ID="memberLastNameLabel" runat="server" Text="Label"></asp:Label></p>
            <asp:LoginStatus runat="server"></asp:LoginStatus>




        <asp:GridView ID="memberGridView" runat="server" OnSelectedIndexChanged="memberGridView_SelectedIndexChanged" CellSpacing="5"></asp:GridView>







    </main>
</asp:Content>
