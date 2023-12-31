<%@ Page Title="" Language="C#" MasterPageFile="~/Industry.Master" AutoEventWireup="true" CodeBehind="EvaluationForm.aspx.cs" Inherits="ctuconnect.EvaluationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <style>
      .evaluation-form {
    width: 80%;
    margin: 0 auto;
    font-family: Arial, sans-serif;
}

.student-info, .instruction {
    margin-top: 20px;
    font-weight: bold;
}

.rating-table {
    border-collapse: collapse;
    width: 100%;
    margin-top: 20px;
    background-color: #ffffff;
}

.rating-table th, .rating-table td {
    border: 1px solid #000;
    padding: 10px;
    text-align: center;
}

.rating-table th {
    background-color: #F7941F;
    font-weight: bold;
}

.rating-table tr:nth-child(odd) {
    background-color: #ffffff;
}


    </style>
    <style>
        table {
        width: 100%;
        margin: 20px auto;
        border-bottom: 3px solid #881A30;
        border:hidden;
        background-color: #ffffff;
    }

    table, th, td {
        border: 1px solid #ccc;
    }

    th, td {
        padding: 10px;
        text-align: left;
    }

    th {
        background-color: #f2f2f2;
    }

    .form-input {
        width: 100%;
    }

    .submit-button {
        margin: 20px auto;
        display: block;
        background-color: #007BFF;
        color: #fff;
        padding: 10px 20px;
        border: none;
        cursor: pointer;
    }

    .txtbox-strengths {
        min-width: 100%;

    }
    .txtbox-improvement {
        min-width: 100%;

    }
    </style>

