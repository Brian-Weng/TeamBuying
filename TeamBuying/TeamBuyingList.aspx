<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamBuyingList.aspx.cs" Inherits="TeamBuying.TeamBuyingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>團購清單頁</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/bootstrap.bundle.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <nav class="nav">
                        <asp:Label ID="lblAccountName" runat="server" CssClass="nav-link text-dark" Text="Welcome, Peter Parker " Visible="false"></asp:Label>
                        <a class="nav-link" href="#">Login</a>
                        <a class="nav-link" href="#">Create Team</a>
                    </nav>
                </div>

                <div class="col-12">
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Search">
                        <button class="btn btn-outline-secondary" type="button" id="btnSearch">Search</button>
                    </div>
                </div>

                <div class="col-12">
                    <asp:Repeater ID="rpTeamBuyings" runat="server">
                        <ItemTemplate>
                            <div class="card text-center">
                                <div class="card-header">
                                    好想吃咖哩
                                </div>
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img src="Images/curry.png" width="150" height="150" class="img-fluid rounded-start" alt="...">
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h5 class="card-title">團長：Peter</h5>
                                            <p class="card-text">店名:咖哩屋</p>
                                            <p class="card-text">好吃的咖哩調理包</p>
                                            <a href="#" class="btn btn-primary">我要參團</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer text-muted">
                                    結算時間: 2021/12/10 17:30
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
