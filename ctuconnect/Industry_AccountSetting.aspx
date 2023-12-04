<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="Industry_AccountSetting.aspx.cs" Inherits="ctuconnect.Industry_AccountSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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
                padding:0px 5px 5px 5px;
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
   /* .horizontal-line {
        border: none;
        border-top: 1px solid black;
        width: 100%;
        margin-top:1%;
        margin-bottom:0%;
    }*/
    
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
        .status-pending {
    background-color: #F9E9B7; 
    color: #F3C129; 
    margin-right:2px;
    border-radius: 25px; 
    padding: 1px 3px; 
    text-align: center;
    cursor: pointer;
}
        .status-approved {
    background-color: #d3ffd3; 
    color: #2c9a5d; 
    margin-right:2px;
    border-radius: 25px;
    padding: 1px 3px; 
    text-align: center;
    cursor: pointer;
}
    .status-column{
        padding:10px;
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
            <asp:TableCell Style="vertical-align:top; height:200px; ">
                <div class="profile-container">
                <asp:Image ID="industryImage1" runat="server" />
                    <center><b><asp:Label ID="disp_industryName" CssClass="disp_industryName"  runat="server" Text=""></asp:Label></b></center>
                    <center><p style="font-size: 14px;">Account ID: <b><asp:Label ID="disp_accID" runat="server" Text=""></asp:Label></b></p></center>
                </div>
            </asp:TableCell>
            <asp:TableCell  RowSpan="2" Style="padding:0px 5px 0px 40px">
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
            <asp:Button ID="cancelButton" class ="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" PostBackUrl="~/Industry_AccountSetting.aspx" />
        </div>
      </div><br />
        <div><b>Delete Account</b></div><br />
        <div class="form-group">
        <div style="margin-left: 20px">
             <asp:Button ID="BtnDelete" class ="btn btn-danger" runat="server" Text="Delete My Account" OnClick="BtnDelete_Click" OnClientClick ="confirmDelete()"/>
             <input type="hidden" id="confirmValue" runat="server" />
        </div>
            </div>
               </div>
            </asp:TableCell>
        </asp:TableRow>
          <asp:TableRow>
            <asp:TableCell Style=" vertical-align:top;">
                <div class="sidemenu-container">
                    <a  href="IndustryDashboard.aspx"><i class='bx bxs-dashboard' aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                     <a  href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                    <a href="IndustryJobPosted.aspx"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                     <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                     <a href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                     <a class="active" href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                    <a href="IndustryProfile.aspx"><i class="fa fa-user" aria-hidden="true"></i>Profile</a>

                     <asp:LinkButton runat="server" ID ="SignOut" OnClick="SignOut_Click" >
   <i class="fa fa-sign-out" aria-hidden="true"></i>
    Sign-out
</asp:LinkButton>
               </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
     <script>
        function confirmDelete() {
            var confirmed = confirm("Are you sure you want to delete your account?");
            if (confirmed) {
                // If user confirms, set a hidden field or take any other necessary actions.
                document.getElementById("confirmValue").value = "yes";
            } else {
                // If user cancels, set a hidden field or take any other necessary actions.
                document.getElementById("confirmValue").value = "no";
            }
        }
     </script>
</asp:Content>
