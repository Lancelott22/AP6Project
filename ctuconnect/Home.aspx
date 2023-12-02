<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ctuconnect.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'>
    <style>
        
        .purpose{
            background: #FFFFFF;      
            
        }

        .feedback{
            background: #F0EBEB;
            padding-top:2em;
            padding-bottom:2em;
        }

        .find{
            font-family:Arial;
            font-size:40px;
        }

        .btn-md{
            border: 1px #F7941F;
            border-radius: 15px;
            background-color: #F7941F;
            position:center;
            width: 90px;
        }

        .icon-box1{
            width:285px;
            height: 45px;
            border: 1px solid grey;
            border-radius: 20px;
            padding: 5px;
            background: #F0EBEB;
            padding: 5px 5px;
            
        }

        .icon{
            text-align:center;
            color:#881A30;
            font-family:'Arial Rounded MT';
        }

        .icon-box{
            min-width:208px;
			position: relative;
			height: 250px;
			background: #F0EBEB;
			margin:30px 10px;
			padding: 20px 15px;
			display:flex;
			flex-direction: column;
            box-shadow: rgb(89, 0, 0) 8px 8px;
			transition:0.3s ease-in-out;
			margin-top: 5%;
            border-radius: 25px;
            text-align:center;
            font-size:18px;
        }

        

        .container-content{
			position: relative;			
			right:0;
			display: flex;
			justify-content: center;
			align-items: center;
			flex-wrap: wrap;
			padding: 0px;
            margin-top: 80px;
            padding:80px 30px 80px 30px;
            width:100%;

		}

        .col-lg-4{
            width:300px;
        }

        .txtsuggestion{
           background-color: #F0EBEB;
           border: 1px solid grey;
           border-radius: 5px;
           min-width:100%;
           min-height:200px;
           padding-top:2px;
           padding:20px;
           line-height: 60px;
        }

        .btnSend{
            border: 1px #F7941F;
            border-radius: 5px;
            background-color: #F7941F;
            border-radius: 25px;
            width: 120px;
            color:#F0EBEB;
        }
        .suggestion-container{
            max-height: 500px; 
            overflow-y: auto;
            background-color:white;
            margin-top:0%;
            margin-bottom:1%;
            margin-left:20%;
            margin-right:20%;
            padding:20px;
        }
        .suggestion-item{
            background-color:whitesmoke;
            padding:10px;
            margin-bottom:1%;
        }
        .suggestion-text{
            padding-top:5px;
            text-indent: 29px;
        }

    </style>
        <section id="hero" class="d-flex align-items-center">
        <div class="container">
          <br /><br />
          <div class="row">
            <div class="col-lg-6 pt-5 pt-lg-0 order-2 order-lg-1 d-flex flex-column justify-content-center">
              <p class="find"><b>Find your matching job and internship</b></p>
              <div class="d-flex">
                   <div class="icon-box1">
                        Start your career here!&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="JobPortal.aspx" class="btn btn-primary btn-md"><i class='bi bi-arrow-right'></i></a>
                    </div>
              </div>
              
            </div>
            <div class="col-lg-6 order-1 order-lg-2 hero-img">
              <img src="images/man.png" class="img-fluid animated" alt="" height="600" width="550">   
       
            </div>
          </div>
          
        </div>
        
      </section>

    <section class="purpose">
        <div class="container-content">
            <br /><br />
            <div class="row justify-content-center">
                <div class="col-lg-4 col-md-6">
                    <div class="icon-box">
                        <div class="icon"><b>STUDENTS</b></div><br />
                        <p class="description">Students can search for internship on the platform and apply to those that match their skills and interests.</p>
                    </div>
                </div>

                <div class="col-lg-4 col-md-10 mt-4 mt-md-0">
                    <div class="icon-box">
                        <div class="icon"><b>INDUSTRY</b></div><br />
                        <p class="description">Partnered company will posts their internship and job opportunities to attract and find students who are a good fit for their organization.</p>
                    </div>
                </div>
                
                <div class="col-lg-4 col-md-10 mt-4 mt-lg-0">
                    <div class="icon-box">
                        <div class="icon"><b>ALUMNI</b></div><br />
                        <p class="description">Alumni can access and find job opportunities that is relevant and well-suited to their interests.</p>
                    </div>
                </div>
            </div>

        </div>
    </section>
    <section class="suggestions" style="background-color:white;">
    <div class="suggestion-container ">
        
        <div class="suggestion-list">
            <%-- Display suggestions here --%>
            <asp:Repeater ID="rptSuggestions" runat="server">
                <ItemTemplate>
                    <div class="suggestion-item">
                        <div style="display: flex; gap:6px;">
                        <img src="images/defaultprofile.jpg" style="width:40px; height:auto; border-radius: 50%;"/>
                        <div>
                            <b>Anonymous:</b> <br />
                            <span style="font-size: 11px; color: #888;">Date Posted: <%# Eval("dateCreated") %></span>
                        </div>
                    </div>
                        <p class="suggestion-text"> <%# Eval("Suggestion") %></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</section>

    <section class="feedback">
        <div class="container px-4 px-lg-5 h-100">
                <div class="row gx-4 gx-lg-5 h-100">
                    <div class="col-lg-12 align-self-end">
                    <h1>Share us your Suggestions!</h1>   
                        <p style="text-indent: 60px;">We value your insights and ideas! Your suggestions are crucial to us as we strive to improve and enhance our services. Whether you have 
                            thoughts on how we can make things even better or ideas for new features, we want to hear from you. Help us shape the future by sharing 
                            your suggestions — because together, we can create an even more exceptional experience for you! 🚀</p>
                        <p style="float:right;">--Team Admin</p>
                    </div>       
                </div>
                <div class="row gx-4 gx-lg-5 h-100">
                    <div class="col-lg-12 align-self-end">
                        <asp:TextBox ID="txtsuggestion" runat="server" CssClass="txtsuggestion"></asp:TextBox>
                    </div>       
                </div>
                <br />
                <div class="row gx-4 gx-lg-5 h-100">
                    <div class="col-lg-12 align-self-end">
                        <p><asp:Button ID="btn" class="btnSend" runat="server" Text="Submit" OnClick="Submit_Suggestions"/></p>
                    </div>       
                </div>
            </div>
    </section>

    <%--SuccesPromptModal--%>
        <div class="modal fade" id="SuccessPrompt" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content rounded-0">
                    <div class="modal-body p-4 px-5">
                    <div class="main-content text-center">
                        <br />
                        <img src="images/check-mark.png" style="width:100px; height:auto;" /><br />
                        <asp:Label ID="Label11" runat="server" Text="Submitted !" Style="font-size:25px;" ></asp:Label><br />
                        <asp:Label ID="Label12" runat="server" Text="Your suggestion was succesfully submitted." Style="font-size:18px;" ></asp:Label>
                    </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" type="button" class="btn btn-secondary" Text="Close" OnCLick="Close_SuccessPrompt" />
                    </div>
                </div>
            </div>
</div>
</asp:Content>
