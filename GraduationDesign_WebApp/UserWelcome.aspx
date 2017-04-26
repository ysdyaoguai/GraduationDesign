<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWelcome.aspx.cs" Inherits="GraduationDesign_WebApp.UserWelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">

        window.onload = function () {
            setTimeout(jump, 3000);
        }

        function jump() {

            var url = document.getElementById("url").href;
            window.location.href = url;
        }

</script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Home.aspx" id="url">点此立即跳转</a>
        </div>
    </form>
</body>
</html>
