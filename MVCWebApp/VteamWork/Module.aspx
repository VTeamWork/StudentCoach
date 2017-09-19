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
                    </div>
                    <div class="body">

                        <div class="form-horizontal panel" style="height: 200px">
                            <div class="col-md-5 col-xs-12 col-sm-5">
                                <label class="col-md-4 text-right">Module Name</label>
                                <div class="col-md-8">
                                    <%--<input type="text" class="form-control" placeholder="Module Name" />--%>
                                    <asp:TextBox ID="ModuleName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-5 col-xs-12 col-sm-5 checkbox" style="display: none">
                                <label class="col-md-4 text-right">Module Description</label>
                                <div class="col-md-8">

                                    <asp:TextBox TextMode="MultiLine" ID="Description" ClientIDMode="Static" CssClass="form-control" runat="server"></asp:TextBox>

                                    <%--<textarea class="form-control"></textarea>--%>
                                </div>

                            </div>

                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                <div class="form-group">

                                    <asp:CheckBox runat="server" ID="chkIs_Default" ClientIDMode="Static" Text="Description View" onchange="checkboxchange()" />

                                </div>
                            </div>

                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                <div class="form-group">

                                    <asp:CheckBox runat="server" ID="chkDefault" ClientIDMode="Static" Text="Is Default" />

                                </div>
                            </div>
                            <div class="col-md-2 col-xs-12 col-sm-2">
                                <asp:HiddenField ID="ModuleID" runat="server" />
                                <asp:Button Text="Save" class="form-control" OnClick="SaveModule_Click" CssClass="btn btn-lg bg-red" runat="server" />

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

                                    <%--<asp:DynamicField DataField="MODULE_ID" />--%>

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
    <script>

        function checkboxchange() {
            debugger
            if ($("#<%=chkIs_Default.ClientID%>").is(":checked")) {
                    $(".checkbox").show();
                }
                else {
                $(".checkbox").hide();
                }
            }


    </script>
</asp:Content>
