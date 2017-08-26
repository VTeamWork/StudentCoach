<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="VteamWork.Question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                               Question Info
                            </h2>
                            <ul class="header-dropdown m-r--5">
                                <li class="dropdown">
                                    <a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                        <i class="material-icons">more_vert</i>
                                    </a>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="javascript:void(0);">Action</a></li>
                                        <li><a href="javascript:void(0);">Another action</a></li>
                                        <li><a href="javascript:void(0);">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="body">
                            <form>
                                <div class="row clearfix">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <input type="text" ID="Name" runat="server" class="form-control">
                                                <label class="form-label">Name</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <%--<input type="password" class="form-control">--%>
                                                <textarea ID="Description" runat="server" class="form-control"></textarea>
                                                <label class="form-label">Descsription</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <%--<input type="password" class="form-control">--%>
                                      <asp:ListBox ID="lstStudents" SelectionMode="Multiple"  runat="server" CssClass="form-control show-tick">
                                        <asp:ListItem>Mustard</asp:ListItem>
                                        <asp:ListItem>Ketchup</asp:ListItem>
                                        <asp:ListItem>Relish</asp:ListItem>
                                    </asp:ListBox>           <%-- <label class="form-label">Select Module</label>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <button type="button" class="btn btn-primary btn-lg m-l-15 waves-effect">Save</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
            <!-- #END# Inline Layout | With Floating Label -->
            <!-- Multi Column -->

</asp:Content>
