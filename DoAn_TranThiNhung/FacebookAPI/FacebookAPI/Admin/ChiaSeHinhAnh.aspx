﻿<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin/Default.Master" CodeBehind="ChiaSeHinhAnh.aspx.cs" Inherits="FacebookAPI.Admin.ChiaSeHinhAnh" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div id="page-wrapper" >
		  <div class="header"> 
                        <h1 class="page-header">
                             Chia sẻ hình ảnh
                        </h1>
						<ol class="breadcrumb">
					  <li><a href="#">Home</a></li>
					  <li><a href="#">Chia sẻ</a></li>
					  <li class="active">Hình ảnh</li>
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
                            Chia sẻ hình ảnh
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-10">
                                    <form role="form">
                                        <div id="divthongbao" class="alert alert-success" runat="server">
									        <asp:Label ID="txtThongBao" runat="server"/>
								        </div>
                                        <div class="form-group">
                                            <label>Mô tả hình ảnh</label>
                                            <asp:TextBox id="txtMota" Columns="50" runat="server" CssClass="form-control" />
                                        </div>

                                        <div class="form-group">
                                            <label>Hình ảnh chia sẻ có sẵn</label>
                                            <asp:TextBox id="txtPhotoLink" Columns="50" runat="server" CssClass="form-control" />
                                        </div>
                                        
                                        <div class="form-group">
                                            <label>Hoặc hình ảnh từ máy của bạn</label>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </div>
                                        <p></p>
                                        <asp:Button ID="btnChiaSeHinhAnh" runat="server" Text="Chia sẻ" CssClass="btn btn-primary" OnClick="btnChiaSeHinhAnh_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Xóa nội dụng chia sẻ" CssClass="btn btn-danger" />
                                    </form>
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