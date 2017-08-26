<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="VteamWork.Team" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- Basic Examples -->

        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>Team
                        </h2>
                    </div>
                    <div class="body">

                        <div class="row clearfix">
                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">search</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search Team" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:Button ID="btnSearch" CssClass="btn btn-block btn-lg bg-red waves-effect " runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-block btn-lg bg-red waves-effect" OnClick="btnAdd_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="table-responsive" id="GridDiv" runat="server" visible="false">
                            <asp:GridView runat="server" ID="GridViewDemo2"
                                ItemType="Model.tbl_TEAM"
                                SelectMethod="GetUser"
                                AutoGenerateColumns="false"
                                CssClass="dataTable table table-bordered table-striped table-hover js-basic-example">

                                <HeaderStyle />
                                <Columns>

                                    <asp:DynamicField DataField="TEAM_NAME" HeaderText="Team Name" />

                                    <asp:DynamicField DataField="TEAM_DESCRITION" HeaderText="Team Description" />
                                    <asp:TemplateField ItemStyle-Height="20px" HeaderText="Action" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("TEAM_ID")%>'
                                                CssClass="btn btn-primary" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>


                            </asp:GridView>
                        </div>
          

                        <div class="row clearfix"  id="DivAdd" runat="server" visible="false">
                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">supervisor_account</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox runat="server" ID="txtTeamName" CssClass="form-control" required="required" placeholder="Team Name" />
                                    </div>
                                </div>
                            </div>

                           

                           <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                               <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">person</i>
                                    </span>
                                <div class="form-line">
                                   
                                    <asp:ListBox ID="lstStudents" SelectionMode="Multiple"  runat="server" CssClass="form-control show-tick">
                                
                                    </asp:ListBox>
                                    </div>
                                   </div>

                                </div>
                          

                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">description</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" required="required" TextMode="MultiLine" placeholder="Team Description" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <div class="form-group">
                                    <div class="form-line">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-block btn-lg bg-red waves-effect" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
