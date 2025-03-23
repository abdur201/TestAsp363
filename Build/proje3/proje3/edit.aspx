<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="proje3.img.edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="civ-div" style="border: 7px outset #00FFFF; width: 294px; background-color:gold; height: 305px; margin-left: 488px; margin-top: 0px; height: 275px;" align="center">
    <p>
        Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="yazi7" runat="server"></asp:TextBox>
    </p>
    <p>
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="yazi8" runat="server"></asp:TextBox>
    </p>
    <p>
        NewUsername:<asp:TextBox ID="yazi9" runat="server"></asp:TextBox>
    </p>
    <p>
        NewPassword:<asp:TextBox ID="yazi10" runat="server"></asp:TextBox>
    </p>
    <font ;font size='1.5'>
        (If you don't want to change one of them, fill it with the same)</font>
    <p>
        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Update" />
    </p>
        </div>
</asp:Content>
