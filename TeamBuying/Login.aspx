<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TeamBuying.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登入頁</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/TeamBuying.css" />
    <script src="js/bootstrap.bundle.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container bg-secondary">
            <div class="row justify-content-center align-items-center" style="height:100vh">
                <div class="col-md-4 text-center bg-white LoginCT">
                    <img src="images/Login.png" width="80" height="60" class="my-3"/>
                    <h2 class="mb-4">Login</h2>
                        <div class="form-group">
                            <asp:TextBox ID="txtAccount" runat="server" CssClass="form-control m-2" placeholder="Your Account"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control m-2" placeholder="Your Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-secondary m-2" OnClick="btnLogin_Click"/>
                        </div>
                        <div>
                            <asp:Label ID="lbMsg" runat="server" Text="" CssClass="text-danger pb-2"></asp:Label>
                        </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
