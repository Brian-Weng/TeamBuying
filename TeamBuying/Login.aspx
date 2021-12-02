<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TeamBuying.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                            <input type="text" class="form-control m-2" placeholder="Your Account"/>
                        </div>
                        <div class="form-group">
                            <input type="password" class="form-control m-2" placeholder="Your Password"/>
                        </div>
                        <div class="form-group">
                            <button type="submit" class="btn btn-secondary m-2">Login</button>
                        </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
