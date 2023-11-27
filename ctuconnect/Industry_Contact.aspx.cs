﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;



namespace ctuconnect
{
    public partial class Industry_Contact : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["IndustryEmail"] == null)
            {
                Response.Redirect("LoginIndustry.aspx");

            }
            else
            {
                disp_industryName.Text = Session["INDUSTRYNAME"].ToString();
                disp_accID.Text = Session["INDUSTRY_ACC_ID"].ToString();

                string imagePath = "~/images/IndustryProfile/" + Session["INDUSTRYPIC"].ToString();
                industryImage1.ImageUrl = imagePath;
                
            }
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginIndustry.aspx");
        }

        protected void SendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (SendToEmail.Value == "" || string.IsNullOrEmpty(Subject.Value) || string.IsNullOrEmpty(message.Text)){
                    Response.Write("<script>alert('Please fill up all the input fields.');</script>");
                } 
                else
                {
                    List<string> selectedEmails = new List<string>();
                    foreach (ListItem item in SendToEmail.Items)
                    {                      
                        if (item.Selected)
                        {
                            selectedEmails.Add(item.Value);
                        }
                    }
                    string sendToEmail = string.Join(",", selectedEmails);
                    string sendFrom = Session["IndustryEmail"].ToString();
                    string Name = Session["INDUSTRYNAME"].ToString();
                    string sendMessage = HttpUtility.HtmlEncode(message.Text);
                    string subject = Subject.Value;
                    MailMessage mm = new MailMessage();
                    mm.From = new MailAddress(sendFrom, "Message from " + Name);
                    mm.To.Add(sendToEmail);
                    mm.Subject = subject;
                    mm.Body = HttpUtility.HtmlDecode(sendMessage);
                    mm.IsBodyHtml = true;
                    mm.ReplyToList.Add(new MailAddress(sendFrom));
                    mm.Bcc.Add(new MailAddress(sendFrom, "Message from you"));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential();
                    NetworkCred.UserName = "ctuconnect00@gmail.com";
                    NetworkCred.Password = "diwvlfhaanwwfsid";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);

                    Response.Write("<script>alert('Message has been sent successfully!');document.location='Industry_Contact.aspx'</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Industry_Contact.aspx'</script>");
            }
        }

        protected void SendToUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUser = SendToUser.SelectedValue;

            if(!string.IsNullOrEmpty(selectedUser))
            {
                if(selectedUser == "Admin")
                {
                    SendToEmail.Items.Clear();
                    SendToEmail.Items.Insert(0, new ListItem("Admin", "ctuconnect00@gmail.com"));                  
                }
                else if(selectedUser == "OJTCoordinator")
                {
                    SendToEmail.Items.Clear();
                    SqlCommand cmd = new SqlCommand("SELECT username, CONCAT(firstName,' ',lastName, ' (', departmentName, ')') as Name FROM COORDINATOR_ACCOUNT JOIN DEPARTMENT ON COORDINATOR_ACCOUNT.department_ID = DEPARTMENT.department_ID", conDB);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    SendToEmail.DataSource = ds;
                    SendToEmail.DataValueField = "username";
                    SendToEmail.DataTextField = "Name";
                    SendToEmail.DataBind();

                }
                else if(selectedUser == "HiredStudent")
                {
                    SendToEmail.Items.Clear();
                    int industryAccID = int.Parse(Session["INDUSTRY_ACC_ID"].ToString());
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT STUDENT_ACCOUNT.email, CONCAT(HIRED_LIST.firstName,' ' ,  HIRED_LIST.lastName) as Name FROM HIRED_LIST JOIN STUDENT_ACCOUNT ON HIRED_LIST.student_accID = STUDENT_ACCOUNT.student_accID WHERE industry_accID = '" + industryAccID + "'", conDB);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    SendToEmail.DataSource = ds;
                    SendToEmail.DataValueField = "email";
                    SendToEmail.DataTextField = "Name";
                    SendToEmail.DataBind();
                   
                }
            }
        }
    }
}