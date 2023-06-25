using projectlab.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectlab.View
{
    public partial class InsertAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["user"].Equals("Cust"))
            {
                Response.Redirect("Home.aspx?redirected=true");
            }
        }

        protected void InsertAlbumBtn_Click(object sender, EventArgs e)
        {
            String[] errList = AlbumController.validate(txtName.Text, txtDescription.Text, txtPrice.Text, txtStock.Text, imageUpload.FileName, Path.GetExtension(imageUpload.FileName), imageUpload.HasFile, imageUpload.FileBytes.Length);

            lblErrorName.Text = errList[0];
            lblErrorDescription.Text = errList[1];
            lblErrorPrice.Text = errList[2];
            lblErrorStock.Text = errList[3];
            lblErrorImage.Text = errList[4];

            if (AlbumController.isValid)
            {
                string filename = Path.GetFileName(imageUpload.PostedFile.FileName);
                imageUpload.SaveAs(Server.MapPath("../Uploads/" + filename));
                string filepath = "../Uploads/" + filename;

                string artistID = Request.QueryString["ID"];
                
                AlbumController.insertAlbum(artistID, txtName.Text, txtDescription.Text, txtPrice.Text, txtStock.Text, filepath);
                Response.Redirect("ArtistDetails.aspx?ID="+artistID);
            }
        }
    }
}