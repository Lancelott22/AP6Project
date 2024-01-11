<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListOfIndustries_Alumni.aspx.cs" Inherits="ctuconnect.ListOfIndustries_Alumni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<style>
    .profile-container{
        background-color:white;
        margin-left:4%;
        padding-bottom:8px;
        border: 2px ;
        box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
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

    .second{
        border: none;
        border-top: 1.5px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:13%;
        margin-bottom:0%;
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
            
    .nav{
        padding:10px 10px 0px 10px;
        width:300px;
        margin-top:5px;
        position: absolute;
        margin-left:10px;
    }

    .nav a{
        font-size:18px;
        font-family:'Arial Rounded MT';
        color:#000000;
        text-decoration:none;
        position:static;
        font-size: 19px;
        display: block;
        margin: 2px 15px 5px 15px ;
        padding: 0px 0px 0px 8px;
    }

    .nav a.active{
        background-color:rgb(255, 194, 102);
        border-radius:10px;
        min-height:10px;

    }

    .nav a:hover{
        background-color:rgb(255, 194, 102);
        border-radius:10px;
        min-height:10px;

    }

    .container {
        min-height: 550px;
        background-color: #FFFFFF;
        max-width:100%;
        width:1550px;
        border: 2px;
        box-shadow: 0px 0px 8px 1px rgba(0, 0, 0, 0.1);
        padding-top:2em;
        padding-left:2em;
        padding-right:2em;                  
        margin-left:50px;
    }
    .container .title{
    font-size:25px;
    font-weight:500;
    position:relative;
    margin-bottom:3%;
    padding-bottom:4px;
    }
    .container .title:before{
        content:'';
        position:absolute;
        height:2px;
        width:60px;
        bottom:0;
        background-color: #881A30;

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
        font-size:14px; 
        height:auto; 
        width:100%;
        color:dimgray;
        padding-right:4px;
    }
    .add-button{
    background-color: white;
    border: 1px solid;
    border-color: gray;
    box-shadow: 0 0px 8px rgba(0, 0, 0.8, 0.2);
    color: black;
    padding-left: 8px;
    padding-right: 8px; 
    text-decoration:none;
    float:right;
    }
    
    .custom-modal-size {
        max-width: 800px; /* Set your desired width */
    }

    .modal-content {
        width: 100%; /* Set the width to 100% to ensure it adapts to the container */
        margin: auto; /* Center the modal content horizontally */
        padding: 20px; /* Add padding for better appearance */
    }

    .container-industry{
        width:90%;
    }
</style>
<div class="container-fluid">
    <div class="row">
        <div class="col-2 d-flex flex-column" >
            <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">
                <div class="profile-container">
                    <img src="images/administratorpic.jpg" />
                    <p >Admin</p>
                    <hr class="horizontal-line" />
                    <a href="AdminDashboard.aspx">
                        <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dashboard
                    </a>
                    <a href="IndustryVerification.aspx">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Industry Verification
                    </a>
                    <a href="ReferralList_Admin.aspx">
                        <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Referred Student
                    </a>
                    <hr class="horizontal-line" />
                    <a class="active" href="ListOfIndustries_Alumni.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Industry
                    </a>
                    <a href="ListOfInterns_Alumni">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Interns
                    </a>
                    <a href="ListOfAlumni_Admin.aspx">
                        <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        List of Alumni
                    </a>
                    <hr class="horizontal-line" />
                    <a href="Dispute.aspx">
                        <i class="fa fa-exclamation-triangle" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Dispute
                    </a>
                    <a href="Blacklist_Admin.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                        Blacklisted
                    </a>
                    <a href="SuggestionsAdmin.aspx">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Suggestions
                    </a>
                    <a href="Admin_Contact.aspx">
                        <i class="fa fa-comments" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Contact
                    </a>
                    <hr class="second" />
                    <a href="TracerDashboard.aspx">
                        <i class="fa fa-ban" aria-hidden="true" style="padding-right: 7px; width: 32px;"></i>
                        Tracer
                    </a>
                    <a href="AdminProfile.aspx">
                        <i class="fa fa-user" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Profile
                    </a>
                    <a href="Coordinator_CreateAccount.aspx">
                        <i class="fa fa-users" aria-hidden="true" style="padding-right: 12px; width: 32px;"></i>
                        Coordinator Account
                    </a>
                </div>
                
            </div>
        </div>
        <div class="col-10 d-flex flex-column">
            <br />
            <div class="container">
                <h1 class="title">List of Partnered Industries</h1>
                 
                <p style="float:left;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>
                <asp:LinkButton ID="BtnAddIndustry" runat="server" CssClass="add-button" OnClick="BtnAddIndustry_Click" CausesValidation="false">
                    <i class="fa fa-plus"></i>Add Industry

                </asp:LinkButton>
                                <asp:ListView ID="dataRepeater" runat="server"> 
                     <LayoutTemplate>
                            <table  class="table-list">
                                 <tr>
                                     <th>No.</th>
                                     <th>Industry Name</th>
                                     <th>Location</th>
                                     <th>Contact Person</th>
                                     <th>Contact Number</th>
                                     <th>Contact Email</th>
                                     <th>MOU</th>
                                 </tr>
                                <tbody>
                                     <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                                 </tbody>
                                </table>
                    </LayoutTemplate>
                                 <Itemtemplate>
                                         <tr>
                                             <td class="datas"><%# Container.DataItemIndex + 1 %></td>
                                             <td class="datas">
                                                 <a href='<%# ResolveUrl("~/ViewIndustryProfile_Admin?industry_accID=" + Eval("industry_accID"))%>' style="text-decoration: underline;">
                                                 <asp:Label runat="server" Text='<%# Eval("industryName") %>'></asp:Label>

                                             </td>
                                             <td class="datas"><%# Eval("location") %></td>
                                             <td class="datas"><%# Eval("contactPerson") %></td>
                                             <td class="datas"><%# Eval("contactNumber") %></td>
                                             <td class="datas"><%# Eval("contactEmail") %></td>
                                             <td class="datas"><asp:Button ID="btnMOU" runat="server" Text="View MOU"
                                                   OnCommand="ViewMOU_Command" CommandName="View"  
                                                   CommandArgument='<%# Eval("mou") %>'/></td>
                                         </tr>
                                </Itemtemplate>
                       </asp:ListView>
</div>
            </div>
        </div>    
   
    </div>
   

    <div class="modal" id="AddIndustryModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered custom-modal-size">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="title">Create Industry Account</h2>
                </div>
                <div class="modal-body" style="align-items:center;">
                    <div class="container-industry">
                        <div class="row">
                           <div class="col-md-12">
                                <!-- Row 1 -->
                                <asp:Label ID="Label1" runat="server" Style="font-size:18px;">
                                    IndustryName<span style="color:red;">*</span>
                                </asp:Label><span style="margin-left:11px;  font-size:18px;">:</span><br />
                                <asp:TextBox ID="txtIndustryName" runat="server" CssClass="form-control" placeholder="Industry name" style="width:400px; margin-left:11px;"></asp:TextBox><br />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" forecolor="#F7941F" ControlToValidate="txtIndustryName"  runat="server" Display="Dynamic" ErrorMessage="this field is required!" ValidationGroup="AddIndustry"></asp:RequiredFieldValidator><br /><br />
                                <!-- Row 2 -->
                                <asp:Label ID="Label2" runat="server" Style="font-size:18px;">
                                    Email<span style="color:red;">*</span>
                                </asp:Label><span style="margin-left:11px;  font-size:18px;">:</span><br />
                                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="example@gmail.com" style="width:400px; margin-left:11px;"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" forecolor="#F7941F" ControlToValidate="txtemail"  runat="server" Display="Dynamic" ErrorMessage="this field is required!" ValidationGroup="AddIndustry"></asp:RequiredFieldValidator><br /><br />
                                <!-- Row 3 -->
                                <!--PASSWORD-->
                                <asp:Label ID="Label3" runat="server" Style="font-size:18px;">
                                    Password<span style="color:red;">*</span>
                                </asp:Label><span style="margin-left:11px;  font-size:18px;">:</span><br />
                               <input type="text" id="txtpwd" runat="server" class="form-control" style="width:400px; margin-left:11px;" placeholder="Password" readonly onfocus="displayPassword()">
                                <asp:RegularExpressionValidator ID="revpwd" runat="server" ControlToValidate="txtpwd" ErrorMessage="Invalid Password" CssClass="text-danger" ValidationExpression="^(?=.*\d)(?=.*[A-Z])(?=.*\W)(?!.*\s).{8,}$"></asp:RegularExpressionValidator><br />
                                
                                <!-- Row 4 -->
                               <!--MOU-->
                                    <asp:Label ID="Label5" runat="server" Style="font-size:18px;">
                                        MOU<span style="color:red;">*</span>
                                    </asp:Label><span style="margin-left:11px;  font-size:18px;">:</span><br />
                               <asp:FileUpload ID="mouUpload" runat="server" style="width:400px; margin-left:11px;"/><br />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" forecolor="#F7941F" ControlToValidate="mouUpload"  runat="server" Display="Dynamic" ErrorMessage="this field is required!" ValidationGroup="AddIndustry"></asp:RequiredFieldValidator><br /><br />
                               <!-- Row 6 -->
                               <asp:Label ID="lblocation" runat="server" Style="font-size:18px;">
                                Location<span style="color:red;">*</span>
                                </asp:Label><span style="margin-left:11px;  font-size:18px;">:</span><br />
                               <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" placeholder="Location" style="width:400px; margin-left:11px;"></asp:TextBox><br />
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" forecolor="#F7941F" ControlToValidate="txtLocation"  runat="server" Display="Dynamic" ErrorMessage="this field is required!" ValidationGroup="AddIndustry"></asp:RequiredFieldValidator><br /><br />
                           </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" CssClass="btn btn-danger" data-dismiss="modal" Text="Close" OnClick="CloseIndustryModal" />
                    <asp:Button ID="BtnSubmit"  class="btn btn-primary" runat="server" Text="Submit" OnCLick="BtnSubmit_Click" autopostback="true" ValidationGroup="AddIndustry"/>
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
                        <asp:Label ID="Label24" runat="server" Text="You succesfully created the account into the list" Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <button runat="server" type="button" class="btn btn-success" Text="Close" OnCLick="close_Modal" />
                    </div>
                </div>
            </div>
</div>
    <script type="text/javascript">
        function closeModal1() {
            var modal = document.getElementById("AddIndustryModal");
            modal.style.display = "none";
        }
        function close_Modal2() {
            var modal = document.getElementById("SuccessPrompt");
            modal.style.display = "none";
        }
        function displayPassword() {

            var inputBox = document.getElementById('<%= txtpwd.ClientID %>');
            var firstName = document.getElementById('<%= txtIndustryName.ClientID %>').value.replace(/\s/g, '');
            var currentDate = new Date();
            var currentYear = currentDate.getFullYear();
            if (firstName != '') {
                inputBox.value = '@' + firstName + currentYear;
            }
        }
    </script>
</asp:Content>
