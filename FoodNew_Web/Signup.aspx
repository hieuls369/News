<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MastePage.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="FoodNew_Web.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/signup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="home" runat="server">
    <div class="signup-form">
            <h2>Sign Up</h2>
            <div class="signup-content">
                <div class="signup-name">
                    <p>Username:</p>
                    <p>Password:</p>
                    <p>RePassword:</p>
                </div>
                <div class="signup-input">
                    <asp:TextBox ID="tbUsername" runat="server" CssClass="tbSign"></asp:TextBox>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="tbSign"></asp:TextBox>
                    <asp:TextBox ID="tbRepass" runat="server" CssClass="tbSign"></asp:TextBox>
                    <asp:Button ID="btnSignup" runat="server" Text="Sign up" CssClass="tbSign" OnClick="btnSignup_Click"/>
                    <asp:Label ID="lbError" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
                
        </div>
</asp:Content>
