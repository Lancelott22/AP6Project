<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="IndustryVerification.aspx.cs" Inherits="ctuconnect.IndustryVerification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            margin-left:3px;
        }
        
       
    
    </style>
    <div class="container-fluid">
        <div class="row">
            <div class="col-3 d-flex flex-column" >
                <div class="nav flex-column flex-nowrap vh-100 overflow-auto p-2">
                    <div class="profile-container">
                        <img src="images/administratorpic.jpg" />
                        <p >Admin</p>
                        <hr class="horizontal-line" />
                        <a href="#">
                            <i class="fa fa-tachometer" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                            Dashboard
                        </a>
                        <a class="active" href="IndustryVerification.aspx">
                            <i class="fa fa-users" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                            Industry Verification
                        </a>
                        <a href="ReferralList_Admin.aspx">
                            <i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                            Referred Student
                        </a>
                        <hr class="horizontal-line" />
                        <a href="ListOfIndustries_Alumni.aspx">
                            <i class="fa fa-industry" aria-hidden="true" style="padding-right:7px; width:32px;"></i>
                            List of Industry
                        </a>
                        <a href="#">
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
                        <a href="#">
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
            <div class="col-9 d-flex flex-column">
                <br />
                <div class="container">
                    <h1 class="title">Industry Verification</h1>
                     <div class="container-fluid" >
                    <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p><br />
                     </div>
                    <div class="container-fluid d-flex flex-column">
                    <asp:ListView ID="IndustryListView" runat="server" OnItemDataBound="IndustryListView_ItemDataBound">
                <LayoutTemplate>
                    <table style="font-size: 18px; line-height: 30px;">
                        <tr style="background-color: #336699; color: White; padding: 10px;">
                            <th>Account ID</th>
                            <th>Industry Name</th>
                            <th>Address</th>
                            <th>Email</th>
                            <th>Mou</th>
                            <th>Verified</th>
                            <th>Status</th>
                            <th></th>
                            <th></th>
                        </tr>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceHolder" runat="server" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr style="border-bottom: solid 1px #336699">
                        <span visible="false" runat="server" id="industryID"><%#Eval("industry_accID")%></span>
                        <td><%#Eval("industry_accID")%></td>
                        <td><%#Eval("industryName")%></td>
                        <td><%#Eval("location")%></td>
                         <td><%#Eval("email")%></td>
                        <td class="my-5">
                            <asp:LinkButton ID="ViewMou" runat="server" CssClass="btn btn-primary" OnCommand="ViewMou_Command" CommandArgument='<%#Eval("mou")%>'>View Mou</asp:LinkButton>
                        </td>
                         <td><%#Eval("Verify")%></td>
                        <td><%#Eval("Deactivate")%></td>
                        <td>
                            <asp:LinkButton ID="Verify" runat="server" CssClass="btn btn-info" OnCommand="Verify_Command" OnClientClick="confirmVerify();" CommandName='<%#Eval("email")%>' CommandArgument='<%#Eval("industry_accID")%>'></asp:LinkButton>
                           </td>
                            <td> <asp:LinkButton ID="Deactivate" runat="server" OnCommand="Deactivate_Command" OnClientClick="confirmDeactivate();"  CommandArguent='<%#Eval("industry_accID")%>'></asp:LinkButton>

                        </td>
                    </tr>
                </ItemTemplate>
                        
            </asp:ListView>
                        </div>
                </div>
            </div>    
       
        </div>
    </div>
    <script type="text/javascript">
    function confirmVerify() {
        if (confirm("Are you sure you want to verify this user?")) {
                
        } else {
            __doPostBack();
            alert("You cancelled the operation.");
        }
     }
        function confirmDeactivate() {
            if (confirm("Are you sure you want to proceed?")) {

            } else {
                __doPostBack();
                alert("You cancelled the operation.");
            }
        }
    </script>
</asp:Content>
