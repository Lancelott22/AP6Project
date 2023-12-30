<%@ Page Title="" Language="C#" MasterPageFile="~/OJTCoordinator.Master" AutoEventWireup="true" CodeBehind="Coord_AccountSetting.aspx.cs" Inherits="ctuconnect.Coord_AccountSetting" %>
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
         .display-container{
             font-family: 'Poppins', sans-serif;
             background-color:white; 
             width:1500px;
             top:0;
             bottom:0;
             padding: 2%;
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
 </style>
 <asp:Table ID="Table1" runat="server"  CssClass="content">
     <asp:TableRow>
         <asp:TableCell  style="vertical-align: top;">
             <div class="profile-container">
                    <asp:Image ID="CoordinatorImage" runat="server"/>   
                        <p >OJT Coordinator</p>
                            <hr class="horizontal-line" />
                            <a href="CoordinatorProfile.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                            <a href="ListOfAlumni.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Alumni</a>
                            <a href="PartneredIndustries.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Partnered Industry</a>
                            <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:32px;"></i>Refer Student</a>
                            <a href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                            <a href="Blacklist.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>Blacklist Industry</a>
                            <a href="Coordinator_Contact.aspx"><i class="fa fa-comments" aria-hidden="true" style="padding-right:12px;"></i>Contact</a>
                            <a href="Coordinator_UploadCSV.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Upload CSV</a>
                            <a href="TracerDashboard.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                            <hr class="second" />
                            <a href="OJTCoordinator_Profile.aspx"><i class="fa fa-user" aria-hidden="true" style="padding-right:12px;"></i>Profile</a>
                            <a class="active" href="#"><i class="fa fa-cog" aria-hidden="true" style="padding-right:12px;"></i>Account Settings</a>
                            <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                               <i class="fa fa-sign-out" aria-hidden="true"></i>
                                Sign-out
                            </asp:LinkButton>   
             </div>
         </asp:TableCell>
         <asp:TableCell Style="padding:0px 5px 0px 40px">
            <div class="display-container">
                <h1 class="title">Account Setting</h1>
                <div><b>Change Password</b></div><br />
                <div class="form-group">
                 <asp:Label runat="server"  style="left: 0px; top: 10px;">Old password</asp:Label>         
               <asp:TextBox ID="Oldpass" runat="server" TextMode="Password" CssClass ="form-control" width ="250px" placeholder="Enter old password"></asp:TextBox>
                <asp:Label ID="PasswordErrorMessage" Font-Size="15px" runat="server" Text="Invalid password! Please enter your current password!" CssClass="text-danger"></asp:Label>             
                    <asp:RequiredFieldValidator ID="reqOldpass" Font-Size="15px" runat="server" ErrorMessage="Required Field!" ControlToValidate="Oldpass" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>  
      </div>
    <div class="form-group">         
                    <asp:Label runat="server" style="left: 0px; top: 10px;">New Password</asp:Label>           
                    <asp:TextBox ID="Newpass" runat="server" TextMode="Password" CssClass ="form-control" width ="250px" placeholder="Enter new password"></asp:TextBox>
                    <asp:Label ID="NewpassErrorMessage" Font-Size="15px" runat="server" Text="New password must be different from current password!" CssClass="text-danger"></asp:Label>
                    <asp:RequiredFieldValidator ID="reqnewpassword" Font-Size="15px" runat="server" ErrorMessage="Required Field!" ControlToValidate="Newpass" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>                                                                                                          <!-- "^(?=.*\d)(?=.*[A-Z])(?=.*\W)(?!.*\s).{8,}$"-->
                    <asp:RegularExpressionValidator ID="regnewPassword" Font-Size="15px" runat="server" ErrorMessage="Password length must be minimum of 8 characters! Must be alphanumeric, atleast 1 uppercase and lowercase letter, and 1 symbol." Display="Dynamic" CssClass="text-danger" ControlToValidate="Newpass" ValidationExpression="(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w])(?!.*\s)^.{8,16}$"></asp:RegularExpressionValidator>    
      </div>
     <div class="form-group">         
                <asp:Label runat="server" style="left: 0px; top: 10px;">Confirm New Password</asp:Label>
            
               <asp:TextBox ID="confirmNewPass" runat="server" TextMode="Password" CssClass ="form-control" width ="250px" placeholder="Enter new confirm password"></asp:TextBox>
               <asp:RequiredFieldValidator ID="reqConfirmNewPass" Font-Size="15px" runat="server" ErrorMessage="Required Field!" ControlToValidate="confirmNewPass" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
               <asp:CompareValidator ID="comNewPassword" Font-Size="15px" runat="server" ErrorMessage="The new password did not match!" ControlToCompare="Newpass" Display="Dynamic" ControlToValidate="confirmNewPass" CssClass="text-danger"></asp:CompareValidator>
          
      </div>
      <div class="form-group">
        <div style="margin-left: 10px">
             <asp:Button ID="BtnUpdatePass" class ="btn btn-success" runat="server" Text="Update Password" OnClick="BtnUpdatePass_Click" />   
            <asp:Button ID="cancelButton" class ="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" PostBackUrl="~/Coord_AccountSetting.aspx" />
        </div>
      </div><br />

    <div class="form-group">
         <div><b>Change Password</b></div><br />
        <asp:FileUpload ID="studentCSV" runat="server" />
        <asp:Button runat="server" Text="Upload" OnClick="Upload" />
    </div>

      
             </div>
         </asp:TableCell>
     </asp:TableRow>
       
 </asp:Table>
    <script>
        function confirmDeactivate() {
            if (confirm("Are you sure you want to deactivate your account?")) {

            } else {
                __doPostBack();
                alert("You cancelled the operation.");
            }
        }
    </script>
</asp:Content>
