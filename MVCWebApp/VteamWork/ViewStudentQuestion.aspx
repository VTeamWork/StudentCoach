<%@ Page Title="" Language="C#" MasterPageFile="~/VteamWork.Master" AutoEventWireup="true" CodeBehind="ViewStudentQuestion.aspx.cs" Inherits="VteamWork.ViewStudentQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <style>
        .RequiredQuestion{
            color:blue !important;
        }

    </style>
    <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>
                               Search Questions
                            </h2> 
             
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

                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                    <label></label>
                                        <div class="form-group">
                                           
                                              <asp:Button  OnClick="Search_Click" Text="Search" CssClass="form-control btn-block bg-red" runat="server" /> 
                                          
                                        </div>       
                                        
                                        
                                    </div>
                                </div>


                        </div>





   <div class="table-responsive">
       <div ID="DataShow" runat="server" style="margin-left:30px">
           

</div>
     
               </div>
    


                    </div>
                </div>
            </div>
  

</asp:Content>


