﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="HiredList.aspx.cs" Inherits="ctuconnect.HiredList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha512-9aLThZMxx+rKTEzeibpBtJPLcA6nhcwScQJ/DV+ytI+73m9Z2ap53lr1dH5tRjS9bOwD3GH1vbAhr5ZC9fIvnQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pikaday/1.8.0/pikaday.min.js"></script>

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
        .profile-container{
            font-family: 'Poppins', sans-serif;
            max-width:260px;
            max-height:300px;
            background-color:white;
            margin-left:4%;
        }
        @media (max-width: 790px) {
            .profile-container, .sidemenu-container {
                max-width: 50%;
                max-height:auto;
                padding:5px 5px 5px 5px;
            }
        }
        .profile-container img{
            display:block;
            width:80%;
            margin-left:auto;
            margin-right:auto;

        }
        .profile-container p{
             display:block;
             text-align:center;
             font-size: 19px;
            margin-top:7%;
        }
        .sidemenu-container{
            font-family: 'Poppins', sans-serif;
           width:253px;
            min-height:280px;
            background-color:white;
            /*margin-top:22%;*/
            padding-top:4px;
            padding-bottom:4px;
            margin-bottom:10%;
            margin-left:4%;
            border-radius: 25px;
            border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }
        .sidemenu-container a {
                position:static;
                border-radius: 25px;
                color: black;
                text-decoration: none;
                font-size: 19px;
                display: flex;
                margin: 10px 15px 5px 15px ;
                padding: 0px 0px 0px 20px;
                align-items:center;
         }
        .sidemenu-container a.active{
                 background-color:#F6B665;
                color:#606060;
         }
        .sidemenu-container a:hover{
                background-color:#fcd49a;
                color:#606060;
                margin: 10px 15px 5px 15px ;
                padding: 0px 0px 0px 20px;
         }
        .display-container{
                font-family: 'Poppins', sans-serif;
                background-color:white; 
                width:1500px;
                top:0;
                bottom:0;
                padding: 2% 2% 0% 2%;
                overflow: auto;
                height:800px;
                
        }
         .display-container .title{
                font-size:25px;
                font-weight:500;
                position:relative;
                margin-bottom:1%;
                padding-bottom:4px;
            }
         .display-container .title:before{
                content:'';
                position:absolute;
                height:2px;
                width:40px;
                bottom:0;
                background-color: #881A30;

            }
         .content{
                 height:100%; 
                 width:97%; 
                 margin-left:2%; 
                 margin-right:2%;
                 padding: 0px 0px 0px 0px;
             }
         .gridview-style{
                 margin-top:5%;
                 text-align:center;
             }
         .gridview-style .header-style{
                 width:20px;
                 text-align:center;
                 align-items:center;
             }
         .sort-dropdown{
                border-radius: 12px;
                width:100px;
                padding-left:8px;
                border-color:#c1beba;
            }
         .gridview-container {
                position: relative;
                min-height: 1px;
                height: auto;
                width: 100%;
            }
         .gridview {
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                display: none;
            }
   
        .full-time:active::before{
                    content:'';
                    position:absolute;
                    height:10px;
                    width:40px;
                    bottom:0%;
                    background-color: #881A30;

        }
        .fa {
                    width:20px;
                    margin-right: 19px; 
        }
