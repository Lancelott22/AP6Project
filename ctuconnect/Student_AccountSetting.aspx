<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Student_AccountSetting.aspx.cs" Inherits="ctuconnect.Student_AccountSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/css/bootstrap-select.min.css">
<script src="https://cdn.jsdelivr.net/npm/bootstrap-select@1.13.14/dist/js/bootstrap-select.min.js"></script>
    <style>
        .nav {
            padding: 10px 10px 10px 10px;
            width: 200px;
            margin: auto;
            margin-top: 20px;
            position: absolute;
            margin-left: 70px;
        }

            .nav a {
                font-size: 18px;
                font-family: 'Arial Rounded MT';
                color: #000000;
                padding-left: 3px;
                text-decoration: none;
            }

                .nav a.active {
                    background-color: rgb(255, 194, 102);
                    border-radius: 10px;
                    min-height: 10px;
                }

                .nav a:hover {
                    background-color: rgb(255, 194, 102);
                    border-radius: 10px;
                    min-height: 10px;
                }

        .buttonStyle {
            background-color: white;
            min-width: 100%;
            min-height: 35px;
            color: orange;
            background-color: white;
            border-radius: 20px;
            border: 1.5px solid orange;
        }

            .buttonStyle:hover {
                background: orange;
                color: white;
                box-shadow: 3px 6px 7px -4px grey;
            }
    .buttonStyleDone {
    background-color: white;
    min-width: 100%;
    min-height: 35px;
    color: red;
    background-color: white;
    border-radius: 20px;
    border: 1.5px solid red;
}
        .imgStyle {
            border-radius: 50%;
            border: solid grey 1px;
            box-shadow: gray;
            width: 100px;
            height: 100px;
            box-shadow: 0px 0px 12px -3px grey;
        }

        .col {
            font-size: 15px;
        }

        h3 {
            font-size: 20px;
        }

        .top {
            height: 200px;
            background-color: #F7941F;
            width: 80%;
        }


        .box {
            width: 85%;
            min-height: 300px;
            background-color: #ffffff;
            padding-left: 2em;
            border: 1px solid #FFFFFF;
            padding: 10px;
            border-radius: 5px;
        }

        .profile {
            border-radius: 50px;
            position: relative;
            top: -50px;
        }

        .line {
            height: 2px;
            width: 95%;
            background-color: #881A30;
            color: #881A30;
            position: center;
        }

        .ContainerBox {
            border: solid 2px #881A30;
            box-shadow: 4px 6px 10px -4px grey;
            height: auto;
            margin: 10px;
            margin-bottom: 15px;
            vertical-align: bottom;
        }

        .statusStyle {
            border: solid 1px #06ba1b;
            background: #06ba1b;
            height: 50px;
            padding: 6px;
            color: white;
            box-shadow: 3px 6px 7px -4px grey;
        }

        .statusStyleReject {
            border: solid 1px #c90a0a;
            background: #c90a0a;
            height: 50px;
            padding: 6px;
            color: white;
            box-shadow: 3px 6px 7px -4px grey;
        }

        .statusStylePending {
            border: solid 1px #a8a8a8;
            background: #a8a8a8;
            height: 50px;
            padding: 6px;
            color: white;
            box-shadow: 3px 5px 10px -5px grey;
        }

        .applicationTimeline {
            position: relative;
            list-style: none;
        }

            .applicationTimeline > li {
                position: relative;
                margin-right: 10px;
                margin-bottom: 15px;
            }

            .applicationTimeline:before {
                content: '';
                position: absolute;
                top: 0;
                bottom: 0;
                width: 5px;
                background: rgb(255, 194, 102);
                left: 0;
                margin: 0;
                border-radius: 2px;
            }

            .applicationTimeline > li > .bx {
                width: 35px;
                height: 35px;
                font-size: 25px;
                line-height: 35px;
                position: absolute;
                color: #1c1c1b;
                background: rgb(255, 194, 102);
                border-radius: 50%;
                text-align: center;
                left: -35px;
                top: 0;
            }

        .jobAppliedBox {
            border: 1px solid #881A30;
            padding: 10px;
            margin: auto;
            margin-bottom: 10px;
            width: contain;
            height: contain;
            box-shadow: 0px 0px 7px -3px #bd0606;
            border-radius: 7px;
            position: relative;
        }

            .jobAppliedBox:hover {
                box-shadow: 3px 7px 18px #bd0606;
            }

        .row {
            margin-bottom: 10px;
        }

        .modal ::-webkit-scrollbar {
            display: none;
            width: 6px;
        }

        /* Track */
        .modal ::-webkit-scrollbar-track {
            box-shadow: inset 0 0 5px grey;
            border-radius: 5px;
        }

        /* Handle */
        .modal ::-webkit-scrollbar-thumb {
            background: rgb(255, 194, 102);
            border-radius: 10px;
        }

        .modal-content:hover ::-webkit-scrollbar {
            display: block;
        }
        /* Handle on hover */
        .modal ::-webkit-scrollbar-thumb:hover {
            background: #881A30;
        }

        .NewBadge {
            border: solid 1px #15d455;
            border-radius: 5px;
            height: 20px;
            width: 30px;
            background: #15d455;
            padding: 2px;
            color: #ffffff;
            font-size: 10px;
            position: absolute;
            top: 10px;
            left: 15px;
            box-shadow: 0px 0px 9px -1px #15d455;
            text-align: center;
        }
    </style>

    <div class="container-fluid">
                <div class="row">
                    <div class="col-3 d-flex flex-column align-self-start">
                        <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">

                            <a href="MyAccount.aspx">
                                <i class='bx bx-user-circle icon'></i>
                                <span class="text nav-text">My Account</span>
                            </a>
                            <a href="Resume.aspx">
                                <i class='bx bx-file-blank icon'></i>
                                <span class="text nav-text">Resume</span>
                            </a>
                            <a href="MyJobApplication.aspx">
                                <i class='bx bx-layer icon'></i>
                                <span class="text nav-text">Application</span>
                            </a>
                            <a class="active" href="Student_AccountSetting.aspx">
                                <i class='bx bx-cog icon'></i>
                                <span class="text nav-text">Account Settings</span>
                            </a>
                            <a href="Report.aspx">
                                <i class='bx bxs-flag-alt'></i>
                                <span class="text nav-text">Report</span>
                            </a>
                            <hr style="height: 2px; border-width: 0; color: #881A30; background-color: #881A30">
                            <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                        <i class='bx bx-log-out icon' ></i>
                        Sign-out
                            </asp:LinkButton>
                        </div>
                    </div>

                    <div class="col-9 d-flex flex-column">
                        
                        

                        <div class="box" id="MyJobApplicationView" runat="server">
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
            <asp:Button ID="cancelButton" class ="btn btn-danger" runat="server" Text="Cancel" CausesValidation="False" PostBackUrl="~/Student_AccountSetting.aspx" />
        </div>
      </div><br />

        <div class="form-group">
    <div style="margin-left: 20px">
        <asp:LinkButton ID="Deactivate" CssClass="btn btn-danger" runat="server" OnCommand="Deactivate_Command" Text="Deactivate Account" OnClientClick="confirmDeactivate();" CausesValidation="false"></asp:LinkButton>
  
    </div>
</div>
               </div>
                        </div>

                    </div>
                </div>
            </div>
<script type="text/javascript">
    
    function confirmDeactivate() {
        if (confirm("Are you sure you want to deactivate your account?")) {

        } else {
            __doPostBack();
            alert("You cancelled the operation.");
        }
    }
</script>

</asp:Content>

