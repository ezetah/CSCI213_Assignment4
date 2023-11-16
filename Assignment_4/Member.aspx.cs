using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class About : Page
    {
        KarateSchoolDataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ejzet\\source\\repos\\ezetah\\CSCI213_Assignment4\\Assignment_4\\App_Data\\KarateSchool(1)(1).mdf;Integrated Security=True;Connect Timeout=30";
            dbcon = new KarateSchoolDataContext(connString);

            if (!IsPostBack)
            {

                var result = from member in dbcon.Members
                             orderby member.Member_UserID
                             join sect in dbcon.Sections on member.Member_UserID equals sect.Member_ID
                             select new
                             {
                                 member.MemberFirstName,
                                 member.MemberLastName,
                                 member.MemberDateJoined,
                                 sect.SectionFee,
                             };
               

                memberGridView.DataSource = result.ToList();
                memberGridView.DataBind();

            }
        }

        protected void memberGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}