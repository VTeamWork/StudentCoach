<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="VteamWork.Question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                               Question Info
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
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <input type="text" ID="Name" runat="server" required="required" class="form-control">
                                                <label class="form-label">Name</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-float">
                                            <div class="form-line">
                                                <%--<input type="password" class="form-control">--%>
                                                <textarea ID="Description" runat="server" class="form-control" required="required"></textarea>
                                                <label class="form-label">Descsription</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-float">
                                         <label>Select Module</label>
                                               
                                                <div class="form-line">
                                                <%--<input type="password" class="form-control">--%>
                                      <asp:ListBox ID="ModuleList" SelectionMode="Single"  runat="server" CssClass="form-control show-tick">
                                  
                                    </asp:ListBox>           <%-- <label class="form-label">Select Module</label>--%>
                                            </div>
                                        </div>
                                    </div>

                                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        <div class="form-group form-float">
                                       <label>Select User Type</label>
                                                 <div class="form-line">
                                      <asp:ListBox ID="ListType" SelectionMode="Single"   runat="server" CssClass="form-control show-tick">
                                  <asp:ListItem Text="Select Type" Value=""> </asp:ListItem>
                                   <asp:ListItem Text="Student" Value="2"></asp:ListItem>
                                   <asp:ListItem Text="Coach" Value="3"></asp:ListItem>
                                   

                                           </asp:ListBox>          
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                        
                                        <asp:HiddenField ID="QuestionID" runat="server" />
                                        
                                        <asp:Button  OnClick="btnSave_Click" Text="Save" CssClass="btn btn-block bg-red" runat="server" /> 
                </div>
                                </div>


                        </div>





   <div class="table-responsive">
                            <asp:GridView runat="server" ID="GridViewDemo2" DataKeyNames="MODULE_ID"
                                ItemType="Model.tbl_QUESTION"
                                SelectMethod="GetQuestions"
                                AutoGenerateColumns="false"
                                CssClass="gvv table table-bordered table-striped table-hover">

                                <HeaderStyle />
                                <Columns>

                                    <asp:DynamicField DataField="QUESTION_ID" HeaderText="ID" />

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
            </div>
            <!-- #END# Inline Layout | With Floating Label -->
            <!-- Multi Column -->

</asp:Content>
