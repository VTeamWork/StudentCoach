<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VteamWork.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- Basic Examples -->
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>User
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
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="GridViewDemo2"
                                ItemType="Model.tbl_USER"
                                SelectMethod="GetUser"
                                AutoGenerateColumns="false"
                                CssClass="dataTable table table-bordered table-striped table-hover js-basic-example">

                                <HeaderStyle />
                                <Columns>

                                    <asp:DynamicField DataField="USER_ID" />
                                    <asp:DynamicField DataField="USER_ID" />

                                    <asp:DynamicField DataField="FIRST_NAME" />

                                    <asp:DynamicField DataField="MOBILE_NO" />

                                    <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-success" Text="Activate" runat="server" />
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
