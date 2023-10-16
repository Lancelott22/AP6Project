<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CourseLists.aspx.cs" Inherits="ctuconnect.CourseLists" %>
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
             }
             /*.gridview-style .header-style{
                 width:20px;
                 text-align:center;
                 align-items:center;
             }*/
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
        border-top: 2px solid black;
        width: 90%;
        margin-left:auto;
        margin-right:auto;
        margin-top:1%;
        margin-bottom:0%;
    }
    .second{
        border: none;
        border-top: 2px solid black;
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
   
    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell  style="vertical-align: top;">
                <div class="profile-container">
                <img src="images/industrypic.png" />
                <p >OJT Coordinator</p>
                    <hr class="horizontal-line" />
                    <a  href="Coordinator.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                     <a href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:32px;"></i>Refer Student</a>
                    <a class="active" href="CourseList.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                     <a  href="Applicants.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                     <hr class="second" />
                     <a  href="ReferralLIst.aspx"><i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>Sign-out</a>
                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding:0px 5px 0px 40px">
               <div class="display-container">
                   <h1 class="title">List of Course</h1>
                    <p style="float:left;">Sort by <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true"  CssClass="sort-dropdown">
                        <asp:ListItem Text="COED" Value="ColumnName1"></asp:ListItem>
                        <asp:ListItem Text="CME" Value="ColumnName1"></asp:ListItem>
                        <asp:ListItem Text="CCICT" Value="ColumnName1"></asp:ListItem>
                        <asp:ListItem Text="COE" Value="ColumnName1"></asp:ListItem>
                    </asp:DropDownList></p>
                   <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p>
                   <asp:GridView ID="GridView1" runat="server" Style="color:black; " AutoGenerateColumns="false"  ShowHeaderWhenEmpty="true" CssClass="gridview-style"
                                      AllowPaging="True"  BackColor="#FFFFFF" BorderColor="#c1beba" BorderStyle="Solid" BorderWidth="1px" CellPadding="50" CellSpacing="50" 
                                      Font-Bold="False" Font-Size="13px"  Height="100%" Width="100%" HorizontalAlign="Center" VerticalAlign="Middle" >  
                        <PagerStyle  HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="false" BackColor="#D3D3D3" Font-Size="12px" ForeColor="black" Height="28px"  HorizontalAlign="Center" VerticalAlign="Middle" Width="100%" />
                       
                            <Columns >
                                <asp:TemplateField HeaderText="No." ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                     <ItemTemplate>
                                         <%# Container.DataItemIndex + 1 %>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                <asp:BoundField DataField="Course" HeaderText="Course" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                 <asp:BoundField DataField="Major" HeaderText="Major" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" SortExpression="ColumnName1"/>
                                <asp:BoundField DataField="hoursNeeded" HeaderText="Internship hours" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" />
                               
                           
                                </Columns>
                    </asp:GridView>
               </div>
            </asp:TableCell>
        </asp:TableRow>
          
    </asp:Table>
</asp:Content>
