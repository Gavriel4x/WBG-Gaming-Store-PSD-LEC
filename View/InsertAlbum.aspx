<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="InsertAlbum.aspx.cs" Inherits="projectlab.View.InsertAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentCon">
        <h2 style="text-align:center;">Insert Album</h2>
        <div class="insertAlbumForm">

            <div class="boxCon">
                <asp:Label ID="lblName" runat="server" Text="Name" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="tBox"></asp:TextBox>

                
            </div>

            <asp:Label ID="lblErrorName" runat="server" Text=""></asp:Label>
            <br /><br />

            <div class="boxCon">
                <asp:Label ID="lblDescription" runat="server" Text="Description" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="tBox"></asp:TextBox>

                
            </div>

            <asp:Label ID="lblErrorDescription" runat="server" Text=""></asp:Label>
            <br /><br />

            <div class="boxCon">
                <asp:Label ID="lblPrice" runat="server" Text="Price" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" CssClass="tBox"></asp:TextBox>

            </div>
            
            <asp:Label ID="lblErrorPrice" runat="server" Text=""></asp:Label>
            <br /><br />
            
            <div class="boxCon">
                <asp:Label ID="lblStock" runat="server" Text="Stock" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtStock" runat="server" TextMode="Number" CssClass="tBox"></asp:TextBox>

                
            </div>

            <asp:Label ID="lblErrorStock" runat="server" Text=""></asp:Label>
            <br /><br />

            <div class="boxCon">
                <asp:Label ID="lblImage" runat="server" Text="Album Image" CssClass="lbl"></asp:Label>
                <asp:FileUpload ID="imageUpload" CssClass="lbl" runat="server"/>
            </div>
            <asp:Label ID="lblErrorImage" runat="server" Text=""></asp:Label>
            <br />

            <asp:Button ID="InsertAlbumBtn" runat="server" CssClass="btn" Text="Insert Album" OnClick="InsertAlbumBtn_Click"/>

            <br />

            

        </div>
    </div>
</asp:Content>
