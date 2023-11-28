using System;
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
using Antlr.Runtime.Tree;
using System.Collections;

namespace ctuconnect
{
    public partial class Coordinator_Contact : System.Web.UI.Page
    {
        SqlConnection conDB = new SqlConnection(WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Username"] == null)
            {
                Response.Redirect("LoginOJTCoordinator.aspx");
            }
            if(!IsPostBack)
            {
                getDepartmentId();
            }
        }

        protected void SendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (SendToEmail.Value == "" || string.IsNullOrEmpty(Subject.Value) || string.IsNullOrEmpty(message.Text))
                {
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
                    string sendFrom = Session["Username"].ToString();
                    string Name = Session["COORD_FNAME"].ToString() + " " + Session["COORD_LNAME"].ToString() + " (Coordinator)";
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

                    Response.Write("<script>alert('Message has been sent successfully!');document.location='Coordinator_Contact.aspx'</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('Something went wrong! Please try again.');document.location='Coordinator_Contact.aspx'</script>");
            }
        }
        protected void SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginOJTCoordinator.aspx");
        }

        protected void SendToUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedUser = SendToUser.SelectedValue;
            string CoordDepartmentId = Session["Coord_DeparmentID"].ToString();


            if (!string.IsNullOrEmpty(selectedUser))
            {
                if (selectedUser == "Admin")
                {
                    SendToEmail.Items.Clear();
                    SendToEmail.Items.Insert(0, new ListItem("Admin", "ctuconnect00@gmail.com"));
                }
                else if (selectedUser == "OJTCoordinator")
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
                else if (selectedUser == "Industry")
                {
                    SendToEmail.Items.Clear();                   
                    SqlCommand cmd = new SqlCommand("SELECT email, industryName FROM INDUSTRY_ACCOUNT", conDB);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    da.Fill(ds);
                    SendToEmail.DataSource = ds;
                    SendToEmail.DataValueField = "email";
                    SendToEmail.DataTextField = "industryName";
                    SendToEmail.DataBind();

                }
                else if (selectedUser == "Student")
                {
                    SendToEmail.Items.Clear();
                    SqlCommand cmd = new SqlCommand("SELECT email,  CONCAT(firstName,' ',lastName) as Name FROM STUDENT_ACCOUNT WHERE department_ID = '" + CoordDepartmentId + "'", conDB);
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
        void getDepartmentId()
        {
            int id = int.Parse(Session["Coor_ACC_ID"].ToString());
            conDB.Open();
            SqlCommand cmd = new SqlCommand("SELECT department_ID, firstName, lastName FROM COORDINATOR_ACCOUNT WHERE coordinator_accID = '" + id + "'", conDB);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Session["Coord_DeparmentID"] = reader["department_ID"];
                Session["COORD_FNAME"] = reader["firstName"];
                Session["COORD_LNAME"] = reader["lastName"];
            }
            conDB.Close();
            reader.Close();
        }
    }
}