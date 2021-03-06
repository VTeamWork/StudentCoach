﻿<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="OldUser.aspx.cs" Inherits="VteamWork.OldUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <!-- Basic Examples -->
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>Old User
                        </h2>
                 
                    </div>
                    <div class="body">
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="GridViewDemo2" DataKeyNames="USER_ID"
                                ItemType="Model.tbl_USER"
                                SelectMethod="GetUser"
                                AutoGenerateColumns="false"
                                CssClass="gvv table table-bordered table-striped table-hover">

                                <HeaderStyle />
                                <Columns>

                                    <asp:DynamicField DataField="USER_ID" />

                                    <asp:DynamicField DataField="FIRST_NAME" />

                                    <asp:DynamicField DataField="LAST_NAME" />

                                    

                                    <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                            <%--<asp:Button CssClass="btn btn-success" Text="Activate Coach" runat="server" OnCommand="ActivateCoach_Click" CommandArgument='<%= USER_ID  %>'  />--%>
                                             <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("USER_ID")%>'
                                                   CssClass="btn btn-success" Text="Activate Coach" OnClick="ActivateCoach_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

 <asp:TemplateField ItemStyle-Height="20px" HeaderText="Action" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                             <asp:LinkButton ID="lnk" runat="server" CommandArgument='<%# Eval("USER_ID")%>'
                                                   CssClass="btn btn-success" Text="Activate Student" OnClick="ActivateStu_Click"></asp:LinkButton>
                                       
                                                 <%--<asp:Button CssClass="btn btn-success" Text="Activate Student " runat="server"  OnCommand="ActivateStu_Click" CommandArgument='<%= USER_ID  %>' />--%>
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
