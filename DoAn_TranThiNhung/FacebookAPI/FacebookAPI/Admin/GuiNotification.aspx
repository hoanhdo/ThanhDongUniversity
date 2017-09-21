<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" MasterPageFile="~/Admin/Default.Master" CodeBehind="GuiNotification.aspx.cs" Inherits="FacebookAPI.Admin.GuiNotification" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div id="page-wrapper" >
		  <div class="header"> 
                        <h1 class="page-header">
                             Gửi thông báo
                        </h1>
						<ol class="breadcrumb">
					  <li><a href="#">Home</a></li>
					  <li class="active">Gửi thông báo</li>
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
                            Gửi thông báo
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-10">
                                    <form role="form">
                                        <div id="divthongbao" class="alert alert-success" runat="server">
									        <asp:Label ID="txtThongBao" runat="server"/>
								        </div>
                                        <div class="form-group">
                                            <label>Nội dung cần thông báo</label>
                                            <asp:TextBox id="txtNoiDungCanThongBao" TextMode="multiline" Columns="50" Rows="5" runat="server" CssClass="form-control" />
                                        </div>

                                        <div class="form-group">
                                            <label>Link cần chia sẻ</label>
                                            <asp:TextBox id="txtLink" Columns="50" runat="server" CssClass="form-control" />
                                        </div>

                                        <asp:Button ID="btnGuiThongBao" runat="server" Text="Thông báo" CssClass="btn btn-primary" OnClick="btnGuiThongBao_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Xóa nội dụng thông báo" CssClass="btn btn-danger" />
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
