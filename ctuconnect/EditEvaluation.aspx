<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="EditEvaluation.aspx.cs" Inherits="ctuconnect.EditEvaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
 <style>
     @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
     
        .profile-container{
            font-family: 'Poppins', sans-serif;
            max-width:260px;
            max-height:660px;
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
         .container{
             font-family: 'Poppins', sans-serif;
             background-color:white; 
             width:1550px;
             top:0;
             bottom:0;
             border: 1px solid grey;
            padding-top:2em;
            padding-left:2em;
            padding-right:2em;
             overflow: auto;
             /*background-color:white;*/
             height:1000px;
             /*overflow: auto;
             float:left;
             margin-left:25%;
             position:relative;
             padding: 4% 0% 0% 6%;*/
         }
         .category{
            padding-left:7em;
         }
         .details{
            padding-left:10em;
         }
         .container2{
            padding-left:4em;
            padding-right:2em;
        }
             
          .content{
            height:100%; 
            width:97%; 
            margin-left:2%; 
            margin-right:2%;
            padding: 0px 0px 0px 0px;
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
        
          .second {
            border: none;
            border-top: 1.5px solid black;
            width: 90%;
            margin-left: auto;
            margin-right: auto;
            margin-top: 13%;
            margin-bottom: 0%;
        }

         .full-time:active::before{
                     content:'';
                     position:absolute;
                     height:10px;
                     width:40px;
                     bottom:0%;
                     background-color: #881A30;

         }
         .line{
            height:2px;
            width:100%;
            background-color:#000000;
            color:#000000;
            position:center;
        }
         .btn-md{
            border: 1px #881A30;
            background-color: #881A30;
            position:center;
            width: 120px;
            height:45px;
        }

         .fa {
            width:20px;
            margin-right: 19px; 
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
                   <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px;"></i>Refer Student</a>
                   <a href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                   <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                   <a href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right:12px;"></i>Contact</a>
                   <a href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                   <a href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                   <a class="active" href="EditEvaluation.aspx"><i class="fa fa-file-text" aria-hidden="true" style="padding-right:12px;"></i>Evaluation Form</a>
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
            <div class="col-9 d-flex flex-column">
                <div class="container">
                    <div class="row">
                        <div class="col-12 d-flex flex-column">
                            <center><h1>Evaluation Form</h1></center><br />
                        </div>
                    </div>
                    <hr class="line" />
                    <div class="row">
                        <div class="col-12 d-flex flex-column">
                            <b>Categories</b>
                            <br />
                            <div class="row category">
                                <div class="col-6">
                                    <b>Productivity</b>
                                    <br />
                                    <div class="row details">
                                        <div class="col-6 d-flex flex-column">
                                            <asp:Label ID="disp_Prod1" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Prod2" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Prod3" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Prod4" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Prod5" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <b>Cooperation</b>
                                    <br />
                                    <div class="row details">
                                        <div class="col-6 d-flex flex-column">
                                            <asp:Label ID="disp_Coop1" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Coop2" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Coop3" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Coop4" runat="server"></asp:Label>
                                            <asp:Label ID="disp_Coop5" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            
                            </div>
                             <div class="row category">
                                 <div class="col-6">
                                     <b>Ability to Follow Instructions</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_AbilityF1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityF2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityF3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityF4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityF5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
                                 <div class="col-6">
                                     <b>Ability to Get Along with People</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_AbilityG1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityG2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityG3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityG4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_AbilityG5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
 
                             </div>
                             <div class="row category">
                                 <div class="col-6">
                                     <b>Initiative</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_Init1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Init2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Init3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Init4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Init5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
                                 <div class="col-6">
                                     <b>Attendance</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_Attend1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Attend2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Attend3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Attend4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Attend5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
 
                             </div>
                             <div class="row category">
                                 <div class="col-6">
                                     <b>Quality of Work</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_Qual1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Qual2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Qual3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Qual4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Qual5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
                                 <div class="col-6">
                                     <b>Appearance</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_Appear1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Appear2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Appear3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Appear4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Appear5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
 
                             </div>
                             <div class="row category">
                                 <div class="col-6">
                                     <b>Dependability</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_Depend1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Depend2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Depend3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Depend4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Depend5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
                                 <div class="col-6">
                                     <b>Overall Performance</b>
                                     <br />
                                     <div class="row details">
                                         <div class="col-6 d-flex flex-column">
                                             <asp:Label ID="disp_Overall1" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Overall2" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Overall3" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Overall4" runat="server"></asp:Label>
                                             <asp:Label ID="disp_Overall5" runat="server"></asp:Label>
                                         </div>
                                     </div>
                                 </div>
 
                             </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="container2">
                    <div class="row">
                        <div class="col-2 d-flex flex-column">
                            <asp:Button ID="btnUpdate" class="btn btn-primary btn-md" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
                        </div>

                    </div>
                </div>
            </div>
         </asp:TableCell>
     </asp:TableRow>
       
 </asp:Table>


</asp:Content>
