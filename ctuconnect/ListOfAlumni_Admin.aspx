<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListOfAlumni_Admin.aspx.cs" Inherits="ctuconnect.ListOfAlumni_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
    .profile-container{
        background-color:white;
        margin-left:4%;
        padding-bottom:8px;
        border: 2px ;
        box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
    }

    .profile-container img{
        display:block;
        width:50%;
        margin-left:auto;
        margin-right:auto;
        margin-top:auto;
        padding-top:10px;
    }

    .profile-container p{
        display:block;
        text-align:center;
        font-size: 19px;
        margin-top:7%;
    }

    .second{
        border: none;
        border-top: 1.5px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:13%;
        margin-bottom:0%;
    }
         
    .horizontal-line {
        border: none;
        border-top: 1.5px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:1%;
        margin-bottom:0%;
    }
            
    .nav{
        padding:10px 10px 0px 10px;
        width:300px;
        margin-top:5px;
        position: absolute;
        margin-left:10px;
    }

    .nav a{
        font-size:18px;
        font-family:'Arial Rounded MT';
        color:#000000;
        text-decoration:none;
        position:static;
        font-size: 19px;
        display: block;
        margin: 2px 15px 5px 15px ;
        padding: 0px 0px 0px 8px;
    }

    .nav a.active{
        background-color:rgb(255, 194, 102);
        border-radius:10px;
        min-height:10px;

    }

    .nav a:hover{
        background-color:rgb(255, 194, 102);
        border-radius:10px;
        min-height:10px;

    }

    .container {
        min-height: 550px;
        background-color: #FFFFFF;
        max-width:100%;
        width:1550px;
        border: 2px;
        box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        padding-top:2em;
        padding-left:2em;
        padding-right:2em;                  
        margin-left:3px;
    }
    .container .title{
    font-size:25px;
    font-weight:500;
    position:relative;
    margin-bottom:3%;
    padding-bottom:4px;
    }
    .container .title:before{
        content:'';
        position:absolute;
        height:2px;
        width:40px;
        bottom:0;
        background-color: #881A30;

    }
   th{
   border-collapse: collapse;
    border-color:white;
    background-color:#f4f4fb;
    padding:5px;

    }
    .datas{
         padding:9px;
          border: 8px solid;
          border-color:white;
         font-weight:bold;
         color:black;
    }

    .table-list{
         border-collapse: collapse;
        font-size:13px; 
        height:auto; 
        width:100%;
        color:dimgray;
    }
    .topnav {
      overflow: hidden;
    }

    .topnav .linkbutton {
      float: left;
      display: block;
      color: black;
      text-align: center;
      padding: 2px 15px;
      text-decoration: none;
      font-size: 17px;
    }

    .topnav .linkbutton:hover {
      border-bottom: 2px solid black;
    }

    .topnav .linkbutton.active {
      border-bottom: 2px solid black;
      color:#881A30;
     }

