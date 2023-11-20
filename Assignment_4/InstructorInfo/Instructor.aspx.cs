using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class Contact : Page
    {
        KarateSchoolDataContext dbcon;


        protected void Page_Load(object sender, EventArgs e)
        {

            string databaseFileName = "KarateSchool(1)(1).mdf";
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFilePath = Path.Combine(directoryPath, "App_Data", databaseFileName);

            string conn = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databaseFilePath};Integrated Security=True;Connect Timeout=30";

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member" ||
                    HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Login.aspx", true);
                }

            }



            //string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ejzet\\source\\repos\\ezetah\\CSCI213_Assignment4\\Assignment_4\\App_Data\\KarateSchool(1)(1).mdf;Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateSchoolDataContext(conn);

            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["userID"] != null)
                {
                    //get current member
                    int currentUser = (int)HttpContext.Current.Session["userID"];

                    var user = from instructor in dbcon.Instructors
                               where instructor.InstructorID == currentUser
                               select new
                               {
                                   instructor.InstructorFirstName,
                                   instructor.InstructorLastName,
                               };

                    instructorFirstNameLabel.Text = user.First().InstructorFirstName;
                    instructorLastNameLabel.Text = user.First().InstructorLastName;



                    var result = from instructor in dbcon.Instructors
                                 where instructor.InstructorID == currentUser
                                 orderby instructor.InstructorID
                                 join sect in dbcon.Sections on instructor.InstructorID equals sect.Instructor_ID
                                 join member in dbcon.Members on sect.Member_ID equals member.Member_UserID
                                 select new
                                 {
                                     sect.SectionName,
                                     member.MemberFirstName,
                                     member.MemberLastName,

                                 };


                    instructorGridView.DataSource = result.ToList();
                    instructorGridView.DataBind();


                }
            }
        }
    }
}