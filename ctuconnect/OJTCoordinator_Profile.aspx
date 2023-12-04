<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="OJTCoordinator_Profile.aspx.cs" Inherits="ctuconnect.OJTCoordinatorProfile" %>
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
            max-height:630px;
            background-color:white;
            margin-left:4%;
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
            

            .form-control:focus {
                box-shadow: none;
                border-color: #BA68C8
            }   

            .profile-section{
                background-color:white;
                box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
                height:500px;
                padding-top:5em;
                align-items:center;
            }

            .profile-details{
                background-color:white;
                box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
                height:100%;
            }

            .profile-pic {
                border-radius: 100px;
            }

            .container{
                margin-left:50px;
            }

            .percentage{
                height:200px;
            }

            .pen-icon {
                display: inline-block;
                cursor: pointer;
                font-size: 20px;
                color: #881A30;
                text-decoration: none;
                transition: color 0.3s;
                justify-content:center;
            }

            /* Hover effect */
            .pen-icon:hover {
                color: orange;
            }

    </style>
<asp:Table ID="Table1" runat="server"  CssClass="content">
    <asp:TableRow>
        <asp:TableCell  style="vertical-align: top;">
            <div class="profile-container">
                <asp:Image ID="CoordinatorImage" runat="server"/>
                    <p >OJT Coordinator</p>
                        <hr class="horizontal-line" />
                        <a  href="CoordinatorProfile.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                        <a  href="ListOfAlumni"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Alumni</a>
                        <a  href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Partnered Industry</a>
                        <a  href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px;"></i>Refer Student</a>
                        <a  href="CourseList.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                        <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                        <a  href="Applicants.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                        <hr class="second" />
                        <a class="active" href="#"><i class="fa fa-user" aria-hidden="true" style="padding-right:12px;"></i>Profile</a>
                        <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                           <i class="fa fa-sign-out" aria-hidden="true"></i>
                            Sign-out
                        </asp:LinkButton>                
            </div>
        </asp:TableCell>
        <asp:TableCell Style="padding:0px 5px 0px 40px; vertical-align:top;">            
            <div class="container">
                <div class="row">
                  <div class="col-lg-4">
                    <div class="card shadow-sm profile-section">
                      
                        <asp:Image ID="ojtcoordProfile" CssClass="profile-pic" Width="150px" Height="150px" runat="server" />
                        <h3><asp:Label ID="disp_name" runat="server" Text=""></asp:Label></h3>
                      
                    </div>
                  </div>
                  <div class="col-lg-8">
                    <div class="card shadow-sm">
                      <div class="card-header bg-transparent border-0">
                          <div class="row">
                              <div class="col-11" style="padding-left:1em;">
                                  <h3 class="mb-0">General Information</h3>
                              </div>
                              <div class="col-1" style="text-align:right;">
                                  <a href="EditCoordinatorProfile.aspx" class="pen-icon"><i class="fa fa-pencil-square-o fa-lg" aria-hidden="true"></i></a>
                              </div>
                          </div>
                        
                          
                      </div>
                      <div class="card-body pt-0">
                        <table class="table table-bordered">
                          <tr>
                            <th width="30%">First Name</th>
                            <td width="2%">:</td>
                            <td><asp:Label ID="coordFname" runat="server" Text=""></asp:Label></td>
                          </tr>
                          <tr>
                            <th width="30%">Last Name</th>
                            <td width="2%">:</td>
                            <td><asp:Label ID="coordLname" runat="server" Text=""></asp:Label></td>
                          </tr>
                            <tr>
                              <th width="30%">Middle Initial</th>
                              <td width="2%">:</td>
                              <td><asp:Label ID="coordInitial" runat="server" Text=""></asp:Label></td>
                            </tr>
                          <tr>
                            <th width="30%">Department</th>
                            <td width="2%">:</td>
                            <td><asp:Label ID="coordDepartment" runat="server" Text=""></asp:Label></td>
                          </tr>
                          <tr>
                            <th width="30%">Username</th>
                            <td width="2%">:</td>
                            <td><asp:Label ID="coordUsername" runat="server" Text=""></asp:Label></td>
                          </tr>
                        </table>
                      </div>
                    </div>
                    <br />
                    <div class="card shadow-sm percentage">
                        
                    </div>
      
                  </div>
                </div>
              </div>               
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
</asp:Content>
