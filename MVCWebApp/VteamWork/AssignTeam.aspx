<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="AssignTeam.aspx.cs" Inherits="VteamWork.AssignTeamMdoule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                               Assign Module
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
                                <div class="row clearfix">
                               
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <label>Select Team</label>
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <asp:ListBox ID="TeamList" SelectionMode="Single"  runat="server" CssClass="form-control">    </asp:ListBox>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <label>Select Module</label>
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                              
                                      <asp:ListBox ID="ModuleList" SelectionMode="Multiple"  runat="server" CssClass="form-control">
                                  <asp:ListItem></asp:ListItem>
                                    </asp:ListBox>                                                   </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        
                                        <asp:HiddenField ID="QuestionID" runat="server" />
                                        
                                        <asp:Button  OnClick="btnSave_Click" Text="Save" CssClass="form-control btn btn-primary btn-lg m-l-15 waves-effect" runat="server" /> 

                                    </div>
                                </div>


                        </div>





   <%--<div class="table-responsive">
                            <asp:GridView runat="server" ID="GridViewDemo2" DataKeyNames="MODULE_ID"
                                ItemType="Model.tbl_TEAM_MODULE"
                                SelectMethod="GetTeamModules"
                                AutoGenerateColumns="false"
                                CssClass="gvv table table-bordered table-striped table-hover">

                                <HeaderStyle />
                                <Columns>
                                    <asp:DynamicField DataField="tbl_TEAM.TEAM_NAME" HeaderText="Team Name" />

                                    <asp:DynamicField DataField="tbl_MODULE.MODULE_NAME" HeaderText="Module Name" />

                                    <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                             <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("Team_module_id")%>'
                                                   CssClass="btn btn-primary" Text="Edit QUESTION" OnClick="EDITASSIGN_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>


                            </asp:GridView>
                        </div>--%>
    


                    </div>
                </div>
            </div>


</asp:Content>
