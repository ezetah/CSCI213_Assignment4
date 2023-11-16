using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class Contact : Page
    {
        KarateSchoolDataContext dbcon;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ejzet\\source\\repos\\ezetah\\CSCI213_Assignment4\\Assignment_4\\App_Data\\KarateSchool(1)(1).mdf;Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateSchoolDataContext(connString);

            if (!IsPostBack)
            {

                var result = from instructor in dbcon.Instructors
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