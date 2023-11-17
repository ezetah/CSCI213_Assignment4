<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="Assignment_4.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Instructor</h3>
       
        <asp:Panel ID="Panel1" runat="server">

            <asp:GridView ID="instructorGridView" runat="server"></asp:GridView>


        </asp:Panel>

    </main>
</asp:Content>
