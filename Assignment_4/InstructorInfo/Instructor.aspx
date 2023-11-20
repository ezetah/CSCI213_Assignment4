<%@ Page Title="Contact" Language="C#" MasterPageFile="~/MasterInfo/Site.Master" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="Assignment_4.Contact" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body { background-color: #DDD0C8 ;}
    </style>
    <main  aria-labelledby="title">
        <h3 class="heading">Instructor</h3>
       


            <p class="hello">Hello,

            <asp:Label ID="instructorFirstNameLabel" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="instructorLastNameLabel" runat="server" Text="Label"></asp:Label></p>
            <asp:LoginStatus class="hello" runat="server"></asp:LoginStatus>
            


            <asp:GridView class="table table-condensed table-hover" ID="instructorGridView" runat="server"></asp:GridView>



    </main>
</asp:Content>
