<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment_4.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Member Page</h3>

        <p>Hello,
        <asp:LoginName ID="LoginName1" runat="server" />
            <asp:LoginStatus runat="server"></asp:LoginStatus>
        </p>




            <asp:GridView ID="memberGridView" runat="server" OnSelectedIndexChanged="memberGridView_SelectedIndexChanged"></asp:GridView>







    </main>
</asp:Content>
