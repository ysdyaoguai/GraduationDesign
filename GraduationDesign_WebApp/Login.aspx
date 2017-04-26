<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GraduationDesign_WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-3.2.1.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#TbUserName").blur(function ()
            {
                var username = $(this).val();
                if (username != "") {
                    $("#MsgUserName").text("");

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


            $("#BtnLogin").click(function ()
            {
                userLogin();
            });

            //用户登录
            function userLogin()
            {
                var userName = document.getElementById("<%=TbUserName.ClientID%>").value;
                var userPwd = document.getElementById("<%=TbUserPwd.ClientID%>").value;
                
                if (userName != "" && userPwd != "")
                {
                    $.post("Login.ashx", { "userName": userName, "userPwd": userPwd }, function (data)
                    {
                        var serverData = data.split(':');
                        

                        if (serverData[0] == "yes") {
                            window.location.href = "UserWelcome.aspx";
                        }
                        else
                        {
                            $("#msg").text(serverData[1]);
                        }
                    });



                }
                else if (userName == "") {
                    $("");
                    $("#MsgUserName").text("用户名不能为空！");
                }
                else if (userPwd == "") {
                    $("#MsgUserName").text("");
                    $("#MsgUserPwd").text("密码不能为空！");
                }
                else if (userName == "" && userPwd == "")
                {
                    $("#MsgUserName").text("用户名不能为空！");
                    $("#MsgUserPwd").text("密码不能为空！");
                }

            }


        });



    </script>


    <link href="css/tableStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" action="Login.aspx">
        <div>
            <asp:Label ID="LbUserName" runat="server" Text="用户名："></asp:Label>
            <asp:TextBox ID="TbUserName" runat="server"></asp:TextBox>
            <asp:Label ID="MsgUserName" runat="server"></asp:Label>
            <br/>
            <asp:Label ID="LbUserPwd" runat="server" Text="密码："></asp:Label>
            <asp:TextBox ID="TbUserPwd" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Label ID="MsgUserPwd" runat="server"></asp:Label>
            <br/>
            <input type="button" id="BtnLogin" value="登录"/>
            <a href="SignUp.aspx">没有账户？用户注册</a>
            <span id="ErrorMsg"><%=ErrorMsg %></span>
        </div>
    </form>
</body>
</html>
