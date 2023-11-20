<%@ Page Title="" Language="C#" MasterPageFile="~/MasterInfo/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_4.Login" %>
<asp:Content class="" ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    body { background-color: #DDD0C8 ;}
</style>


    <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate1">
        <LayoutTemplate >
            <table cellspacing="0" cellpadding="1" style="border-collapse: collapse; background-color: #323232;">
                <tr class="loginColor">
                    <td>
                        <table cellpadding="5">
                            <tr style="background-color: #DDD0C8;">
                                <td class="logTitle" align="center" colspan="2">
                                    <br class="Apple-interchange-newline">Log In</td>
                            </tr>
                            <tr style="background-color: #DDD0C8;">
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">User Name:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="Login1" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="background-color: #DDD0C8;">
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="Password" ID="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="Login1" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="background-color: #DDD0C8;">
                                <td colspan="2">
                                    <asp:CheckBox runat="server" Text="Remember me next time." ID="RememberMe"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr style="background-color: #DDD0C8;">
                                <td align="center" colspan="2" style="color: Red;">
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr style="background-color: #DDD0C8;">
                                <td align="right" colspan="2">
                                    <asp:Button class="logBtn" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" ID="LoginButton"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>
    </asp:Content>

