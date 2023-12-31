<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEvaluation.aspx.cs" Inherits="ctuconnect.ViewEvaluation" EnableViewState="true" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
    <script>
        function goBack() {
            window.history.back(); // This function triggers the browser's back functionality
        }
    </script>
</head>
    
<body>
    <form id="form1" runat="server">
    <div id="evaluationForm" class="evaluation-form" runat="server">

    <table>
        <tr >
            <td colspan="6"><center><h1>OJT PERFORMANCE EVALUATION FORM</h1><br /><p>for&nbsp <asp:Label ID="forCourse" runat="server" ></asp:Label></p></center></td>
        </tr>
        <tr>
            <td colspan="2">Student:</td>
            <td colspan="4"><asp:Label ID="firstName" runat="server" ></asp:Label>&nbsp<asp:Label ID="lastName" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">Training Period:</td>
            <td colspan="4"><asp:Label ID="trainingPeriod" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">Course:</td>
            <td colspan="4"><asp:Label ID="course" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6">Instruction: &nbsp <p>This report is to completed by the immediate supervisor of the OJT and to be returned
        to the OJT coordinator. In the space at the left, encircle the rating that describe the OJT most accurately.
        Total the value for all responses and record in the Total Scores section.</p></td>
        </tr>
        <tr>
        <th colspan="3">Productivity</th>
        <th colspan="3">Cooperation</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="1" />&nbsp 1 </td> 
        <td><input type="radio" name="productivity" value="2"  />&nbsp 2</td>
        <td><asp:Label ID="disp_Prod1" runat="server"></asp:Label></td>
        <td><input type="radio" name="cooperation" value="1" />&nbsp 1</td>
        <td><input type="radio" name="cooperation" value="2" />&nbsp 2</td>
        <td><asp:Label ID="disp_Coop1" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="productivity" value="4"  />&nbsp 4</td>
        <td><asp:Label ID="disp_Prod2" runat="server"></asp:Label></td>
        <td><input type="radio" name="cooperation" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="cooperation" value="4"  />&nbsp 4</td>
        <td><asp:Label ID="disp_Coop2" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="5" />&nbsp 5</td>
        <td><input type="radio" name="productivity" value="6"  />&nbsp 6</td>
        <td><asp:Label ID="disp_Prod3" runat="server"></asp:Label></td>
        <td><input type="radio" name="cooperation" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="cooperation" value="6" />&nbsp 6</td>
        <td><asp:Label ID="disp_Coop3" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="productivity" value="8" />&nbsp 8</td>
        <td><asp:Label ID="disp_Prod4" runat="server"></asp:Label></td>
        <td><input type="radio" name="cooperation" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="cooperation" value="8"  />&nbsp 8</td>
        <td><asp:Label ID="disp_Coop4" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="productivity" value="10"  />&nbsp 10</td>
        <td><asp:Label ID="disp_Prod5" runat="server"></asp:Label></td>
        <td><input type="radio" name="cooperation" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="cooperation" value="10"  />&nbsp 10</td>
        <td><asp:Label ID="disp_Coop5" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <th colspan="3">Ability to Follow Instructions</th>
        <th colspan="3">Ability to Get Along with People</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="abilityToFollow" value="2"  />&nbsp 2</td>
        <td><asp:Label ID="disp_AbilityF1" runat="server"></asp:Label></td>
        <td><input type="radio" name="abilityToGet" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="abilityToGet" value="2"  />&nbsp 2</td>
        <td><asp:Label ID="disp_AbilityG1" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="3" />&nbsp 3</td>
        <td><input type="radio" name="abilityToFollow" value="4"  />&nbsp 4</td>
        <td><asp:Label ID="disp_AbilityF2" runat="server"></asp:Label></td>
        <td><input type="radio" name="abilityToGet" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="abilityToGet" value="4"  />&nbsp 4</td>
        <td><asp:Label ID="disp_AbilityG2" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="5" />&nbsp 5</td>
        <td><input type="radio" name="abilityToFollow" value="6"  />&nbsp 6</td>
        <td><asp:Label ID="disp_AbilityF3" runat="server"></asp:Label></td>
        <td><input type="radio" name="abilityToGet" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="abilityToGet" value="6" />&nbsp 6</td>
        <td><asp:Label ID="disp_AbilityG3" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="7" />&nbsp 7</td>
        <td><input type="radio" name="abilityToFollow" value="8"  />&nbsp 8</td>
        <td><asp:Label ID="disp_AbilityF4" runat="server"></asp:Label></td>
        <td><input type="radio" name="abilityToGet" value="7" />&nbsp 7</td>
        <td><input type="radio" name="abilityToGet" value="8" />&nbsp 8</td>
        <td><asp:Label ID="disp_AbilityG4" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="abilityToFollow" value="10"  />&nbsp 10</td>
        <td><asp:Label ID="disp_AbilityF5" runat="server"></asp:Label></td>
        <td><input type="radio" name="abilityToGet" value="9" />&nbsp 9</td>
        <td><input type="radio" name="abilityToGet" value="10"  />&nbsp 10</td>
        <td><asp:Label ID="disp_AbilityG5" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <th colspan="3">Initiative</th>
        <th colspan="3">Attendance</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category5" value="2" />&nbsp 2</td>
        <td><asp:Label ID="disp_Init1" runat="server"></asp:Label></td>
        <td><input type="radio" name="category6" value="1" />&nbsp 1</td>
        <td><input type="radio" name="category6" value="2"  />&nbsp 2</td>
        <td><asp:Label ID="disp_Attend1" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category5" value="4" />&nbsp 4</td>
        <td><asp:Label ID="disp_Init2" runat="server"></asp:Label></td>
        <td><input type="radio" name="category6" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category6" value="4"  />&nbsp 4</td>
        <td><asp:Label ID="disp_Attend2" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="5" />&nbsp 5</td>
        <td><input type="radio" name="category5" value="6" />&nbsp 6</td>
        <td><asp:Label ID="disp_Init3" runat="server"></asp:Label></td>
        <td><input type="radio" name="category6" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="category6" value="6"  />&nbsp 6</td>
        <td><asp:Label ID="disp_Attend3" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category5" value="8"  />&nbsp 8</td>
        <td><asp:Label ID="disp_Init4" runat="server"></asp:Label></td>
        <td><input type="radio" name="category6" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category6" value="8"  />&nbsp 8</td>
        <td><asp:Label ID="disp_Attend4" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category5" value="10" />&nbsp 10</td>
        <td><asp:Label ID="disp_Init5" runat="server"></asp:Label></td>
        <td><input type="radio" name="category6" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category6" value="10" />&nbsp 10</td>
        <td><asp:Label ID="disp_Attend5" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <th colspan="3">Quality of Work</th>
        <th colspan="3">Appearance</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category7" value="2"  />&nbsp 2</td>
        <td><asp:Label ID="disp_Qual1" runat="server"></asp:Label></td>
        <td><input type="radio" name="category8" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category8" value="2" />&nbsp 2</td>
        <td><asp:Label ID="disp_Appear1" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="3" />&nbsp 3</td>
        <td><input type="radio" name="category7" value="4"/>&nbsp 4</td>
        <td><asp:Label ID="disp_Qual2" runat="server"></asp:Label></td>
        <td><input type="radio" name="category8" value="3" />&nbsp 3 </td>
        <td><input type="radio" name="category8" value="4"  />&nbsp 4</td>
        <td><asp:Label ID="disp_Appear2" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="5" />&nbsp 5</td>
        <td><input type="radio" name="category7" value="6"/>&nbsp 6</td>
        <td><asp:Label ID="disp_Qual3" runat="server"></asp:Label></td>
        <td><input type="radio" name="category8" value="5"/>&nbsp 5</td>
        <td><input type="radio" name="category8" value="6"/>&nbsp 6</td>
        <td><asp:Label ID="disp_Appear3" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="7"/>&nbsp 7</td>
        <td><input type="radio" name="category7" value="8" />&nbsp 8</td>
        <td><asp:Label ID="disp_Qual4" runat="server"></asp:Label></td>
        <td><input type="radio" name="category8" value="7"/>&nbsp 7</td>
        <td><input type="radio" name="category8" value="8" />&nbsp 8</td>
        <td><asp:Label ID="disp_Appear4" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category7" value="10"  />&nbsp 10</td>
        <td><asp:Label ID="disp_Qual5" runat="server"></asp:Label></td>
        <td><input type="radio" name="category8" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category8" value="10" />&nbsp 10</td>
        <td><asp:Label ID="disp_Appear5" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <th colspan="3">Dependability</th>
        <th colspan="3">Overall Performance</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category9" value="2" />&nbsp 2</td>
        <td><asp:Label ID="disp_Depend1" runat="server"></asp:Label></td>
        <td><input type="radio" name="category10" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category10" value="2"  />&nbsp 2</td>
        <td><asp:Label ID="disp_Overall1" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category9" value="4" />&nbsp 4</td>
        <td><asp:Label ID="disp_Depend2" runat="server"></asp:Label></td>
        <td><input type="radio" name="category10" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category10" value="4" />&nbsp 4</td>
        <td><asp:Label ID="disp_Overall2" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="5" />&nbsp 5</td>
        <td><input type="radio" name="category9" value="6"  />&nbsp 6</td>
        <td><asp:Label ID="disp_Depend3" runat="server"></asp:Label></td>
        <td><input type="radio" name="category10" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="category10" value="6"  />&nbsp 6</td>
        <td><asp:Label ID="disp_Overall3" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category9" value="8" />&nbsp 8</td>
        <td><asp:Label ID="disp_Depend4" runat="server"></asp:Label></td>
        <td><input type="radio" name="category10" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category10" value="8" />&nbsp 8</td>
        <td><asp:Label ID="disp_Overall4" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="9" />&nbsp 9</td>
        <td><input type="radio" name="category9" value="10" />&nbsp 10</td>
        <td><asp:Label ID="disp_Depend5" runat="server"></asp:Label></td>
        <td><input type="radio" name="category10" value="9" />&nbsp 9</td>
        <td><input type="radio" name="category10" value="10" />&nbsp 10</td>
        <td><asp:Label ID="disp_Overall5" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="2">Total Score:</td>
        <td><asp:Label ID="score" runat="server"></asp:Label></td>
        <td colspan="2">Grade Equivalent:</td>
        <td><asp:Label ID="grade" runat="server"></asp:Label></td>
        
        
    </tr>

    </table>

    <table class="styled-table">
        <tr>
            <td >Describe the On-The-Job Trainee’s area of strengths:</td>
            <td>
                <asp:TextBox ID="txtStrengths" runat="server" ReadOnly="true" TextMode="MultiLine" CssClass="form-control txtbox-strengths" Rows="4" Columns="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Describe the On-The-Job Trainee’s areas that needed improvement:</td>
            <td>
                <asp:TextBox ID="txtImprovement" runat="server" ReadOnly="true" TextMode="MultiLine" CssClass="form-control txtbox-improvement" Rows="4" Columns="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>OJT Supervisor's Printed Name:</td>
            <td>
                <asp:Label ID="disp_SupervisorName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Position:</td>
            <td>
                <asp:Label ID="disp_position" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>OJT Supervisor's Signature:</td>
            <td>
                <asp:Label ID="disp_suprSignature" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Date:</td>
            <td>
                <asp:Label ID="disp_date" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Cooperating Agency:</td>
            <td>
                <asp:Label ID="disp_industryName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Address:</td>
            <td>
                <asp:Label ID="disp_Indlocation" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Date Evaluated:</td>
            <td>
                <asp:Label ID="disp_dateEval" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
 </div>
 
