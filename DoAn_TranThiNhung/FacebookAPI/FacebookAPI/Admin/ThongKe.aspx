<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Default.Master" CodeBehind="ThongKe.aspx.cs" Inherits="FacebookAPI.Admin.ThongKe" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div id="page-wrapper" >
		  <div class="header"> 
                        <h1 class="page-header">
                             Thống kê
                        </h1>
						<ol class="breadcrumb">
					  <li><a href="#">Home</a></li>
					  <li class="active">Thống kê</li>
					</ol> 
									
		</div>
		
            <div id="page-inner"> 
              <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Mô tả chức năng
                        </div>
                        <div class="panel-body">
                            Mô tả chức năng
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Thống kê
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-sm-12 col-xs-12">
                                    <div class="panel panel-primary text-center no-boder blue">
                                        <div class="panel-left pull-left blue">
                                            <i class="fa fa-eye fa-5x"></i>
                                        </div>
                                        <div class="panel-right">
								            <h3>
                                                <asp:Label ID="lblTotalPage" runat="server" Text="Label"></asp:Label> &nbsp;</h3>
                                           <strong> Số lượng Page hiện đang quản trị</strong>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12 col-xs-12">
                                    <div class="panel panel-primary text-center no-boder blue">
                                          <div class="panel-left pull-left blue">
                                            <i class="fa fa-users fa-5x"></i>
								            </div>
                                
                                        <div class="panel-right">
							            <h3>
                                            <asp:Label ID="lblTotalLike" runat="server" Text="Label"></asp:Label> &nbsp; </h3>
                                           <strong> Số lượng like của trang Page: Túi xinh rẻ đẹp chất lượng</strong>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-12 col-xs-12">
                                    <div class="panel panel-primary text-center no-boder blue">
                                        <div class="panel-left pull-left blue">
                                            <i class="fa fa-bell fa-5x"></i>
                                
                                        </div>
                                        <div class="panel-right">
							            <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTotalFriends" runat="server" Text="Label"></asp:Label>  &nbsp;&nbsp;&nbsp;&nbsp; </h3>
                                        <strong>Bạn bè  </strong>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
			<footer><p>FacebookAPI, Trần Thị Nhung</p></footer>
			</div>
             <!-- /. PAGE INNER  -->
            </div>
         <!-- /. PAGE WRAPPER  -->
</asp:Content>


    