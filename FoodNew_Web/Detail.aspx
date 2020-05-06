<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MastePage.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="FoodNew_Web.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/detail.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="home" runat="server">
        <asp:Repeater ID="detail" runat="server">
            <HeaderTemplate>
                <div class="detail-news">
            </HeaderTemplate>
            <ItemTemplate>
                <h2><%# Eval("title") %></h2>
                <div class="side">
                <div class="left-side">
                <h4 >Publisher: <%# Eval("UserName")%></h4>
                </div>
                <div class="right-side">
                <p><%# Eval("datePub") %></p>
                    </div>
                </div>
                <div class="detail-cake">
                    <div class="detail-name">
                        <p><%# Eval("shortDes") %></p>
                    </div>
                    <div class="detail-img">
                        <img src="../Image/food/<%# Eval("imgLink") %>" alt="" />
                    </div>
                </div>
                <p><%# Eval("longDes") %></p>
                
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
</asp:Content>
