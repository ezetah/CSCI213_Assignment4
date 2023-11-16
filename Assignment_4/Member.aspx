<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment_4.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Member</h3>


        <asp:Panel ID="Panel1" runat="server">

            <asp:GridView ID="memberGridView" runat="server" OnSelectedIndexChanged="memberGridView_SelectedIndexChanged"></asp:GridView>




        </asp:Panel>



    </main>
</asp:Content>
