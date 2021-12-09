<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamBuyingDetail.aspx.cs" Inherits="TeamBuying.TeamBuyingDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>團購內容</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/TeamBuying.css" />
    <script src="js/bootstrap.bundle.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <%--本團基本資訊--%>
                <div class="card">
                    <div class="row g-0">
                        <div class="col-md-4 text-center">
                            <img src="Images/curry.png" class="rounded-start" alt="Curry" height="220">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title">好想吃咖哩</h5>
                                <p class="card-text">店名：咖哩屋</p>
                                <p class="card-text">團長：Peter</p>
                                <p class="card-text">未結案</p>
                                <p class="card-text">結算時間: 2021/12/10 17:30</p>
                            </div>
                        </div>
                    </div>
                </div>

                <%--參團人訂購內容--%>
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <div class="col-md-12 h5">已參團人</div>
                    <asp:Repeater ID="rpOrderLists" runat="server">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card h-100">

                                    <div class="row">
                                        <div class="col-8">
                                            <img src="Images/curry.png" class="float-end" alt="Whoisin" height="150">
                                        </div>
                                        <div class="col-4 alert alert-dismissible" role="alert">
                                                <button type="button" class="btn-close"></button>
                                        </div>
                                    </div>

                                    <div class="card-body row">
                                        <h5 class="card-title text-center">Peter</h5>
                                        <asp:Label ID="lblCurryName" runat="server" Text="辛辣咖哩包" CssClass="col-8 col-form-label"></asp:Label>
                                        <div class="col-4">
                                            <asp:TextBox ID="txtCurryName" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <%--巢狀Repeater  是否需要????? 若將全部需要的資料組成一個List是不是就不用了??--%>
                                        <asp:Repeater ID="rpOrderDetail" runat="server">
                                            <ItemTemplate>
                                                <h5 class="card-title text-center">Peter</h5>
                                                <asp:Label ID="lblCurryName" runat="server" Text="辛辣咖哩包" CssClass="col-8 col-form-label"></asp:Label>
                                                <div class="col-4">
                                                    <asp:TextBox ID="txtCurryName" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <%--商品內容--%>
                <div class="row row-cols-1 row-cols-md-6 g-4">
                    <div class="col-md-4 h5">商品內容</div>
                    <div class="col-md-4 h5 text-center">
                        <asp:Literal ID="ltOrderTotal" runat="server">已訂購金額：1,000 NT</asp:Literal>
                    </div>
                    <div class="col-md-4 d-md-flex justify-content-md-end">
                        <button class="btn btn-primary" type="button">訂購</button>
                    </div>

                    <asp:Repeater ID="rpProducts" runat="server">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card h-100">
                                    <img src="Images/curry.png" class="mx-auto d-block" alt="ProductImg" height="80">
                                    <div class="card-body row text-center">
                                        <asp:Label ID="lblCurryName" runat="server" Text="辛辣咖哩包" CssClass="col-form-label"></asp:Label>
                                        <asp:Label ID="lblPrice" runat="server" Text="$100" CssClass="col-form-label"></asp:Label>
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:Label ID="lblTotal" runat="server" Text="總計：" CssClass="col-form-label"></asp:Label>
                                    </div>
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
