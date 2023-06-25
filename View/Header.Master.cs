using projectlab.Handler;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectlab
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {//guest mode

                Cart.Visible = false;
                //Transaction.Visible = false;
                UpdateProfile.Visible = false;
                Logout.Visible = false;

                Home.Visible = true;
                Register.Visible = true;
                Login.Visible = true;

            } else if (Session["user"].Equals("Cust"))
            {

                Register.Visible = false;
                Login.Visible = false;

                Home.Visible = true;
                Cart.Visible = true;
                //Transaction.Visible = true;
                UpdateProfile.Visible = true;
                Logout.Visible = true;

            } else if (Session["user"].Equals("Admin"))
            {
                Register.Visible = false;
                Login.Visible = false;
                Cart.Visible = false;

                Home.Visible = true;
                //Transaction.Visible = true;
                UpdateProfile.Visible = true;
                Logout.Visible = true;
            }


        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                Session.Remove("user");
                Session.Remove("userid");
            }
            Response.Redirect("Login.aspx?redirected=true");
        }

        protected void Register_Click(object sender, EventArgs e)
        {

            Response.Redirect("Register.aspx");
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?redirected=true");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx?redirected=true");
        }

        protected void Cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void Transaction_Click(object sender, EventArgs e)
        {
            if (Session["user"].Equals("Cust"))
            {
                int id = Convert.ToInt32(Session["userid"].ToString());

                Response.Redirect("Transaction.aspx");
            }
            else if(Session["user"].Equals("Admin"))
            {
                Response.Redirect("TransactionReport.aspx");
            }


        }

        protected void UpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }
    }
}