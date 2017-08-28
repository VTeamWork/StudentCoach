<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="VteamWork.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <head>
        <link rel="icon" href="../../../favicon.ico" type="image/x-icon">

        <!-- Google Fonts -->
        <link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css">
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css">

        <!-- Bootstrap Core Css -->
        <link href="../../../plugins/bootstrap/css/bootstrap.css" rel="stylesheet">

        <!-- Waves Effect Css -->
        <link href="../../../plugins/node-waves/waves.css" rel="stylesheet" />

        <!--WaitMe Css-->
        <link href="../../../plugins/waitme/waitMe.css" rel="stylesheet" />

        <!-- Animation Css -->
        <link href="../../../plugins/animate-css/animate.css" rel="stylesheet" />

        <!-- Custom Css -->
        <link href="../../../css/style.css" rel="stylesheet">

        <!-- AdminBSB Themes. You can choose a theme from css/themes instead of get all themes -->
        <link href="../../../css/themes/all-themes.css" rel="stylesheet" />

    </head>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- Basic Examples -->
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>Student
                        </h2>
                      
                    </div>
                    <div class="body">
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="GridViewDemo2"
                                ItemType="Model.tbl_USER"
                                SelectMethod="GetUser"
                                AutoGenerateColumns="false"
                                CssClass="gvv table table-bordered table-striped table-hover">

                                <HeaderStyle />
                                <Columns>

                                    <asp:DynamicField DataField="USER_ID" />
                                    <asp:DynamicField DataField="USER_ID" />

                                    <asp:DynamicField DataField="FIRST_NAME" />

                                    <asp:DynamicField DataField="MOBILE_NO" />

                                    <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("USER_ID")%>'
                                                CssClass="btn btn-danger" Text="Deactivate" OnClick="Deactivate_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" runat="server" CommandArgument='<%# Eval("USER_ID")%>'
                                                CssClass="btn btn-primary" Text="Reset Password" OnClick="ResetPwd_Click"></asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>


                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
