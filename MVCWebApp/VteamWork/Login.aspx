<%@ Page Title="" Language="C#" MasterPageFile="~/VtMasterMain.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VteamWork.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
  <title>Sign In </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginFormPlaceHolder" runat="server">
    <div >
       <%-- <div class="logo">
            <a href="javascript:void(0);">VTeamWork</a>
            <small>Web Pannel</small>
        </div>--%>
        <div class="card">
            <div class="body">
                <form id="sign_in" method="POST" runat="server">
                    <div class="msg">Sign in to start your session</div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">person</i>
                        </span>
                        <div class="form-line">
                            <%--<input type="text" class="form-control" name="username" placeholder="Username" required autofocus>--%>
                            <asp:TextBox runat="server" ID="LOGIN_ID" CssClass="form-control" required="required" placeholder="Username" autofocus=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">lock</i>
                        </span>
                        <div class="form-line">
                            <asp:TextBox ID="PASSWORD" runat="server" CssClass="form-control" TextMode="Password" placeholder="password" required="required"></asp:TextBox>
                           <%-- <input type="password" class="form-control" name="password" placeholder="password" required>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-8 p-t-5">
                            <input type="checkbox" name="rememberme" id="rememberme" class="filled-in chk-col-pink">
                            <label for="rememberme">Remember Me</label>
                        </div>
                        <div class="col-xs-4">
                            <asp:Button OnClick="Login_Click" CssClass="btn btn-default waves-effect" runat="server" Text="Sign In" />
                            <%--<button class="btn btn-block bg-pink waves-effect" type="submit">SIGN IN</button>--%>
                        </div>
                    </div>
                    <div class="row m-t-15 m-b--20">
                        <div class="col-xs-6">
                            <a href="SignUp.aspx">Register Now!</a>
                        </div>
                        <div class="col-xs-6 align-right">
                            <a href="ResetPassword.aspx">Forgot Password?</a>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    
</asp:Content>
