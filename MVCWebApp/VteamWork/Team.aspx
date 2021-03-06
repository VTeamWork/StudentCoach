﻿<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="VteamWork.Team" %>

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

                        <div class="row clearfix" >
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="margin:0px !important">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">supervisor_account</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox runat="server" ID="txtTeamName" CssClass="form-control" required="required" placeholder="Team Name" />
                                    </div>
                                </div>
                            </div>

                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">description</i>
                                    </span>
                                    <div class="form-line">
                                        <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" required="required" TextMode="MultiLine" placeholder="Team Description" />
                                    </div>
                                </div>
                            </div>

                           
                                      <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12" style="padding:0px !important;margin:0px !important">
                               <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">person</i>
                                    </span>
                                   <label>Select Coach</label>
                                <div class="form-line">
                                   
                                    <asp:ListBox ID="CoachList" SelectionMode="Single"  runat="server" CssClass="form-control show-tick">
                                
                                    </asp:ListBox>
                                    </div>
                                   </div>




                                </div>

                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                               <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="material-icons">person</i>
                                    </span>
                                   <label>Select Multiple Student</label>
                                <div class="form-line">
                                   
                                    <asp:ListBox ID="lstStudents" SelectionMode="Multiple"  runat="server" CssClass="form-control show-tick">
                                      

                                
                                    </asp:ListBox>
                                      <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" ErrorMessage="Please select 5 students only." ClientValidationFunction="CustomValidator1_ClientValidate" > </asp:CustomValidator>
                                    </div>
                                   </div>
                                </div>


                        

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            
                                <div  class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                               <asp:HiddenField ID="TeamID" runat="server" />
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-block btn-lg bg-red waves-effect" OnClick="btnSave_Click" />
                               
                            </div>
                                </div>
                        </div>

                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="GridViewDemo2"
                                ItemType="Model.tbl_TEAM"
                                SelectMethod="GetUser"
                                AutoGenerateColumns="false"
                                CssClass="gvv table table-bordered table-striped table-hover">

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
          


                    </div>
                </div>
            </div>
        </div>
    </div>

     
<script>
function CustomValidator1_ClientValidate(source,args)
{ 
var listbox = document.getElementById("<%=lstStudents.ClientID %>");
var total = 0;
var i=0;
for( i = 0; i < listbox.options.length; i++ )
{
 if (listbox.options[i].selected) 
  {
   total ++; 
    if (total >5) {
      args.IsValid = false;
      return;
  }
  } 
 } 
 args.IsValid = true; return;
}
</script>


</asp:Content>
