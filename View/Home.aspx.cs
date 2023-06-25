using projectlab.Controller;
using projectlab.Handler;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectlab.View
{
    public partial class Home : System.Web.UI.Page
    {
        public String Role { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Role = "";
                if (Session["user"] == null)
                {
                    HttpCookie cookies = HttpContext.Current.Request.Cookies["Login"];

                    if (cookies != null)
                    {
                        String email = cookies.Values["Email"];
                        String password = cookies.Values["Password"];

                        Customer c = CustomerController.login(email, password);
                        if (c != null)
                        {
                            if (Request.QueryString["redirected"] != "true")
                            {
                                Session["user"] = c.CustomerRole;
                            }

                        }
                    }

                    
                }
                lvArtists.DataSource = ArtistController.getAll();
                lvArtists.DataBind();
            }

            if (Session["user"] != null)
            {
                if (Session["user"].Equals("Admin"))
                {
                    Role = "Admin";
                    InsertArtistBtn.Visible = true;
                }
                else if (Session["user"].Equals("Cust"))
                {
                    Role = "Cust";
                    InsertArtistBtn.Visible = false;
                }
            }
            else
            {
                Role = "Guest";
                InsertArtistBtn.Visible = false;
            }
        }

        protected void DeleteArtistBtn_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string artistID = deleteButton.CommandArgument;

            ArtistController.removeArtist(artistID);
            Response.Redirect("Home.aspx?redirected=true");
        }

        protected void UpdateArtistBtn_Click(object sender, EventArgs e)
        {
            Button updateButton = (Button)sender;
            string artistID = updateButton.CommandArgument;

            Response.Redirect("UpdateArtist.aspx?ID=" + artistID);
        }

        protected void InsertArtistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertArtist.aspx");
        }

        protected void ImgButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;
            string artistID = clickedButton.CommandArgument;
            Response.Redirect("ArtistDetails.aspx?ID=" + artistID);
        }

        protected void lvArtists_DataBound(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                if (Session["user"].Equals("Admin"))
                {
                    Role = "Admin";
                }
                else if (Session["user"].Equals("Cust"))
                {
                    Role = "Cust";
                }
            }
            else
            {
                Role = "Guest";
            }

            foreach (ListViewItem item in lvArtists.Items)
            {
                Panel panel = (Panel)item.FindControl("Panel1");

                panel.Visible = Role.Equals("Admin");
            }
        }
    }
}