<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="SubModule.aspx.cs" Inherits="VteamWork.SubModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <!-- Basic Examples -->
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="card">
                    <div class="header">
                        <h2>Sub Module
                        </h2>
                       
                    </div>
                    <div class="body">

<div class="form-horizontal panel" style="height:200px">
    

         <div class="col-md-5 col-xs-12 col-sm-5">
        <label class="col-md-4 text-right">Select Module</label>
        <div class="col-md-8">
   <asp:ListBox ID="ModuleList" SelectionMode="Single"  runat="server" CssClass="form-control show-tick">
         </asp:ListBox> 
        </div>

    </div>

    <div class="col-md-5 col-xs-12 col-sm-5">
        <label class="col-md-4 text-right">Sub Module Name</label>
        <div class="col-md-8">
            <%--<input type="text" class="form-control" placeholder="Module Name" />--%>
           <asp:TextBox ID="ModuleName" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>

    </div>
     <div class="col-md-5 col-xs-12 col-sm-5">
        <label class="col-md-4 text-right">Module Description</label>
        <div class="col-md-8">
           <asp:TextBox TextMode="MultiLine" ID="Description" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
         </div>

    </div>
     <div class="col-md-2 col-xs-12 col-sm-2">
    <asp:HiddenField ID="ModuleID" runat="server" />
             <input type="button" runat="server" ID="btnAdd"  value="Add Record" class="btn btn-primary"  onclick="Add();" style="margin-top:20px !important"  />
            <asp:button text="Save" class="form-control"  OnClick="SaveModule_Click" Cssclass="btn btn-lg bg-red"    runat="server" />
    
    </div>
    
                  
</div>
                              <div id="addedpartners" class="body table-responsive" >
                             <table class="table" id="tblSeries" style="display:none">
                    <tr>
                        <th scope="col">Sub Module Name</th>
                        <th scope="col">Sub Module Description</th>
                    </tr>
            </table>
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
        
    <asp:HiddenField runat="server" ID="table" ClientIDMode="Static" />
        </div>

    
    <script type="text/javascript">

        var i = 0;
        var partner_details = [];

        function Add() {

            debugger

            var mdlName = $("#<%=ModuleName.ClientID%>").val();
            var mdlDesc = $("#<%=Description.ClientID%>").val();
            if (mdlName == "") {
                alert("Enter Module Name");
                return;
            }

            if (mdlDesc == "") {
                alert("Enter Module Description");
                return;
            }

            
            if (selectedrowid == null) {
                i++;
                $("#tblSeries").show();
              
                $('#tblSeries tr:last').after("<tr class=\"gridItemStyle genrow\" id=" + i + "><td>" + mdlName + "</td><td>" + mdlDesc + "</td><td><a id=\"rempartner_" + i + "\" class=\"removepart\" href=\"#\" onclick=\"del('" + i + "');\">Remove</a> | <a id=\"rempartnerupd_" + i + "\" class=\"removepartupd\"  href=\"#\" onclick=\"Edit('" + mdlName + "','" + mdlDesc + "');\">Edit</a></td></tr>");



                partner_details.push({

                     "rowid":i,
                    "mdlName": mdlName,
                    "mdlDesc": mdlDesc,
                });
                $("#table").val(JSON.stringify(partner_details));


           }
            else {
                for(var index in partner_details)
                {
                    if (partner_details[index].rowid == selectedrowid)
                    {
                        partner_details.mdlName = mdlName ;
                        partner_details.mdlDesc = mdlDesc ;
                    }

                }
                $('#' + selectedrowid).html("<td>" + mdlName + "</td><td>" + mdlDesc + "</td><td><a id=\"rempartner_" + selectedrowid + "\" class=\"removepart\" href=\"#\" onclick=\"del('" + i + "');\">Remove</a> | <a id=\"rempartnerupd_" + i + "\" class=\"removepartupd\" href=\"#\" onclick=\"Edit('" + mdlName + "','" + mdlDesc + "''" + selectedrowid + "');\">Edit</a></td>");

            }
            Clear();
            selectedrowid = null;
        }

        function Clear() {


            $("#<%=ModuleName.ClientID%>").val("");
            $("#<%=Description.ClientID%>").val("");
        }
        function del(i) {


            var a = i;


            $('#tblSeries').on('click', '.removepart', function (e) {

                debugger

                var rowId = $(this).attr("id").split("_")[1];
                var index = partner_details.indexOf(rowId);
                partner_details.splice(index, rowId);
                $("#table").val(JSON.stringify(partner_details));
                $("#" + rowId).remove();


                if ($(".genrow").length <= 0) {
                    $('#tblSeries').hide();
                }

                return false;



            });
        }


        var selectedrowid = null;
        function Edit(mdlName, mdlDesc, selectedrow) {

            $("#<%=ModuleName.ClientID%>").val(mdlName);
            $("#<%=Description.ClientID%>").val(mdlDesc);
            selectedrowid = selectedrow;
        }

     

    </script>
</asp:Content>
