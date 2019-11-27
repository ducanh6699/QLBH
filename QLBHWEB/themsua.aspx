<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="themsua.aspx.cs" Inherits="QLBHWEB.themsua" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="assets/vendor/bootstrap/css/bootstrap.min.css">
    <link href="assets/vendor/fonts/circular-std/style.css" rel="stylesheet">
    <link rel="stylesheet" href="assets/libs/css/style.css">
    <link rel="stylesheet" href="assets/vendor/fonts/fontawesome/css/fontawesome-all.css">
    <link rel="stylesheet" href="assets/vendor/vector-map/jqvmap.css">
    <link href="assets/vendor/jvectormap/jquery-jvectormap-2.0.2.css" rel="stylesheet">
    <link rel="stylesheet" href="assets/vendor/charts/chartist-bundle/chartist.css">
    <link rel="stylesheet" href="assets/vendor/charts/c3charts/c3.css">
    <link rel="stylesheet" href="assets/vendor/charts/morris-bundle/morris.css">
    <link rel="stylesheet" type="text/css" href="assets/vendor/daterangepicker/daterangepicker.css" />
    <title>Thêm/sửa hàng</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="dashboard-main-wrapper">
                <div class="dashboard-header">
                    <nav class="navbar navbar-expand-lg bg-white fixed-top">
                        <a class="navbar-brand" href="index.aspx">Quản lý bán hàng</a>
                        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse " id="navbarSupportedContent" runat="server">
                            <ul class="navbar-nav ml-auto navbar-right-top">
                                <li class="nav-item dropdown nav-user">
                                    <a class="nav-link nav-user-img" href="#" id="navbarDropdownMenuLink2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <img src="assets/images/avatar-1.jpg" alt="" class="user-avatar-md rounded-circle"></a>
                                    <div class="dropdown-menu dropdown-menu-right nav-user-dropdown" aria-labelledby="navbarDropdownMenuLink2">
                                        <div class="nav-user-info">
                                            <h5 class="mb-0 text-white nav-user-name">Quản trị viên </h5>
                                            <span class="status"></span><span class="ml-2">Available</span>
                                        </div>
                                        <a class="dropdown-item" href="logout.aspx"><i class="fas fa-power-off mr-2"></i>Đăng xuất</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>

                <div class="nav-left-sidebar sidebar-dark">
                    <div class="menu-list">
                        <nav class="navbar navbar-expand-lg navbar-light">
                            <a class="d-xl-none d-lg-none" href="#">Bảng hàng</a>
                            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                                <span class="navbar-toggler-icon"></span>
                            </button>
                            <div class="collapse navbar-collapse" id="navbarNav">
                                <ul class="navbar-nav flex-column">
                                    <li class="nav-divider">Menu
                                    </li>
                                    <li class="nav-item ">
                                        <a class="nav-link active" href="#">
                                            <i class="fa fa-fw fa-user-circle"></i>Bảng hàng <span class="badge badge-success">6</span></a>
                                    </li>
                                </ul>
                            </div>
                        </nav>
                    </div>
                </div>

                <div class="dashboard-wrapper">

                    <div class="col-xl-6 col-lg-6 col-md-6 offset-md-3 col-sm-12 col-12">
                        <div class="card">
                            <h5 class="card-header">Horizontal Form</h5>
                            <div class="card-body">
                                <div class="form-group row">
                                    <label for="inputEmail2" class="col-3 col-lg-2 col-form-label text-right">Mã vạch</label>
                                    <div class="col-9 col-lg-10">
                                        <asp:TextBox ID="mavach" CssClass="form-control" runat="server" placeholder="Điền Mã vạch"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail2" class="col-3 col-lg-2 col-form-label text-right">Tên hàng</label>
                                    <div class="col-9 col-lg-10">
                                        <asp:TextBox ID="tenhang" CssClass="form-control" runat="server" placeholder="Điền tên hàng"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail2" class="col-3 col-lg-2 col-form-label text-right">Số lượng</label>
                                    <div class="col-9 col-lg-10">
                                        <asp:TextBox ID="soluong" CssClass="form-control" runat="server" placeholder="Điền số lượng"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="inputEmail2" class="col-3 col-lg-2 col-form-label text-right">Giá</label>
                                    <div class="col-9 col-lg-10">
                                        <asp:TextBox ID="gia" CssClass="form-control" runat="server" placeholder="Điền giá"></asp:TextBox>
                                    </div>
                                </div>
                                    <div class="col-sm-6 pl-0">
                                        <p class="text-right">
                                            <asp:Button ID="them" class="btn btn-space btn-success" runat="server" Text="Thêm" OnClientClick="return confirm('Bạn chắc chắn chứ');" OnClick="them_Click" />
                                            <asp:Button ID="sua" class="btn btn-space btn-info" runat="server" Text="Sửa" OnClientClick="return confirm('Bạn chắc chắn chứ');" OnClick="sua_Click" />
                                        </p>
                                    </div>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
                                    Copyright © 2019
                                </div>
                                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
                                    <div class="text-md-right footer-links d-none d-sm-block">
                                        <a href="javascript: void(0);">About</a>
                                        <a href="javascript: void(0);">Support</a>
                                        <a href="javascript: void(0);">Contact Us</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
