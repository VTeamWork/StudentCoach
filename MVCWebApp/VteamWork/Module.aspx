<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Module.aspx.cs" Inherits="VteamWork.Module" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <!-- Basic Examples -->
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>Module
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

<div class="form-horizontal panel" style="height:200px">
    <div class="col-md-5 col-xs-12 col-sm-5">
        <label class="col-md-4 text-right">Module Name</label>
        <div class="col-md-8">
            <%--<input type="text" class="form-control" placeholder="Module Name" />--%>
           <asp:TextBox ID="ModuleName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

    </div>
     <div class="col-md-5 col-xs-12 col-sm-5">
        <label class="col-md-4 text-right">Module Description</label>
        <div class="col-md-8">

           <asp:TextBox TextMode="MultiLine" ID="Description" CssClass="form-control" runat="server"></asp:TextBox>
        
        <%--<textarea class="form-control"></textarea>--%>
         </div>

    </div>
     <div class="col-md-2 col-xs-12 col-sm-2">
    <asp:HiddenField ID="ModuleID" runat="server" />
            <asp:button text="Save" class="form-control"  OnClick="SaveModule_Click" Cssclass="btn btn-lg bg-red"    runat="server" />
    
    </div>

</div>


                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="GridViewDemo2" DataKeyNames="MODULE_ID"
                                ItemType="Model.tbl_MODULE"
                                SelectMethod="GetModule"
                                AutoGenerateColumns="false"
                                CssClass="gvv table table-bordered table-striped table-hover">

                                <HeaderStyle />
                                <Columns>

                                    <asp:DynamicField DataField="MODULE_ID" />

                                    <asp:DynamicField DataField="MODULE_NAME" />

                                    <asp:DynamicField DataField="MODULE_DESCRITION" />

                                    <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                        <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                        <ItemTemplate>
                                            <%--<asp:Button CssClass="btn btn-success" Text="Activate Coach" runat="server" OnCommand="ActivateCoach_Click" CommandArgument='<%= USER_ID  %>'  />--%>
                                             <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("MODULE_ID")%>'
                                                   CssClass="btn btn-primary" Text="Edit Module" OnClick="EDITMODULE_Click"></asp:LinkButton>
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
