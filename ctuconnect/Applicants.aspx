<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Applicants.aspx.cs" Inherits="ctuconnect.Applicants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        *{
            font-family: 'Poppins', sans-serif;
        }
        .profile-container{
            max-width:260px;
            max-height:300px;
            background-color:white;
            margin-left:4%;
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
            
            @media (max-width: 790px) {
                .display-container {
                    max-width: 50%;
                }
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
             .fa {
                width:20px;
                margin-right: 19px; 
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
            <asp:TableCell  RowSpan="2" Style="padding:0px 5px 0px 40px">
                <div class="display-container">
                     <h1 class="title">Applicants List</h1>
                    <p style="float:left;">Sort by <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true"  CssClass="sort-dropdown">
                        <asp:ListItem Text="Type" Value="ColumnName1"></asp:ListItem>
                        <asp:ListItem Text="Date" Value="ColumnName2"></asp:ListItem>
                        <asp:ListItem Text="Status" Value="ColumnName3"></asp:ListItem>
                    </asp:DropDownList></p>
                    <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p> 
                        <asp:GridView ID="GridView1" runat="server" Style="color:black; " AutoGenerateColumns="false"  ShowHeaderWhenEmpty="true" CssClass="gridview-style"
                                      AllowPaging="True"  BackColor="#FFFFFF" BorderColor="#c1beba" BorderStyle="Solid" BorderWidth="1px" CellPadding="50" CellSpacing="50" 
                                      Font-Bold="False" Font-Size="13px"  Height="100%" Width="100%" >  
                        <PagerStyle  HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="false"  BackColor="#D3D3D3" Font-Size="12px" ForeColor="black" Height="28px"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                       
                            <Columns >
                               <asp:BoundField DataField="ApplicantID" HeaderText="Applicant ID"  ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                <asp:BoundField DataField="Type" HeaderText="Type" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" SortExpression="ColumnName1"/>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                 <asp:BoundField DataField="DateApplied" HeaderText="Date Applied" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" SortExpression="ColumnName2"/>
                                <asp:BoundField DataField="Resume" HeaderText="Resume" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" />
                                <asp:BoundField DataField="RequirementsStatus" HeaderText="Requirements" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                 <asp:BoundField DataField="InterviewStatus" HeaderText="Interview" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                <asp:BoundField DataField="ApplicantStatus" HeaderText="Status" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" SortExpression="ColumnName3"/>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="View resume" CommandName="Edit"  Style="border-radius:15px; width:80px;"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                           
                                </Columns>
                    </asp:GridView>
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
</asp:Content>
