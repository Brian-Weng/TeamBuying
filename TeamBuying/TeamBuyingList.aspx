<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamBuyingList.aspx.cs" Inherits="TeamBuying.TeamBuyingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>團購清單頁</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/TeamBuying.css" />
    <script src="js/bootstrap.bundle.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <%--功能列--%>
                <div class="col-12">
                    <nav class="nav">
                        <asp:Label ID="lblAccountName" runat="server" CssClass="nav-link text-dark" Text="Welcome, Peter Parker " Visible="false"></asp:Label>
                        <asp:LinkButton ID="lbLogout" runat="server" CssClass="nav-link" Visible="false" OnClick="lbLogout_Click">Logout</asp:LinkButton>
                        <asp:LinkButton ID="lbLogin" runat="server" CssClass="nav-link" PostBackUrl="~/Login.aspx">Login</asp:LinkButton>
                        <asp:LinkButton ID="lbCreateTeam" runat="server" CssClass="nav-link" Visible="false" data-bs-toggle="modal" data-bs-target="#CreateTeamModal">揪團</asp:LinkButton>
                    </nav>
                </div>

                <%--搜尋列--%>
                <div class="col-12">
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Search"/>
                        <button class="btn btn-outline-secondary" type="button" id="btnSearch">Search</button>
                    </div>
                </div>

                <%--開團列表--%>
                <div class="col-12">
                    <asp:Repeater ID="rpTeamBuyings" runat="server">
                        <ItemTemplate>
                            <div class="card text-center">
                                <div class="card-header">
                                    好想吃咖哩
                                </div>s
                                <div class="row g-0">
                                    <div class="col-md-4">
                                        <img src="Images/curry.png" width="150" height="150" class="img-fluid rounded-start" alt="curry">
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

        <%--建立團購的Modal--%>
        <div class="modal fade" id="CreateTeamModal" tabindex="-1">
            <div class="modal-dialog  modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">來揪一個團吧</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="mb-3">
                            <label for="<%= this.txtTeamName.ClientID %>" class="col-form-label">團名：</label>
                            <asp:TextBox ID="txtTeamName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="<%= this.ddlStoreName.ClientID %>" class="col-form-label">店名：</label>
                            <asp:DropDownList ID="ddlStoreName" runat="server">
                                <asp:ListItem Value="0" Text="咖哩屋"></asp:ListItem>
                                <asp:ListItem Value="1" Text="天然面膜"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="<%= this.txtBody.ClientID %>" class="col-form-label">內容：</label>
                            <asp:TextBox ID="txtBody" runat="server" CssClass="form-control noResize" TextMode="MultiLine" Rows="4" Columns="50" MaxLength="200"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="" class="col-form-label">結算時間：</label>
                            <asp:Label ID="Label1" runat="server"><%= DateTime.Now.Year%>年</asp:Label>
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="me-1">
                                <asp:ListItem Value="1" Text="1月"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2月"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlDay" runat="server"  CssClass="me-1">
                                <asp:ListItem Value="1" Text="1日"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2日"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlTime" runat="server">
                                <asp:ListItem Value="1" Text="8:00"></asp:ListItem>
                                <asp:ListItem Value="2" Text="9:00"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <asp:Button ID="btnSave" runat="server" Text="建立" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