</style>
<div class="container-fluid">
    <div class="row">
        <div class="col-3 d-flex flex-column" >
            <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">
                <div class="profile-container">
                    <img src="images/administratorpic.jpg" />
                    <p >Admin</p>
                    <hr class="horizontal-line" />
                    <a href="AdminDashboard.aspx">
                        <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dashboard
                    </a>
                    <a href="#myaccount">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Create Partnership
                    </a>
                    <a  href="IndustryVerification.aspx">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Industry Verification
                    </a>
                    <a href="ReferralList_Admin.aspx">
                        <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Referred Student
                    </a>
                    <hr class="horizontal-line" />
                    <a href="ListOfIndustries_Alumni.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Industry
                    </a>
                    <a href="ListOfInterns_Alumni.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Interns
                    </a>
                    <a class="active" href="ListOfAlumni_Admin.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Alumni
                    </a>
                    <hr class="horizontal-line" />
                    <a href="Dispute.aspx">
                        <i class="fa fa-exclamation-triangle" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dispute
                    </a>
                    <a href="Blacklist_Admin.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Blacklist
                    </a>
                    <hr class="second" />
                    <a href="TracerDashboard.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Tracer
                    </a>
                    <a href="#">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right:12px; width:32px;"></i>
                        Profile
                    </a>
                    <asp:LinkButton runat="server" ID ="LinkButton1">
                        <i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>
                        Sign-out
                    </asp:LinkButton>
                </div>
                
            </div>
        </div>
        <div class="col-9 d-flex flex-column">
            <br />
            <div class="container">
                <h1 class="title">List of Alumni</h1>
                <div class="col-lg-5 order-1 order-lg-2 topnav">
                    <asp:LinkButton ID="myLinkButton1"  runat="server" OnClick="btnSwitchGrid_CAS" CssClass="linkbutton" >CAS</asp:LinkButton>
                    <asp:LinkButton ID="myLinkButton2" runat="server" OnClick="btnSwitchGrid_CCICT" CssClass="linkbutton">CCICT</asp:LinkButton>
                    <asp:LinkButton ID="myLinkButton3"  runat="server" OnClick="btnSwitchGrid_CME" CssClass="linkbutton" >CME</asp:LinkButton>
                    <asp:LinkButton ID="myLinkButton4" runat="server" OnClick="btnSwitchGrid_COE" CssClass="linkbutton">COE</asp:LinkButton> 
                    <asp:LinkButton ID="myLinkButton5"  runat="server" OnClick="btnSwitchGrid_COEd" CssClass="linkbutton" >COEd</asp:LinkButton>
                    <asp:LinkButton ID="myLinkButton6" runat="server" OnClick="btnSwitchGrid_COT" CssClass="linkbutton">COT</asp:LinkButton> 
                </div>
                 
                <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                       <%--CAS Gridview--%>
                            <asp:Repeater ID="dataRepeater1" runat="server">
                            <HeaderTemplate>
                                <table  class="table-list">
                                    <tr>
                                         <th style="width: 150px;">Student ID</th>
                                        <th style="width: 200px;">Last name</th>
                                        <th style="width: 190px;">First name</th>
                                        <th style="width: 190px;">Middle initial</th>
                                        <th style="width: 200px;">Program enrolled</th>
                                        <th style="width: 200px;">Contact Number</th>
                                        <th style="width: 200px;">Email</th>
                                        <th style="width: 200px;">Year Graduated</th>
                                    </tr>
                                  </table>
                            </HeaderTemplate>
                                    <ItemTemplate>
                                        <table class="table-list">
                                        <tr class="datas">
                                             <td style="width: 120px;"><%# Eval("studentId") %></td>
                                            <td style="width: 160px;"><%# Eval("lastname") %></td>
                                            <td style="width: 170px;"><%# Eval("firstname") %></td>
                                            <td style="width: 170px;"><%# Eval("midinitials") %></td>
                                            <td style="width: 150px;"><%# Eval("course") %></td>
                                            <td style="width: 150px;"><%# Eval("contactNumber") %></td>
                                            <td style="width: 150px;"><%# Eval("email") %></td>
                                            <td style="width: 150px;"><%# Eval("yearGraduated") %></td>
                                        </tr>
                                            </table>
                                    </ItemTemplate>
                                </asp:Repeater>


                         

                                  <%--CCICT Gridview--%>
                               <asp:Repeater ID="dataRepeater2" runat="server">
                                <HeaderTemplate> 
                                    <table  class="table-list">
                                        <tr>
                                             <th style="width: 150px;">Student ID</th>
                                            <th style="width: 200px;">Last name</th>
                                            <th style="width: 190px;">First name</th>
                                            <th style="width: 190px;">Middle initial</th>
                                            <th style="width: 200px;">Program enrolled</th>
                                            <th style="width: 200px;">Contact Number</th>
                                            <th style="width: 200px;">Email</th>
                                            <th style="width: 200px;">Year Graduated</th>
                                        </tr>
                                      </table>
                                </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="table-list">
                                            <tr class="datas">
                                                 <td style="width: 120px;"><%# Eval("studentId") %></td>
                                                <td style="width: 160px;"><%# Eval("lastname") %></td>
                                                <td style="width: 170px;"><%# Eval("firstname") %></td>
                                                <td style="width: 170px;"><%# Eval("midinitials") %></td>
                                                <td style="width: 150px;"><%# Eval("course") %></td>
                                                <td style="width: 150px;"><%# Eval("contactNumber") %></td>
                                                <td style="width: 150px;"><%# Eval("email") %></td>
                                                <td style="width: 150px;"><%# Eval("yearGraduated") %></td>
                                            </tr>
                                                </table>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                      <%--CME Gridview--%>
                            <asp:Repeater ID="dataRepeater3" runat="server">
                             <HeaderTemplate>
                                    <table  class="table-list">
                                        <tr>
                                             <th style="width: 150px;">Student ID</th>
                                            <th style="width: 200px;">Last name</th>
                                            <th style="width: 190px;">First name</th>
                                            <th style="width: 190px;">Middle initial</th>
                                            <th style="width: 200px;">Program enrolled</th>
                                            <th style="width: 200px;">Contact Number</th>
                                            <th style="width: 200px;">Email</th>
                                            <th style="width: 200px;">Year Graduated</th>
                                        </tr>
                                      </table>
                                </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="table-list">
                                            <tr class="datas">
                                                 <td style="width: 120px;"><%# Eval("studentId") %></td>
                                                <td style="width: 160px;"><%# Eval("lastname") %></td>
                                                <td style="width: 170px;"><%# Eval("firstname") %></td>
                                                <td style="width: 170px;"><%# Eval("midinitials") %></td>
                                                <td style="width: 150px;"><%# Eval("course") %></td>
                                                <td style="width: 150px;"><%# Eval("contactNumber") %></td>
                                                <td style="width: 150px;"><%# Eval("email") %></td>
                                                <td style="width: 150px;"><%# Eval("yearGraduated") %></td>
                                            </tr>
                                                </table>
                                     </ItemTemplate>
                                 </asp:Repeater>
                                       

                                      <%--COE Gridview--%>
                            <asp:Repeater ID="dataRepeater4" runat="server">
                             <HeaderTemplate>
                                     <table  class="table-list">
                                        <tr>
                                             <th style="width: 150px;">Student ID</th>
                                            <th style="width: 200px;">Last name</th>
                                            <th style="width: 190px;">First name</th>
                                            <th style="width: 190px;">Middle initial</th>
                                            <th style="width: 200px;">Program enrolled</th>
                                            <th style="width: 200px;">Contact Number</th>
                                            <th style="width: 200px;">Email</th>
                                            <th style="width: 200px;">Year Graduated</th>
                                        </tr>
                                      </table>
                                </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="table-list">
                                            <tr class="datas">
                                                 <td style="width: 120px;"><%# Eval("studentId") %></td>
                                                <td style="width: 160px;"><%# Eval("lastname") %></td>
                                                <td style="width: 170px;"><%# Eval("firstname") %></td>
                                                <td style="width: 170px;"><%# Eval("midinitials") %></td>
                                                <td style="width: 150px;"><%# Eval("course") %></td>
                                                <td style="width: 150px;"><%# Eval("contactNumber") %></td>
                                                <td style="width: 150px;"><%# Eval("email") %></td>
                                                <td style="width: 150px;"><%# Eval("yearGraduated") %></td>
                                            </tr>
                                                </table>
                                     </ItemTemplate>
                                 </asp:Repeater>

                                      <%--COEd Gridview--%>
                        <asp:Repeater ID="dataRepeater5" runat="server">
                         <HeaderTemplate>
                                    <table  class="table-list">
                                        <tr>
                                             <th style="width: 150px;">Student ID</th>
                                            <th style="width: 200px;">Last name</th>
                                            <th style="width: 190px;">First name</th>
                                            <th style="width: 190px;">Middle initial</th>
                                            <th style="width: 200px;">Program enrolled</th>
                                            <th style="width: 200px;">Contact Number</th>
                                            <th style="width: 200px;">Email</th>
                                            <th style="width: 200px;">Year Graduated</th>
                                        </tr>
                                      </table>
                                </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="table-list">
                                            <tr class="datas">
                                                 <td style="width: 120px;"><%# Eval("studentId") %></td>
                                                <td style="width: 160px;"><%# Eval("lastname") %></td>
                                                <td style="width: 170px;"><%# Eval("firstname") %></td>
                                                <td style="width: 170px;"><%# Eval("midinitials") %></td>
                                                <td style="width: 150px;"><%# Eval("course") %></td>
                                                <td style="width: 150px;"><%# Eval("contactNumber") %></td>
                                                <td style="width: 150px;"><%# Eval("email") %></td>
                                                <td style="width: 150px;"><%# Eval("yearGraduated") %></td>
                                            </tr>
                                                </table>
                                 </ItemTemplate>
                             </asp:Repeater>

                                          <%--COT Gridview--%>
                        <asp:Repeater ID="dataRepeater6" runat="server">
                         <HeaderTemplate>
                                    <table  class="table-list">
                                        <tr>
                                             <th style="width: 150px;">Student ID</th>
                                            <th style="width: 200px;">Last name</th>
                                            <th style="width: 190px;">First name</th>
                                            <th style="width: 190px;">Middle initial</th>
                                            <th style="width: 200px;">Program enrolled</th>
                                            <th style="width: 200px;">Contact Number</th>
                                            <th style="width: 200px;">Email</th>
                                            <th style="width: 200px;">Year Graduated</th>
                                        </tr>
                                      </table>
                                </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="table-list">
                                            <tr class="datas">
                                                 <td style="width: 120px;"><%# Eval("studentId") %></td>
                                                <td style="width: 160px;"><%# Eval("lastname") %></td>
                                                <td style="width: 170px;"><%# Eval("firstname") %></td>
                                                <td style="width: 170px;"><%# Eval("midinitials") %></td>
                                                <td style="width: 150px;"><%# Eval("course") %></td>
                                                <td style="width: 150px;"><%# Eval("contactNumber") %></td>
                                                <td style="width: 150px;"><%# Eval("email") %></td>
                                                <td style="width: 150px;"><%# Eval("yearGraduated") %></td>
                                            </tr>
                                                </table>
                                 </ItemTemplate>
                             </asp:Repeater>

                            </ContentTemplate>
                            </asp:UpdatePanel>
</div>
            </div>
        </div>    
   
    </div>
</asp:Content>
