using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctuconnect
{
    public partial class Student : System.Web.UI.MasterPage
    {
        string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;
        private DataTable dtRefer = new DataTable();
        private DataTable dtFeedback = new DataTable();
        bool isHired = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                studNavAttendance.DataBind();
                studentDetails();
                displayStudentPic();
                if (isHired == false)
                {
                    attendance.Visible = false;
                }else
                {
                    attendance.Visible = true;
                }
            }
            int totalCounts = UnreadReferCount() + UnreadFeedbackCount();
            lblUnreadCount.Text = totalCounts.ToString();

            this.LoadRefer();
            rptrefer.DataSource = dtRefer;
            rptrefer.DataBind();

            this.LoadFeedback();
            rptstudentfeedback.DataSource = dtFeedback;
            rptstudentfeedback.DataBind();

            refreshCounting();
            disableHeader();
            disableHeader1();

            if(!IsPostBack && Session["StudentEmail"] != null && Session["STATUSorTYPE"].ToString() == "Alumni")
            {
                alumniForm.Visible = true;
            }
        }

        private void displayStudentPic()
        {
            if (!string.IsNullOrEmpty(Session["PICTURE"].ToString()))
            {
                imageProfile.ImageUrl = "~/images/StudentProfiles/" + Session["PICTURE"].ToString();
                profileimg.Src = "~/images/StudentProfiles/" + Session["PICTURE"].ToString();
            }
            else
            {
                imageProfile.ImageUrl = "~/images/StudentProfiles/defaultprofile.jpg";
                profileimg.Src = "~/images/StudentProfiles/defaultprofile.jpg";
            }

        }

        private void studentDetails()
        {
            string studentAccID = Session["Student_ACC_ID"].ToString();
            using (var db = new SqlConnection(conDB))
            {

                string query = "SELECT * FROM STUDENT_ACCOUNT WHERE student_accID = '" + studentAccID + "' ";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    lblname.Text = reader["firstName"].ToString() + " " + reader["lastName"].ToString();
                    Session["PICTURE"] = reader["studentPicture"];
                    lblstudentID.Text = reader["studentID"].ToString();
                    isHired = bool.Parse(reader["isHired"].ToString());
                }
                reader.Close();
            }
        }

        void refreshCounting()
        {
            if (lblUnreadCount.Text == "0")
            {
                lblUnreadCount.Visible = false;
            }
            else
            {
                lblUnreadCount.Visible = true;
            }
        }

        void disableHeader()
        {

            if (rptrefer.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer = rptrefer.Controls[0].Controls[0].FindControl("headerTemplateContainer");

                if (headerTemplateContainer != null)
                {
                    headerTemplateContainer.Visible = false;
                }
            }

        }

        void disableHeader1()
        {

            if (rptstudentfeedback.Items.Count == 0)
            {
                // Find the headerTemplateContainer and set its Visible property to false
                Control headerTemplateContainer = rptstudentfeedback.Controls[0].Controls[0].FindControl("headerTemplateContainer1");

                if (headerTemplateContainer != null)
                {
                    headerTemplateContainer.Visible = false;
                }
            }

        }

        private void LoadRefer()
        {
            string studentAccID = Session["Student_ACC_ID"].ToString();


                using (var db = new SqlConnection(conDB))
                {
                    string query = "SELECT * FROM REFERRAL JOIN INDUSTRY_ACCOUNT ON REFERRAL.INDUSTRY_ACCID = INDUSTRY_ACCOUNT.INDUSTRY_ACCID WHERE isStudentRemove = 0 and student_accID = '" + studentAccID + "' ORDER BY dateReferred DESC";
                    SqlCommand cmd = new SqlCommand(query, db);

                    db.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtRefer);
                }


                rptrefer.DataSource = dtRefer;
                rptrefer.DataBind();
                disableHeader();
            

        }

        private void LoadFeedback()
        {
            string studentAccID = Session["Student_ACC_ID"].ToString();

            using (var db = new SqlConnection(conDB))
            {
                string query = "SELECT * FROM STUDENT_FEEDBACK JOIN INDUSTRY_ACCOUNT ON STUDENT_FEEDBACK.sendfrom = INDUSTRY_ACCOUNT.INDUSTRY_ACCID WHERE STUDENT_FEEDBACK.isRemove = 0 and sendto = '" + studentAccID + "' ORDER BY dateCreated DESC";
                SqlCommand cmd = new SqlCommand(query, db);

                db.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtFeedback);
            }


            rptstudentfeedback.DataSource = dtFeedback;
            rptstudentfeedback.DataBind();
            disableHeader1();


        }

        protected int UnreadReferCount()
        {
            string studentAccID = Session["Student_ACC_ID"].ToString();
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM REFERRAL WHERE isStudentRead = 0 and student_accID = '" + studentAccID + "'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        protected int UnreadFeedbackCount()
        {
            string studentAccID = Session["Student_ACC_ID"].ToString();
            int count = 0;

            // Replace with your connection string
            string conDB = WebConfigurationManager.ConnectionStrings["CTUConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conDB))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM STUDENT_FEEDBACK WHERE isRead = 0 and sendto = '" + studentAccID + "'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        protected void readRefer_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRead")
            {
                int referralID = Convert.ToInt32(e.CommandArgument);

                MarkReferAsRead(referralID);


            }
            // Refresh the notifications
            this.LoadRefer();
            this.UnreadReferCount();

        }


        private void MarkReferAsRead(int referralID)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REFERRAL SET isStudentRead = 1 WHERE referralID = @ReferralID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ReferralID", referralID);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadReferCount() + UnreadFeedbackCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
            RedirectToJobPortal(referralID);


        }

        private void RedirectToJobPortal(int referralID)
        {
            Response.Redirect("JobPortal.aspx?referralID=" + referralID);
        }

        private void ReferRead(int referralID)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REFERRAL SET isStudentRead = 1 WHERE referralID = @ReferralID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ReferralID", referralID);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadReferCount() + UnreadFeedbackCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader();
        }

        protected void removeRefer_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRemove")
            {
                int referralID = Convert.ToInt32(e.CommandArgument);

                MarkReferAsRemoved(referralID);
                ReferRead(referralID);


            }

            // Refresh the notifications
            this.LoadRefer();
            this.UnreadReferCount();
        }
        private void MarkReferAsRemoved(int referralID)
        {
            // Update the isRemove property in the database
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE REFERRAL SET isStudentRemove = 1 WHERE referralID = @ReferralID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ReferralID", referralID);
                db.Open();
                cmd.ExecuteNonQuery();

                int totalCounts = UnreadReferCount() + UnreadFeedbackCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //this.disableHeader();

            if (rptrefer.Items.Count == 1)
            {
                disableHeader();
            }
        }

        protected void readFeedback_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRead")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                MarkFeedbackAsRead(id);


            }
            // Refresh the notifications
            this.LoadFeedback();
            this.UnreadFeedbackCount();

        }

        private void MarkFeedbackAsRead(int id)
        {

            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE STUDENT_FEEDBACK SET isRead = 1 WHERE id = @ID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ID", id);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadReferCount() + UnreadFeedbackCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader1();
            RedirectToMyAccount(id);


        }

        private void RedirectToMyAccount(int id)
        {
            Response.Redirect("MyAccount.aspx?id=" + id);
        }

        private void FeedbackRead(int id)
        {
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE STUDENT_FEEDBACK SET isRead = 1 WHERE id = @ID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ID", id);
                db.Open();
                cmd.ExecuteNonQuery();



                // Update the unread count
                int totalCounts = UnreadReferCount() + UnreadFeedbackCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            this.disableHeader1();
        }

        protected void removeFeedback_ItemCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "MarkAsRemove")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                MarkFeedbackAsRemoved(id);
                FeedbackRead(id);


            }

            // Refresh the notifications
            this.LoadFeedback();
            this.UnreadFeedbackCount();
        }

        private void MarkFeedbackAsRemoved(int id)
        {
            // Update the isRemove property in the database
            using (var db = new SqlConnection(conDB))
            {

                string query = "UPDATE STUDENT_FEEDBACK SET isRemove = 1 WHERE id = @ID";
                SqlCommand cmd = new SqlCommand(query, db);
                cmd.Parameters.AddWithValue("@ID", id);
                db.Open();
                cmd.ExecuteNonQuery();

                int totalCounts = UnreadReferCount() + UnreadFeedbackCount();
                lblUnreadCount.Text = totalCounts.ToString();
            }
            refreshCounting();
            //this.disableHeader();

            if (rptstudentfeedback.Items.Count == 1)
            {
                disableHeader1();
            }
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {

            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("LoginStudent.aspx");

        }
    }
}