.topnav {
          overflow: hidden;
          width:100%;
        }
        .topnav2{
            overflow: hidden;
            width:100%;
            padding: 2px 15px;
        }
        .bulk-action{
            float:right;
            display:flex; 
            gap:10px;
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
        th{
           border-collapse: collapse;
            border-color:white;
            background-color:#f4f4fb;

        }

        .datas{
              border: 5px solid;
              border-color:white;
             color:black;
             cursor:default;
        }


        .table-list{
         border-collapse: collapse;
        font-size:15px; 
        height:auto; 
        width:100%;
        color:dimgray;
        padding-right:4px;
        }
        .evaluateButton{
            background-color: #F9E9B7; 
            color: #F3C129; 
            margin-right:2px;
            border-radius: 25px; 
            padding: 1px 3px; 
            text-align: center;
            cursor: pointer;
            border:none;
        }
        .ellipsis {
        cursor: pointer;
        position: absolute;
        transform: translateY(-50%);
        font-size: 28px; /* Adjust font size as needed */
        color: gray; /* Adjust color as needed */
    }
        .highlighted-row {
            background-color: whitesmoke; /* Adjust background color as needed */
        }
/*        .modal{
     width:25%;
     margin:auto;
     margin-top:100px;
 }*/
.modalprompt{
width:100%;
     margin:auto;
     margin-top:100px;
}
/* .modal-content{
     padding-left:7%;
    
 }*/
         .selectedRow {
        background-color: whitesmoke; /* Change this to your desired highlight color */
    }
    .icon-link-button {
        background: none;
        border: none;
        padding: 0;
        font-size: inherit;
        color:gray;/* You can adjust the color to match your design */
        cursor: pointer;
        text-decoration: none;
        display: inline-block;
    }
    .edit-button {
    background-color: white;
    border: 1px solid;
    border-color: gray;
    box-shadow: 0 0px 8px rgba(0, 0, 0.8, 0.2);
    background-color: #881a30;
    color: white;
    padding-left: 8px;
    padding-right: 8px; 
    text-decoration:none;
    }
    .edit-button:hover {
        color: lightgray; 
        text-decoration: none; 
    }
    .delete-button {
    background-color: white;
    border: 1px solid;
    border-color: gray;
    box-shadow: 0 0px 8px rgba(0, 0, 0.8, 0.2);
    color: black;
    padding-left: 8px;
    padding-right: 8px; 
    text-decoration:none;
    }
    .delete-button:hover {
        color: dimgray; 
        text-decoration: none; 
    }
        th.clickable {
        cursor: pointer;
        text-decoration: underline;
    }

    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; height:200px;">
                <div class="profile-container">
                    <asp:Image ID="industryImage1" runat="server" />
                    <center>
                        <b>
                            <asp:Label ID="disp_industryName" CssClass="disp_industryName" runat="server" Text=""></asp:Label></b></center>
                    <center>
                        <p style="font-size: 14px;">
                            Account ID: <b>
                                <asp:Label ID="disp_accID" runat="server" Text=""></asp:Label></b>
                        </p>
                    </center>
                </div>
            </asp:TableCell>
            <asp:TableCell  RowSpan="2" Style="padding:0px 5px 0px 40px">

               <div class="display-container">
                   <h1 class="title">Hired List</h1>
                   <p style="float:right;">Search <asp:Textbox ID="searchInput" runat="server" style="border-color:#c1beba; border-width:1px;" OnTextChanged="SearchInternInfo" AutoPostBack="true" EnableViewState="true"></asp:Textbox></p> 
                   <div class="col-lg-5 order-1 order-lg-2 topnav">
                       <asp:LinkButton ID="myLinkButton1"  runat="server" OnClick="btnSwitchGrid_Click1" CssClass="linkbutton" >Full Time</asp:LinkButton>
                       <asp:LinkButton ID="myLinkButton2" runat="server" OnClick="btnSwitchGrid_Click2" CssClass="linkbutton">Internship</asp:LinkButton>  
                       <p style="float:left;">Status <asp:DropDownList ID="academicYear" runat="server" AutoPostBack="true" Style="width:90px;" CssClass="sort-dropdown">
                            <asp:ListItem Text="ongoing" Value="ColumnName1"></asp:ListItem>
                            <asp:ListItem Text="done" Value="ColumnName2"></asp:ListItem>
                        </asp:DropDownList></p>
                       <div class="bulk-action">
                           <asp:LinkButton ID="btnEdit" runat="server" CssClass="edit-button" OnClick="onEditButton_Click" > 
                               <i class="fas fa-edit"></i> Edit
                           </asp:LinkButton>
                           <asp:LinkButton ID="btnDelete" runat="server" CssClass="delete-button" OnClientClick="return confirmDelete();" >
                               <i class="fas fa-trash"></i> Delete
                           </asp:LinkButton>
                           </div>
                    </div>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
                            <%--First Gridview--%>
                           <asp:ListView ID="listView1" runat="server"  OnDataBound="listView1_DataBound">
                                <LayoutTemplate>
                                <table  class="table-list">
                                    <tr>
                                        <%--<th>No.</th>--%>
                                       <th>Last Name</th>
                                       <th >First Name</th>
                                       <th >Date Started</th>
                                       <th>Position</th>
                                       <th>Resume</th>
                                    </tr>
                                  </table>
                                        <tbody>
                                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                        </tbody>
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <table class="table-list">
                                        <tr>
                                            <%--<td><%# Container.ItemIndex + 1 %></td>--%>
                                           <td ><%# Eval("lastName") %></td>
                                           <td ><%# Eval("firstName") %></td>
                                           <td><%# Eval("dateStarted") %></td>
                                           <td><%# Eval("position") %></td>
                                            <td class="datas">
                                                <asp:Button ID="ResumeButton"  runat="server" Text="View Resume"
                                                OnCommand="ViewResume_Command" CommandName="View"  
                                                CommandArgument='<%# Eval("resumeFile") %>'/>
                                            </td>
                                        </tr>
                                            </table>
                                    </ItemTemplate>
                                   </asp:ListView>
                          
                   
                            <%--Second Gridview--%>
                                  
                                       <asp:ListView ID="listView2" runat="server" >
                                    <LayoutTemplate>
                                        <table  class="table-list">
                                            <tr>
                                                <th></th>
                                                <th>Last Name <i class="fas fa-sort"></i></th>
                                                <th>First Name <i class="fas fa-sort"></i>
</th>
                                                <th>Position</th>
                                                <th >Hired</span></th>
                                                <th>Started</span></th>
                                                <th>Ended</th>
                                                <th>Internship Status</th>
                                                <th>Rendered Hours</th>
                                                <th>Evaluation</th>
                                            </tr>
                                            <tbody>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                            </tbody>
                                            </table>
                                        </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr class="datas clickableRow" onclick="toggleHighlightAndCheckbox(document.getElementById('<%# ((ListViewDataItem)Container).FindControl("chkSelect").ClientID %>'));" >
                                                        <td>
                                                            <asp:CheckBox ID="chkSelect" runat="server" onclick="event.stopPropagation(); toggleHighlight(this);"  />
                                                        </td>
                                                        <td style="display:none;"><asp:Label ID="lblStudentID" runat="server" Visible="false" Text='<%# Eval("student_accID") %>'></asp:Label></td>
                                                        <td >
                                                             <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("lastName") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                             <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("firstName") %>'></asp:Label>
                                                        </td>
                                                        <td >
                                                             <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("position") %>'></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateHired" runat="server" Text='<%# Eval("dateHired") %>'></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblDateStarted" runat="server" Text='<%# Eval("dateStarted") %>'></asp:Label>
                                                        </td>
                                                        <td >
                                                            <asp:Label ID="lblDateEnded" runat="server" Text='<%# Eval("dateEnded") %>'></asp:Label>
                                                        </td>
                                                        <td >
                                                             <i class='<%# string.Equals(Eval("internshipStatus").ToString(), "Ongoing", StringComparison.OrdinalIgnoreCase) ? "fas fa-play-circle text-warning" : "fas fa-check-circle text-success" %>'></i>
                                                             <asp:Label ID="lblInternshipStatus" runat="server" Text='<%# Eval("internshipStatus") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblRenderedHours" runat="server" Text='<%# Eval("renderedHours") %>'></asp:Label>
                                                        </td>
                                                        <td >
                                                            <asp:Button ID="EvaluationBtn"  runat="server" Text='<%# Eval("evaluationRequest") %>' CommandArgument='<%# Eval("student_accID") %>' CommandName='<%# Eval("id") %>'  OnCommand="EvaluationBtn_Command" CssClass='<%# GetButtonCssClass(Eval("evaluationRequest")) %>'/>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:ListView>
                       </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top;">
                <div class="sidemenu-container">
                    <a  href="IndustryDashboard.aspx"><i class='bx bxs-dashboard' aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                   <a  href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                     <a href="IndustryJobPosted.aspx"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                     <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                     <a class="active" href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                     <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                    <a href="IndustryProfile.aspx"><i class="fa fa-user" aria-hidden="true"></i>Profile</a>
                     <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                    <i class="fa fa-sign-out" aria-hidden="true"></i>
                     Sign-out
                    </asp:LinkButton>
               </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>



    <div id="myModal" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
         <div class="modal-content">
             <asp:Label ID="studentID" runat="server" style="display:none;"></asp:Label>
             <div class="modal-header">
                 <h3><b>Intern Details</b></h3> 
             </div>
             <div class="modal-body" style="padding-left:12%;">
                    <asp:Label ID="Label22" runat="server" Text="Intern Names" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:40px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="fullnameLabel" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                     <asp:Label ID="Label3" runat="server" Text="Position" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:84px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="positionLabel" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                    <asp:Label ID="Label4" runat="server" Text="Hired" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:106px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="hiredLabel" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                    <asp:Label ID="Label5" runat="server" Text="Date Started" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:48px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                       <asp:Label ID="dateStartedlbl" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                    <asp:Label ID="Label6" runat="server" Text="Status" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:98px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:DropDownList runat="server" ID="ddlStatus" style="width:100px; padding-left:10px; font-size:18px; border-radius:10px;" onchange="handleStatusChange()">
                             <asp:ListItem Text="ongoing" Value="Ongoing"></asp:ListItem>
                             <asp:ListItem Text="done" Value="Done"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblStatus" runat="server"  Visible="false"></asp:Label>
                    </div><div style="clear: both;"></div>
                <div id="detailsDateEnded">
                    <asp:Label ID="Label10" runat="server" Text="Date Ended" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:54px; font-size:18px; float:left;">:</span>
                               
                    <div style="margin-left: 5%; float:left;">
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                        <asp:TextBox ID="txtDateEnded" runat="server" TextMode="Date" CssClass="txtbox" Width="100px" Height="25px" AutoPostBack="true" OnTextChanged="TxtDate_TextChanged" ></asp:TextBox><br />
                        <asp:Label ID="dateErrorlabel" runat="server"  Font-Size="Medium" ForeColor="Red" style="font-size:11px;" ></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                </div><asp:Label ID="lbldate" runat="server" Font-Size="Medium" ForeColor="Red" Visible="false"></asp:Label>
                 <div style="clear: both;"></div>
                <div  id="detailsFeedback">
                    <asp:Label ID="Label7" runat="server" Text="Feedback" Style="font-size:18px;" ></asp:Label><br /><br />
                    <div style="clear: both;"></div>
                    <asp:TextBox ID="txtFeedback" runat="server" class="form-control" Height="200px" Width="500px" placeholder="(Optional)"></asp:TextBox>
                    
                </div>
           </div>
        <div class="modal-footer">
             <div style="float: right;">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="saveDatesDetails" class="btn btn-success" type="button"/>
                <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="closeEditModal" class="btn btn-danger" />
            </div>
        </div>
        </div>
       </div>
    </div>

        <div id="myModal2" class="modal" tabindex="-1" role="dialog" aria-hidden="true">
             <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
                <div class="modal-content">
                 <div class="modal-header">
                     <h3><b>Intern Details</b></h3>
                 </div>
              <div class="modal-body" style="padding-left:12%;">
                <asp:Label ID="Label11" runat="server" Text="Intern Names" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:40px; font-size:18px; float:left;">:</span>
                <div style="margin-left: 5%; float:left;">
                    <asp:Label runat="server" ID="namelabel" style="font-size:18px;"></asp:Label>
                </div><div style="clear: both;"></div>
                <asp:Label ID="Label12" runat="server" Text="Date Ended" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:53px; font-size:18px; float:left;">:</span>
                <div style="margin-left: 5%; float:left;">
                    <asp:TextBox ID="txtendedDate" runat="server" TextMode="Date" CssClass="txtbox" Width="200px" Height="25px"></asp:TextBox>
                </div><div style="clear: both;"></div><br />
                  <asp:Label ID="Label15" runat="server" Style="font-size:16px; text-align:center;">
                  <span style="color: red;">Note: </span>Please provide feedback individually
                  </asp:Label><br />
            </div>
            <div class="modal-footer">
                    <asp:Button ID="Button1" runat="server" Text="Save"  class="btn btn-success" OnClick="SaveMultipleEdit"/>
                    <asp:Button ID="Button2" runat="server" Text="Close" class="btn btn-secondary" />
            </div>
                </div>
            </div>
        </div>

        <div id="myModalforDoneInternship" class="modal" tabindex="-1" role="dialog" aria-hidden="true" >
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
         <div class="modal-content">
             <div class="modal-header">
                 <h3><b>Intern Details</b></h3> 
             </div>
             <div class="modal-body" style="padding-left:12%;">
                    <asp:Label ID="Label16" runat="server" Text="Intern Names" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:40px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="namelbl" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                     <asp:Label ID="Label18" runat="server" Text="Position" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:84px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="positionlbl" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                    <asp:Label ID="Label20" runat="server" Text="Hired" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:106px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="hiredlbl" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                    <asp:Label ID="Label25" runat="server" Text="Date Started" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:48px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                       <asp:Label ID="startlbl" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                    <asp:Label ID="Label27" runat="server" Text="Status" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:98px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                       <asp:Label ID="statuslabel" runat="server" style="font-size:18px; color:green;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
                    <asp:Label ID="Label29" runat="server" Text="Date Ended" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:54px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="dateendedlabel" runat="server" style="font-size:18px;"></asp:Label>
                    </div><br /><div style="clear: both;"></div>
        <div class="modal-footer">
             <div style="float: right;">
                <asp:Button ID="Button3" runat="server" Text="OK" data-dismis="modal" class="btn btn-success" type="button"/>
            </div>
        </div>
       </div>
        </div>
       </div>
    </div>

      <div class="modal fade" id="SuccessPrompt" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                         <br />
                        <img src="images/check-mark.png" style="width:100px; height:auto;" /><br />
                        <asp:Label ID="Label23" runat="server" Text="Success !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label24" runat="server" Text="Your update was succesful." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="Close_SuccessPrompt" />
                    </div>
                </div>
            </div>
</div>

            <div class="modal fade" id="DoneInternshipSelected" tabindex="-1" role="dialog" aria-hidden="true" >
             <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" >
                 <div class="modal-content">
                     <div class="modal-header">
                           <h2><span style="color: red;">&#9888;</span> Failed to Proceed</h2>
                     </div>
                    <div class="modal-body" style="padding-left:8%; text-align:center;">
                              <asp:Label ID="Label8" runat="server" Style="font-size:16px; text-align:center;">
                                <span style="color: red;">Note: </span>You can only edit multiple rows with the same status in their internship
                                </asp:Label><br />
                     </div>
                     <div class="modal-footer">
                         <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                     </div>
                 </div>
             </div>
            </div>

                <div class="modal fade" id="AllDone" tabindex="-1" role="dialog" aria-hidden="true" >
             <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable" >
                 <div class="modal-content">
                     <div class="modal-header">
                           <h2><span style="color: red;">&#9888;</span> Failed to Proceed</h2>
                     </div>
                    <div class="modal-body" style="padding-left:8%; text-align:center;">
                              <asp:Label ID="Label9" runat="server" Style="font-size:16px; text-align:center;">
                               <b>Note:</b> Multiple edit on <span style="color: green;">Done</span> interns <span style="color: red;">is not supported</span><br />
                                  Please edit feedback individually
                                </asp:Label><br />
                     </div>
                     <div class="modal-footer">
                         <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                     </div>
                 </div>
             </div>
            </div>

                <div class="modal fade" id="NoSelected" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                        <asp:Label ID="Label13" runat="server" Style="font-size:25px;" ><span style="color: red;">&#9888;</span> No Selected !</asp:Label><br />
                        <asp:Label ID="Label14" runat="server" Text="Please select atleast one row, Thank you." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="OK" OnCLick="Close_NoSelectedPrompt" />
                    </div>
                </div>
            </div>
</div>


                <div class="modal fade" id="SuccessMultipleEditPrompt" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                         <br />
                        <img src="images/check-mark.png" style="width:100px; height:auto;" /><br />
                        <asp:Label ID="Label1" runat="server" Text="Success !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" Text="Your update was successful." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="Close_MultipleEditSuccessPrompt" />
                    </div>
                </div>
            </div>
</div>

    <div class="modal fade" id="confirmDeleteModal" tabindex="-1" role="dialog" aria-labelledby="confirmDeleteModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="confirmDeleteModalLabel">Confirmation</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                Are you sure you want to delete this record?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
                <button type="button" class="btn btn-danger" onclick="deleteRow();">Delete</button>
            </div>
        </div>
    </div>
</div>
    <script type="text/javascript">
        //function highlightRow(row) {
        //    // Remove the 'highlighted-row' class from all rows
        //    var rows = document.querySelectorAll('.datas');
        //    rows.forEach(function (r) {
        //        r.classList.remove('highlighted-row');
        //    });

        //    // Add the 'highlighted-row' class to the clicked row
        //    row.classList.add('highlighted-row');namelabel
        //}
        function openModal2(existingname) {
            var modal = document.getElementById("myModal2");
            modal.style.display = "block";

            var formattedNames = existingname.replace(/,/g, '<br>');
            
            document.getElementById('<%=namelabel.ClientID%>').innerHTML = formattedNames;

        }
        function openSingleSelectModal(existingID,existingname, existingposition, existingdatehired, existingdatestarted, existingdateended, existingstatus  ) {
            var modal = document.getElementById("myModal");
            var statusDropdown = document.getElementById('<%= ddlStatus.ClientID %>'); 

            document.getElementById('<%=studentID.ClientID%>').innerHTML = existingID;
            document.getElementById('<%=fullnameLabel.ClientID%>').innerHTML = existingname;
            document.getElementById('<%=positionLabel.ClientID%>').innerHTML = existingposition;
            document.getElementById('<%=hiredLabel.ClientID%>').innerHTML = existingdatehired;
            document.getElementById('<%=dateStartedlbl.ClientID%>').innerHTML = existingdatestarted;

            
            statusDropdown.value = existingstatus;
            if (statusDropdown.value === 'Ongoing') {
                document.getElementById("detailsDateEnded").style.display = "none";
                document.getElementById("detailsFeedback").style.display = "none";

            }
            else if (statusDropdown.value === 'Done') {
                document.getElementById("detailsDateEnded").style.display = "flex";
                document.getElementById("detailsFeedback").style.display = "flex";

            }

            modal.style.display = "block";
        }
        function openSingleSelectDoneModal(existingname, existingposition, existingdatehired, existingdatestarted, existingdateended, existingstatus, studentfeedback) {
            var modal = document.getElementById("myModalforDoneInternship");

                    document.getElementById('<%=namelbl.ClientID%>').innerHTML = existingname;
                    document.getElementById('<%=positionlbl.ClientID%>').innerHTML = existingposition;
                    document.getElementById('<%=hiredlbl.ClientID%>').innerHTML = existingdatehired;
            document.getElementById('<%=startlbl.ClientID%>').innerHTML = existingdatestarted;
            document.getElementById('<%=hiredlbl.ClientID%>').innerHTML = existingdatehired;
            document.getElementById('<%=dateendedlabel.ClientID%>').innerHTML = existingdateended;
            document.getElementById('<%=statuslabel.ClientID%>').innerHTML = existingstatus


                    modal.style.display = "block";
                }
        
        function closeModal() {
            document.getElementById("myModal").style.display = "none";

        }
        function closeEditModal() {
            var modal = document.getElementById("myModal");
            modal.style.display = "none";

            var checkboxes = document.getElementsByClassName("chkSelect");
            var row = checkbox.closest('tr');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = row.classList.remove('selectedRow');
            }
            

        }
        function openModalFailedEdit() {
            var modal = document.getElementById("doneInternshipSelected");
            modal.style.display = "block";
        }
        function closeModalFailedEdit() {
            var modal = document.getElementById("doneInternshipSelected");
            modal.style.display = "none";
        }

        
        function toggleHighlightAndCheckbox(checkbox) {
            checkbox.checked = !checkbox.checked; // Toggle the checkbox
            toggleHighlight(checkbox);
            /*toggleButtonsVisibility(checkbox.checked);*/
            var lblInternshipStatus = checkbox.closest('tr').querySelector('.lblInternshipStatus'); // Adjust the class name accordingly
            var btnEdit = document.getElementById("btnEdit");

            if (lblInternshipStatus != null && btnEdit != null) {
                // Check the status and hide the btnEdit accordingly
                if (lblInternshipStatus.innerText.trim().toUpperCase() === "DONE") {
                    btnEdit.style.display = "none";
                } else {
                    btnEdit.style.display = "block";
                }
            }
        }

        function toggleHighlight(checkbox) {
            var row = checkbox.closest('tr');
            if (checkbox.checked) {
                row.classList.add('selectedRow');
                /*toggleButtonsVisibility(checkbox.checked);*/
            } else {
                row.classList.remove('selectedRow');
                /*toggleButtonsVisibility(checkbox.checked);*/
            }
        }
        function handleStatusChange() {
            var statusDropdown = document.getElementById('<%= ddlStatus.ClientID %>');
            var txtDateEnded = document.getElementById('<%= txtDateEnded.ClientID %>');
            var txtFeedback = document.getElementById('<%= txtFeedback.ClientID %>');

            // Hide all divs initially
            if (statusDropdown.value === 'Ongoing'){
            document.getElementById("detailsDateEnded").style.display = "none";
                document.getElementById("detailsFeedback").style.display = "none";
                txtDateEnded.value = "";
                txtFeedback.value = "";
            }
             // Show the relevant divs based on the selected status
           
            if (statusDropdown.value === 'Done'){
                document.getElementById("detailsDateEnded").style.display = "flex";
                document.getElementById("detailsFeedback").style.display = "flex";
            }
            }
        function confirmDelete() {
        // Show the confirmation modal
        $('#confirmDeleteModal').modal('show');

        // Prevent the postback
        return false;
    }

    function deleteRow() {
        // Hide the modal
        $('#confirmDeleteModal').modal('hide');

        // Find the parent row of the button
        var row = document.getElementById('<%# btnDelete.ClientID %>').closest("tr");

        // Hide the row
        if (row) {
            row.style.display = "none";
        }
    }
  
       
    </script>
</asp:Content>
