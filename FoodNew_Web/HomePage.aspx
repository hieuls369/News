<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MastePage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FoodNew_Web.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="home" runat="server">
    <div class="content-items first">
        <img ID="img" runat="server" src="#" alt="" />
        <h3 ID="title" runat="server"></h3>
    </div>
    <asp:Repeater ID="NewsRepeater" runat="server">
        <HeaderTemplate>
            <div class="content-items second">
        </HeaderTemplate>
        <ItemTemplate>
                <div class="image">
                    <img src="../Image/food/<%#Eval ("imgLink")%>" alt="" />
                    <h3><%#Eval ("title")%></h3>
                </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>
