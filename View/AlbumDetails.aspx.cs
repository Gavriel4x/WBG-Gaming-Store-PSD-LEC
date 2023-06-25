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
    public partial class AlbumDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["ID"]);
                Album album = AlbumController.getAlbum(id);

                AlbumImg.ImageUrl = album.AlbumImage;
                AlbumName.InnerText = album.AlbumName;
                AlbumDescription.InnerText = album.AlbumDescription;
                AlbumPrice.InnerText = album.AlbumPrice.ToString();
                AlbumStock.InnerText = album.AlbumStock.ToString();

            }
            if (Session["user"] != null)
            {
                if (Session["user"].Equals("Cust"))
                {
                    Panel1.Visible = true;
                }
                else if (Session["user"].Equals("admin"))
                {
                    Panel1.Visible = false;
                }
            }
            else
            {
                Panel1.Visible = false;
            }



        }

        protected void AddToCartBtn_click (object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["ID"]);
            Album album = AlbumController.getAlbum(id);

            string error = CartController.insertValidation(txtQuantity.Text, album);
            lblErrorQuantity.Text = error;

            if (error.Equals(""))
            {
                int cid = Convert.ToInt32(Session["userid"].ToString());
                CartController.insertCart(id.ToString(), cid, int.Parse(txtQuantity.Text));
                Response.Redirect("AlbumDetails.aspx?ID=" + id);
            }
            else
            {
                lblErrorQuantity.Text = error;
            }

        }
    }
}