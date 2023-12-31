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
         max-height:630px;
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
             height:1000px;
             /*overflow: auto;
             float:left;
             margin-left:25%;
             position:relative;
             padding: 4% 0% 0% 6%;*/
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
 .txtbox{
    opacity: 0.5;
    border-radius: 5px;
    height: 28px;
    width: 1000%;
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
                 <a  href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                 <a  href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                 <a  href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                 <a  href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                 <a  class="active" href="EditEvaluation.aspx"><i class="fa fa-file-text" aria-hidden="true" style="padding-right:12px;"></i>Evaluation Form</a>
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
                <h1 class="title">Evaluation</h1>
                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Productivity</h3><br />
                    <div class="col-sm-3 d-flex flex-column justify-content-center"><asp:TextBox ID="prod1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div class="col-sm-3 d-flex flex-column justify-content-center"><asp:TextBox ID="prod2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div class="col-sm-3 d-flex flex-column justify-content-center"><asp:TextBox ID="prod3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div class="col-sm-3 d-flex flex-column justify-content-center"><asp:TextBox ID="prod4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div class="col-sm-3 d-flex flex-column justify-content-center"><asp:TextBox ID="prod5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Cooperation</h3><br />
                    <div><asp:TextBox ID="coop1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="coop2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="coop3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="coop4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="coop5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Ability to Follow Instructions</h3><br />
                    <div><asp:TextBox ID="abilityF1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityF2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityF3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityF4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityF5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Ability to Ge tAlong with People</h3><br />
                    <div><asp:TextBox ID="abilityG1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityG2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityG3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityG4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="abilityG5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Initiative</h3><br />
                    <div><asp:TextBox ID="init1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="init2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="init3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="init4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="init5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Attendance</h3><br />
                    <div><asp:TextBox ID="attend1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="attend2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="attend3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="attend4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="attend5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Quality of Work</h3><br />
                    <div><asp:TextBox ID="qual1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="qual2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="qual3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="qual4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="qual5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Appearance</h3><br />
                    <div><asp:TextBox ID="appear1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="appear2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="appear3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="appear4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="appear5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Dependability</h3><br />
                    <div><asp:TextBox ID="depend1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="depend2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="depend3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="depend4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="depend5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>

                <div class="row gx-4 gx-lg-5 h-50 align-items-center justify-content-center">
                    <h3>Overall Performance</h3><br />
                    <div><asp:TextBox ID="overAll1" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="overAll2" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="overAll3" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="overAll4" CssClass="txtbox" runat="server"></asp:TextBox></div>
                    <div><asp:TextBox ID="overAll5" CssClass="txtbox" runat="server"></asp:TextBox></div>
                </div>
            </div>
         </asp:TableCell>
     </asp:TableRow>
       
 </asp:Table>


</asp:Content>
