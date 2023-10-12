<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Refer.aspx.cs" Inherits="ctuconnect.Refer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <meta name='viewport' content='width=device-width, initial-scale=1'>
<script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
   
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400&display=swap');
        
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
                width:750px;
                top:0;
                bottom:0;
                padding: 2% 4% 4% 4%;
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
    .txtbox {
                 display:flex;
                 position:relative;
                 border-radius: 10px;
                 min-width: 100%;
                min-height:35px;
                margin-bottom:2%;
                padding-left:20px;
                border: 1px solid gray;
                justify-content: center; /* Add this property to include padding in the width calculation */
               
    }
    .txtbox-id {
             position:relative;
             border-radius: 10px;
             width: 200px;
            height:35px;
            margin-bottom:2%;
            padding-left:20px;
            border: 1px solid gray;
            justify-content: center; /* Add this property to include padding in the width calculation */
           
}
    .dropdown1{
               
                display:flex; 
                position:relative;
                 border-radius: 10px;
                min-height:35px;
                margin-bottom:2%;
                justify-content: center;
            }
    .button-submit {
        background-color: white;
        min-width: 100%;
        min-height: 35px;
        color: orange;
        border-radius: 10px;
        border: 1px solid orange;
        transition: background-color 0.3s, color 0.3s, border-color 0.3s;
    }
    .button-find {
    background-color: white;
    width: 80px;
    height: 35px;
    color: orange;
    border-radius: 10px;
    border: 1px solid orange;
    transition: background-color 0.3s, color 0.3s, border-color 0.3s;
}
    .button-find:hover {
    background-color: #F6B665;
    color: white;
    border-color: orange;
}
    .button-submit:hover {
        background-color: #F6B665;
        color: white;
        border-color: orange;
    }
    .fa {
                width:20px;
                margin-right: 19px; 
    }
    .display-container .column{
        display: flex;
        column-gap: 5px;
    }
    </style>
    <asp:Table ID="Table1" runat="server"  CssClass="content">
        <asp:TableRow>
            <asp:TableCell  style="vertical-align: top;">
                <div class="profile-container">
                    <img src="images/industrypic.png" />
                        <p >OJT Coordinator</p>
                            <hr class="horizontal-line" />
                            <a  href="CoordinatorProfile.aspx"><i class="fa fa-users" aria-hidden="true" style="padding-right:12px;"></i>List of Interns</a>
                            <a class="active" href="Refer.aspx"><i class="fa fa-handshake-o" aria-hidden="true" style="padding-right:12px; width:20px;"></i>Refer Student</a>
                            <a  href="CourseList.aspx"> <i class="fa fa-book" aria-hidden="true" style="padding-right:12px;"></i>Course List</a>
                            <a  href="Applicants.aspx"><i class="fa fa-bullseye" aria-hidden="true" style="padding-right:12px;"></i>Tracer</a>
                            <hr class="second" />
                            <a  href="ReferralLIst.aspx"><i class="fa fa-sign-out" aria-hidden="true" style="padding-right:12px;"></i>Sign-out</a>
                </div>
            </asp:TableCell>
            <asp:TableCell Style="padding:0px 5px 0px 40px">
                <div class="display-container">
                     <h1 class="title">Referral</h1>
                        <p style="float:left;">Sort by <asp:DropDownList ID="ddlSortBy" runat="server" AutoPostBack="true"  CssClass="sort-dropdown">
                            <asp:ListItem Text="Date" Value="ColumnName1"></asp:ListItem>
                            <asp:ListItem Text="Status" Value="ColumnName2"></asp:ListItem>
                        </asp:DropDownList></p>
                            <asp:Button ID="addreferstudent" runat="server" Text="Add Refer Student" AutoPostBack="false" OnClick="addRefer_Click" style="float:right;"    />
                           <%-- <p style="float:right;">Search <input type="text" id="searchInput" Style="border-color:#c1beba; border-width:1px;" /></p> --%>
                            <asp:GridView ID="GridView1" runat="server" Style="color:black; " AutoGenerateColumns="false"  CssClass="gridview-style"
                                              AllowPaging="True"  BackColor="#FFFFFF" BorderColor="#c1beba" BorderStyle="Solid" BorderWidth="1px" CellPadding="50" CellSpacing="50" 
                                              Font-Bold="False" Font-Size="13px" Height="100%" Width="100%" ShowHeaderWhenEmpty="true" >  
                            <PagerStyle  HorizontalAlign="Center" />
                            <HeaderStyle Font-Bold="false"  BackColor="#D3D3D3" Font-Size="12px" ForeColor="black" Height="28px"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                                <EmptyDataTemplate>
                                     <p>No data available</p>
                                 </EmptyDataTemplate>
                            <Columns >
                                        <asp:TemplateField HeaderText="No." ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="lastName" HeaderText="Last Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                        <asp:BoundField DataField="firstName" HeaderText="First Name" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                        <asp:BoundField DataField="midInitials" HeaderText="Middle Initial" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px"/>
                                        <asp:BoundField DataField="industryName" HeaderText="Industry" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" />
                                        <asp:BoundField DataField="referredBy" HeaderText="Referred by" ItemStyle-BorderColor="#c1beba" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1px" />
                                        
                            </Columns>
                            </asp:GridView>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


     <%--Modal--%>
 <div class="modal fade" id="AddReferralModal" tabindex="-1" role="dialog" >
     <div class="modal-dialog modal-dialog-centered" >
         <div class="modal-content">
             <div class="modal-header">
                 <h1 class="title">Refer a Student</h1>
             </div>
                 <div class="modal-body">
                     
                                <div class="column">
                                     <asp:Label ID="Label1" runat="server" Text="Student ID" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                     <asp:TextBox ID="txtID_student" runat="server" CssClass="txtbox-id" AutoPostBack="false"  Placeholder="e.g. 1202200" ></asp:TextBox>
                                     <asp:Button runat="server" OnClick="findByID_Student" Text="Find"  CssClass="button-find" CausesValidation="false" />
                                </div>

                                      <asp:Label ID="Label8" runat="server" Text="First Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtFirstName_student" runat="server" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label9" runat="server" Text="Middle Initial" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtMiddleInitial_student" runat="server" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label3" runat="server" Text="Last Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtLastName_student" runat="server" CssClass="txtbox"  ></asp:TextBox>

                                      <asp:Label ID="Label6" runat="server" Text="Industry" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                       <div class="dropdown1">
                                           <select name="jobtype" id="jobtype" Style="border-radius: 10px;  min-width: 100%; min-height:35px; margin-bottom:2%; padding-left:20px; padding-right:20px;">
                                               <option value="100000000">Accenture.Inc</option>
                                               <option value="#">Concentrix</option>
                                               </select>
                                      </div>

                                      <asp:Label ID="Label7" runat="server" Text="Resume" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                     <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox"  ></asp:TextBox> <br>

                                     <div class="column">
                                      <asp:Label ID="Label4" runat="server" Text="Referred by" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtID_coordinator" runat="server" CssClass="txtbox-id" Placeholder="Enter your ID" ></asp:TextBox>
                                         </div>
                                      <asp:Label ID="Label2" runat="server" Text="First Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtFirstName_coordinator" runat="server" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label10" runat="server" Text="Middle Initial" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtMiddleInitial_coordinator" runat="server" CssClass="txtbox"  ></asp:TextBox>
                                      <asp:Label ID="Label5" runat="server" Text="Last Name" Style="font-size:18px;" ></asp:Label><span style="color: red">*</span> 
                                      <asp:TextBox ID="txtLastName_coordinator" runat="server" CssClass="txtbox"  ></asp:TextBox>
                      
             </div>
             <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                 <%--<asp:linkbutton id="submit"  class="buttonstyle" runat="server"  oncommand="submit_command" autopostback="false">submit</asp:linkbutton>--%>
             </div>
         </div>
     </div>
  </div>
</asp:Content>
