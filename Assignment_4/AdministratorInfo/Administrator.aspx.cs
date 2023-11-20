using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            string databaseFileName = "KarateSchool(1)(1).mdf";
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFilePath = Path.Combine(directoryPath, "App_Data", databaseFileName);

            string conn = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databaseFilePath};Integrated Security=True;Connect Timeout=30";

            dbcon = new KarateSchoolDataContext(conn);

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member" ||
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


            //grid view 1 (members) population
            var mresult = from Member in dbcon.Members
                          select new { Id = Member.Member_UserID, First = Member.MemberFirstName, Last = Member.MemberLastName, Phone = Member.MemberPhoneNumber, Date = Member.MemberDateJoined };

            String[] dkNames = { "Id", "First", "Last", "Phone", "Date" };

            GridView1.DataKeyNames = dkNames;
            GridView1.DataSource = mresult;
            GridView1.DataBind();


            //grid view 2 (instructors population
            var iresult = from Instructor in dbcon.Instructors
                          select new { Id = Instructor.InstructorID, First = Instructor.InstructorFirstName, Last = Instructor.InstructorLastName };

            String[] idkNames = { "Id", "First", "Last" };

            GridView2.DataKeyNames = idkNames;
            GridView2.DataSource = iresult;
            GridView2.DataBind();


            //instructors dropdown in section assignment

            var ddResult = from instructor in dbcon.Instructors
                           select new { Name = instructor.InstructorFirstName + " " + instructor.InstructorLastName, ID = instructor.InstructorID };
            instructorDropdown.DataSource = ddResult;
            instructorDropdown.DataTextField = "Name";
            instructorDropdown.DataValueField = "ID";

            instructorDropdown.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Object o = (GridView1?.SelectedValue ?? 0);
            int memberID = int.Parse(o.ToString());
            Member member = (from Membership in dbcon.Members
                             where Membership.Member_UserID == memberID
                             select Membership).ToArray()[0];

            NetUser user = (from NetUser in dbcon.NetUsers
                            where NetUser.UserID == memberID
                            select NetUser).ToArray()[0];

            if (memberID == 0)
            {
                return;
            };

            memberFirstTxt.Text = member.MemberFirstName.ToString();
            memberLastTxt.Text = member.MemberLastName.ToString();
            memberPhoneTxt.Text = member.MemberPhoneNumber.ToString();
            memberEmailTxt.Text = member.MemberEmail.ToString();
            memberUsernameTxt.Text = user.UserName.ToString();
            memberPasswordTxt.Text = user.UserPassword.ToString();

        }

        protected void memberDeleteBtn_Click(object sender, EventArgs e)
        {
            Object o = (GridView1?.SelectedValue ?? 0);
            int memberID = int.Parse(o.ToString());
            NetUser user = (from NetUser in dbcon.NetUsers
                            where NetUser.UserID == memberID
                            select NetUser).ToArray()[0];



            if (user != null)
            {

                var relatedRecordsMember = dbcon.Members.Where(t => t.Member_UserID == user.UserID).ToList();
                dbcon.Members.DeleteAllOnSubmit(relatedRecordsMember);

                var relatedRecordsSection = dbcon.Sections.Where(t => t.Member_ID == user.UserID).ToList();
                dbcon.Sections.DeleteAllOnSubmit(relatedRecordsSection);

                dbcon.NetUsers.DeleteOnSubmit(user);

                dbcon.SubmitChanges();
            }





            //grid view 1 (members) population
            var mresult = from Member in dbcon.Members
                          select new { Id = Member.Member_UserID, First = Member.MemberFirstName, Last = Member.MemberLastName, Phone = Member.MemberPhoneNumber, Date = Member.MemberDateJoined };

            String[] dkNames = { "Id", "First", "Last", "Phone", "Date" };

            GridView1.DataKeyNames = dkNames;
            GridView1.DataSource = mresult;
            GridView1.DataBind();
        }

        protected void memberSubmitBtn_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {

                NetUser user = new NetUser();
                user.UserName = memberUsernameTxt.Text;
                user.UserPassword = memberPasswordTxt.Text;
                user.UserType = "Member";



                dbcon.NetUsers.InsertOnSubmit(user);

                try
                {
                    dbcon.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return;
                }

                user = (from cuser in dbcon.NetUsers
                        where cuser.UserName == memberUsernameTxt.Text
                        select cuser).ToArray()[0];

                Member newMember = new Member();
                newMember.Member_UserID = user.UserID;
                newMember.MemberFirstName = memberFirstTxt.Text;
                newMember.MemberLastName = memberLastTxt.Text;
                newMember.MemberPhoneNumber = memberPhoneTxt.Text;
                newMember.MemberEmail = memberEmailTxt.Text;
                newMember.MemberDateJoined = DateTime.Now;

                dbcon.Members.InsertOnSubmit(newMember);
                dbcon.SubmitChanges();
            }
            else
            {

                Object o = (GridView1?.SelectedValue ?? 0);
                int memberID = int.Parse(o.ToString());
                Member member = (from Membership in dbcon.Members
                                 where Membership.Member_UserID == memberID
                                 select Membership).ToArray()[0];

                NetUser user = (from NetUser in dbcon.NetUsers
                                where NetUser.UserID == memberID
                                select NetUser).ToArray()[0];

                if (memberID == 0)
                {
                    return;
                }

                if (member != null)
                {
                    member.MemberFirstName = memberFirstTxt.Text;
                    member.MemberLastName = memberLastTxt.Text;
                    member.MemberPhoneNumber = memberPhoneTxt.Text;
                    member.MemberEmail = memberEmailTxt.Text;
                }


                if (user != null)
                {
                    user.UserName = memberUsernameTxt.Text;
                    user.UserPassword = memberUsernameTxt.Text;
                }

                dbcon.SubmitChanges();
            }


            //grid view 1 (members) population
            var mresult = from Member in dbcon.Members
                          select new { Id = Member.Member_UserID, First = Member.MemberFirstName, Last = Member.MemberLastName, Phone = Member.MemberPhoneNumber, Date = Member.MemberDateJoined };

            String[] dkNames = { "Id", "First", "Last", "Phone", "Date" };

            GridView1.DataKeyNames = dkNames;
            GridView1.DataSource = mresult;
            GridView1.DataBind();
        }

        protected void addToSect_Click(object sender, EventArgs e)
        {
            try
            {
                Section section = new Section();
                section.SectionName = DropDownList1.SelectedValue;
                section.SectionStartDate = Calendar1.SelectedDate;
                section.Member_ID = int.Parse((GridView1?.SelectedValue ?? 0).ToString());
                section.Instructor_ID = int.Parse((instructorDropdown?.SelectedValue ?? "").ToString());
                section.SectionFee = Decimal.Parse(feeTxt.Text);

                dbcon.Sections.InsertOnSubmit(section);
                dbcon.SubmitChanges();
            }
            catch (System.FormatException ex)
            {
                feeTxt.BackColor = System.Drawing.Color.LightPink;
            }
            catch (System.Data.SqlTypes.SqlTypeException ex)
            {
                Calendar1.BackColor = System.Drawing.Color.LightPink;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                errorLbl.Text = "Select Member";
            }

            feeTxt.BackColor = System.Drawing.Color.White;
            Calendar1.BackColor = System.Drawing.Color.White;
            errorLbl.Text = "";
        }

        protected void InstructorsDeleteBtn_Click(object sender, EventArgs e)
        {
            Object o = (GridView2?.SelectedValue ?? 0);
            int instructorID = int.Parse(o.ToString());
            NetUser user = (from NetUser in dbcon.NetUsers
                            where NetUser.UserID == instructorID
                            select NetUser).ToArray()[0];




            if (user != null)
            {

                var relatedRecordsInstructor = dbcon.Instructors.Where(t => t.InstructorID == user.UserID).ToList();
                dbcon.Instructors.DeleteAllOnSubmit(relatedRecordsInstructor);

                var relatedRecordsSection = dbcon.Sections.Where(t => t.Instructor_ID == user.UserID).ToList();
                dbcon.Sections.DeleteAllOnSubmit(relatedRecordsSection);

                dbcon.NetUsers.DeleteOnSubmit(user);

                dbcon.SubmitChanges();
            }

            //grid view 2 (instructors population
            var iresult = from Instructor in dbcon.Instructors
                          select new { Id = Instructor.InstructorID, First = Instructor.InstructorFirstName, Last = Instructor.InstructorLastName };

            String[] idkNames = { "Id", "First", "Last" };

            GridView2.DataKeyNames = idkNames;
            GridView2.DataSource = iresult;
            GridView2.DataBind();


            //instructors dropdown in section assignment

            var ddResult = from instructor in dbcon.Instructors
                           select new { Name = instructor.InstructorFirstName + " " + instructor.InstructorLastName, ID = instructor.InstructorID };
            instructorDropdown.DataSource = ddResult;
            instructorDropdown.DataTextField = "Name";
            instructorDropdown.DataValueField = "ID";

            instructorDropdown.DataBind();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object o = (GridView2?.SelectedValue ?? 0);
            int instructorID = int.Parse(o.ToString());
            Instructor instructor = (from i in dbcon.Instructors
                                     where i.InstructorID == instructorID
                                     select i).ToArray()[0];

            NetUser user = (from NetUser in dbcon.NetUsers
                            where NetUser.UserID == instructorID
                            select NetUser).ToArray()[0];

            if (instructorID == 0)
            {
                return;
            };

            instructorFirstTxt0.Text = instructor.InstructorFirstName;
            instructorLastTxt0.Text = instructor.InstructorLastName;
            instructorPhoneTxt0.Text = instructor.InstructorPhoneNumber;
            instructorUsernameTxt0.Text = user.UserName;
            instructorPasswordTxt0.Text = user.UserPassword;

        }

        protected void instructorSubmitBtn_Click(object sender, EventArgs e)
        {

            if (CheckBox2.Checked)
            {

                NetUser user = new NetUser();
                user.UserName = instructorUsernameTxt0.Text;
                user.UserPassword = instructorPasswordTxt0.Text;
                user.UserType = "Instructor";



                dbcon.NetUsers.InsertOnSubmit(user);

                try
                {
                    dbcon.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return;
                }

                user = (from cuser in dbcon.NetUsers
                        where cuser.UserName == instructorUsernameTxt0.Text
                        select cuser).ToArray()[0];

                Instructor instructor = new Instructor();
                instructor.InstructorID = user.UserID;
                instructor.InstructorFirstName = instructorFirstTxt0.Text;
                instructor.InstructorLastName = instructorLastTxt0.Text;
                instructor.InstructorPhoneNumber = instructorPhoneTxt0.Text;


                dbcon.Instructors.InsertOnSubmit(instructor);
                dbcon.SubmitChanges();
            }
            else
            {

                Object o = (GridView2?.SelectedValue ?? 0);
                int instructorID = int.Parse(o.ToString());
                Instructor instructor = (from i in dbcon.Instructors
                                         where i.InstructorID == instructorID
                                         select i).ToArray()[0];

                NetUser user = (from NetUser in dbcon.NetUsers
                                where NetUser.UserID == instructorID
                                select NetUser).ToArray()[0];

                if (instructorID == 0)
                {
                    return;
                }

                if (instructor != null)
                {
                    instructor.InstructorFirstName = instructorFirstTxt0.Text;
                    instructor.InstructorLastName = instructorLastTxt0.Text;
                    instructor.InstructorPhoneNumber = instructorPhoneTxt0.Text;
                }


                if (user != null)
                {
                    user.UserName = instructorUsernameTxt0.Text;
                    user.UserPassword = instructorPasswordTxt0.Text;
                }

                dbcon.SubmitChanges();
            }


            //grid view 2 (instructors population
            var iresult = from Instructor in dbcon.Instructors
                          select new { Id = Instructor.InstructorID, First = Instructor.InstructorFirstName, Last = Instructor.InstructorLastName };

            String[] idkNames = { "Id", "First", "Last" };

            GridView2.DataKeyNames = idkNames;
            GridView2.DataSource = iresult;
            GridView2.DataBind();


            //instructors dropdown in section assignment

            var ddResult = from instructor in dbcon.Instructors
                           select new { Name = instructor.InstructorFirstName + " " + instructor.InstructorLastName, ID = instructor.InstructorID };
            instructorDropdown.DataSource = ddResult;
            instructorDropdown.DataTextField = "Name";
            instructorDropdown.DataValueField = "ID";

            instructorDropdown.DataBind();
        }
    }
}