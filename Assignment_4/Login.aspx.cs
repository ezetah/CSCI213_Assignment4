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
    public partial class Login : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ejzet\\source\\repos\\ezetah\\CSCI213_Assignment4\\Assignment_4\\App_Data\\KarateSchool(1)(1).mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {

            string databaseFileName = "KarateSchool(1)(1).mdf";
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFilePath = Path.Combine(directoryPath, "App_Data", databaseFileName);

            string conn = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databaseFilePath};Integrated Security=True;Connect Timeout=30";

            dbcon = new KarateSchoolDataContext(conn);
        }

        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            string nUserName = Login1.UserName;
            string nPassword = Login1.Password;

            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["uPass"] = nPassword;

            //search for user in database
            NetUser user = (from x in dbcon.NetUsers
                            where x.UserName ==
            HttpContext.Current.Session["nUserName"].ToString()
                            && x.UserPassword ==
            HttpContext.Current.Session["uPass"].ToString()
                            select x).First();

            if (user != null) 
            {
                //add to session
                HttpContext.Current.Session["userID"] = user.UserID;
                HttpContext.Current.Session["userType"] = user.UserType;
            }
            if (user != null &&
                HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/MemberInfo/Member.aspx");
            }
            else if (user != null &&
                HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/InstructorInfo/Instructor.aspx");
            }
            else if (user != null &&
                HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/AdministratorInfo/Administrator.aspx");
            }
            else
                Response.Redirect("Login.aspx", true);
        }
    }
}