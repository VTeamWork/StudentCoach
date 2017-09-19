<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="TeamReview.aspx.cs" Inherits="VteamWork.TeamReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                               Team Review
                            </h2> 
      
                        </div>
                        <div class="body">
                                <div class="row clearfix">
                               
                                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                        <label>Select Team</label>
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <asp:ListBox ID="TeamList" SelectionMode="Single"  runat="server" CssClass="form-control" OnSelectedIndexChanged="TeamList_SelectedIndexChanged" AutoPostBack="true"> 
                                                    <%--<asp:ListItem Text="please select" Value="0" Selected="True"></asp:ListItem>--%>

                                                </asp:ListBox>  
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12">
                                        <label>Select Module</label>
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                    <asp:ListBox ID="ModuleList" SelectionMode="Single" runat="server" CssClass="form-control show-tick"></asp:ListBox>
                                              
                                        </div>
                                    </div>
                                        </div>
                         

                                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">

                                    <label>1 Overall notes on team IG performance</label>
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                    <asp:TextBox TextMode="MultiLine" ID="Comments" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>                                                 </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <label></label>
                                        <div class="form-group">
                                            <div class="form-line">
                                                 <asp:HiddenField ID="ReviewID" runat="server" />
                                              <asp:Button  OnClick="btnSave_Click" Text="Save" CssClass="form-control btn btn-block  bg-red" runat="server" /> 
                                                   </div>
                                        </div>       
                                        
                                        
                                    </div>
                                </div>


                        </div>





   <div class="table-responsive">
                            <asp:gridview runat="server" id="gridviewdemo2" datakeynames="TeamReviewID"
                                itemtype="Model.TeamReview"
                                selectmethod="GetTeamModules"
                                autogeneratecolumns="false"
                                cssclass="gvv table table-bordered table-striped table-hover">

                                <headerstyle />
                                <columns>
                                  <%--  <asp:dynamicfield datafield="TeamID" headertext="team name" />--%>

                                    
                                     <asp:TemplateField HeaderText="Team Name">
              <ItemTemplate>
                <asp:Label Text="<%# Item.tbl_TEAM.TEAM_NAME %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
                                    
                                          <asp:TemplateField HeaderText="Comments">
              <ItemTemplate>
                <asp:Label Text="<%# Item.TeamReviewComment %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>       
                                       <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                            <%--<asp:Button CssClass="btn btn-success" Text="Activate Coach" runat="server" OnCommand="ActivateCoach_Click" CommandArgument='<%= USER_ID  %>'  />--%>
                                            <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("TeamReviewID")%>'
                                                CssClass="btn btn-primary" Text="Edit" OnClick="EDITMODULE_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </columns>


                            </asp:gridview>
                        </div>
    


                    </div>
                </div>
            </div>


</asp:Content>
