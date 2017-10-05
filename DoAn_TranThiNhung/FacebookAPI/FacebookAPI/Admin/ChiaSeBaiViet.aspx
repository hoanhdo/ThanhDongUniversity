<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Default.Master" EnableEventValidation="false" CodeBehind="ChiaSeBaiViet.aspx.cs" Inherits="FacebookAPI.Admin.ChiaSeBaiViet" %>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div id="page-wrapper" >
		  <div class="header"> 
                        <h1 class="page-header">
                             Chia sẻ bài viết
                        </h1>
						<ol class="breadcrumb">
					  <li><a href="#">Home</a></li>
					  <li><a href="#">Chia sẻ</a></li>
					  <li class="active">Bài viết</li>
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
                            Chia sẻ nội dung bài viết của mình lên Facebook, danh sách bạn bè cũng nhìn thấy nội dung
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Chia sẻ bài viết
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-10">
                                    <form role="form">
                                        <div id="divthongbao" class="alert alert-success" runat="server">
									        <asp:Label ID="txtThongBao" runat="server"/>
								        </div>
                                        <div class="form-group">
                                            <label>Nội dung cần chia sẻ</label>
                                            <asp:TextBox id="txtNoiDungCanChiaSe" TextMode="multiline" Columns="50" Rows="5" runat="server" CssClass="form-control" />
                                        </div>
							
                                        <div class="form-group">
                                            <label>Link chia sẻ</label>
                                            <asp:TextBox id="txtLinkChiaSe" Columns="50" runat="server" CssClass="form-control" />
                                        </div>

                                        <div class="form-group">
                                            <label>Ảnh chia sẻ</label>
                                            <asp:TextBox id="txtAnhChiaSe" Columns="50" runat="server" CssClass="form-control" />
                                        </div>
                                        
                                        <asp:Button ID="btnChiaSeBaiViet" runat="server" Text="Chia sẻ" CssClass="btn btn-primary" OnClick="btnChiaSeBaiViet_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Xóa nội dụng chia sẻ" CssClass="btn btn-danger" OnClick="btnReset_Click" />
                                    <//form>
                                </div>
                                <!-- /.col-lg-6 (nested) -->
                                <!-- /.col-lg-6 (nested) -->
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
