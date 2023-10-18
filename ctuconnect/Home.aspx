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

        .txtfeed{
           background-color: #F0EBEB;
           border: 1px solid grey;
           border-radius: 5px;
           min-width:100%;
           min-height:200px;

        }

        .btnSend{
            border: 1px #F7941F;
            border-radius: 5px;
            background-color: #F7941F;
            border-radius: 25px;
            width: 120px;
            color:#F0EBEB;
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

    <section class="feedback">
        <div class="container px-4 px-lg-5 h-100">
                <div class="row gx-4 gx-lg-5 h-100">
                    <div class="col-lg-12 align-self-end">
                    <h1>Share us your feedback!</h1>    
                    </div>       
                </div>
                <div class="row gx-4 gx-lg-5 h-100">
                    <div class="col-lg-12 align-self-end">
                        <asp:TextBox ID="txtfeedback" runat="server" CssClass="txtfeed"></asp:TextBox>
                    </div>       
                </div>
                <br />
                <div class="row gx-4 gx-lg-5 h-100">
                    <div class="col-lg-12 align-self-end">
                        <p><asp:Button ID="btn" class="btnSend" runat="server" Text="Send"/></p>
                    </div>       
                </div>
            </div>
    </section>
</asp:Content>
