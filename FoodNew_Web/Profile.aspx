<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MastePage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="FoodNew_Web.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/profile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="home" runat="server">
    <div class="profile">
        <div class="info-profile">
            <div class="info-name">
                <p>Info of User:</p>
                <p>Username:</p>
                <p>Email:</p>
                <p>Address:</p>
                <p>Phone:</p>
                <p>Date:</p>
            </div>
            <div class="info-input">
                <p><%=Session["accName"] %></p>
                <asp:TextBox ID="tbUsername" runat="server" CssClass="tbp"></asp:TextBox>
                <asp:TextBox ID="tbEmail" runat="server" CssClass="tbp"></asp:TextBox>
                <asp:TextBox ID="tbAddress" runat="server" CssClass="tbp"></asp:TextBox>
                <asp:TextBox ID="tbPhone" runat="server" CssClass="tbp"></asp:TextBox>
                <asp:TextBox ID="tbDate" runat="server" CssClass="tbp"></asp:TextBox>
                <span>dd/MM/yyyy</span>
            </div>
            <div class="img-profile">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />
                <hr />
                <asp:Image ID="Image1" runat="server" Height="200" Width="200" />
            </div>
        </div>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="tbp" OnClick="btnUpdate_Click" />
            <asp:Label ID="lbError" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
            <asp:Button ID="btnRe" runat="server" Text="Request" CssClass="tbRe" OnClick="btnRe_Click" />
        </div>
    </div>
    <div class="repeat-news">
        <asp:Repeater ID="RepeaterNews" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr style="align-content: center">
                        <th>Title</th>
                        <th>Short Description</th>
                        <th>Date publish</th>
                        <th>Type</th>
                        <th>Country</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="align-content: center">
                    <td><%#Eval ("title")%></td>
                    <td><%#Eval ("shortDes")%></td>
                    <td><%#Eval ("datePub")%></td>
                    <td><%#Eval ("typeName")%></td>
                    <td><%#Eval ("countryName")%></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <div style="margin-top: 20px;">
            <table>
                <tr>
                    <asp:Label ID="lblpage" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' Text='<%# Eval("PageIndex") %> ' Width="20px" CssClass="indexClick"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
