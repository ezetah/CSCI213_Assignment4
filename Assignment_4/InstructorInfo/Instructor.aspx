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
            
            


            <asp:GridView ID="instructorGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>



    <br />
            <asp:GridView class="table table-condensed table-hover" ID="instructorGridView" runat="server"></asp:GridView>



    </main>
            <asp:LoginStatus runat="server"></asp:LoginStatus>
            


            </asp:Content>
