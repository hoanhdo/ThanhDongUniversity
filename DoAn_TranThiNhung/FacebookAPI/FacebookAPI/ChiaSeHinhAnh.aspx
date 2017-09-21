<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiaSeHinhAnh.aspx.cs" Inherits="FacebookAPI.ChiaSeHinhAnh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>FacebookAPI</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.css" rel="stylesheet" type="text/css" />
    <link rel="Shortcut Icon" href="images/favicon.ico" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
     <link href="http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css"
        rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Lato:300,400,700,300italic,400italic,700italic"  rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--<div class="container">
        <div id="logo">
            <img src="images/logo.png" alt="Freshdesign" />
        </div>
    </div>-->
    <!-- Navigation -->
    <nav class="navbar navbar-default" role="navigation">
    <div class="container">
    <div class="navbar-header">
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNav">
    <span class="icon-bar"></span>
    <span class="icon-bar"></span>
    <span class="icon-bar"></span>
    </button>
    </div>
    <div class="collapse navbar-collapse" id="myNav">
    <ul class="nav navbar-nav">
        <li><a href="#">Trang chủ</a></li>
        <li><a href="ChiaSeBaiViet.aspx">Chia sẻ bài viết</a></li>
        <li class="active"><a href="ChiaSeHinhAnh.aspx">Chia sẻ ảnh</a></li>
        <li><a href="LayThongTinNguoiDung.aspx">Thông tin bạn bè</a></li>
        <li><a href="GuiThongBao.aspx">Gửi thông báo</a></li>
        <li><a href="About.aspx">Giới thiệu</a></li>
        <li><a href="Contact.aspx">Liên hệ</a></li>
    </ul>
    <ul class="nav navbar-nav navbar-right">
    <li><a href="#" class="btn-link" class="btn-link" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-user"></span> Đăng nhập</a></li>
    </ul>
    </div>
    </div>   
    </nav>
    <!-- Modal -->
    <div id="myModal" class="modal fade in" role="dialog">
        <div class="modal-dialog">
            <!-- Modal Content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        &times</button>
                    <h4 class="modal-title">
                        Đăng nhập</h4>
                </div>
                <div class="modal-body">
                    <div role="form">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Tên đăng nhập"></asp:Label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" Text="Mật khẩu"></asp:Label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        </div>
                        <hr class="divider">
                        <div class="form-group">
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:CheckBox ID="chkRemberme" runat="server" Text="Nhớ mật khẩu" CssClass="checkbox-inline" />
                                    |
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="text-primary">Quên mật khẩu ?</asp:LinkButton>
                                </div>
                                <div class="col-sm-6">
                                    <span class="pull-right">
                                        <asp:Button ID="btnSumbit" CssClass="btn btn-success" runat="server" Text="Gửi" /></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Landing Page -->
    
    <!-- Start Our Services -->
    
    <!-- /# Our Services -->
    <!-- Slider -->
    
    <!-- Service Section -->
    <section id="services" class="padding50">
        <div class="container">
            <div class="row">
                <h2 class="background double animated wow fadeInUp" data-wow-delay="0.2s"><span><strong>F</strong>eatures</span></h2>
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-laptop animated wow fadeInDown"></i>
                    <div class="sc-inner">
                        <h4>
                            Responsive Design</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-support animated wow fadeInDown" data-wow-delay="0.2s"></i>
                    <div class="sc-inner">
                        <h4>
                            Quick Support</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-paper-plane-o animated wow fadeInDown" data-wow-delay="0.4s"></i>
                    <div class="sc-inner">
                        <h4>
                            Mailchimp Newsletter</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-pie-chart animated wow fadeInUp" data-wow-delay="0.6s"></i>
                    <div class="sc-inner">
                        <h4>
                            Awesome Stats</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-puzzle-piece animated wow fadeInUp" data-wow-delay="0.8s"></i>
                    <div class="sc-inner">
                        <h4>
                            Easy update</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-youtube-play animated wow fadeInUp" data-wow-delay="0.10s"></i>
                    <div class="sc-inner">
                        <h4>
                            Video Support</h4>
                        <p>
                            Want more Bootstrap themes & templates? Subscribe to our mailing list to receive
                            an update when new items arrive!</p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
            <!-- ./ end row -->
        </div>
        <div class="clearfix">
        </div>
    </section>
    <!-- ./ End Service Section -->

    <!-- footer -->
    <footer id="footer">
		<!-- footer-widget-wrapper -->
		<div class="footer-widget-wrapper">
			<div class="container">
				<div class="row">

					<!-- footer-widget -->				
					<div class="col-md-3 col-sm-6">
						<div class="footer-widget text-widget">
							<a href="#" class="footer-logo"> </a>
							<p>Hàng ngày, mọi người đăng nội dung tuyệt vời lên Trang và Trang cá nhân Facebook của họ. Làm sống động những video và bài viết đó trên trang web của bạn với video được nhúng và bài viết được nhúng hiện dễ nhìn và dễ tùy chỉnh hơn</p>
							<ul class="social list-inline">
								<li><a href="#"><i class="fa fa-skype"></i></a></li>
								<li><a href="#"><i class="fa fa-twitter"></i></a></li>
								<li><a href="#"><i class="fa fa-facebook"></i></a></li>
								<li><a href="#"><i class="fa fa-pinterest"></i></a></li>
								<li><a href="#"><i class="fa fa-dribbble"></i></a></li>
							</ul>
						</div>
					</div><!-- footer-widget -->

					<!-- footer-widget -->				
					<div class="col-md-3 col-sm-6">
						<div class="footer-widget contact-widget">
							<h1>Liên hệ</h1>
							<p><i class="fa fa-map-marker"></i><strong>Họ Tên: </strong>Trần Thị Nhung</p>
							<p><i class="fa fa-phone"></i><strong>Phone: <a href="tel:+9687542521">0974772543</a></strong></p>
							<p><i class="fa fa-envelope"></i><strong>E-mail: <a href="mailto:trannhung.1206@gmail.com">trannhung.1206@gmail.com</a></strong></p>
						</div>
					</div><!-- footer-widget -->

					<!-- footer-widget -->				
					<div class="col-md-3 col-sm-6">
						<div class="footer-widget twitter-widget">
							<h1><span>Twitter</span> Feed</h1>
							<p><i class="fa fa-twitter"></i>Twitter</p>
							<p>Twitter là dịch vụ mạng xã hội trực tuyến cho phép người dùng gửi và đọc các tin nhắn ngắn 140 ký tự được gọi là "tweets".</p>
						</div>
					</div><!-- footer-widget -->

					<!-- footer-widget -->				
					<div class="col-md-3 col-sm-6">
						<div class="footer-widget instagram-widget">
							<h1><span>Facebook</span></h1>		
                            <p><i class="fa fa-facebook"></i> Facebook</p>
                            <p>
                            Facebook là một dịch vụ mạng xã hội trực tuyến có trụ sở tại Menlo Park, California. Trang web của nó đã được đưa ra vào ngày 4 tháng 2 năm 2004 bởi Mark Zuckerberg với bạn cùng phòng học đại học và sinh viên đại học Harvard Eduardo Saverin, Andrew McCollum, Dustin Moskovitz và Chris Hughes.
                            </p>					
						</div>
					</div><!-- footer-widget -->
				</div>
			</div>
		</div><!-- footer-widget-wrapper -->

		<!-- footer-bottom -->
		<div class="footer-bottom">
			<div class="container">
				<div class="row">				
					<div class="col-sm-8">
						<ul class="footer-menu list-inline">
							<li><a href="#">Trang chủ</a></li>
							<li><a href="#">Chia sẻ</a></li>
							<li><a href="#">Lấy thông tin người dùng</a></li>
							<li><a href="#">Thông báo</a></li>
							<li><a href="#">Giới thiệu</a></li>
							<li><a href="#">Liên hệ</a></li>
						</ul>
					</div>
				</div>
			</div>
		</div><!-- footer-bottom -->
	</footer>
    <!--/#footer-->
    <!-- Script -->
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.js" type="text/javascript"></script>
    </form>
</body>
</html>

