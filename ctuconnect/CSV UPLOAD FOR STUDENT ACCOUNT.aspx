<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSV UPLOAD FOR STUDENT ACCOUNT.aspx.cs" Inherits="ctuconnect.CSV_UPLOAD_FOR_STUDENT_ACCOUNT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="studentCSV" runat="server" />
            <asp:Button Text="Upload" OnClick="Upload" runat="server" />
        </div>
    </form>
</body>
</html>
