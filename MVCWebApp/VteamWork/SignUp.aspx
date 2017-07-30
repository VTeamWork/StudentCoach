<%@ Page Title="" Language="C#" MasterPageFile="~/VtMasterMain.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="VteamWork.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginFormPlaceHolder" runat="server">
    <div class="card">
        <div class="body">
            <form id="sign_up" method="POST" runat="server">
                <div class="msg">Register a new membership</div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">person</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox runat="server" ID="FIRST_NAME" CssClass="form-control" required="required" placeholder="First Name" autofocus=""></asp:TextBox>
                        <%--<input type="text" class="form-control" name="namesurname" placeholder="Name Surname" required autofocus>--%>
                    </div>
                </div>

                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">person</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox runat="server" ID="LAST_NAME" CssClass="form-control" required="required" placeholder="Last Name" autofocus=""></asp:TextBox>
                        <%--<input type="text" class="form-control" name="namesurname" placeholder="Name Surname" required autofocus>--%>
                    </div>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">email</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox runat="server" ID="EMAIL" CssClass="form-control" required="required" placeholder="Email" autofocus=""></asp:TextBox>
                    </div>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">lock</i>
                    </span>
                    <div class="form-line">
                        <%--<input type="password" class="form-control" name="password" minlength="6" placeholder="Password" required>--%>
                        <asp:TextBox ID="PASSWORD" runat="server" CssClass="form-control" TextMode="Password" placeholder="password" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">lock</i>
                    </span>
                    <div class="form-line">
                        <%--<input type="password" class="form-control" name="confirm" minlength="6" placeholder="Confirm Password" required>--%>
                        <asp:TextBox ID="confirm" runat="server" CssClass="form-control" TextMode="Password" placeholder="confirm password" required="required"></asp:TextBox>
                    </div>
                </div>

                  <div class="form-group">
                    <asp:CheckBox ID="CHK_ISSTUDENT" runat="server"  CssClass="filled-in chk-col-pink" Text="Is Student"/>
                </div>
                <div class="form-group">
                    <input type="checkbox" name="terms" id="terms" class="filled-in chk-col-pink">
                    <label for="terms">I read and agree to the <a href="javascript:void(0);">terms of usage</a>.</label>
                </div>

              

                <%--  <button class="btn btn-block btn-lg bg-pink waves-effect" type="submit">SIGN UP</button>--%>
           
                <asp:Button OnClick="Rigestered_Click" CssClass="btn btn-block btn-lg bg-red waves-effect" runat="server" Text="Sign UP" />
           
                <%--<button class="btn btn-block bg-pink waves-effect" type="submit">SIGN IN</button>--%>


                <div class="m-t-25 m-b--5 align-center">
                    <a href="Login.aspx">You already have a membership?</a>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
