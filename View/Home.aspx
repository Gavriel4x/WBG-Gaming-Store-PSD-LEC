<%@ Page Title="WBG Gaming Store - Home" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="projectlab.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contentCon">

        <h2 style="margin:1em;">Available Games</h2>

        <div id="carousel_suggestion" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-inner w-100">
            <div class="carousel-item active" data-bs-interval="5000" style="height:400px; width:800px;" >
              <img src="../Assets/wbg-gaming-store-logo.png" class="d-block " alt="pic1" style="height:400px; margin:0 auto;">
            </div>
            <div class="carousel-item " data-bs-interval="2000" style="height:400px; width:800px;">
              <img src="../Assets/elden-ring.jpg" class="d-block" alt="pic2" style="height:400px; margin:0 auto;">
            </div>
            <div class="carousel-item" data-bs-interval="2000" style="height:400px; width:800px;">
              <img src="../Assets/hollow-knight.jpg" class="d-block" alt="pic3" style="height:400px; margin:0 auto;">
            </div>
          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carousel_suggestion" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#carousel_suggestion" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div>

        <%--BAWAH--%>
       
        <div  class="boxCon">
            <br />
            <h2 style="margin:1em;">Available Artists</h2>

            <asp:ListView ID="lvArtists" runat="server" OnDataBound="lvArtists_DataBound">
                <LayoutTemplate>
                    <div class="artistRow">
                        <div class="artistCol" runat="server" id="itemPlaceholder">
                        </div>
                    </div>

                </LayoutTemplate>

                <ItemTemplate>
                    <div class="artistCol" runat="server">
                        <div class="artistDesc">
                            <asp:LinkButton ID="ImgButton" runat="server" OnClick="ImgButton_Click" CommandArgument='<%# Eval("ArtistID") %>'>
                                <asp:Image CssClass="artistImg" ImageUrl='<%# Eval("ArtistImage")%>' runat="server"/>

                            </asp:LinkButton>
                            
                            <h3><%# Eval("ArtistName") %></h3>                            
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <asp:Button ID="UpdateArtistBtn" CssClass="btn" runat="server" Text="Update" OnClick="UpdateArtistBtn_Click" CommandArgument='<%# Eval("ArtistID") %>'/>
                                <asp:Button ID="DeleteArtistBtn" CssClass="btn" runat="server" Text="Delete" OnClick="DeleteArtistBtn_Click" CommandArgument='<%# Eval("ArtistID") %>'/>
                                
                            </asp:Panel>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:ListView>
            </div>
            
            <br /><br /><br /><br />
                <asp:Button ID="InsertArtistBtn" CssClass="btn" runat="server" Text="Insert Artist" OnClick="InsertArtistBtn_Click" Visible ="false"/>
            <br /><br />
    </div>
</asp:Content>
