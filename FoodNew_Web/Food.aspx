<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MastePage.Master" AutoEventWireup="true" CodeBehind="Food.aspx.cs" Inherits="FoodNew_Web.Food" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/food.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="home" runat="server">
        <div class="cake-list">
            <asp:TextBox ID="tbSearchByName" runat="server" Width="350px"></asp:TextBox>
            <asp:DropDownList ID="ddType" runat="server" Width="140px" Height="22px">
            </asp:DropDownList>
            <asp:DropDownList ID="ddCountry" runat="server" Width="140px" Height="22px">
            </asp:DropDownList>
            <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
        </div>
        <asp:Repeater ID="MoreNewsRepeater" runat="server" OnItemCommand="MoreNewsRepeater_ItemCommand">
            <HeaderTemplate>
                <div class="cake-list">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="cake">
                    <div class="cake-content">
                        <asp:LinkButton  ID="detail" runat="server" CommandArgument='<%#Eval ("FID") %>'><h3><%#Eval ("title")%></h3></asp:LinkButton>
                        
                        <p><%#Eval ("shortDes")%></p>
                    </div>
                    <div class="cake-img">
                        <img src="../Image/food/<%#Eval ("imgLink")%>" alt="" />
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
        <div style="margin-top: 20px;" class="cake-list">
            <table>
                <tr>
                    <asp:Label ID="lblpage" runat="server" Text="" Font-Size="Medium"></asp:Label>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <asp:LinkButton  ID="lbPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' Text='<%# Eval("PageIndex") %> ' Width="20px" CssClass="linkClick"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
