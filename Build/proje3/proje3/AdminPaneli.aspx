g<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPaneli.aspx.cs" Inherits="proje3.AdminPaneli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Admin Paneli</title>
    <!-- Gerekirse head içeriğini buraya ekleyin -->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Admin Paneli</h1>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ad" HeaderText="Ad" SortExpression="ad" />
                    <asp:BoundField DataField="şifre" HeaderText="Şifre" SortExpression="şifre" />
                    <asp:TemplateField HeaderText="Ad" SortExpression="ad">
                        <ItemTemplate>
                            <asp:Label ID="lblAd" runat="server" Text='<%# Eval("ad") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAd" runat="server" Text='<%# Bind("ad") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Şifre" SortExpression="şifre">
                        <ItemTemplate>
                            <asp:Label ID="lblSifre" runat="server" Text='<%# Eval("şifre") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSifre" runat="server" Text='<%# Bind("şifre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" BackColor="#99CCFF" BorderStyle="Outset" NavigateUrl="~/edit.aspx">update page</asp:HyperLink>
    </form>

</body>
</html>
