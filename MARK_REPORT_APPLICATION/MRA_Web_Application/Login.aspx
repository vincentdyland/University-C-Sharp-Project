<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MRA_Web_Application.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MAR Management</title>
    <link href="Css/login.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="modal">
            <div class="title">
                Login
            </div>

            <div class="container form-login">
                <table>
                    <tr >
                        <td class="child-one">Username</td>
                        <td class="child-two">
                            <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="input"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="child-one">Password</td>
                        <td class="child-two">
                            <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="input"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            <div class="container form-controller">
                <div class="labelIncorrect">
                    <asp:Label Text="Incorrect your username or password" runat="server" CssClass="incorrect-label" ID ="labelIncorrect"/>
                </div>
                <div class="buttonLogin">
                    <asp:Button Text="Login" runat="server" CssClass="button-login" OnClick="ButtonLogin_Click"/>
                </div>
            </div>
            
        </div>
    </form>
</body>
</html>
