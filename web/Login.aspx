<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
<meta charset="utf-8"/>
<title>Metronic | Admin Dashboard Template</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1.0" name="viewport"/>
<meta content="" name="description"/>
<meta content="" name="author"/>
<meta name="MobileOptimized" content="320">
<!-- BEGIN GLOBAL MANDATORY STYLES -->
<link href="/admin/design/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="/admin/design/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="/admin/design/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="/admin/design/plugins/select2/select2_metro.css"/>
<!-- END PAGE LEVEL SCRIPTS -->
<!-- BEGIN THEME STYLES -->
<link href="/admin/design/css/style-metronic.css" rel="stylesheet" type="text/css"/>
<link href="/admin/design/css/style.css" rel="stylesheet" type="text/css"/>
<link href="/admin/design/css/style-responsive.css" rel="stylesheet" type="text/css"/>
<link href="/admin/design/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="/admin/design/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
<link href="/admin/design/css/pages/login.css" rel="stylesheet" type="text/css"/>
<link href="/admin/design/css/custom.css" rel="stylesheet" type="text/css"/>
<!-- END THEME STYLES -->
<link rel="shortcut icon" href="favicon.ico"/>
</head>
<!-- BEGIN BODY -->
<body class="login">
<!-- BEGIN LOGO -->
<div class="logo" style="color:white">
	<%--<img src="/admin/design/img/logo-big.png" alt=""/>--%>
    <%=SiteName %>
</div>
<!-- END LOGO -->
<!-- BEGIN LOGIN -->
<div class="content">
	<!-- BEGIN LOGIN FORM -->
	<form class="login-form" id="form1" runat="server">
		<h3 class="form-title">Admin paneline giris yapın</h3>
		<div class="alert alert-danger display-hide">
			<button class="close" data-close="alert"></button>
			<span>
				 Enter any username and password.
			</span>
		</div>
        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
		    <div class="form-group">
			    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
			    <label class="control-label visible-ie8 visible-ie9">Username</label>
			    <div class="input-icon">
				    <i class="fa fa-user"></i>
                    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Email"></asp:TextBox>				
			    </div>
		    </div>
		    <div class="form-group">
			    <label class="control-label visible-ie8 visible-ie9">Password</label>
			    <div class="input-icon">
				    <i class="fa fa-lock"></i>
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control placeholder-no-fix" placeholder="Şifre" TextMode="Password"></asp:TextBox>
			    </div>
		    </div>
		    <div class="form-actions">
                <asp:Button ID="btnLogin" runat="server" Text="Giriş Yap" CssClass="btn green pull-right" OnClick="btnLogin_Click" />            
		    </div>
        </asp:Panel>
		
	</form>
	<!-- END LOGIN FORM -->
</div>
<!-- END LOGIN -->
<!-- BEGIN COPYRIGHT -->
<div class="copyright">
	 <%=DateTime.Now.Year %> &copy; <%=SiteName %>. Admin Paneli.
</div>
<!-- END COPYRIGHT -->
<!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
<!-- BEGIN CORE PLUGINS -->
<!--[if lt IE 9]>
	<script src="/admin/design/plugins/respond.min.js"></script>
	<script src="/admin/design/plugins/excanvas.min.js"></script> 
	<![endif]-->
<script src="/admin/design/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="/admin/design/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
<script src="/admin/design/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="/admin/design/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
<script src="/admin/design/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="/admin/design/plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="/admin/design/plugins/jquery.cokie.min.js" type="text/javascript"></script>
<script src="/admin/design/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
<!-- END CORE PLUGINS -->
<!-- BEGIN PAGE LEVEL PLUGINS -->
<script src="/admin/design/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>
<script type="text/javascript" src="/admin/design/plugins/select2/select2.min.js"></script>
<!-- END PAGE LEVEL PLUGINS -->
<!-- BEGIN PAGE LEVEL SCRIPTS -->
<script src="/admin/design/scripts/app.js" type="text/javascript"></script>
<script src="/admin/design/scripts/login.js" type="text/javascript"></script>
<!-- END PAGE LEVEL SCRIPTS -->
<script>
    jQuery(document).ready(function () {
        App.init();
        Login.init();
    });
	</script>
<!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>