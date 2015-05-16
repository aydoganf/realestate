<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>OzelHocaDersi.com Admin Panel | Login</title>

    <!-- Bootstrap -->
    <link href="/design/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300' rel='stylesheet' type='text/css'>
    <link href="/design/css/font-awesome.min.css" rel="stylesheet">
    <link href="/design/css/style.css" rel="stylesheet">
    <link href="/design/css/style-responsive.css" rel="stylesheet">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="middle-login"> 
                <div class="block-web">
                    <div class="head">
                        <h3 class="text-center"><%=SiteName %></h3>
                    </div>
                    <div style="background: #fff;">

                        <div class="content">
                            <h4 class="title">Login Access</h4>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                        <asp:TextBox ID="tbEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="text" class="form-control" id="username" placeholder="Username">--%>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" placeholder="Parola" CssClass="form-control"></asp:TextBox>
                                        <%--<input type="password" class="form-control" id="password" placeholder="Password">--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="foot">
                            <br /><br /><br /><br /><br />
                            <div class="clearfix"></div>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
                <div class="text-center out-links"><a href="#"><%=DateTime.Now.Year %> &copy;  Copyright <%=SiteName %> </a></div>
            </div>
        </div>

        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="/design/js/jquery-2.0.2.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="/design/bootstrap/js/bootstrap.min.js"></script>
        <script src="/design/js/accordion.js"></script>
        <script src="/design/js/common-script.js"></script>
        <script src="/design/js/jquery.nicescroll.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {

                $('#<%=btnLogin.ClientID%>').click(function () {

                    if ($('#<%=tbEmail.ClientID%>').val() == '' || $('#<%=tbPassword.ClientID%>').val() == '') {
                        alert('Lütfen email ve parola giriniz.');
                        return false;
                    }

                });

            });
        </script>
    </form>
</body>
</html>
