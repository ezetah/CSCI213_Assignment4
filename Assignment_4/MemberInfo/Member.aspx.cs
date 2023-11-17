using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class About : Page
    {
        KarateSchoolDataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator" ||
                    HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx", true);
                }

            }


            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ejzet\\source\\repos\\ezetah\\CSCI213_Assignment4\\Assignment_4\\App_Data\\KarateSchool(1)(1).mdf;Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateSchoolDataContext(connString);

            if (!IsPostBack)
            {
                if(HttpContext.Current.Session["userID"] != null)
                {
                    //get current member
                    int currentUser = (int)HttpContext.Current.Session["userID"];

                    var user = from member in dbcon.Members
                               where member.Member_UserID == currentUser
                               select new
                               {
                                   member.MemberLastName,
                                   member.MemberFirstName,
                               };

                    memberFirstNameLabel.Text = user.First().MemberFirstName;
                    memberLastNameLabel.Text = user.First().MemberLastName;


                    //display on grid
                    var result = from member in dbcon.Members
                                 where member.Member_UserID == currentUser
                                 orderby member.Member_UserID
                                 join sect in dbcon.Sections on member.Member_UserID equals sect.Member_ID
                                 join instructor in dbcon.Instructors on sect.Instructor_ID equals instructor.InstructorID
                                 select new
                                 {
                                     sect.SectionName,
                                     instructor.InstructorFirstName,
                                     instructor.InstructorLastName,
                                     member.MemberDateJoined,
                                     sect.SectionFee,
                                 };


                    memberGridView.DataSource = result.ToList();
                    memberGridView.DataBind();
                }
                


                

            }
        }

        protected void memberGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}