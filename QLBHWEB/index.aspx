<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" EnableEventValidation="false" Inherits="QLBHWEB.index" %>

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
    <title>Bảng hàng</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-main-wrapper">
            <div class="dashboard-header">
                <nav class="navbar navbar-expand-lg bg-white fixed-top">
                    <a class="navbar-brand" href="index.aspx">Quản lý bán hàng</a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse " id="navbarSupportedContent" runat="server" visible="false">
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

                <div id="banghang" runat="server">
                    <div class="dashboard-finance">
                        <div class="container-fluid dashboard-content">
                            <div class="row">
                                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                    <div class="page-header">
                                        <h3 class="mb-2">Bảng hàng</h3>
                                        <p class="pageheader-text">Proin placerat ante duiullam scelerisque a velit ac porta, fusce sit amet vestibulum mi. Morbi lobortis pulvinar quam.</p>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <h5 class="card-header">Bảng hàng <div class="fa-pull-right"><a href="themsua.aspx" class="btn btn-success">Thêm</a></div></h5>
                                        <div class="card-body">
                                            <asp:GridView ID="mathang" runat="server" Width="100%" AllowPaging="True" PageSize="20" OnRowCommand="mathang_RowCommand" OnPageIndexChanging="mathang_PageIndexChanging">
                                                <Columns>
                                                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-primary form-control" HeaderText="Sửa" Text="Sửa" CommandName="Sua">
                                                        <ControlStyle CssClass="btn btn-primary form-control"></ControlStyle>
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-info form-control" HeaderText="Xóa" Text="Xóa" CommandName="Xoa">
                                                        <ControlStyle CssClass="btn btn-info form-control"></ControlStyle>
                                                    </asp:ButtonField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="dangnhap" runat="server" style="padding-bottom: 400px;">
                    <div class="card col-md-4 col-sm-12 col offset-md-4">
                        <h5 class="card-header">
                            <asp:Label ID="Label1" runat="server" Text="Bạn cần đăng nhập trước" BackColor="White" Font-Names="Times New Roman"></asp:Label>

                        </h5>
                        <div class="card-body">
                            <form id="form" data-parsley-validate="" novalidate="">
                                <div class="form-group row">
                                    <label for="inputEmail2" class="col-4 col-lg-2 col-form-label text-right">Tài khoản</label>
                                    <div class="col-8 col-lg-10">
                                        <asp:TextBox ID="taikhoan" placeholder="Tài khoản" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="inputPassword2" class="col-4 col-lg-2 col-form-label text-right">Mật khẩu</label>
                                    <div class="col-8 col-lg-10">
                                        <asp:TextBox ID="matkhau" TextMode="Password" placeholder="Mật khẩu" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="alert alert-danger" role="alert" id="sai" visible="false" runat="server">
                                    <div class="row">Sai tài khoản hoặc mật khẩu</div>
                                </div>

                                <div class="row pt-2 pt-sm-5 mt-1">
                                    <div class="col-md-12 pl-0">
                                        <p class="text-right">
                                            <asp:Button ID="login" class="btn btn-space btn-primary" runat="server" Text="Đăng nhập" OnClick="login_Click" />
                                        </p>
                                    </div>
                                </div>
                            </form>
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
        <script src="../assets/vendor/jquery/jquery-3.3.1.min.js"></script>
        <script src="../assets/vendor/bootstrap/js/bootstrap.bundle.js"></script>
        <script src="../assets/vendor/slimscroll/jquery.slimscroll.js"></script>
        <script src="../assets/vendor/parsley/parsley.js"></script>
        <script src="../assets/libs/js/main-js.js"></script>
    </form>
</body>
</html>
