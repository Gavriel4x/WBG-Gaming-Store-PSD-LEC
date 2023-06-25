using projectlab.Controller;
using projectlab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectlab.View
{
    public partial class ArtistDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                Artist artist = ArtistController.getArtist(id);

                ArtistImg.ImageUrl = artist.ArtistImage;
                ArtistName.InnerText = artist.ArtistName;

                lvAlbum.DataSource = AlbumController.getAll(id);
                lvAlbum.DataBind();

                if(AlbumController.getAll(id).Count == 0)
                {
                    AlbumTitle.InnerText = "No Available Soundtrack Album";
                }
            }

            if (Session["user"] != null)
            {
                if (Session["user"].Equals("Admin"))
                {
                    InsertAlbumBtn.Visible = true;
                }
                else if (Session["user"].Equals("Cust"))
                {
                    InsertAlbumBtn.Visible = false;
                }
            }
            else
            {
                InsertAlbumBtn.Visible = false;
            }

        }

        protected void ImgButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;
            string albumID = clickedButton.CommandArgument;
            Response.Redirect("AlbumDetails.aspx?ID=" + albumID);
        }

        protected void InsertAlbumBtn_Click(object sender, EventArgs e)
        {
            string artistId = (Request.QueryString["ID"]);
            Response.Redirect("InsertAlbum.aspx?ID="+artistId);
        }

        protected void lvAlbum_DataBound(object sender, EventArgs e)
        {
            string Role = "";
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

            foreach (ListViewItem item in lvAlbum.Items)
            {
                Panel panel = (Panel)item.FindControl("Panel1");

                panel.Visible = Role.Equals("Admin");
            }
        }

        protected void UpdateAlbumBtn_Click(object sender, EventArgs e)
        {
            Button updateButton = (Button)sender;
            string albumID = updateButton.CommandArgument;

            string artistid = Request.QueryString["ID"];
            Response.Redirect("UpdateAlbum.aspx?ArtistID="+artistid+"&ID="+albumID);
        }

        protected void DeleteAlbumBtn_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string albumID = deleteButton.CommandArgument;

            AlbumController.removeAlbum(albumID);
            Response.Redirect(Request.Url.ToString());
        }
    }
}