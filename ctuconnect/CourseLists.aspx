<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="CourseLists.aspx.cs" Inherits="ctuconnect.CourseLists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
        .profile-container{
            font-family: 'Poppins', sans-serif;
            max-width:260px;
            max-height:650px;
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
                padding: 4%;
                overflow: auto;
                height:550px;
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
             }
             /*.gridview-style .header-style{
                 width:20px;
                 text-align:center;
                 align-items:center;
             }*/
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
        th{
       border-collapse: collapse;
        border-color:white;
        background-color:#f4f4fb;
        padding:5px;

    }
    td{
        padding-left:5px;
    }
    .datas{
          border: 5px solid;
          border-color:white;
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
    .custom-modal-size {
        max-width: 800px; /* Set your desired width */
    }
    .modal-content{
        padding-left: 3%;
        padding-right:3%;
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
                    <a  href="ListOfAlumni.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Alumni</a>
                    <a  href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Partnered Industry</a>
                     <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:32px;"></i>Refer Student</a>
                    <a lass="active" href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                    <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                     <a  href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right:12px;"></i>Contact</a>
                    <a  href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                     <a  href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                     <hr class="second" />
                    <a href="OJTCoordinatorProfile.aspx"><i class="fa fa-user" aria-hidden="true" style="padding-right:12px;"></i>Profile</a>
                    <a href="Coord_AccountSetting.aspx"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                     <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                       <i class="fa fa-sign-out" aria-hidden="true"></i>
                        Sign-out
                    </asp:LinkButton>
                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding:0px 5px 0px 40px">
               <div class="display-container">
                   <h1 class="title">List of Course</h1>
                    <asp:Button runat="server" style="float:left;" Text="Add New Program" OnClick="CreateNewProgram_Click"/>
                   <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>


                    <asp:ListView ID="programListView" runat="server"> 
                        <LayoutTemplate>
                               <table  class="table-list">
                                    <tr>
                                        <th>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="toggleSelectAll(this);" />
                                        </th>
                                        <th>Course ID</th>
                                        <th>Department</th>
                                        <th>Course</th>
                                        <th>Name</th>
                                        <th style="width:400px;">Major</th>
                                        <th>No. of hours for Internship</th>
                                        <th></th>
                                    </tr>
                                   <tbody>
                                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                    </tbody>
                                   </table>
                          </LayoutTemplate>         
                                        <Itemtemplate>
                                            <tr class="datas clickableRow" onclick="toggleHighlightAndCheckbox(document.getElementById('<%# ((ListViewDataItem)Container).FindControl("chkSelect").ClientID %>'));">
                                                <td>
                                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="event.stopPropagation(); toggleHighlight(this);"  />
                                                </td>
                                                <td><%# Eval("course_ID") %></td>
                                                <td><%# Eval("departmentName") %></td>
                                                <td><%# Eval("course") %></td>
                                                <td><%# Eval("courseName") %></td>
                                                <td><%# Eval("major") %></td>
                                                <td><%# Eval("hoursNeeded") %></td>
                                            </tr>
                                        </Itemtemplate>
                   </asp:ListView>


               </div>
            </asp:TableCell>
        </asp:TableRow>
          
    </asp:Table>

    <div class="modal" id="GenerateNewProgram" tabindex="-1" role="dialog">
     <div class="modal-dialog modal-dialog-centered custom-modal-size" >
         <div class="modal-content">
             <div class="modal-header">
                 <h2 class="title">
                    Create New Program
                </h2>
             </div>
                 <div class="modal-body" style="align-items:center;">
                     <div style="float:left; text-align:right;">
                        <asp:Label ID="Label5" runat="server" Style="font-size:18px;">
                            Course Code
                        </asp:Label><span style="margin-left:11px;  font-size:18px;">:</span><br />
                         <asp:Label ID="Label6" runat="server" Style="font-size:18px;">
                            Course Name
                        </asp:Label><span style="margin-left:11px;  font-size:18px;">:</span><br />
                        <asp:Label ID="Label7" runat="server" Style="font-size:18px;">
                            Major
                        </asp:Label><span style="margin-left:11px; font-size:18px; ">:</span><br />
                        <asp:Label ID="Label8" runat="server" Style="font-size:18px;">
                            No. of hours for internship
                        </asp:Label><span style="margin-left:11px; font-size:18px;">:</span>
                    </div>
                     <div style="float:left;">
                    
                        <asp:TextBox ID="txtCoursecode" CssClass="txtbox" runat="server" style="width:400px; margin-left:11px;" > </asp:TextBox><br />
                    
                        <asp:TextBox ID="txtCourseName" CssClass="txtbox" runat="server" style="width:400px; margin-left:11px;" > </asp:TextBox><br />
                    
                        <asp:TextBox ID="txtMajor" CssClass="txtbox" runat="server" style="width:400px; margin-left:11px;"  > </asp:TextBox><br /> 
                    
                       <asp:TextBox ID="txtHoursNeeded" CssClass="txtbox" runat="server" style="width:400px; margin-left:11px;" > </asp:TextBox><br /> 
                   </div>
             </div>
             <div class="modal-footer">
                 <asp:Button  class="buttonSubmit" runat="server" Text="Submit" OnClick="SaveNewProgram_Click" autopostback="false" />
                 <button type="button" class="btn btn-secondary" data-dismiss="modal" OnCLick="closeModal1()">Okay</button>
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
                        <asp:Label ID="Label23" runat="server" Text="Program Created !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label24" runat="server" Text="You succesfully created the program into the list" Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="close_Modal2()" />
                    </div>
                </div>
            </div>
</div>
    <script type="text/javascript">
        function closeModal1() {
            var modal = document.getElementById("GenerateNewProgram");
            modal.style.display = "none";
        }
        function close_Modal2() {
            var modal = document.getElementById("SuccessPrompt");
            modal.style.display = "none";
        }
    </script>


</asp:Content>
