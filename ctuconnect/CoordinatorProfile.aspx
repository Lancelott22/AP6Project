<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="CoordinatorProfile.aspx.cs" Inherits="ctuconnect.CoordinatorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha512-9aLThZMxx+rKTEzeibpBtJPLcA6nhcwScQJ/DV+ytI+73m9Z2ap53lr1dH5tRjS9bOwD3GH1vbAhr5ZC9fIvnQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
        .profile-container{
            font-family: 'Poppins', sans-serif;
            max-width:260px;
            max-height:660px;
            background-color:white;
            margin-left:1%;
            padding-bottom:8px;
             border: 2px ;
            box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
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
                padding: 2%;
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
                 border-color:white;
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
                width:100px;
                padding-left:8px;
                border-color:#c1beba;
            }
            .sort-dropdown1{
                width:110px;
                padding-left:8px;
                border-color:#c1beba;
            }
            .sort-dropdown2{
                width:153px;
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
        border-top: 1.5px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:1%;
        margin-bottom:0%;
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
    .full-time:active::before{
                content:'';
                position:absolute;
                height:10px;
                width:40px;
                bottom:0%;
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
    .evaluateButton{
        padding-left:3px;
    padding-right:3px;
    background-color: #F9E9B7; 
    color: #F3C129; 
    margin-right:2px;
    border-radius: 25px;
    text-align: center;
    cursor: pointer;
    border:none;
}
    .actions{
     color: gray; 
     cursor: pointer;
     width:5px;
     height:auto;
    }
        .selectedRow {
        background-color: whitesmoke; /* Change this to your desired highlight color */
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
            .action-button {
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
            .edit-button{
        background-color: white;
        border: 1px solid;
        border-color: gray;
        box-shadow: 0 0px 8px rgba(0, 0, 0.8, 0.2);
        color: black;
        padding-left: 8px;
        padding-right: 8px; 
        text-decoration:none;
            }
                            .edit-button:hover {
        color: dimgray; 
        text-decoration: none; 
    }

    .edit-button i {
        margin-right: 5px; /* Adjust the margin as needed */
    }
                .action-button:hover {
        color: lightgray; 
        text-decoration: none; 
    }

    .action-button i {
        margin-right: 5px; /* Adjust the margin as needed */
    }
   
    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell  style="vertical-align: top;">
                <div class="profile-container">
                    <asp:Image ID="CoordinatorImage" runat="server"/>
                    <p >OJT Coordinator</p>
                    <hr class="horizontal-line" />
                    <a class="active" href="Coordinator.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                    <a  href="ListOfAlumni.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Alumni</a>
                    <a  href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Partnered Industry</a>
                     <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:32px;"></i>Refer Student</a>
                    <a  href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                    <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                     <a  href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right:12px;"></i>Contact</a>
                    <a  href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                     <a  href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
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
                 <h1 class="title">List of Interns</h1>

                   <p style="float:right;">Search <asp:Textbox runat="server" ID="searchInput" Style="border-color:#c1beba; border-width:1px;" OnTextChanged="SearchInternInfo" AutoPostBack="true" EnableViewState="true"/></p>
                    <div class="col-lg-5 order-1 order-lg-2 topnav">
                    <%-- <asp:DropDownList ID="statusList" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="status_SelectedIndexChanged">
                         <asp:ListItem Text="Hired" Value="1" />
                         <asp:ListItem Text="Not Hired" Value="0" />
                     </asp:DropDownList>--%>
                                           <div id="academicYearSemesterFilter" style="float:left; min-width:50%;" runat="server">
                    <p style="float:left;">Academic Year  <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="sort-dropdown1" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicYear_SelectedIndexChanged" >
                    </asp:DropDownList></p>
                    <asp:DropDownList ID="ddlSemester" runat="server" style="margin-left:1%;" CssClass="sort-dropdown2" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:DropDownList ID="programList" runat="server" AutoPostBack="true" Style="width:150px;" CssClass="sort-dropdown" OnSelectedIndexChanged="program_SelectedIndexChanged"></asp:DropDownList>
                   </div>
                       <div class="bulk-action">
                     <asp:LinkButton ID="btnEdit" runat="server" CssClass="edit-button" OnClick="Edit_Click">
                        <i class="fas fa-edit"></i> Edit
                    </asp:LinkButton> 
                    <asp:LinkButton ID="lnkRefer" runat="server" CssClass="action-button" OnClick="referIntern_Click">
                        <i class="fas fa-paper-plane"></i> Refer
                    </asp:LinkButton>                           

                       </div>
                    </div>
                   <asp:ListView ID="internListView" runat="server"> 
                       <LayoutTemplate>
                               <table  class="table-list">
                                    <tr>
                                        <th>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleSelectAll(this);" />
                                        </th>
                                        <th>Student ID</th>
                                        <th>Last name</th>
                                        <th>First name</th>
                                        <th>Middle initial</th>
                                        <th>Program enrolled</th>
                                        <th>Semester</th>
                                        <th>Contact Number</th>
                                        <th>Email</th>
                                        <th>Status</th>
                                        <th>Rendered Hours</th>
                                        <th>Evaluation</th>
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
                                                <th>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleSelectAll(this);" />
                                                </th>
                                                <th>Student ID</th>
                                                <th>Last name</th>
                                                <th>First name</th>
                                                <th>Middle initial</th>
                                                <th>Program enrolled</th>
                                                <th>Semester</th>
                                                <th>Contact Number</th>
                                                <th>Email</th>
                                                <th>Status</th>
                                                <th>Rendered Hours</th>
                                                <th>Evaluation</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td style="text-align:center; font-size:18px;" colspan="10">No data available</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </EmptyDataTemplate>
                                        <Itemtemplate>
                                            <tr class="clickableRow" onclick="toggleHighlightAndCheckbox(document.getElementById('<%# ((ListViewDataItem)Container).FindControl("chkSelect").ClientID %>'));">
                                                <td class="datas">
                                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="event.stopPropagation(); toggleHighlight(this);"  />
                                                </td>
                                                <td style="display:none;"><asp:Label ID="lblStudentaccId" runat="server" Visible="false" Text='<%# Eval("student_accID") %>'></asp:Label></td>
                                                <td class="datas">
                                                    <asp:Label ID="lblStudentId" runat="server" Text='<%# Eval("studentId") %>'></asp:Label>

                                                </td>
                                                <td class="datas">
                                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("lastname") %>'></asp:Label>

                                                </td>
                                                <td class="datas">
                                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("firstname") %>'></asp:Label>

                                                </td>
                                                <td class="datas"><%# Eval("midinitials") %></td>
                                                <td class="datas"> 
                                                    <asp:Label ID="courseLabel" runat="server" Text='<%# Eval("course") %>'></asp:Label>
                                                </td>
                                                <td class="datas"> 
                                                    <asp:Label ID="Label25" runat="server" Text='<%# Eval("semdescription") %>'></asp:Label>
                                                </td>
                                                <td class="datas">
                                                    <asp:Label ID="contactLabel" runat="server" Text='<%# Eval("contactNumber") %>'></asp:Label>
                                                </td >
                                                <td class="datas">
                                                    <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                                                </td>
                                                <td class="datas">
                                                    <asp:Label ID="lblIsHired" runat="server" Text='<%# Convert.ToBoolean(Eval("isHired")) %>' Visible="false"></asp:Label>
                                                        <%# (Convert.ToBoolean(Eval("isHired")) ? "<i class='fa fa-check' style='color: green;'></i> Hired" : "<i class='fa fa-times' style='color: red;'></i> Not Hired") %>
                                                </td>


                                                <td class="datas">
                                                    <asp:Label ID="hourslabel" runat="server" Text='<%# Eval("renderedHours") %>'></asp:Label>
                                                </td>
                                                <td class="datas">
                                                    <asp:Button ID="EvaluationBtn" runat="server" Text='<%# Eval("evaluationRequest").ToString() == "Evaluated" ? "Evaluation" : "Not Available" %>' CommandArgument='<%# Eval("student_accID") %>' CommandName='<%# Eval("id") %>'  OnCommand="EvaluationBtn_Command" CssClass='<%# GetButtonCssClass(Eval("evaluationRequest")) %>' />
             
                                                </td>
                                                <td><asp:Button ID="ViewIntern" Text="ioi" runat="server" style="padding:0px; width:30px; border:none;"  OnCommand="TraceIntern_Command" CommandArgument='<%#Eval("student_accID")%>' />
                                                </td>
                                            </tr>
                                        </Itemtemplate>
                   </asp:ListView>

               </div>
            </asp:TableCell>
        </asp:TableRow>
          
    </asp:Table>

             <div class="modal" id="failPrompt" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                 <h2 class="title">
                    <span style="color: red;">&#9888;</span> Failed to Proceed
                </h2>
             </div>
                 <div class="modal-body" style="text-align:center;">
                     <asp:Label ID="Label3" runat="server" Style="font-size:16px; text-align:center;">
                        The row you selected includes intern that is <span style="color: green;">already hired</span>
                    </asp:Label><br />
                     <asp:Label ID="Label2" runat="server" Text="Select another row. Thank you!" Style="font-size:16px; text-align:center;" ></asp:Label>
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnCLick="closeModal1()">Okay</button>
             </div>
         </div>
     </div>
  </div>


     <div class="modal" id="addReferral" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                 <h2 class="title">Refer Interns</h2>
             </div>
                 <div class="modal-body" style="padding-left:8%;">
                      <asp:Label ID="Label1" runat="server" Text="Intern Names" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:19px; font-size:18px; float:left;">:</span>
                      <div style="margin-left: 5%; float:left;">
                        <asp:Label ID="internNamesDisplay" runat="server" Style="white-space: pre;"></asp:Label>
                       </div><br />
                     <div style="clear: both;"></div>
                     <asp:Label ID="Label4" runat="server" Text="Industry" Style="font-size:18px;" ></asp:Label><span style="margin-left:63px; font-size:18px;">:</span>
                      <asp:DropDownList ID="dropdownIndustries" runat="server" style="margin-left:20px; width:278px;"></asp:DropDownList>
                     <asp:Label ID="Label5" runat="server" Text="Referral Letter" Style="font-size:18px;" ></asp:Label><span style="margin-left:11px; font-size:18px;">:</span>
                     <asp:FileUpload ID="referralUpload" runat="server" style="margin-left:20px;"/>
                     
                      
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnClick="closeModal2()">Close</button>
                 <asp:Button  class="buttonSubmit" runat="server" Text="Submit" OnClick="SaveRefer_Click" autopostback="false" />
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

            <div class="modal fade" id="SuccessSingleEditPrompt" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                         <br />
                        <img src="images/check-mark.png" style="width:100px; height:auto;" /><br />
                        <asp:Label ID="Label20" runat="server" Text="Success !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label21" runat="server" Text="You succesfully updated the hours rendered." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="Close_SuccessSingleEditPrompt" />
                    </div>
                </div>
            </div>
</div>
<%--            <div class="modal fade" id="AlreadyExistPrompt" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                         <br />
                        <img src="images/check-mark.png" style="width:100px; height:auto;" /><br />
                        <asp:Label ID="Label6" runat="server" Text="Intern Already Referred !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label7" runat="server" Text="the intern selected is already in the referral list" Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" OnClick="closeModal3()">Close</button>
                    </div>
                </div>
            </div>
</div>--%>

         <div class="modal" id="alreadyExistPrompt" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                  <img src="images/check-mark.png" style="width:60px; height:auto;" />
                <asp:Label ID="Label6" runat="server" Text="Intern Already Referred !" Style="font-size:25px;" ></asp:Label><br />
             </div>
                 <div class="modal-body" style="padding-left:8%; text-align:center;">
                      <asp:Label ID="Label7" runat="server" Text="the selected intern is already in the referral list" Style="font-size:18px;" ></asp:Label><br />
                     <asp:Label ID="alreadyexistintern" runat="server"  Style="font-size:15px;" ></asp:Label>

                     
                      
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnClick="closeModal3()">Close</button>
             </div>
         </div>
     </div>
  </div>

             <div class="modal" id="stillHaveNotHired" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                   <h2 class="title">
                         <span style="color: red;">&#9888;</span> Failed to Proceed
                    </h2>
             </div>
                 <div class="modal-body" style="padding-left:8%; text-align:center;">
                      <asp:Label ID="Label8" runat="server" Style="font-size:16px; text-align:center;">
                        The row you selected includes intern that is <span style="color: red;">not hired</span>
                    </asp:Label><br />
                    <asp:Label ID="Label9" runat="server" Text="Select another row. Thank you!" Style="font-size:16px; text-align:center;" ></asp:Label>
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnClick="closeModalFailedEdit()">Close</button>
             </div>
         </div>
     </div>
  </div>
                 <div class="modal" id="allNotHired" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                   <h2 class="title">
                         <span style="color: red;">&#9888;</span> Failed to Proceed
                    </h2>
             </div>
                 <div class="modal-body" style="padding-left:8%; text-align:center;">
                      <asp:Label ID="Label26" runat="server" Style="font-size:16px; text-align:center;">
                        No edit action for <span style="color: red;">not hired</span>
                    </asp:Label><br />
                    <asp:Label ID="Label27" runat="server" Text="Select another row. Thank you!" Style="font-size:16px; text-align:center;" ></asp:Label>
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnClick="closeFailedEditAllNotHired()">Close</button>
             </div>
         </div>
     </div>
  </div>

                 <div class="modal" id="editMultiple" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                   <h2 class="title">
                         Edit Hours Rendered
                    </h2>
             </div>
                 <div class="modal-body" style="padding-left:8%;">
                     <asp:Label ID="Label22" runat="server" Text="Intern Names" Style="font-size:18px; float:left;" ></asp:Label><span style="margin-left:45px; font-size:18px; float:left;">:</span>
                    <div style="margin-left: 5%; float:left;">
                      <asp:Label ID="internsLabel" runat="server" Style="white-space: pre;"></asp:Label>
                     </div><br />
                     <div style="clear: both;"></div>
                      <asp:Label ID="Label10" runat="server" Style="font-size:18px; float:left;">
                        Hours Rendered
                    </asp:Label><span style="margin-left:19px; margin-right:5%; font-size:18px; float:left;">:</span>
                    <asp:TextBox ID="txtrenderedHours" runat="server" > </asp:TextBox>
             </div>
             <div class="modal-footer">
                 <asp:Button  class="buttonSubmit" runat="server" Text="Submit" OnClick="SaveMultipleEdit_Click" autopostback="false" />
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnClick="closeModalBulkEdit()">Close</button>
             </div>
         </div>
     </div>
  </div>

            <div class="modal fade" id="NoSelected" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                         <br />
                        <img src="images/check-mark.png" style="width:100px; height:auto;" /><br />
                        <asp:Label ID="Label13" runat="server" Text="No Selected !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label14" runat="server" Text="PLease select atleast one row, Thank you." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="Close_NoSelectedPrompt" />
                    </div>
                </div>
            </div>
</div>

                     <div class="modal" id="singleEdit" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                   <h2 class="title">
                         Edit Hours Rendered
                    </h2>
             </div>
                 <div class="modal-body" style="padding-left:8%;">
                     <asp:Label ID="Label16" runat="server" Text="Intern Name" Style="font-size:18px;" ></asp:Label><span style="margin-left:63px; font-size:18px;">:</span>
                     <asp:Label ID="fullnametxt" runat="server" Style="font-size:18px;" ></asp:Label><br />
                     <asp:Label ID="Label17" runat="server" Text="Program" Style="font-size:18px;" ></asp:Label><span style="margin-left:93px; font-size:18px;">:</span>
                     <asp:Label ID="programtxt" runat="server" Style="font-size:18px;" ></asp:Label><br />
                     <asp:Label ID="Label19" runat="server" Text="Contact Number" Style="font-size:18px;" ></asp:Label><span style="margin-left:31px; font-size:18px;">:</span>
                     <asp:Label ID="contacttxt" runat="server" Style="font-size:18px;" ></asp:Label><br />
                     <asp:Label ID="Label18" runat="server" Text="Email" Style="font-size:18px;" ></asp:Label><span style="margin-left:117px; font-size:18px;">:</span>
                     <asp:Label ID="emailtxt" runat="server" Style="font-size:18px;" ></asp:Label><br />
                      <asp:Label ID="Label15" runat="server" Style="font-size:18px;">
                        Hours Rendered
                    </asp:Label><span style="margin-left:25px; font-size:18px;">:</span>
                    <asp:TextBox ID="hoursRenderedtxt" runat="server"> </asp:TextBox><br />
             </div>
             <div class="modal-footer">
                 <asp:Button  class="buttonSubmit" runat="server" Text="Submit" OnClick="SaveSingleEdit_Click" autopostback="false" />
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnClick="closeModalSingleEdit()">Close</button>
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
                        <asp:Label ID="Label23" runat="server" Text="Success !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label24" runat="server" Text="You succesfully updated the hours rendered." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="Close_MultipleEditSuccessPrompt" />
                    </div>
                </div>
            </div>
</div>

   <script type="text/javascript">
       function openModal1() {
           var modal = document.getElementById("failPrompt");
           modal.style.display = "block";
       }
       function openModal2(internNamesString) {
           var modal = document.getElementById("addReferral");
           modal.style.display = "block";

           var formattedNames = internNamesString.replace(/,/g, '<br>');

           document.getElementById('<%=internNamesDisplay.ClientID%>').innerHTML = formattedNames;
           
       }
       function openModal3(existinginternNamesString) {
           var modal = document.getElementById("alreadyExistPrompt");
           modal.style.display = "block";

           var formattedNames = existinginternNamesString.replace(/,/g, '<br>');

           document.getElementById('<%=alreadyexistintern.ClientID%>').innerHTML = formattedNames;

       }
       function openModalFailedEdit() {
           var modal = document.getElementById("stillHaveNotHired");
           modal.style.display = "block";
       }
       function openFailedEditAllNotHired() {
           var modal = document.getElementById("allNotHired");
           modal.style.display = "block";
       }
       function openModalMultipleEdit(existingname) {
           var modal = document.getElementById("editMultiple");
           modal.style.display = "block";

           var formattedNames = existingname.replace(/,/g, '<br>');

           document.getElementById('<%=internsLabel.ClientID%>').innerHTML = formattedNames;
       }
       function openEditModal(name, program, cnumber, emailaddress, existingrenderedhours) {
           var modal = document.getElementById("singleEdit");
           modal.style.display = "block";

           document.getElementById('<%=fullnametxt.ClientID%>').innerHTML = name;
           document.getElementById('<%=programtxt.ClientID%>').innerHTML = program;
           document.getElementById('<%=contacttxt.ClientID%>').innerHTML = cnumber;
           document.getElementById('<%=emailtxt.ClientID%>').innerHTML = emailaddress;
           document.getElementById('<%=hoursRenderedtxt.ClientID%>').value = existingrenderedhours;;
       }
       

       function closeModal1() {
           document.getElementById("failPrompt").style.display = "none";

       }
       function closeModal2() {
           document.getElementById("addReferral").style.display = "none";

       }
       function closeModal3() {
           document.getElementById("alreadyExistPrompt").style.display = "none";

       }
       function closeModalFailedEdit() {
           document.getElementById("stillHaveNotHired").style.display = "none";

       }
       function closeFailedEditAllNotHired() {
           document.getElementById("allNotHired").style.display = "none";

       }
       function closeModalBulkEdit() {
           document.getElementById("editMultiple").style.display = "none";

       }
       function closeModalSingleEdit() {
           document.getElementById("singleEdit").style.display = "none";

       }
       
       function toggleHighlightAndCheckbox(checkbox) {
           checkbox.checked = !checkbox.checked; // Toggle the checkbox
           toggleHighlight(checkbox);
           /*toggleButtonsVisibility(checkbox.checked);*/
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
       function toggleSelectAll(checkbox) {
           var listView = document.getElementById('<%= internListView.ClientID %>');
           var checkboxes = listView.querySelectorAll('input[id*="chkSelect"]');

        for (var i = 0; i < checkboxes.length; i++) {
            checkboxes[i].checked = checkbox.checked;
            toggleHighlight(checkboxes[i]);
            
         }
        }
       //function toggleButtonsVisibility(isChecked) {
       //    var buttons = document.querySelectorAll('.additionalButtons');

       //    for (var i = 0; i < buttons.length; i++) {
       //        buttons[i].style.display = isChecked ? 'inline' : 'none';
       //    }
       //}
   </script>
</asp:Content>
