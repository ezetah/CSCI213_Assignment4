<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="Assignment_4.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Instructor</h3>
       


            <p>Hello,

            <asp:Label ID="instructorFirstNameLabel" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="instructorLastNameLabel" runat="server" Text="Label"></asp:Label></p>
            <asp:LoginStatus runat="server"></asp:LoginStatus>
            


            <asp:GridView ID="instructorGridView" runat="server"></asp:GridView>



    </main>
</asp:Content>
