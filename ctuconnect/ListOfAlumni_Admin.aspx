<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListOfAlumni_Admin.aspx.cs" Inherits="ctuconnect.ListOfAlumni_Admin" EnableEventValidation="false" %>
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
        margin-left:50px;
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
         border: 1px solid;
         border-color:#c4c4c4;
        background-color:#f4f4fb;
        padding:5px;

    }
    .datas{
        border: 1px solid;
        border-color:#c4c4c4;
        padding-left:5px;
         color:black;
         cursor:default;
    }

    .table-list{
        border-collapse: collapse;        
        font-size:13px; 
        height:auto; 
        width:100%;
        color:dimgray;
        padding-right:4px;
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
        <div class="col-2 d-flex flex-column" >
            <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">
                <div class="profile-container">
                    <img src="images/administratorpic.jpg" />
                    <p >Admin</p>
                    <hr class="horizontal-line" />
                    <a href="AdminDashboard.aspx">
                        <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dashboard
                    </a>
                    <a href="IndustryVerification.aspx">
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
                    <a href="ListOfInterns_Alumni">
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
                        Blacklisted
                    </a>
                    <a href="SuggestionsAdmin.aspx">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Suggestions
                    </a>
                    <a href="Admin_Contact.aspx">
                        <i class="fa fa-comments" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Contact
                    </a>
                    <hr class="second" />
                    <a href="TracerDashboard.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                        Tracer
                    </a>
                    <a href="AdminProfile.aspx">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Profile
                    </a>
                    <a href="Coordinator_CreateAccount.aspx">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Coordinator Account
                    </a>
                </div>
                
            </div>
        </div>
        <div class="col-10 d-flex flex-column">
            <br />
            <div class="container">
                <h1 class="title">List of Alumni</h1>
                 <div id="academicYearSemesterFilter" style="float:left; min-width:50%;" runat="server">
                 <p style="float:left;">Academic Year  <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="sort-dropdown1" AutoPostBack="true" OnSelectedIndexChanged="dropdownsforCAS_SelectedIndexChanged"></asp:DropDownList></p>
                 <asp:DropDownList ID="programList" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="dropdownsforCAS_SelectedIndexChanged" ></asp:DropDownList>

                 <asp:DropDownList ID="ddlAcademicYear2" runat="server" CssClass="sort-dropdown1" AutoPostBack="true" OnSelectedIndexChanged="dropdownsforCCICT_SelectedIndexChanged" Visible="false"></asp:DropDownList>
                 <asp:DropDownList ID="programList2" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="dropdownsforCCICT_SelectedIndexChanged" Visible="false"></asp:DropDownList>

                 <asp:DropDownList ID="ddlAcademicYear3" runat="server" CssClass="sort-dropdown1" AutoPostBack="true" OnSelectedIndexChanged="dropdownsforCME_SelectedIndexChanged" Visible="false" ></asp:DropDownList>
                 <asp:DropDownList ID="programList3" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="dropdownsforCME_SelectedIndexChanged" Visible="false"></asp:DropDownList>

                 <asp:DropDownList ID="ddlAcademicYear4" runat="server" CssClass="sort-dropdown1" AutoPostBack="true" OnSelectedIndexChanged="dropdownsforCOE_SelectedIndexChanged" Visible="false" ></asp:DropDownList>
                 <asp:DropDownList ID="programList4" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="dropdownsforCOE_SelectedIndexChanged" Visible="false"></asp:DropDownList>

                  <asp:DropDownList ID="ddlAcademicYear5" runat="server" CssClass="sort-dropdown1" AutoPostBack="true" OnSelectedIndexChanged="dropdownsforCOEd_SelectedIndexChanged" Visible="false"></asp:DropDownList>
                 <asp:DropDownList ID="programList5" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="dropdownsforCOEd_SelectedIndexChanged" Visible="false"></asp:DropDownList>

                 <asp:DropDownList ID="ddlAcademicYear6" runat="server" CssClass="sort-dropdown1" AutoPostBack="true" OnSelectedIndexChanged="dropdownsforCOT_SelectedIndexChanged" Visible="false" ></asp:DropDownList>
                 <asp:DropDownList ID="programList6" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="dropdownsforCOT_SelectedIndexChanged" Visible="false"></asp:DropDownList>

                </div><div style="clear: both;"></div>
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
                            <asp:Listview ID="CASListview" runat="server">
                                      <LayoutTemplate>
                                          <table  class="table-list">
                                               <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                      </tr>
                                    <tbody>
                                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                               </tbody>
                              </table>
                              </LayoutTemplate> 
                               <EmptyDataTemplate>
                                <table class="table-list">
                                    <thead>
                                        <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align:center; font-size:18px;" colspan="8">No data available</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                                      <ItemTemplate>
                                          <tr>
                                               <td class="datas"><%# Eval("studentId") %></td>
                                              <td class="datas"><%# Eval("lastname") %></td>
                                              <td class="datas"><%# Eval("firstname") %></td>
                                              <td class="datas"><%# Eval("midinitials") %></td>
                                              <td class="datas"><%# Eval("course") %></td>
                                              <td class="datas"><%# Eval("contactNumber") %></td>
                                              <td class="datas"><%# Eval("email") %></td>
                                              <td class="datas"><%# Eval("yearGraduated") %></td>
                                          </tr>
                                      </ItemTemplate>
                                  </asp:Listview>


                         

                                  <%--CCICT Gridview--%>
                               <asp:Listview ID="CCICTListview" runat="server">
                                      <LayoutTemplate>
                                          <table  class="table-list">
                                               <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                      </tr>
                                    <tbody>
                                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                               </tbody>
                              </table>
                              </LayoutTemplate> 
                               <EmptyDataTemplate>
                                <table class="table-list">
                                    <thead>
                                        <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align:center; font-size:18px;" colspan="8">No data available</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                                      <ItemTemplate>
                                          <tr>
                                               <td class="datas"><%# Eval("studentId") %></td>
                                              <td class="datas"><%# Eval("lastname") %></td>
                                              <td class="datas"><%# Eval("firstname") %></td>
                                              <td class="datas"><%# Eval("midinitials") %></td>
                                              <td class="datas"><%# Eval("course") %></td>
                                              <td class="datas"><%# Eval("contactNumber") %></td>
                                              <td class="datas"><%# Eval("email") %></td>
                                              <td class="datas"><%# Eval("yearGraduated") %></td>
                                          </tr>
                                      </ItemTemplate>
                                  </asp:Listview>

                                      <%--CME Gridview--%>
                            <asp:Listview ID="CMEListview" runat="server">
                                      <LayoutTemplate>
                                          <table  class="table-list">
                                               <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                      </tr>
                                    <tbody>
                                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                               </tbody>
                              </table>
                              </LayoutTemplate> 
                               <EmptyDataTemplate>
                                <table class="table-list">
                                    <thead>
                                        <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align:center; font-size:18px;" colspan="8">No data available</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                                      <ItemTemplate>
                                          <tr>
                                               <td class="datas"><%# Eval("studentId") %></td>
                                              <td class="datas"><%# Eval("lastname") %></td>
                                              <td class="datas"><%# Eval("firstname") %></td>
                                              <td class="datas"><%# Eval("midinitials") %></td>
                                              <td class="datas"><%# Eval("course") %></td>
                                              <td class="datas"><%# Eval("contactNumber") %></td>
                                              <td class="datas"><%# Eval("email") %></td>
                                              <td class="datas"><%# Eval("yearGraduated") %></td>
                                          </tr>
                                      </ItemTemplate>
                                  </asp:Listview>
                                       

                                      <%--COE Gridview--%>
                            <asp:Listview ID="COEListview" runat="server">
                                      <LayoutTemplate>
                                          <table  class="table-list">
                                               <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                      </tr>
                                    <tbody>
                                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                               </tbody>
                              </table>
                              </LayoutTemplate> 
                               <EmptyDataTemplate>
                                <table class="table-list">
                                    <thead>
                                        <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align:center; font-size:18px;" colspan="8">No data available</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                                      <ItemTemplate>
                                          <tr>
                                               <td class="datas"><%# Eval("studentId") %></td>
                                              <td class="datas"><%# Eval("lastname") %></td>
                                              <td class="datas"><%# Eval("firstname") %></td>
                                              <td class="datas"><%# Eval("midinitials") %></td>
                                              <td class="datas"><%# Eval("course") %></td>
                                              <td class="datas"><%# Eval("contactNumber") %></td>
                                              <td class="datas"><%# Eval("email") %></td>
                                              <td class="datas"><%# Eval("yearGraduated") %></td>
                                          </tr>
                                      </ItemTemplate>
                                  </asp:Listview>

                                      <%--COEd Gridview--%>
                        <asp:Listview ID="COEdListview" runat="server">
                                      <LayoutTemplate>
                                          <table  class="table-list">
                                               <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                      </tr>
                                    <tbody>
                                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                               </tbody>
                              </table>
                              </LayoutTemplate> 
                               <EmptyDataTemplate>
                                <table class="table-list">
                                    <thead>
                                        <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align:center; font-size:18px;" colspan="8">No data available</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                                      <ItemTemplate>
                                          <tr>
                                               <td class="datas"><%# Eval("studentId") %></td>
                                              <td class="datas"><%# Eval("lastname") %></td>
                                              <td class="datas"><%# Eval("firstname") %></td>
                                              <td class="datas"><%# Eval("midinitials") %></td>
                                              <td class="datas"><%# Eval("course") %></td>
                                              <td class="datas"><%# Eval("contactNumber") %></td>
                                              <td class="datas"><%# Eval("email") %></td>
                                              <td class="datas"><%# Eval("yearGraduated") %></td>
                                          </tr>
                                      </ItemTemplate>
                                  </asp:Listview>

                                          <%--COT Gridview--%>
                        <asp:Listview ID="COTListview" runat="server">
                                      <LayoutTemplate>
                                          <table  class="table-list">
                                               <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                      </tr>
                                    <tbody>
                                   <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                               </tbody>
                              </table>
                              </LayoutTemplate> 
                               <EmptyDataTemplate>
                                <table class="table-list">
                                    <thead>
                                        <tr>
                                           <th>Student ID</th>
                                          <th>Last name</th>
                                          <th>First name</th>
                                          <th>Middle initial</th>
                                          <th>Program enrolled</th>
                                          <th>Contact Number</th>
                                          <th>Email</th>
                                          <th>Year Graduated</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td style="text-align:center; font-size:18px;" colspan="8">No data available</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </EmptyDataTemplate>
                                      <ItemTemplate>
                                          <tr>
                                               <td class="datas"><%# Eval("studentId") %></td>
                                              <td class="datas"><%# Eval("lastname") %></td>
                                              <td class="datas"><%# Eval("firstname") %></td>
                                              <td class="datas"><%# Eval("midinitials") %></td>
                                              <td class="datas"><%# Eval("course") %></td>
                                              <td class="datas"><%# Eval("contactNumber") %></td>
                                              <td class="datas"><%# Eval("email") %></td>
                                              <td class="datas"><%# Eval("yearGraduated") %></td>
                                          </tr>
                                      </ItemTemplate>
                                  </asp:Listview>

                            </ContentTemplate>
                            </asp:UpdatePanel>
</div>
            </div>
        </div>    
   
    </div>
</asp:Content>
