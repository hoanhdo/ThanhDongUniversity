<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Default.Master" CodeBehind="LayThongTinNguoiDung.aspx.cs" Inherits="FacebookAPI.Admin.LayThongTinNguoiDung" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <!-- /. NAV SIDE  -->
        <div id="page-wrapper" >
		  <div class="header"> 
                        <h1 class="page-header">
                             Thông tin người dùng
                        </h1>
						<ol class="breadcrumb">
					  <li><a href="#">Home</a></li>
					  <li class="active">Thông tin người dùng</li>
					</ol> 
									
		</div>
		
            <div id="page-inner"> 
              <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            Mô tả chức năng
                        </div>
                        <div class="panel-body">
                            Mô tả chức năng
                        </div>
                    </div>
                  <!--   Kitchen Sink -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Thông tin người dùng
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Tên</th>
                                            <th>Ảnh đại diện</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="ListView1" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("num") %></td>
                                                    <td><%# Eval("name") %></td>
                                                    <td><img src="<%# Eval("picture_link") %>" /></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
			<footer><p>FacebookAPI, Trần Thị Nhung</p></footer>
			</div>
             <!-- /. PAGE INNER  -->
            </div>
         <!-- /. PAGE WRAPPER  -->

    </asp:Content>
