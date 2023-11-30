<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="ALUMNI_EMPLOYMENT_FORM.aspx.cs" Inherits="ctuconnect.ALUMNI_EMPLOYMENT_FORM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container  d-flex align-items-center justify-content-center">
        <div class="d-inline-block bg-light p-5 w-50">
            <div class="col">
                <h2 class="text-center">Alumni Employment Form</h2>

                <div class="form-group">
                    <label for="EmploymentStatus">Employment Status:</label>
                    <asp:DropDownList ID="EmploymentStatus" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="EmploymentStatus_SelectedIndexChanged">
                        <asp:ListItem Text="Employed" Value="Employed"></asp:ListItem>
                        <asp:ListItem Text="Not Employed" Value="Not Employed"></asp:ListItem>
                        <asp:ListItem Text="Self-Employed" Value="Self-Employed"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="txtCompanyOrBusinessName">Company or Business Name:</label>
                    <asp:TextBox ID="txtCompanyOrBusinessName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtDepartment">Department:</label>
                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtPosition">Position:</label>
                    <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="TypeOfEmployment">Type of Employment:</label>
                    <asp:DropDownList ID="TypeOfEmployment" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Fulltime" Value="Fulltime"></asp:ListItem>
                        <asp:ListItem Text="Part-Time" Value="Part-Time"></asp:ListItem>
                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="N/A"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="SalaryRange">Salary Range:</label>
                    <asp:DropDownList ID="SalaryRange" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Minimum" Value="Minimum"></asp:ListItem>
                        <asp:ListItem Text="Average" Value="Average"></asp:ListItem>
                        <asp:ListItem Text="Above Average" Value="Above Average"></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="N/A"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="form-group">
                    <label for="txtDateHired">Date Hired:</label>
                    <asp:TextBox ID="txtDateHired" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-group">
                     <label for="txtDateHired">Is Connected To Course:</label>
                    <asp:RadioButtonList ID="ConnectedToCourse" runat="server">
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="N/A"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group">
                     <label for="txtDateHired">Is Aligned to Skills:</label>
                    <asp:RadioButtonList ID="AlignedToSkills" runat="server">
                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        <asp:ListItem Text="N/A" Value="N/A"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="d-flex justify-content-start">
                    <div class="form-group ms-2">
                        <asp:Button ID="Save" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Save_Click" />
                    </div>
                    <div class="form-group ms-2">
                        <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="Cancel_Click" OnClientClick="return confirmCancel();" CausesValidation="false"/> 
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        // Get the date input element
        var dateInput = document.getElementById('<%= txtDateHired.ClientID %>');

        // Set the minimum attribute to a minimum allowed date (e.g., project start date)
        var minDate = 'YYYY-MM-DD'; // Replace with your desired minimum date
        dateInput.setAttribute('min', minDate);

        // Set the maximum attribute to today's date
        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); // January is 0!
        var yyyy = today.getFullYear();

        today = yyyy + '-' + mm + '-' + dd;
        dateInput.setAttribute('max', today);

        function confirmCancel() {
            return confirm("Are you sure you want to answer it later?");
        }
    </script>
</asp:Content>
