﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="EditResume.aspx.cs" Inherits="ctuconnect.EditResume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='https://unpkg.com/boxicons@2.1.1/css/boxicons.min.css' rel='stylesheet'>
    <style>
        .container {
            min-height: 550px;
            background-color: #FFFFFF;
            width:55%;
            border: 1px solid #FFFFFF;
            padding-top:2em;
            padding-left:2em;
            padding-right:2em;
          
        }

        .container2 {
            margin: auto;
            padding-right:2em;
            padding-left:1em;
            width:55%;
  
        }

        .txtbox{
            border-radius: 5px;
            
        }

        .btn1{
            border: 1px solid red;
            border-radius: 5px;
            background-color: red;
            font-size: 14px;
            
        }

        .btn2{
            border: 1px #00cc99;
            border-radius: 5px;
            background-color: #00cc99;
            font-size: 14px;
    
        }

        .btn-md{
            border: 1px #F7941F;
            background-color: #F7941F;
            position:center;
            width: 120px;
            height:45px;
        }

        .btn-cancel{
            border: 1px solid #F7941F;
            background-color: #F0EBEB;
            position:center;
            width: 120px;
            height:45px;
            color:  #F7941F;
        }

        .error-container {
            display: none;
            position: absolute;
            background-color: #f44336;
            color: white;
            padding: 10px;
            border-radius: 5px;
            bottom: 20px;
            left: 50%;
            transform: translateX(-50%);
        }
    </style>

    <div class="container-fluid">
        <br />
        <div class="container">
            <div class="col-12 d-flex flex-column">
                <h3 style="text-align:center">Build Resume</h3> 
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Label ID="lblProfilePicture" runat="server" Text="Profile Picture:"></asp:Label>
                        <asp:FileUpload ID="fileUploadProfilePicture" runat="server" />
                        <br />
                        <asp:Image ID="imgProfilePicture" runat="server" CssClass="profile-picture" height="144px" Width="144px"/>
                        <br />
                        <asp:Button ID="btnUploadPicture" runat="server" Text="Upload" OnClick="btnUploadPicture_Click" />
                        <br />
                    </div>   
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <b>PERSONAL INFORMATION</b>
                    </div>
                    
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        Last Name
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtlname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        First Name
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtfname" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        Contact
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtContact" runat="server" CssClass="txtbox" Width="400px" Height="30px" oninput="validateContactNumber()"></asp:TextBox>
                        <div id="errorContainer" class="error-container">
                            <span id="errorMessage" class="error-message"></span>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        Email
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        Birthdate
                    </div>
                    <div class="col-sm-9">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                            <asp:TextBox ID="txtbdate" runat="server" TextMode="Date" CssClass="txtbox" Width="400px" Height="30px" AutoPostBack="true" OnTextChanged="txtbdate_TextChanged"></asp:TextBox>
                            <asp:Label ID="labelbdate" runat="server" Visible="false" Font-Size="Medium" ForeColor="Red"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        Gender
                    </div>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="drpgender" CssClass="txtbox" runat="server" Width="400px" Height="30px">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        Address
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-3">
                        Job Level
                    </div>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="drpjoblevel" CssClass="txtbox" runat="server" Width="400px" Height="30px">
                        <asp:ListItem>OJT (Student Interns and On-the-job trainees)</asp:ListItem>
                        <asp:ListItem>No Experience (Fresh Graduates)</asp:ListItem>
                        <asp:ListItem>Entry Level (6 Months to 1 Year Experience)</asp:ListItem>
                        <asp:ListItem>Experienced Employee (2-4 Years Experience)</asp:ListItem>
                        <asp:ListItem>Advanced Employee (5+ Years of Experience)</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <b>SKILLS</b>
                    </div>   
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="skillsContainer" runat="server">
                            <asp:Repeater ID="rptSkills" runat="server" OnItemCommand="rptSkills_ItemCommand">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtSkills" Text='<%# Eval("skills") %>' placeholder="Skills..." CssClass="txtbox" Width="400px" Height="30px"></asp:TextBox>                                    
                                    <asp:Button runat="server" Text="Remove" CommandName="RemoveSkills" CommandArgument='<%# Container.ItemIndex %>' class="btn btn-danger" Height="28px"/>
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <asp:Button ID="btnAddSkills" runat="server" Text="Add Skill" OnClick="btnAddSkills_Click" class="btn btn-success" Height="28px"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddSkills" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <b>EDUCATION</b>
                    </div>   
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="educationContainer" runat="server">
                            <asp:Repeater ID="rptEducation" runat="server" OnItemCommand="rptEducation_ItemCommand">
                                <ItemTemplate>
                                    
                                    <asp:TextBox runat="server" ID="txtDegree" Text='<%# Eval("edDegree") %>' placeholder="Degree" CssClass="txtbox" Width="200px" Height="30px"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtSchool" Text='<%# Eval("edNameOfSchool") %>' placeholder="Name of School" CssClass="txtbox" Width="200px" Height="30px"></asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtGradDate" Text='<%# Eval("edGraduationDate") %>' placeholder="Year" CssClass="txtbox" Width="100px" Height="30px"></asp:TextBox>
                                    <asp:Button runat="server" Text="Remove" CommandName="RemoveEducation" CommandArgument='<%# Container.ItemIndex %>' class="btn btn-danger" Height="28px"/>
                                    <br />                                
                                        
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <asp:Button ID="btnAddEducation" runat="server" Text="Add Education" OnClick="btnAddEducation_Click" class="btn btn-success" Height="28px"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddEducation" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <b>CERTIFICATES</b>
                    </div>   
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="certificatesContainer" runat="server">
                            <asp:Repeater ID="rptCertificate" runat="server" OnItemCommand="rptCertificate_ItemCommand">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txtCertificates" Text='<%# Eval("certificate") %>' placeholder="Certificate" CssClass="txtbox" Width="600px" Height="30px"></asp:TextBox>                                   
                                    <asp:Button runat="server" Text="Remove" CommandName="RemoveCertificates" CommandArgument='<%# Container.ItemIndex %>' class="btn btn-danger" Height="28px"/>
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <asp:Button ID="btnAddCertificates" runat="server" Text="Add Certificate" OnClick="btnAddCertificates_Click" class="btn btn-success" Height="28px" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddCertificates" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>
                    </div>
                </div>
                <br />
                
            </div>
        </div>
        <br />
        <div class="container2">
            <div class="row">
                <div class="col-2 d-flex flex-column">
                    <asp:Button ID="btnSave" class="btn btn-primary btn-md" runat="server" Text="Save" OnClick="btnSave_Click"/>
                </div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="col-2 d-flex flex-column">
                    <asp:Button ID="btnCancel" class="btn btn-primary btn-md btn-cancel" runat="server" Text="Back" OnClick="btnCancel_Click"/>
                </div>
            </div>
        </div>
        <br />
        <br />
        <br />
    </div>

    <script>
        function validateContactNumber() {
            var textBox = document.getElementById('<%= txtContact.ClientID %>');
            var errorContainer = document.getElementById('errorContainer');
            var errorMessage = document.getElementById('errorMessage');

            if (!/^\d{11}$/.test(textBox.value.trim())) {
                errorMessage.innerHTML = 'Contact number must be 11 digits.';
                errorContainer.style.display = 'block';

                // Hide the error message after 3 seconds (3000 milliseconds)
                setTimeout(function () {
                    errorContainer.style.display = 'none';
                }, 3000);
            } else {
                errorContainer.style.display = 'none';
            }
        }
    </script>
    
</asp:Content>
