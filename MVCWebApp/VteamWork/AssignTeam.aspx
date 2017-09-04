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
                               
                                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                        <label>Select Team</label>
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <asp:ListBox ID="TeamList" SelectionMode="Single"  runat="server" CssClass="form-control">    </asp:ListBox>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                    <label>Select Module</label>
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                              
                                      <asp:ListBox ID="ModuleList" SelectionMode="Multiple"  runat="server" CssClass="form-control">
                                  <asp:ListItem></asp:ListItem>
                                    </asp:ListBox>                                                   </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <label></label>
                                        <div class="form-group">
                                            <div class="form-line">
                                              <asp:Button  OnClick="btnSave_Click" Text="Save" CssClass="form-control btn btn-primary btn-lg m-l-15 waves-effect" runat="server" /> 
                                                   </div>
                                        </div>       
                                        
                                        
                                    </div>
                                </div>


                        </div>





   <div class="table-responsive">
                            <asp:gridview runat="server" id="gridviewdemo2" datakeynames="Team_module_id"
                                itemtype="Model.tbl_TEAM_MODULE"
                                selectmethod="GetTeamModules"
                                autogeneratecolumns="false"
                                cssclass="gvv table table-bordered table-striped table-hover">

                                <headerstyle />
                                <columns>
                                    <asp:dynamicfield datafield="team_id" headertext="team name" />

                                    
                                     <asp:TemplateField HeaderText="Team Name">
              <ItemTemplate>
                <asp:Label Text="<%# Item.tbl_TEAM.TEAM_NAME %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
                                    
                                          <asp:TemplateField HeaderText="Module Name">
              <ItemTemplate>
                <asp:Label Text="<%# Item.tbl_MODULE.MODULE_NAME %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>       

                                </columns>


                            </asp:gridview>
                        </div>
    


                    </div>
                </div>
            </div>


</asp:Content>
