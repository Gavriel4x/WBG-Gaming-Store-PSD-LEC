<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="AlbumDetails.aspx.cs" Inherits="projectlab.View.AlbumDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentCon">
        <div class="albumCon">
            <asp:Image ID="AlbumImg" CssClass="albumImg" ImageUrl ='<%# Eval("AlbumImage")%>' runat="server" />
            <div class ="albumData">
                <h2><span id="AlbumName" runat="server"></span></h2>
                <h5><span id="AlbumDescription" runat="server"></span></h5>
                <h5>Rp <span id="AlbumPrice" runat="server"></span></h5>
                <h5>Stock : <span id="AlbumStock" runat="server"></span></h5>
            </div>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="boxCon">
                 <asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="lbl" Visible ="true" ></asp:Label>
                <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" CssClass="tBox" Visible ="true" ></asp:TextBox>
                <asp:Label ID="lblErrorQuantity" runat="server" Text=""></asp:Label>
                <asp:Button ID="AddToCartBtn" runat="server" Text="Add To Cart"  OnClick="AddToCartBtn_click" Visible ="true" CssClass="btn"/>   
           </div>
        </asp:Panel>
            

       
    </div>
    
</asp:Content>
