<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MastePage.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="FoodNew_Web.Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/request.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="home" runat="server">
    <div class="main">
        <h2>Make a request</h2>
        <asp:Label ID="lbShow" runat="server" ></asp:Label>
        <div class="request">
            <div class="request-name">
                <p>Title:</p>
                <p>Content Request:</p>
            </div>
            <div class="request-input">
                <asp:TextBox ID="tbTitle" runat="server" CssClass="tbr"></asp:TextBox>
                <textarea name="taDescrip" cols="55" rows="10"></textarea>
                <asp:Button ID="btnRequest" runat="server" Text="Submit" CssClass="btr" OnClick="btnRequest_Click" />
            </div>
        </div>
        <asp:Repeater ID="RepeaterRequest" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr style="align-content: center">
                        <th>Title</th>
                        <th>Content</th>
                        <th>Date publish</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="align-content: center">
                    <td><%#Eval ("title")%></td>
                    <td><%#Eval ("description")%></td>
                    <td><%#Eval ("date")%></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
