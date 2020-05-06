<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MastePage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodNew_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="home" runat="server">
        <div class="login-form">
            <h2>Login</h2>
            <div class="login-content">
                <div class="login-name">
                    <p>Username: </p>
                    <p>Password: </p>
                </div>
                <div class="login-input">
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="tb"></asp:TextBox>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="tb" OnClick="btnLogin_Click"/>
                    <asp:Label ID="lbError" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
        </div>
</asp:Content>
