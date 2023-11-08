﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HiredList.aspx.cs" Inherits="ctuconnect.HiredList" %>
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
           width:253px;
            height:280px;
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
                width:1500px;
                top:0;
                bottom:0;
                padding: 2% 2% 0% 2%;
                overflow: auto;
                height:550px;
                
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
        .topnav {
          overflow: hidden;
        }

        .topnav .linkbutton {
          float: left;
          display: block;
          color: black;
          text-align: center;
          padding: 2px 15px;
          text-decoration: none;
          font-size: 17px;
        }

        .topnav .linkbutton:hover {
          border-bottom: 2px solid black;
        }

        .topnav .linkbutton.active {
          border-bottom: 2px solid black;
          color:#881A30;
         }
        th{
           border-collapse: collapse;
            border-color:white;
            background-color:#f4f4fb;
            padding:5px;

        }
        .datas{
             padding:5px;
              border: 3px solid;
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
        .evaluateButton{
            background-color: #F9E9B7; 
            color: #F3C129; 
            margin-right:2px;
            border-radius: 25px; 
            padding: 1px 3px; 
            text-align: center;
            cursor: pointer;
            border:none;
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
                   <h1 class="title">Hired List</h1>
                   <div class="col-lg-5 order-1 order-lg-2 topnav">
                       <asp:LinkButton ID="myLinkButton1"  runat="server" OnClick="btnSwitchGrid_Click1" CssClass="linkbutton" >Full Time</asp:LinkButton>
                       <asp:LinkButton ID="myLinkButton2" runat="server" OnClick="btnSwitchGrid_Click2" CssClass="linkbutton">Internship</asp:LinkButton>      
                   </div>
                   <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p> 
                
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
     <ContentTemplate>
                            <%--First Gridview--%>
                        <asp:Repeater ID="dataRepeater1" runat="server">
                            <HeaderTemplate>
                                <table  class="table-list">
                                    <tr>
                                        <th style="width: 50px;">No.</th>
                                       <th style="width: 200px;">Last Name</th>
                                       <th style="width: 200px;">First Name</th>
                                       <th style="width: 200px;">Date Started</th>
                                       <th style="width: 200px;">Position</th>
                                       <th>Resume</th>
                                    </tr>
                                  </table>
                            </HeaderTemplate>
                                    <ItemTemplate>
                                        <table class="table-list">
                                        <tr class="datas">
                                            <td style="width: 50px;"><%# Container.ItemIndex + 1 %></td>
                                           <td style="width: 150px;"><%# Eval("lastName") %></td>
                                           <td style="width: 150px;"><%# Eval("firstName") %></td>
                                           <td style="width: 150px;"><%# Eval("dateStarted") %></td>
                                           <td style="width: 150px;"><%# Eval("position") %></td>
                                            <td >
                                                <asp:Button ID="ResumeButton"  runat="server" Text="View Resume"
                                                OnCommand="ViewResume_Command" CommandName="View"  
                                                CommandArgument='<%# Eval("resumeFile") %>'/>
                                            </td>
                                        </tr>
                                            </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                           
                            <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Style="text-align:center;" Height="100%" Width="100%"  AllowPaging="True"  BackColor="#FFFFFF" BorderColor="#c1beba" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="50" CellSpacing="50" Font-Bold="False" Font-Size="13px" ShowHeaderWhenEmpty="true">
                            <PagerStyle  HorizontalAlign="Center" />
                            <HeaderStyle Font-Bold="false"  BackColor="#D3D3D3" Font-Size="12px" ForeColor="black" Height="28px"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                                <EmptyDataTemplate>
                                    <p>No data available</p>
                                </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="No." ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                <asp:BoundField DataField="DateStarted" HeaderText="Date Started" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" />
                                <asp:BoundField DataField="Position" HeaderText="Position" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                <asp:BoundField DataField="ResumeFile" HeaderText="Resume" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" />
                            </Columns>
                            </asp:GridView>--%>
                   
                            <%--Second Gridview--%>
                                   <asp:Repeater ID="dataRepeater2" runat="server">
                                    <HeaderTemplate>
                                        <table  class="table-list">
                                            <tr>
                                                <th style="width: 78px;">No.</th>
                                                <th style="width: 230px;">Last Name</th>
                                                <th style="width: 230px;">First Name</th>
                                                <th style="width: 230px;">Date Hired</th>
                                                <th style="width: 230px;">Internship Status</th>
                                                <th style="width: 230px;">Rendered Hours</th>
                                                <th style="width: 230px;">Evaluation</th>
                                            </tr>
                                            </table>
                                        </HeaderTemplate>
                                                <ItemTemplate>
                                                     <table class="table-list">
                                                    <tr class="datas">
                                                        <td style="width: 78px;"><%# Container.ItemIndex + 1 %></td>
                                                        <td style="width: 230px;"><%# Eval("lastName") %></td>
                                                        <td style="width: 230px;"><%# Eval("firstName") %></td>
                                                        <td style="width: 230px;"><%# Eval("dateHired") %></td>
                                                        <td style="width: 230px;"><%# Eval("internshipStatus") %></td>
                                                        <td style="width: 230px;"><%# Eval("renderedHours") %></td>
                                                        <td >
                                                            <asp:Button ID="EvaluationBtn" CssClass="evaluateButton" runat="server" Text='<%# Eval("evaluationRequest") %>'
                                                            OnCLick="Evaluate_BtnClick"/>
                                                        </td>
                                                    </tr>
                                                    </table>

                                                </ItemTemplate>
        
                                            </asp:Repeater>
                                      
                            <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Visible="false" Style="text-align:center;" Height="100%" Width="100%"  AllowPaging="True"  BackColor="#FFFFFF" BorderColor="#c1beba" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="50" CellSpacing="50" Font-Bold="False" Font-Size="13px" ShowHeaderWhenEmpty="true" OnRowDataBound="GridView2_RowDataBound">
                                <PagerStyle  HorizontalAlign="Center" />
                                <HeaderStyle Font-Bold="false"  BackColor="#D3D3D3" Font-Size="12px" ForeColor="black" Height="28px"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                                <EmptyDataTemplate>
                                     <p>No data available</p>
                                </EmptyDataTemplate>
                             <Columns>
                                    <asp:TemplateField HeaderText="No." ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                    <asp:BoundField DataField="DateStarted" HeaderText="Date Started" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                    <asp:BoundField DataField="InternshipStatus" HeaderText="Status" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                    <asp:BoundField DataField="RenderedHours" HeaderText="Rendered hours" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                    <asp:BoundField DataField="EvaluationRequest" HeaderText="Evaluation Request" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                               </Columns>
                            </asp:GridView>--%>
                       </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Style="vertical-align:top;">
                <div class="sidemenu-container">
                    <a  href="IndustryDashboard.aspx"><i class='bx bxs-dashboard' aria-hidden="true"></i>&nbsp&nbsp&nbsp Dashboard</a>
                   <a  href="IndustryHome.aspx"><i class="fa fa-edit" aria-hidden="true"></i>Post a Job</a>
                     <a href="IndustryJobPosted.aspx"><i class="fa fa-briefcase" aria-hidden="true"></i>Job Posted</a>
                     <a href="Applicants.aspx"><i class="fa fa-group" aria-hidden="true"></i>Applicants</a>
                     <a class="active" href="HiredList.aspx"><i class="fa fa-check-circle" aria-hidden="true"></i>Hired List</a>
                     <a href="ReferralList.aspx"><i class="fa fa-handshake-o" aria-hidden="true"></i>Referral List</a>
                     <asp:LinkButton runat="server" ID="SignOut" OnClick="SignOut_Click">
                    <i class="fa fa-sign-out" aria-hidden="true"></i>
                     Sign-out
                    </asp:LinkButton>
               </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
  
</asp:Content>
