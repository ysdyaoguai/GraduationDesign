<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="GraduationDesign_WebApp.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>


        <script src="js/jquery-3.2.1.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#UserName").blur(function ()
            {
                var username = $(this).val();
                if (username != "") {
                    $("#MsgUserName").text("");
                    $.post("SignUp.ashx", { "name": username }, function (data)
                    {
                        $("#MsgUserName").text(data);

                    });

                }
                else
                {
                    $("#MsgUserName").text("用户名不能为空！");
                }
            });

            $("#UserPwd").blur(function () {
                var username = $(this).val();
                if (username != "") {
                    $("#MsgUserPwd").text("");

                }
                else {
                    $("#MsgUserPwd").text("密码不能为空！");
                }
            });


        });



    </script>




</head>
<body>
    <form id="form1" runat="server">
        <div>
            用户名：
            <input type="text" name="UserName" id="UserName"/>
            <asp:Label ID="MsgUserName" runat="server"></asp:Label>
            <br/>
            密码：
            <input type="password" name="UserPwd" id="UserPwd"/>
            <asp:Label ID="MsgUserPwd" runat="server"></asp:Label>
            <br/>
            用户类型(admin/user)：
            <select id="UserType" name="UserType">
                <option>admin</option>
                <option>user</option>
            </select>
            <br/>
        <asp:Button ID="BtnSignUp" runat="server" Text="注册" />
            <br/>
        </div>
    </form>
</body>
</html>