<div class="button1">
    <div class="row">
        <div class="col-2 d-flex flex-column">
            <asp:Button ID="btnDownLoad" runat="server" Text="Download" OnClick="btnDownLoad_Click" class="btn btn-primary btn-md" />
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div class="col-2 d-flex flex-column">
            
            <asp:Button ID="btnBack" runat="server" Text="Go Back" OnClientClick="goBack(); return false;" class="btn btn-primary btn-md btn-close" />
        </div>
    </div>
</div>
 </form> 
</body>
    <script>
        var productivityValue = <%=Session["Productivity"] %>;
        var cooperationValue = <%=Session["Cooperation"] %>;
        var AbilityToFollowValue = <%=Session["AbilityToFollow"] %>;
        var abilityToGetValue = <%=Session["AbilityToGet"] %>;
        var category5Value = <%=Session["Category5"] %>;
        var category6Value = <%=Session["Category6"] %>;
        var category7Value = <%=Session["Category7"] %>;
        var category8Value = <%=Session["Category8"] %>;
        var category9Value = <%=Session["Category9"] %>;
        var category10Value = <%=Session["Category10"] %>;
        // Repeat for other categories

        // Assuming you have unique names for your radio button groups
        setRadioButtonCheckedStatus('productivity', productivityValue);
        setRadioButtonCheckedStatus('cooperation', cooperationValue);
        setRadioButtonCheckedStatus('abilityToFollow', AbilityToFollowValue);
        setRadioButtonCheckedStatus('abilityToGet', abilityToGetValue);
        setRadioButtonCheckedStatus('category5', category5Value);
        setRadioButtonCheckedStatus('category6', category6Value);
        setRadioButtonCheckedStatus('category7', category7Value);
        setRadioButtonCheckedStatus('category8', category8Value);
        setRadioButtonCheckedStatus('category9', category9Value);
        setRadioButtonCheckedStatus('category10', category10Value);
        // Repeat for other categories

        function setRadioButtonCheckedStatus(groupName, value) {
            var radioButtons = document.getElementsByName(groupName);
            for (var i = 0; i < radioButtons.length; i++) {
                radioButtons[i].checked = (parseInt(radioButtons[i].value) === value);
                if (!radioButtons[i].checked) {
                    radioButtons[i].disabled = true;
                }
            }
        }
    </script>
    
</html>
