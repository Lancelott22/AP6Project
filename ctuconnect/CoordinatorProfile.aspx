<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CoordinatorProfile.aspx.cs" Inherits="ctuconnect.CoordinatorProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        *{
            font-family: 'Poppins', sans-serif;
        }
        .profile-container{
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
       
            a {
                position:static;
                border-radius: 10px;
                color: black;
                text-decoration: none;
                font-size: 19px;
                display: block;
                margin: 2px 15px 5px 15px ;
                padding: 0px 0px 0px 30px;
            }
            a.active{
                 background-color:#F6B665;
                color:#606060;
            }
            a:hover{
                background-color:#fcd49a;
                color:#606060;
                margin: 2px 15px 5px 15px ;
                padding: 0px 0px 0px 30px;
                text-decoration: none;
            }
            .display-container{
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
                <img src="images/industrypic.png" />
                <p >OJT Coordinator</p>
                    <hr class="horizontal-line" />
                    <a class="active" href="Coordinator.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                     <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:32px;"></i>Refer Student</a>
                    <a  href="CourseLists.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                     <a  href="Applicants.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                     <hr class="second" />
                     <a  href="ReferralLIst.aspx"><i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>Sign-out</a>
                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding:0px 5px 0px 40px">
               <div class="display-container">
                   <h1 class="title">List of Interns</h1>
                    <p style="float:left;">Sort by <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true"  CssClass="sort-dropdown">
                        <asp:ListItem Text="Course" Value="ColumnName1"></asp:ListItem>
                        <asp:ListItem Text="Status" Value="ColumnName2"></asp:ListItem>
                    </asp:DropDownList></p>
                   <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>
                   <%--<asp:gridview id="gridview1" runat="server" style="color:black; " autogeneratecolumns="false"  showheaderwhenempty="true" cssclass="gridview-style"
                                      allowpaging="true"  backcolor="#ffffff" bordercolor="#c1beba" borderstyle="solid" borderwidth="1px" cellpadding="50" cellspacing="50" 
                                      font-bold="false" font-size="13px"  height="100%" width="100%" >  
                        <pagerstyle  horizontalalign="center" />
                        <headerstyle font-bold="false"  backcolor="#d3d3d3" font-size="12px" forecolor="black" height="28px"  horizontalalign="center" verticalalign="middle"/>
                       
                            <columns >
                               <asp:boundfield datafield="studentid" headertext="student id"  itemstyle-bordercolor="#c1beba" itemstyle-borderstyle="solid" itemstyle-borderwidth="1px"/>
                                <asp:boundfield datafield="lastname" headertext="last name" itemstyle-bordercolor="#c1beba" itemstyle-borderstyle="solid" itemstyle-borderwidth="1px"/>
                                <asp:boundfield datafield="firstname" headertext="first name" itemstyle-bordercolor="#c1beba" itemstyle-borderstyle="solid" itemstyle-borderwidth="1px"/>
                                 <asp:boundfield datafield="course" headertext="course" itemstyle-bordercolor="#c1beba" itemstyle-borderstyle="solid" itemstyle-borderwidth="1px" sortexpression="columnname1"/>
                                <asp:boundfield datafield="workedat" headertext="worked at" itemstyle-bordercolor="#c1beba" itemstyle-borderstyle="solid" itemstyle-borderwidth="1px" />
                                <asp:boundfield datafield="datestarted" headertext="date started" itemstyle-bordercolor="#c1beba" itemstyle-borderstyle="solid" itemstyle-borderwidth="1px"/>
                                 <asp:boundfield datafield="internshipstatus" headertext="internship status" itemstyle-bordercolor="#c1beba" itemstyle-borderstyle="solid" itemstyle-borderwidth="1px" sortexpression="columnname2"/>
                                
                           
                                </columns>
                    </asp:gridview>--%>
                               <table  class="table-list">
                                    <tr>
                                        <th>student id</th>
                                        <th>last name</th>
                                        <th>first name</th>
                                        <th>middle initial</th>
                                        <th>program enrolled</th>
                                        <th>worked at</th>
                                        <th>date started</th>
                                        <th>hours needed</th>
                                        <th>rendered hours</th>
                                        <th>evaluation</th>
                                        <th>status</th>
                                    </tr>
                                    <asp:Repeater ID="dataRepeater" runat="server">
                                        <Itemtemplate>
                                            <tr class="datas">
                                                <td><%# Eval("studentId") %></td>
                                                <td><%# Eval("lastname") %></td>
                                                <td><%# Eval("firstname") %></td>
                                                <td><%# Eval("midinitials") %></td>
                                                <td><%# Eval("course") %></td>
                                                <td><%# Eval("workedAt") %></td>
                                                <td><%# Eval("dateStarted") %></td>
                                                <td><%# Eval("hoursNeeded") %></td>
                                                <td><%# Eval("renderedHours") %></td>
                                                <td><%# Eval("evaluationRequest") %></td>
                                                <%--<td>
                                                    <asp:button id="evaluationBtn" runat="server" text="view evaluation"
                                                    oncommand="reviewletter_command" commandname="review"  
                                                    commandargument='<%# Eval("evaluationRequest") %>'/>
                                                </td>--%>
                                                <td><%# Eval("internshipStatus") %></td>
                                            </tr>
                                        </Itemtemplate>
        
                                    </asp:Repeater>
                                </table>
               </div>
            </asp:TableCell>
        </asp:TableRow>
          
    </asp:Table>
</asp:Content>
