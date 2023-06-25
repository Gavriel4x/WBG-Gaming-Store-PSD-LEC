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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["user"].Equals("Admin"))
            {
                Response.Redirect("Home.aspx?redirected=true");
            }


            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Session["userid"].ToString());
                List<Model.Cart> carts = CartController.getAllCart(id);
                if(carts.Count == 0)
                {
                    CheckOutBtn.Visible = false;
                    lblError.Visible = true;
                }
                else
                {
                    CheckOutBtn.Visible = true;
                    lblError.Visible = false;
                    lvCarts.DataSource = carts;
                    lvCarts.DataBind();
                }
                
            }

        }

        protected void DeleteCartBtn_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            string albumID = deleteButton.CommandArgument;
            int userID = Convert.ToInt32(Session["userid"].ToString());

            CartController.removeCart(int.Parse(albumID), userID);
            Response.Redirect("Cart.aspx");
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["userid"].ToString());
            List<Model.Cart> carts = CartController.getAllCart(id);

            int tid = TransactionController.insertHeader(id, DateTime.Now);

            foreach (Model.Cart c in carts)
            {
                TransactionController.insertDetail(tid, c.AlbumID,c.Qty , id);
            }

            Response.Redirect("Home.aspx?redirected=true");
        }
    }
}