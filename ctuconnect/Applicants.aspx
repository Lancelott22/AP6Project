<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Applicants.aspx.cs" Inherits="ctuconnect.Applicants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
        .profile-container{
            max-width:200px;
            max-height:300px;
            background-color:white;
            margin-left:2%;
            border-radius: 20px;
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
            width:200px;
            height:200px;
            background-color:white;
            /*margin-top:22%;*/
            padding-top:4px;
            margin-bottom:10%;
            margin-left:2%;
            border-radius: 20px;
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
                background-color:white; 
                width:1000px;
                top:0;
                bottom:0;
                padding: 2% 2% 0% 2%;
                overflow: auto;
                /*background-color:white;*/
                height:550px;
                /*overflow: auto;
                float:left;
                margin-left:25%;
                position:relative;
                padding: 4% 0% 0% 6%;*/
            }
            
            .display-container {
                    min-width: 100%;
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
                width:70px;
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
             .fa {
                width:20px;
                margin-right: 19px; 
             }

             .modal{
                 width:500px;
                 margin:auto;
                 margin-top:20px;
                
                 
             }
             .modal-content{
                 padding-left:2em;
             }

             .center-header {
                text-align: center;
            }

             .applicant-details{
                 padding-left:2em;
             }

             .txtbox{
                border-radius: 3px;
    
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

            .applicant-buttons{
                padding-left:5em;
            }

            


             
    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; height:200px;">
                <div class="profile-container">
                <img src="images/industrypic.png" />
                <p >Industry Name</p>
                </div>
            </asp:TableCell>
            <asp:TableCell RowSpan="2" Style="padding:0px 10px 0px 25px; vertical-align:top;">
                <div class="display-container">
                     <h1 class="title">Applicants List</h1>
                    <p style="float:left;">Sort by <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true"  CssClass="sort-dropdown" Height="">
                        <asp:ListItem Text="Type" Value="ColumnName1"></asp:ListItem>
                        <asp:ListItem Text="Date" Value="ColumnName2"></asp:ListItem>
                        <asp:ListItem Text="Status" Value="ColumnName3"></asp:ListItem>
                    </asp:DropDownList></p>
                    <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p> 

                                  
                                <asp:GridView RowStyle-CssClass="GridViewRowStyle" ShowHeaderWhenEmpty="True" ID="GridView1" runat="server"
                                    AutoGenerateColumns="False" CellPadding="50" Font-Bold="False" Font-Size="13px" Width="1015px" BackColor="#FFFFFF" BorderColor="#c1beba" BorderStyle="Solid" BorderWidth="1px"
                                    CellSpacing="2" OnRowEditing="GridView1_RowEditing" OnRowCreated="GridView1_RowCreated">
                                    <HeaderStyle Font-Bold="false"  BackColor="#D3D3D3" Font-Size="12px" ForeColor="black" Height="28px"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                                     <Columns>
                                            <asp:BoundField DataField="applicantID" readonly = "true"  HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">                    
                                            </asp:BoundField>
                                            <asp:BoundField DataField="jobType" readonly = "true"  HeaderText="Type" ItemStyle-HorizontalAlign="Center"  ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">                    
                                            </asp:BoundField>
                                            <asp:BoundField DataField="applicantFname" readonly = "true" HeaderText="First Name" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" >
                                            </asp:BoundField>
                                            <asp:BoundField DataField="applicantLname" readonly = "true" HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="dateApplied" readonly = "true" HeaderText="Date" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="resume" readonly = "true" HeaderText="Resume" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="resumeStatus" readonly = "true" HeaderText="Resume Status" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="interviewDetails" readonly = "true" HeaderText="Interview Details" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="interviewStatus" readonly = "true" HeaderText="Interview Status" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="applicantStatus" readonly = "true" HeaderText="Applicant Status" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="StudentType" readonly = "true" HeaderText="Student Type" ItemStyle-HorizontalAlign="Center" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            </asp:BoundField>
                                         <asp:TemplateField>
                                            <ItemTemplate>                                                  
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="EditRecord" CommandName="Edit"/>                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            
                                     </Columns>
                                     
                                    
                               </asp:GridView>

                                

                    <script>
                        // Show the modal and populate it with data when the "Edit" button is clicked
                        function openEditModal(resumeStatus, interviewDetails, interviewStatus, applicantStatus) {                                                     
                            document.getElementById('<%=drpResumeStatus.ClientID%>').value = resumeStatus;                     
                            document.getElementById('<%=txtInterviewDetails.ClientID%>').value = interviewDetails;
                            document.getElementById('<%=drpInterviewStatus.ClientID%>').value = interviewStatus;
                            document.getElementById('<%=drpApplicantStatus.ClientID%>').value = applicantStatus;
                            // Additional fields can be populated similarly
                            document.getElementById('editModal').style.display = 'block';
                        }

                        
                    </script>

                                                                       
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top; ">
                <div class="sidemenu-container">
                    <a  href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                     <a href="#"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                     <a class="active" href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                     <a  href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                     <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

                            <!-- Modal -->
                            <div id="editModal" class="modal">
                                <div class="modal-content">
                                    <!--<span class="close" id="closeModal" onclick="closeEditModal()">&times;</span>-->
                                    <br />
                                    <h3 style="text-align:center">Applicant Details</h3> 
                                    <br />
                                    <div class="row applicant-details">
                                        <div class="col-3 d-flex flex-column">
                                            Applicant ID:
                                        </div>
                                        <div class="col-9 d-flex flex-column">
                                            <asp:Label ID="lblapplicantID" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row applicant-details">
                                        <div class="col-3 d-flex flex-column">
                                            Name:
                                        </div>
                                        <div class="col-9 d-flex flex-column">
                                            <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row applicant-details">
                                        <div class="col-3 d-flex flex-column">
                                            Date Applied:
                                        </div>
                                        <div class="col-9 d-flex flex-column">
                                            <asp:Label ID="lblDateApplied" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row applicant-details">
                                        <div class="col-3 d-flex flex-column">
                                            Resume Status:
                                        </div>
                                        <div class="col-9 d-flex flex-column">
                                            <asp:DropDownList ID="drpResumeStatus" runat="server" CssClass="txtbox" Width="100px" Height="20px">
                                            <asp:ListItem>Pending</asp:ListItem>
                                            <asp:ListItem>Reviewed</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                    <br />
                                    <div class="row applicant-details">
                                        <div class="col-3 d-flex flex-column">
                                            Interview Details:
                                        </div>
                                        <div class="col-9 d-flex flex-column">
                                            <asp:TextBox ID="txtInterviewDetails" runat="server" CssClass="txtbox" Width="200px" Height="50px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row applicant-details">
                                        <div class="col-3 d-flex flex-column">
                                            Interview Status:
                                        </div>
                                        <div class="col-9 d-flex flex-column">
                                            <asp:DropDownList ID="drpInterviewStatus" runat="server" CssClass="txtbox" Width="100px" Height="20px">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Pending</asp:ListItem>
                                            <asp:ListItem>Scheduled</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row applicant-details">
                                        <div class="col-3 d-flex flex-column">
                                            Applicant Status:
                                        </div>
                                        <div class="col-9 d-flex flex-column">
                                            <asp:DropDownList ID="drpApplicantStatus" runat="server" CssClass="txtbox" Width="100px" Height="20px">
                                            <asp:ListItem>Pending</asp:ListItem>
                                            <asp:ListItem>Approved</asp:ListItem>
                                            <asp:ListItem>Rejected</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />                                                                                                        
                                    <div class="row applicant-buttons">
                                        <div class="col-4 d-flex flex-column">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="SaveRecord" CssClass="btn2" Height="28px" Width="100px"/>
                                        </div>
                                        <div class="col-2 d-flex flex-column">
                
                                        </div>
                                        <div class="col-4 d-flex flex-column">
                                            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="closeEditModal" CssClass="btn1" Height="28px" Width="100px"/>
                                        </div>
                                    </div>
                                    <br /><br />
        
                                </div>
                            </div>
</asp:Content>
