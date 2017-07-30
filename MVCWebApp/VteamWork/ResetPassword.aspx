<%@ Page Title="" Language="C#" MasterPageFile="~/VtMasterMain.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="VteamWork.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <title>Reset Password</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginFormPlaceHolder" runat="server">
     <div class="card">
            <div class="body">
                <form id="forgot_password" method="POST" runat="server">
                    <div class="msg">
                        Enter your email address that you used to register. We'll send you an email with your username and a
                        new password.
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">email</i>
                        </span>
                        <div class="form-line">
                         <%--   <input type="email" class="form-control" name="email" placeholder="Email" required autofocus>--%>

                            <asp:TextBox runat="server" ID="EMAIL" CssClass="form-control" required="required" placeholder="Email" autofocus=""></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnResetPassword" OnClick="btnResetPassword_Click"  CssClass="btn btn-default waves-effect" runat="server" Text="RESET MY PASSWORD" />

                    <div class="row m-t-20 m-b--5 align-center">
                        <a href="Login.aspx">Sign In!</a>
                    </div>
                </form>
            </div>
        </div>


</asp:Content>
