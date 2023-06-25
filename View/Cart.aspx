<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="projectlab.View.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentCon">
       
        <asp:Label ID="lblError" runat="server" Text="No Album in Cart"></asp:Label>
       <div class="cartCon">
            <div  class="boxCon">
                <asp:ListView ID="lvCarts" runat="server" >
                <LayoutTemplate>
                    <div class="artistRow">
                        <div class="artistCol" runat="server" id="itemPlaceholder">
                        </div>
                    </div>

                </LayoutTemplate>

                <ItemTemplate>
                    <div class="artistCol" runat="server">
                        <div class="artistDesc">
 
                           <asp:Image CssClass="artistImg" ImageUrl='<%# Eval("Album.AlbumImage")%>' runat="server"/>
                            <h3><%# Eval("Album.AlbumName") %></h3>  
                            <h5>Quantity: <%# Eval("Qty") %></h5>
                            <h5>Price: Rp <%# Eval("Album.AlbumPrice") %></h5>
<%--                            <asp:Panel ID="Panel1" runat="server" Visible="false">--%>
                                <asp:Button ID="DeleteCartBtn" CssClass="btn" runat="server" Text="Delete" OnClick="DeleteCartBtn_Click" CommandArgument='<%# Eval("Album.AlbumID") %>'/>
                            <%--</asp:Panel>--%>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:ListView>
            </div>
        </div>

        <br /><br /><br />
        <asp:Button ID="CheckOutBtn" CssClass="btn" runat="server" Text="Checkout Cart" OnClick="CheckOutBtn_Click"/>
    </div>
 

</asp:Content>
