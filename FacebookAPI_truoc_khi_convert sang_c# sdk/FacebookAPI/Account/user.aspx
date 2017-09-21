﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="FacebookAPI.Account.user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>Id:</td>
                            <td><%# Eval("id") %><br />
                            </td>
                        </tr>
                        <tr>
                            <td>First Name:</td>
                            <td><%# Eval("first_name") %><br />
                            </td>
                        </tr>
                        <tr>
                            <td>Last Name:</td>
                            <td><%# Eval("last_name") %><br />
                            </td>
                        </tr>
                        <tr>
                            <td>Link:</td>
                            <td><%# Eval("link") %><br />
                            </td>
                        </tr>
                        <tr>
                            <td>Gender:</td>
                            <td><%# Eval("gender") %><br />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