<div class="evaluation-form" runat="server">
    <h1>OJT PERFORMANCE EVALUATION FORM</h1>
    <p>for&nbsp <asp:Label ID="forCourse" runat="server" ></asp:Label></p>
    
    
        <table id="table1" runat="server" >
            <tr class="student-info">
                <td>Student:</td>
                <td><asp:Label ID="firstName" runat="server" ></asp:Label>&nbsp<asp:Label ID="lastName" runat="server" ></asp:Label></td>
                
                
            </tr>
            <tr>
                <td>Course:</td>
                <td><asp:Label ID="course" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td>Training Period:</td>
                <td><asp:Label ID="disp_trainingPeriod" runat="server" ></asp:Label></td>
            </tr>
            <tr class="instruction">
                <td>Instruction:</td>
                <td><p>This report is to completed by the immediate supervisor of the OJT and to be returned
            to the OJT coordinator. In the space at the left, encircle the rating that describe the OJT most accurately.
            Total the value for all responses and record in the Total Scores section.</p></td>
            </tr>
            


        </table>
    

    

    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0"  onactiveviewchanged="MultiView1_ActiveViewChanged" >
               <asp:View ID="View1" runat="server">
                   <table class="rating-table">
        <tr>
            <th colspan="3">Productivity</th>
            <th colspan="3">Cooperation</th>
            
        </tr>
        <tr>
            <td><input type="radio" name="productivity" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1 </td> 
            <td><input type="radio" name="productivity" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_Prod1" runat="server"></asp:Label></td>
            <td><input type="radio" name="cooperation" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="cooperation" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_Coop1" runat="server"></asp:Label></td>
            
        </tr>
        <tr>
            <td><input type="radio" name="productivity" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="productivity" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Prod2" runat="server"></asp:Label></td>
            <td><input type="radio" name="cooperation" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="cooperation" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Coop2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="productivity" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="productivity" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Prod3" runat="server"></asp:Label></td>
            <td><input type="radio" name="cooperation" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="cooperation" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Coop3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="productivity" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="productivity" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Prod4" runat="server"></asp:Label></td>
            <td><input type="radio" name="cooperation" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="cooperation" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Coop4" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="productivity" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="productivity" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Prod5" runat="server"></asp:Label></td>
            <td><input type="radio" name="cooperation" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="cooperation" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Coop5" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th colspan="3">Ability to Follow Instructions</th>
            <th colspan="3">Ability to Get Along with People</th>
            
        </tr>
        <tr>
            <td><input type="radio" name="abilityToFollow" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="abilityToFollow" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_AbilityF1" runat="server"></asp:Label></td>
            <td><input type="radio" name="abilityToGet" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="abilityToGet" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_AbilityG1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="abilityToFollow" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="abilityToFollow" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_AbilityF2" runat="server"></asp:Label></td>
            <td><input type="radio" name="abilityToGet" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="abilityToGet" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_AbilityG2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="abilityToFollow" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="abilityToFollow" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_AbilityF3" runat="server"></asp:Label></td>
            <td><input type="radio" name="abilityToGet" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="abilityToGet" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_AbilityG3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="abilityToFollow" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="abilityToFollow" value="8" onchange="calculateScore();"  AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged"/>&nbsp 8</td>
            <td><asp:Label ID="disp_AbilityF4" runat="server"></asp:Label></td>
            <td><input type="radio" name="abilityToGet" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="abilityToGet" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_AbilityG4" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="abilityToFollow" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="abilityToFollow" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_AbilityF5" runat="server"></asp:Label></td>
            <td><input type="radio" name="abilityToGet" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="abilityToGet" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_AbilityG5" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th colspan="3">Initiative</th>
            <th colspan="3">Attendance</th>
            
        </tr>
        <tr>
            <td><input type="radio" name="category5" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="category5" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged"/>&nbsp 2</td>
            <td><asp:Label ID="disp_Init1" runat="server"></asp:Label></td>
            <td><input type="radio" name="category6" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged"/>&nbsp 1</td>
            <td><input type="radio" name="category6" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_Attend1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category5" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="category5" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Init2" runat="server"></asp:Label></td>
            <td><input type="radio" name="category6" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="category6" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Attend2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category5" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="category5" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Init3" runat="server"></asp:Label></td>
            <td><input type="radio" name="category6" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="category6" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Attend3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category5" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="category5" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Init4" runat="server"></asp:Label></td>
            <td><input type="radio" name="category6" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="category6" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Attend4" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category5" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="category5" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Init5" runat="server"></asp:Label></td>
            <td><input type="radio" name="category6" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="category6" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Attend5" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th colspan="3">Quality of Work</th>
            <th colspan="3">Appearance</th>
            
        </tr>
        <tr>
            <td><input type="radio" name="category7" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="category7" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_Qual1" runat="server"></asp:Label></td>
            <td><input type="radio" name="category8" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="category8" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_Appear1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category7" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="category7" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Qual2" runat="server"></asp:Label></td>
            <td><input type="radio" name="category8" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3 </td>
            <td><input type="radio" name="category8" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Appear2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category7" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="category7" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Qual3" runat="server"></asp:Label></td>
            <td><input type="radio" name="category8" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="category8" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Appear3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category7" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="category7" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Qual4" runat="server"></asp:Label></td>
            <td><input type="radio" name="category8" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="category8" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Appear4" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category7" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="category7" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Qual5" runat="server"></asp:Label></td>
            <td><input type="radio" name="category8" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="category8" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Appear5" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <th colspan="3">Dependability</th>
            <th colspan="3">Overall Performance</th>
            
        </tr>
        <tr>
            <td><input type="radio" name="category9" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="category9" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_Depend1" runat="server"></asp:Label></td>
            <td><input type="radio" name="category10" value="1" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 1</td>
            <td><input type="radio" name="category10" value="2" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 2</td>
            <td><asp:Label ID="disp_Overall1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category9" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="category9" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Depend2" runat="server"></asp:Label></td>
            <td><input type="radio" name="category10" value="3" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 3</td>
            <td><input type="radio" name="category10" value="4" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 4</td>
            <td><asp:Label ID="disp_Overall2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category9" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="category9" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Depend3" runat="server"></asp:Label></td>
            <td><input type="radio" name="category10" value="5" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 5</td>
            <td><input type="radio" name="category10" value="6" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 6</td>
            <td><asp:Label ID="disp_Overall3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category9" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="category9" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Depend4" runat="server"></asp:Label></td>
            <td><input type="radio" name="category10" value="7" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 7</td>
            <td><input type="radio" name="category10" value="8" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 8</td>
            <td><asp:Label ID="disp_Overall4" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><input type="radio" name="category9" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="category9" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Depend5" runat="server"></asp:Label></td>
            <td><input type="radio" name="category10" value="9" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 9</td>
            <td><input type="radio" name="category10" value="10" onchange="calculateScore();" AutoPostBack="true" onCheckedChanged="RadioButton_CheckedChanged" />&nbsp 10</td>
            <td><asp:Label ID="disp_Overall5" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">Total Score:</td>
            <td><span id="disp_score" >0</span></td>
            <td colspan="2">Grade Equivalent:</td>
            <td><span id="disp_grade" >0</span></td>
            
            
        </tr>
    </table>
                  <asp:Button CommandName="NextView" ID="btnnext1" runat="server" Text = "Go To Next" UseSubmitBehavior="true" OnClick="btnnext1_Click"/>
                   
               </asp:View> 
					
               <asp:View ID="View2" runat="server">
                  <table class="styled-table">
            <tr>
                <td >Describe the On-The-Job Trainee’s area of strengths:</td>
                <td>
                    <asp:TextBox ID="txtStrengths" runat="server" TextMode="MultiLine" CssClass="form-control txtbox-strengths" Rows="4" Columns="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Describe the On-The-Job Trainee’s areas that needed improvement:</td>
                <td>
                    <asp:TextBox ID="txtImprovement" runat="server" TextMode="MultiLine" CssClass="form-control txtbox-improvement" Rows="4" Columns="50"></asp:TextBox>
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
                  <asp:Button CommandName="PrevView" ID="btnprevious2" runat="server" Text = "Go To Previous View" />
                 

              
               </asp:View> 
            
               
            </asp:MultiView>
       <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnCommand="btnsubmit_Command"  CssClass="btn-primary" Visible="false"/> 
                  <input type="hidden" runat="server" id="hidden_score" name="HiddenScore" value="" />
                  <input type="hidden" runat="server" id="hidden_grade" name="HiddenGrade" value="" />    
         
