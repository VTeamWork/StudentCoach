<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="VteamWork.Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row clearfix">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="card">
                <div class="header">
                    <h2>Student Question Info
                    </h2>

                </div>
                <div class="body">
                    <div class="row clearfix">
                           <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12">
                            <div class="form-group form-float" style="margin :0px !important">
                                <label>Select Module</label>
                                <div class="form-line">
                                  <asp:ListBox ID="subModule" SelectionMode="Single"  runat="server" CssClass="form-control show-tick" OnSelectedIndexChanged="ModuleList_SelectedIndexChanged" AutoPostBack="true">
                                      </asp:ListBox> 
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12">
                            <div class="form-group form-float" style="margin :0px !important">
                                <label>Select Sub Module</label>
                                <div class="form-line">
                                    <asp:ListBox ID="ModuleList" SelectionMode="Single" runat="server" CssClass="form-control show-tick"></asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <input type="text" id="Name" runat="server"  class="form-control">
                                    <label class="form-label">Name</label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 col-md-5 col-sm-6 col-xs-12">
                            <div class="form-group form-float">
                                <div class="form-line">
                                    <textarea id="Description" runat="server" class="form-control"></textarea>
                                    <label class="form-label">Descsription</label>
                                </div>
                            </div>
                        </div>
                         <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                            <div class="form-group">
                  
                              <asp:CheckBox runat="server" ID="chkIs_Mendatory" ClientIDMode="Static" Text="Is Mandatory"/>
                                   
                            </div>
                        </div>

                        <div class="col-md-2 col-xs-12 col-sm-2">

                            <asp:HiddenField ID="QuestionID" runat="server" />
                             <input type="button" runat="server" ID="btnAdd"  value="Add Record" class="btn btn-primary"  onclick="Add();"  />
                        </div>
                    
                        <div class="col-md-2 col-xs-12 col-sm-2">
                        <asp:Button OnClick="btnSave_Click" Text="Save" CssClass="btn btn-block bg-red" runat="server" />
</div>                        
                    </div>


                </div>

                <div id="addedpartners" class="body table-responsive">
                    <table class="table" id="tblSeries" style="display: none">
                    <tbody></tbody>
                    </table>
                </div>





                <div class="table-responsive">
                    <asp:GridView runat="server" ID="GridViewDemo2" DataKeyNames="MODULE_ID"
                        ItemType="Model.tbl_QUESTION"
                        SelectMethod="GetQuestions"
                        AutoGenerateColumns="false"
                        CssClass="gvv table table-bordered table-striped table-hover">

                        <HeaderStyle />
                        <Columns>

                            <%--<asp:DynamicField DataField="QUESTION_ID" HeaderText="ID" />--%>

                            <asp:DynamicField DataField="QUESTION_NAME" HeaderText="Name" />

                            <asp:DynamicField DataField="QUESTION_DESCRITION" HeaderText="Description" />

                            <asp:TemplateField ItemStyle-Height="20px" HeaderText="Task Date" SortExpression="DATE" HeaderStyle-ForeColor="white">
                                <ItemStyle Width="15%" HorizontalAlign="Left" CssClass=" gridRow" Wrap="false" />
                                <ItemTemplate>
                                    <%--<asp:Button CssClass="btn btn-success" Text="Activate Coach" runat="server" OnCommand="ActivateCoach_Click" CommandArgument='<%= USER_ID  %>'  />--%>
                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%# Eval("QUESTION_ID")%>'
                                        CssClass="btn btn-primary" Text="Edit QUESTION" OnClick="EDITQUESTION_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="table" ClientIDMode="Static" />
    </div>


    <script type="text/javascript">
        var i = 0;
        var partner_details = [];

        function Add() {

            if (i == 0) {
                $("#tblSeries tbody").append("<tr><th>Question</th><th>Question Desciption</th><th>Is Mandatory</th> </tr>");
            }
            var mdlName = $("#<%=Name.ClientID%>").val();
            var mdlDesc = $("#<%=Description.ClientID%>").val();
           
            var IsMndtry = "";
            if ($("#<%=chkIs_Mendatory.ClientID%>").is(":checked")) {
                IsMndtry = "True"
            }
            else
            {
                IsMndtry = "False"
            }


            if (mdlName == "") {
                alert("Enter Module Name");
                return;
            }

            //if (mdlDesc == "") {
            //    alert("Enter Module Description");
            //    return;
            //}


            if (selectedrowid == null) {
                i++;
                $("#tblSeries").show();

                $('#tblSeries tr:last').after("<tr class=\"gridItemStyle genrow\" id=" + i + "><td>" + mdlName + "</td><td>" + mdlDesc + "</td><td>" + IsMndtry + "</td><td><a id=\"rempartner_" + i + "\" class=\"removepart\" href=\"#\" onclick=\"del('" + i + "');\">Remove</a></td></tr>");



                partner_details.push({

                    "rowid": i,
                    "mdlName": mdlName,
                    "mdlDesc": mdlDesc,
                    "IsMndtry": IsMndtry,
                });
                $("#table").val(JSON.stringify(partner_details));


            }
            else {
                for (var index in partner_details) {
                    if (partner_details[index].rowid == selectedrowid) {
                        partner_details.mdlName = mdlName;
                        partner_details.mdlDesc = mdlDesc;
                        partner_detailsils.isMndtry = IsMndtry;
                    }

                }
                $('#' + selectedrowid).html("<td>" + mdlName + "</td><td>" + mdlDesc + "</td><td>" + IsMndtry + "</td><td><a id=\"rempartner_" + selectedrowid + "\" class=\"removepart\" href=\"#\" onclick=\"del('" + i + "');\">Remove</a></td>");

            }
            Clear();
            selectedrowid = null;
        }

        function Clear() {


            $("#<%=Name.ClientID%>").val("");
            $("#<%=Description.ClientID%>").val("");
            $("#<%=chkIs_Mendatory.ClientID%>").prop('checked', false);
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
      



    </script>

</asp:Content>
