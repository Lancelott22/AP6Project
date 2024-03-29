﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="Refer.aspx.cs" Inherits="ctuconnect.Refer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <meta name='viewport' content='width=device-width, initial-scale=1'>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
   
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
        .profile-container{
            font-family: 'Poppins', sans-serif;
            max-width:260px;
            min-height:660px;
            background-color:white;
            margin-left:4%;
            padding-bottom:8px;
             border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        }
        @media (max-width: 790px) {
            .profile-container, .sidemenu-container {
                max-width: 50%;
                max-height:100%;
                
                 padding:5px 5px 5px 5px;
            }
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
        .sidemenu-container{
            font-family: 'Poppins', sans-serif;
            width:260px;
            height:200px;
            background-color:white;
            /*margin-top:22%;*/
            padding-top:4px;
            margin-bottom:10%;
            margin-left:4%;
            border-radius: 25px;
            border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
            
        }
       
            .profile-container a {
                position:static;
                border-radius: 10px;
                color: black;
                text-decoration: none;
                font-size: 19px;
                display: block;
                margin: 2px 15px 5px 15px ;
                padding: 0px 0px 0px 8px;
            }
            .profile-container a.active{
                 background-color:#F6B665;
                color:#606060;
            }
            .profile-container a:hover{
                background-color:#fcd49a;
                color:#606060;
                margin: 2px 15px 5px 15px ;
                padding: 0px 0px 0px 8px;
                text-decoration: none;
            }
            .display-container{
                font-family: 'Poppins', sans-serif;
                background-color:white; 
                width:1550px;
                top:0;
                bottom:0;
                padding: 2% ;
                overflow: auto;
                /*background-color:white;*/
                height:800px;
            }
            
                .display-container {
                    max-width: 100%;
                }
           .display-container .title{
                font-size:25px;
                font-weight:500;
                position:relative;
                margin-bottom:3%;
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
   .horizontal-line {
        border: none;
        border-top: 2px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:1%;
        margin-bottom:0%;
    }
    .second{
        border: none;
        border-top: 2px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:13%;
        margin-bottom:0%;
    }
    .full-time:active::before{
                content:'';
                position:absolute;
                height:10px;
                width:40px;
                bottom:0%;
                background-color: #881A30;

    }
    .txtbox {
                 display:flex;
                 position:relative;
                 border-radius: 10px;
                 min-width: 100%;
                min-height:35px;
                margin-bottom:2%;
                padding-left:20px;
                border: 1px solid gray;
                justify-content: center; 
               
    }
    .txtbox-id {
             position:relative;
             border-radius: 10px;
             width: 200px;
            height:35px;
            margin-bottom:2%;
            padding-left:20px;
            border: 1px solid gray;
            justify-content: center; 
           
}
    .dropdown1{
               
                display:flex; 
                position:relative;
                 border-radius: 10px;
                 min-width:100%;
                min-height:35px;
                margin-bottom:2%;
                 border: 1px solid gray;
                justify-content: center;
                padding-left:20px;
            }
    .buttonSubmit {
            background-color: white;
            width: 80px;
            height: 35px;
            color: orange;
            border-radius: 10px;
            border: 1px solid orange;
            transition: background-color 0.3s, color 0.3s, border-color 0.3s;
        }

     .buttonSubmit:hover {
             background-color: #F6B665;
             color: white;
             border-color: orange;
            }
    .button-find {
    background-color: white;
    width: 80px;
    height: 35px;
    color: orange;
    border-radius: 10px;
    border: 1px solid orange;
    transition: background-color 0.3s, color 0.3s, border-color 0.3s;
}
    .button-find:hover {
    background-color: #F6B665;
    color: white;
    border-color: orange;
}
    
    .fa {
                width:20px;
                margin-right: 19px; 
    }
    .display-container .column{
        display: flex;
        column-gap: 5px;
    }
    .status-pending {
    color:red;
    text-align: center;
    cursor: pointer;
}
        .status-approved {
    color:green;
    text-align: center;
    cursor: pointer;
}
    .status-column{
        padding:10px;
    }
    th{
         border: 1px solid;
         border-color:#c4c4c4;
        background-color:#f4f4fb;
        padding:5px;

    }
/*    td{
        border: 1px solid;
        border-color:dimgray;
        padding-left:5px;
    }*/
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
    
    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell  style="vertical-align: top;">
                 <div class="profile-container">
                   <asp:Image ID="CoordinatorImage" runat="server"/>   
                       <p >OJT Coordinator</p>
                       <hr class="horizontal-line" />
                       <a href="CoordinatorProfile.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                       <a href="ListOfAlumni"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Alumni</a>
                       <a href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Partnered Industry</a>
                       <a class="active" href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px;"></i>Refer Student</a>
                       <a href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                       <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                       <a href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right:12px;"></i>Contact</a>
                       <a href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                       <a href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                       <a href="EditEvaluation.aspx"><i class="fa fa-file-text" aria-hidden="true" style="padding-right:12px;"></i>Evaluation Form</a>
                       <hr class="second" />
                       <a href="OJTCoordinator_Profile.aspx"><i class="fa fa-user" aria-hidden="true" style="padding-right:12px;"></i>Profile</a>
                       <a href="Coord_AccountSetting.aspx"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                       <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                           <i class="fa fa-sign-out" aria-hidden="true"></i>
                           Sign-out
                           </asp:LinkButton>
                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding:0px 5px 0px 40px">
                <div class="display-container">
                     <h1 class="title">Referral</h1>
                        <p style="float:left;">Sort by <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true"  CssClass="sort-dropdown">
                            <asp:ListItem Text="Date" Value="ColumnName1"></asp:ListItem>
                            <asp:ListItem Text="Status" Value="ColumnName2"></asp:ListItem>
                        </asp:DropDownList>
                        </p>
                            <asp:Button ID="addreferstudent" runat="server" Text="Add Refer Student" AutoPostBack="false" OnClick="addRefer_Click" style="float:right;"    />
                           
                              <asp:ListView ID="referredListView" runat="server">
                                    <LayoutTemplate>
                                      <table  class="table-list">
                                        <tr>
                                            <th>Student ID</th>
                                            <th>Last Name</th>
                                            <th>First Name</th>
                                            <th>Middle Initial</th>
                                            <th>Industry</th>
                                            <th>Referred by</th>
                                            <th>Referral Letter</th>
                                            <th>Date</th>
                                            <th>Status</th>
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
                                                <th>Last Name</th>
                                                <th>First Name</th>
                                                <th>Middle Initial</th>
                                                <th>Industry</th>
                                                <th>Referred by</th>
                                                <th>Referral Letter</th>
                                                <th>Date</th>
                                                <th>Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td style="text-align:center; font-size:18px;" colspan="9">No data available</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                  <ItemTemplate>
                                                <tr >
                                                    <td class="datas"><%# Eval("studentId") %></td>
                                                    <td class="datas"><%# Eval("lastName") %></td>
                                                    <td class="datas"><%# Eval("firstName") %></td>
                                                    <td class="datas"><%# Eval("midInitials") %></td>
                                                    <td class="datas"><%# Eval("industryName") %></td>
                                                    <td class="datas"><%# Eval("referredBy") %></td>
                                                    <td class="datas">
                                                        <asp:Button ID="btnEndorsementLetterButton" runat="server" Text="View Referral Letter"
                                                        OnCommand="ReviewLetter_Command" CommandName="Review"  
                                                        CommandArgument='<%# Eval("referralLetter") %>'/>
                                                    </td>
                                                    <td class="datas"><%# Eval("dateReferred") %></td>
                                                    <td class='datas <%# GetStatusCssClass(Eval("ReferralStatus").ToString()) %>' ><%# Eval("ReferralStatus") %></td>
                                                </tr>
                                            </ItemTemplate>
                            </asp:ListView>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


     <%--Modal--%>
 <div class="modal" id="AddReferralModal" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                 <h2 class="title">Refer a Student</h2>
             </div>
                 <div class="modal-body">
                     
                                <div class="column">
                                     <asp:Label ID="Label1" runat="server" Text="Student ID" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                     <asp:TextBox ID="txtID_student" runat="server" CssClass="txtbox-id" AutoPostBack="false"  Placeholder="e.g. 1202200" ></asp:TextBox>
                                     <asp:Button runat="server" OnClick="findByID_Student" Text="Find"  CssClass="button-find" CausesValidation="false" />
                                </div>

                                      <asp:Label ID="Label8" runat="server" Text="First Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtFirstName_student" runat="server" ReadOnly="true" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label9" runat="server" Text="Middle Initial" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtMiddleInitial_student" runat="server"  ReadOnly="true" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label3" runat="server" Text="Last Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtLastName_student" runat="server" ReadOnly="true" CssClass="txtbox"  ></asp:TextBox>

                                      <asp:Label ID="Label6" runat="server" Text="Industry" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                       <asp:DropDownList ID="dropdownIndustries" runat="server" CssClass="dropdown1"></asp:DropDownList>

                                      <asp:Label ID="Label7" runat="server" Text="Resume" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:Label ID="txtResumeFileName" runat="server" Text="" Style="font-size:14px;" ></asp:Label><br>
                                        
                                      <asp:Label ID="Label13" runat="server" Text="Referral Letter" Style="font-size:18px;" ></asp:Label>
                                      <asp:FileUpload ID="referralUpload" runat="server" Width="300px" /><br />

                                     <div class="column">
                                      <asp:Label ID="Label4" runat="server" Text="Referred by" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtID_coordinator" runat="server" CssClass="txtbox-id" Placeholder="Enter your ID" ReadOnly="true" AutoPostBack="true"></asp:TextBox>
                                         </div>
                                      <asp:Label ID="Label2" runat="server" Text="First Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtFirstName_coordinator" runat="server" ReadOnly="true" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label10" runat="server" Text="Middle Initial" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtMiddleInitial_coordinator" runat="server" ReadOnly="true" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label5" runat="server" Text="Last Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtLastName_coordinator" runat="server" ReadOnly="true" CssClass="txtbox"  ></asp:TextBox>
                      
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                 <asp:Button  class="buttonSubmit" runat="server" Text="Submit" OnCLick="Submit_ButtonClick" autopostback="false" />
             </div>
         </div>
     </div>
  </div>
    
   <%-- <div class="modal fade" id="SuccessPrompt" tabindex="-1" role="dialog" >
    <div class="modal-dialog modal-dialog-centered" >
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="title"></h1>
            </div>
             <asp:Label ID="SuccesfulPrompt" runat="server" Text="Your referral succesfully added." Style="font-size:18px;" ></asp:Label>
        </div>
        <div class="modal-footer">
               <button type="button" class="btn btn-secondary" data-dismiss="modal">OK</button>
        </div>
    </div>
    </div>--%>
    <div class="modal fade" id="SuccessPrompt" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                         <br />
                        <img src="images/check-mark.png" style="width:100px; height:auto;" /><br />
                        <asp:Label ID="Label11" runat="server" Text="Success !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label12" runat="server" Text="Your referral succesfully added." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="Close_SuccessPrompt" />
                    </div>
                </div>
            </div>
</div>

</asp:Content>