</div>
<script type="text/javascript">
    function calculateScore() {
        let scoreElement = document.getElementById("disp_score");
        let gradeElement = document.getElementById("disp_grade");

        let hiddenScoreElement = document.getElementById('<%= hidden_score.ClientID %>');
        let hiddenGradeElement = document.getElementById('<%= hidden_grade.ClientID %>');


        let totalScore = 0;
        if (!hiddenScoreElement || !hiddenGradeElement) {
            console.error("One or both of the hidden fields are not found.");
            return false;
        }



        // Loop through all radio button inputs and sum their values
        const radioButtons = document.querySelectorAll('input[type="radio"]');
        radioButtons.forEach((element) => {
            if (element.checked) {
                totalScore += parseInt(element.value);
            }
        });

        // Display the total score
        scoreElement.textContent = totalScore;

        // Calculate the equivalent grade based on the total score
        let equivalentGrade = "";
        if (totalScore >= 98) {
            equivalentGrade = "95";
        } else if (totalScore >= 95) {
            equivalentGrade = "94";
        } else if (totalScore >= 92) {
            equivalentGrade = "93";
        } else if (totalScore >= 89) {
            equivalentGrade = "92";
        } else if (totalScore >= 85) {
            equivalentGrade = "91";
        } else if (totalScore >= 81) {
            equivalentGrade = "90";
        } else if (totalScore >= 77) {
            equivalentGrade = "89";
        } else if (totalScore >= 73) {
            equivalentGrade = "88";
        } else if (totalScore >= 69) {
            equivalentGrade = "87";
        } else if (totalScore >= 65) {
            equivalentGrade = "86";
        } else if (totalScore >= 61) {
            equivalentGrade = "85";
        } else if (totalScore >= 57) {
            equivalentGrade = "84";
        } else if (totalScore >= 53) {
            equivalentGrade = "83";
        } else if (totalScore >= 49) {
            equivalentGrade = "82";
        } else if (totalScore >= 45) {
            equivalentGrade = "81";
        } else if (totalScore >= 41) {
            equivalentGrade = "80";
        } else if (totalScore >= 37) {
            equivalentGrade = "79";
        } else if (totalScore >= 33) {
            equivalentGrade = "78";
        } else if (totalScore >= 29) {
            equivalentGrade = "77";
        } else if (totalScore >= 25) {
            equivalentGrade = "76";
        } else if (totalScore >= 21) {
            equivalentGrade = "75";
        } else if (totalScore >= 17) {
            equivalentGrade = "74";
        } else if (totalScore >= 12) {
            equivalentGrade = "73";
        } else if (totalScore >= 8) {
            equivalentGrade = "72";
        } else if (totalScore >= 4) {
            equivalentGrade = "71";
        } else if (totalScore >= 0) {
            equivalentGrade = "70";
        }

        // Display the equivalent grade
        gradeElement.textContent = equivalentGrade;

        // Set the values in the hidden fields
        hiddenScoreElement.value = totalScore;
        hiddenGradeElement.value = equivalentGrade;

       


        return false; // Prevent the form from submitting
    }  
</script>
</asp:Content>
