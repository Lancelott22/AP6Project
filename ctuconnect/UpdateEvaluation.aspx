<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="UpdateEvaluation.aspx.cs" Inherits="ctuconnect.UpdateEvaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <style>
        .container{
            min-height: 1050px;
            background-color: #FFFFFF;
            width:55%;
            border: 1px solid #FFFFFF;
            padding-top:2em;
            padding-left:2em;
            padding-right:2em;
        }
        .container2 {
            margin: auto;
            padding-right:2em;
            padding-left:1em;
            width:55%;
  
        }
        .details{
           padding-left:10em;
        }
        .txtbox{
            border-radius: 5px;
            width:400px;
            height: 30px;
        }
        .btn1{
            border: 1px solid red;
            border-radius: 5px;
            background-color: red;
            font-size: 14px;
    
        }

        .btn2{
            border: 1px #00cc99;
            border-radius: 5px;
            background-color: #00cc99;
            font-size: 14px;
    
        }
        .btn-md{
            border: 1px #F7941F;
            background-color: #F7941F;
            position:center;
            width: 120px;
            height:45px;
        }
        .btn-cancel{
            border: 1px solid #F7941F;
            background-color: #F0EBEB;
            position:center;
            width: 120px;
            height:45px;
            color:  #F7941F;
        }
        
    </style>
    <div class="container-fluid">
        <br />
        <div class="container">
            <div class="col-12 d-flex flex-column">
                <div class="row">
                    <div class="col-12 d-flex flex-column">
                        <h3 style="text-align:center">Update Evaluation</h3>
                            <br />
                            <div class="row">
                                <div class="col-12 d-flex flex-column">
                                    <div class="row">
                                        <div class="col-6">
                                            <b>Productivity</b>
                                                <br />
                                                <div class="row details">
                                                    <div class="col-6 d-flex flex-column">
                                                        <asp:TextBox ID="txtProd1" runat="server" CssClass="txtbox" placeholder=" Fails to do..."></asp:TextBox>
                                                        <asp:TextBox ID="txtProd2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtProd3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtProd4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtProd5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                    </div>
                                                </div>
                                        </div><br />
                                        <div class="col-6">
                                        <b>Cooperation</b>
                                        <br />
                                        <div class="row details">
                                            <div class="col-6 d-flex flex-column">
                                                <asp:TextBox ID="txtCoop1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtCoop2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtCoop3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtCoop4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtCoop5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    </div><br />
                                    <div class="row">
                                        <div class="col-6">
                                            <b>Ability to Follow Instructions</b>
                                                <br />
                                                <div class="row details">
                                                    <div class="col-6 d-flex flex-column">
                                                        <asp:TextBox ID="txtAbilityF1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtAbilityF2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtAbilityF3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtAbilityF4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtAbilityF5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>

                                                    </div>
                                                </div>
                                        </div><br />
                                        <div class="col-6">
                                        <b>Ability to Get Along with People</b>
                                        <br />
                                        <div class="row details">
                                            <div class="col-6 d-flex flex-column">
                                                <asp:TextBox ID="txtAbilityG1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAbilityG2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAbilityG3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAbilityG4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAbilityG5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    </div><br />
                                    <div class="row">
                                        <div class="col-6">
                                            <b>Initiative</b>
                                                <br />
                                                <div class="row details">
                                                    <div class="col-6 d-flex flex-column">
                                                        <asp:TextBox ID="txtInit1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtInit2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtInit3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtInit4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtInit5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                    </div>
                                                </div>
                                        </div><br />
                                        <div class="col-6">
                                        <b>Attendance</b>
                                        <br />
                                        <div class="row details">
                                            <div class="col-6 d-flex flex-column">
                                                <asp:TextBox ID="txtAttend1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAttend2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAttend3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAttend4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAttend5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    </div><br />
                                    <div class="row">
                                        <div class="col-6">
                                            <b>Quality of Work</b>
                                                <br />
                                                <div class="row details">
                                                    <div class="col-6 d-flex flex-column">
                                                    <asp:TextBox ID="txtQual1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                    <asp:TextBox ID="txtQual2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                    <asp:TextBox ID="txtQual3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                    <asp:TextBox ID="txtQual4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                    <asp:TextBox ID="txtQual5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>  
                                                    </div>
                                                </div>
                                        </div><br />
                                        <div class="col-6">
                                        <b>Appearance</b>
                                        <br />
                                        <div class="row details">
                                            <div class="col-6 d-flex flex-column">
                                                <asp:TextBox ID="txtAppear1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAppear2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAppear3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAppear4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtAppear5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>
                                    </div><br />
                                    <div class="row">
                                        <div class="col-6">
                                            <b>Dependability</b>
                                                <br />
                                                <div class="row details">
                                                    <div class="col-6 d-flex flex-column">
                                                        <asp:TextBox ID="txtDepend1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtDepend2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtDepend3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtDepend4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                        <asp:TextBox ID="txtDepend5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox> 
                                                    </div>
                                                </div>
                                        </div>
                                        <div class="col-6">
                                        <b>Overall Performance</b>
                                        <br />
                                        <div class="row details">
                                            <div class="col-6 d-flex flex-column">
                                                <asp:TextBox ID="txtOverall1" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtOverall2" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtOverall3" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtOverall4" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox>
                                                <asp:TextBox ID="txtOverall5" runat="server" CssClass="txtbox" placeholder="Does just enough..."></asp:TextBox> 
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div><br />
        <div class="container2">
            <div class="row">
                <div class="col-2 d-flex flex-column">
                    <asp:Button ID="btnSave" class="btn btn-primary btn-md" runat="server" Text="Save" OnClick="btnSave_Click"/>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="col-2 d-flex flex-column">
                    <asp:Button ID="btnCancel" class="btn btn-primary btn-md btn-cancel" runat="server" Text="Back" OnClick="btnCancel_Click"/>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
    </div>
    
</asp:Content>
