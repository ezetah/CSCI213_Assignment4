<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="Assignment_4.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Administrator</h3>
    <p>
        <table style="padding: 10px; height: 346px;">
            <tr>
                <td style="padding: 15px; width: 611px; height: 313px; border-left-style: solid; border-left-width: 1px; border-right-style: hidden; border-right-width: 1px; border-top-style: solid; border-top-width: 1px; border-bottom-style: solid; border-bottom-width: 1px;">Members<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="178px" Width="606px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="First" HeaderText="First" />
            <asp:BoundField DataField="Last" HeaderText="Last" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:BoundField DataField="Date" HeaderText="Date Joined" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
                    <br />
                    <asp:Button ID="memberDeleteBtn" runat="server" Text="Delete" OnClick="memberDeleteBtn_Click" />
                </td>
                <td style="padding: 15px; border-style: solid; border-width: 1px; height: 313px; width: 680px;">
                    Instructors<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="None" Height="178px" Width="336px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="First" HeaderText="First" />
                            <asp:BoundField DataField="Last" HeaderText="Last" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <br />
                    <asp:Button ID="InstructorsDeleteBtn" runat="server" Text="Delete" OnClick="InstructorsDeleteBtn_Click" />
                </td>
            </tr>
            <tr>
                <td style="width: 611px">

                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;First:
                    <asp:TextBox ID="memberFirstTxt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Last:
                    <asp:TextBox ID="memberLastTxt" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone:
                    <asp:TextBox ID="memberPhoneTxt" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:
                    <asp:TextBox ID="memberEmailTxt" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserName:
                    <asp:TextBox ID="memberUsernameTxt" runat="server"></asp:TextBox>
&nbsp;&nbsp; Password:&nbsp;
                    <asp:TextBox ID="memberPasswordTxt" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="memberSubmitBtn" runat="server" OnClick="memberSubmitBtn_Click" Text="Submit" />
&nbsp;
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="New Member" />
                    <br />
                    <br />
                    <hr />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Assign to Section
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Karate Age-Uke</asp:ListItem>
                        <asp:ListItem>Karate Chudan-Uke</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="addToSect" runat="server" Text="Add" OnClick="addToSect_Click" />
&nbsp;&nbsp;
                    <asp:Label ID="errorLbl" runat="server" ForeColor="Red"></asp:Label>
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Instructor
                    <asp:DropDownList ID="instructorDropdown" runat="server">
                    </asp:DropDownList>
&nbsp;&nbsp;&nbsp; Fee
                    <asp:TextBox ID="feeTxt" runat="server" TextMode="Number"></asp:TextBox>
                    <br />
                    <div style="padding-left: 45px;">
                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    </div>
                    <br />

                </td>
                <td style="width: 680px">

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;First:
                    <asp:TextBox ID="instructorFirstTxt0" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Last:
                    <asp:TextBox ID="instructorLastTxt0" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phone:
                    <asp:TextBox ID="instructorPhoneTxt0" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserName:
                    <asp:TextBox ID="instructorUsernameTxt0" runat="server"></asp:TextBox>
&nbsp;&nbsp; Password:&nbsp;
                    <asp:TextBox ID="instructorPasswordTxt0" runat="server"></asp:TextBox>
                    <br />
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="instructorSubmitBtn" runat="server" OnClick="instructorSubmitBtn_Click" Text="Submit" />
&nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Text="New Instructor" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
