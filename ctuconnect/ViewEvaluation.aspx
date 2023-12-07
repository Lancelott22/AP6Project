<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEvaluation.aspx.cs" Inherits="ctuconnect.ViewEvaluation" EnableViewState="true" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />

</head>
    
<body>
    <form id="form1" runat="server">
    <div id="evaluationForm" class="evaluation-form" runat="server">

    <table>
        <tr >
            <td colspan="6"><center><h1>OJT PERFORMANCE EVALUATION FORM</h1><br /><p>(for BSIT, BSICT, BSGD and BSMx)</p></center></td>
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
        <td>Falls to do an adequate job</td>
        <td><input type="radio" name="cooperation" value="1" />&nbsp 1</td>
        <td><input type="radio" name="cooperation" value="2" />&nbsp 2</td>
        <td>Uncooperative, antagonistic</td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="productivity" value="4"  />&nbsp 4</td>
        <td>Does just enough to get by</td>
        <td><input type="radio" name="cooperation" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="cooperation" value="4"  />&nbsp 4</td>
        <td>Cooperates reluctantly</td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="5" />&nbsp 5</td>
        <td><input type="radio" name="productivity" value="6"  />&nbsp 6</td>
        <td>Maintains constant level of performance</td>
        <td><input type="radio" name="cooperation" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="cooperation" value="6" />&nbsp 6</td>
        <td>Cooperates willingly when asked</td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="productivity" value="8" />&nbsp 8</td>
        <td>Very industrious, does more than required</td>
        <td><input type="radio" name="cooperation" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="cooperation" value="8"  />&nbsp 8</td>
        <td>Cooperates eagerly and cheerfully</td>
    </tr>
    <tr>
        <td><input type="radio" name="productivity" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="productivity" value="10"  />&nbsp 10</td>
        <td>Superior work production record</td>
        <td><input type="radio" name="cooperation" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="cooperation" value="10"  />&nbsp 10</td>
        <td>Always cooperates eagerly and cheerfully</td>
    </tr>
    <tr>
        <th colspan="3">Ability to Follow Instructions</th>
        <th colspan="3">Ability to Get Along with People</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="abilityToFollow" value="2"  />&nbsp 2</td>
        <td>Usable to follow instructions</td>
        <td><input type="radio" name="abilityToGet" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="abilityToGet" value="2"  />&nbsp 2</td>
        <td>Frequently rude and unfriendly</td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="3" />&nbsp 3</td>
        <td><input type="radio" name="abilityToFollow" value="4"  />&nbsp 4</td>
        <td>Needs repeated detailed instructions</td>
        <td><input type="radio" name="abilityToGet" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="abilityToGet" value="4"  />&nbsp 4</td>
        <td>Has some difficulty working with others</td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="5" />&nbsp 5</td>
        <td><input type="radio" name="abilityToFollow" value="6"  />&nbsp 6</td>
        <td>Follows most instructions without difficulty</td>
        <td><input type="radio" name="abilityToGet" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="abilityToGet" value="6" />&nbsp 6</td>
        <td>Usually gets along well with people</td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="7" />&nbsp 7</td>
        <td><input type="radio" name="abilityToFollow" value="8"  />&nbsp 8</td>
        <td>Follows instructions with no difficulty</td>
        <td><input type="radio" name="abilityToGet" value="7" />&nbsp 7</td>
        <td><input type="radio" name="abilityToGet" value="8" />&nbsp 8</td>
        <td>Is courteous and tactful with people</td>
    </tr>
    <tr>
        <td><input type="radio" name="abilityToFollow" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="abilityToFollow" value="10"  />&nbsp 10</td>
        <td>Uses initiative in interpreting and following instructions</td>
        <td><input type="radio" name="abilityToGet" value="9" />&nbsp 9</td>
        <td><input type="radio" name="abilityToGet" value="10"  />&nbsp 10</td>
        <td>Exceptionally well accepted by peers and supervisors</td>
    </tr>
    <tr>
        <th colspan="3">Initiative</th>
        <th colspan="3">Attendance</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category5" value="2" />&nbsp 2</td>
        <td>Always attempts to avoid work</td>
        <td><input type="radio" name="category6" value="1" />&nbsp 1</td>
        <td><input type="radio" name="category6" value="2"  />&nbsp 2</td>
        <td>Often absent without good excuse</td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category5" value="4" />&nbsp 4</td>
        <td>Sometimes attempts to avoid work</td>
        <td><input type="radio" name="category6" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category6" value="4"  />&nbsp 4</td>
        <td>Frequently late</td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="5" />&nbsp 5</td>
        <td><input type="radio" name="category5" value="6" />&nbsp 6</td>
        <td>Does assigned job willingly</td>
        <td><input type="radio" name="category6" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="category6" value="6"  />&nbsp 6</td>
        <td>Usually present and on time</td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category5" value="8"  />&nbsp 8</td>
        <td>Does more than assigned job willingly</td>
        <td><input type="radio" name="category6" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category6" value="8"  />&nbsp 8</td>
        <td>Very prompt and regular, volunteers for overtime when asked</td>
    </tr>
    <tr>
        <td><input type="radio" name="category5" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category5" value="10" />&nbsp 10</td>
        <td>Shows resourcefulness in going beyond assigned job</td>
        <td><input type="radio" name="category6" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category6" value="10" />&nbsp 10</td>
        <td>Always prompt and regular, volunteers for overtime when asked</td>
    </tr>
    <tr>
        <th colspan="3">Quality of Work</th>
        <th colspan="3">Appearance</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category7" value="2"  />&nbsp 2</td>
        <td>Does almost no acceptable work</td>
        <td><input type="radio" name="category8" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category8" value="2" />&nbsp 2</td>
        <td>Untidy or inappropriately groomed</td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="3" />&nbsp 3</td>
        <td><input type="radio" name="category7" value="4"/>&nbsp 4</td>
        <td>Does less than required amount of satisfactory work</td>
        <td><input type="radio" name="category8" value="3" />&nbsp 3 </td>
        <td><input type="radio" name="category8" value="4"  />&nbsp 4</td>
        <td>Sometimes neglected of appearance</td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="5" />&nbsp 5</td>
        <td><input type="radio" name="category7" value="6"/>&nbsp 6</td>
        <td>Does normal amount of acceptable work</td>
        <td><input type="radio" name="category8" value="5"/>&nbsp 5</td>
        <td><input type="radio" name="category8" value="6"/>&nbsp 6</td>
        <td>Satisfactory appearance</td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="7"/>&nbsp 7</td>
        <td><input type="radio" name="category7" value="8" />&nbsp 8</td>
        <td>Does more than required amount of neat, accurate work</td>
        <td><input type="radio" name="category8" value="7"/>&nbsp 7</td>
        <td><input type="radio" name="category8" value="8" />&nbsp 8</td>
        <td>Careful about personal appearance </td>
    </tr>
    <tr>
        <td><input type="radio" name="category7" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category7" value="10"  />&nbsp 10</td>
        <td>Shows special attitude for doing neat, accurate work beyond required amount</td>
        <td><input type="radio" name="category8" value="9"  />&nbsp 9</td>
        <td><input type="radio" name="category8" value="10" />&nbsp 10</td>
        <td>Exceptionally neat, and appropriately groomed</td>
    </tr>
    <tr>
        <th colspan="3">Dependability</th>
        <th colspan="3">Overall Performance</th>
        
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category9" value="2" />&nbsp 2</td>
        <td>Unreliable</td>
        <td><input type="radio" name="category10" value="1"  />&nbsp 1</td>
        <td><input type="radio" name="category10" value="2"  />&nbsp 2</td>
        <td>Unsatisfactory</td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category9" value="4" />&nbsp 4</td>
        <td>Sometimes fails in obligations</td>
        <td><input type="radio" name="category10" value="3"  />&nbsp 3</td>
        <td><input type="radio" name="category10" value="4" />&nbsp 4</td>
        <td>Below average</td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="5" />&nbsp 5</td>
        <td><input type="radio" name="category9" value="6"  />&nbsp 6</td>
        <td>Meets obligations under supervision</td>
        <td><input type="radio" name="category10" value="5"  />&nbsp 5</td>
        <td><input type="radio" name="category10" value="6"  />&nbsp 6</td>
        <td>Average</td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category9" value="8" />&nbsp 8</td>
        <td>Meets obligations under very little supervision</td>
        <td><input type="radio" name="category10" value="7"  />&nbsp 7</td>
        <td><input type="radio" name="category10" value="8" />&nbsp 8</td>
        <td>Very good</td>
    </tr>
    <tr>
        <td><input type="radio" name="category9" value="9" />&nbsp 9</td>
        <td><input type="radio" name="category9" value="10" />&nbsp 10</td>
        <td>Meets obligations without supervision</td>
        <td><input type="radio" name="category10" value="9" />&nbsp 9</td>
        <td><input type="radio" name="category10" value="10" />&nbsp 10</td>
        <td>Outstanding</td>
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
    </table>
 </div>
 
<div class="button1">
    <div class="row">
        <div class="col-2 d-flex flex-column">
            <asp:Button ID="btnDownLoad" runat="server" Text="Download" OnClick="btnDownLoad_Click" class="btn btn-primary btn-md" />
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div class="col-2 d-flex flex-column">
            <button onclick="history.back()" class="btn btn-primary btn-md btn-close">Go Back</button>
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
