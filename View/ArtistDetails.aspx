<%@ Page Title="" Language="C#" MasterPageFile="~/View/Header.Master" AutoEventWireup="true" CodeBehind="ArtistDetails.aspx.cs" Inherits="projectlab.View.ArtistDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentCon">
        <div class="artistCon">
            <div>
                <asp:Image ID="ArtistImg" CssClass="artistImg" ImageUrl='<%# Eval("ArtistImage") %>' runat="server"/>
            </div>

            <div>
                <h3 id="ArtistName" runat="server"></h3>
                <asp:Button ID="InsertAlbumBtn" CssClass="btn" runat="server" Text="Insert Soundtrack Album" OnClick="InsertAlbumBtn_Click" Visible ="false"/>
            </div>
        </div>

        <h3 id="AlbumTitle" style="margin:3em;" runat="server">Albums</h3>


        <div  class="boxCon">
            <asp:ListView ID="lvAlbum" runat="server" OnDataBound="lvAlbum_DataBound">
                <LayoutTemplate>
                    <div class="albumRow">
                        <div class="albumCol" runat="server" id="itemPlaceholder">
                        </div>
                    </div>

                </LayoutTemplate>

                <ItemTemplate>
                    <div class="albumCol" runat="server">
                        <div class="albumDesc">
                            <asp:LinkButton ID="ImgButton" runat="server" OnClick="ImgButton_Click" CommandArgument='<%# Eval("AlbumID") %>'>
                                <asp:Image CssClass="albumImg" ImageUrl='<%# Eval("AlbumImage")%>' runat="server"/>

                            </asp:LinkButton>
                            
                            <h3><%# Eval("AlbumName") %></h3>  
                            <h5>Rp <%# Eval("AlbumPrice") %></h5> 
                            <h5 style="overflow: hidden; white-space: nowrap; text-overflow: ellipsis; width:10em; text-align:center"><%# Eval("AlbumDescription") %></h5> 
                             
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <asp:Button ID="UpdateAlbumBtn" CssClass="btn" runat="server" Text="Update" OnClick="UpdateAlbumBtn_Click" CommandArgument='<%# Eval("AlbumID") %>'/>
                                <asp:Button ID="DeleteAlbumBtn" CssClass="btn" runat="server" Text="Delete" OnClick="DeleteAlbumBtn_Click" CommandArgument='<%# Eval("AlbumID") %>'/>
                                
                            </asp:Panel>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:ListView>
        </div>

    </div>

</asp:Content>
