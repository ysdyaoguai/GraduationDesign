<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TB_USER_LIST.aspx.cs" Inherits="GraduationDesign_WebApp.TB_USER_LIST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/tableStyle.css" rel="stylesheet" />
    <link href="css/themes/metro/easyui.css" rel="stylesheet" />
    <link href="css/themes/icon.css" rel="stylesheet" />
    <link href="css/PageBarStyle.css" rel="stylesheet" />
    <script src="js/jquery-3.2.1.js"></script>
    <script src="js/jquery.easyui.min.js"></script>
    <script src="js/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript">
        $(function ()
        {
            $("#showDetail").css("display", "none");
            $("#addUserDiv").css("display", "none");
            $("#editUserDiv").css("display", "none");

            //绑定添加事件
            $("#addUser").click(function () {
                showAddTbUser();

            });


            loadTbUserList();

        });

        //展示添加用户信息界面
        function showAddTbUser()
        {
            $("#addUserDiv").css("display", "block");

            $('#addUserDiv').dialog({
                title: '添加用户信息',
                collapsible: true,
                modal: true,


                buttons: [
                    {
                        text: '确定',
                        iconCLs: 'icon-ok',
                        handler: function () {
                            //将添加表单中的数据通过异步方式发送到服务器
                            addTbUser();
                        }
                    },

                    {
                    text: '取消',
                    handler: function () {
                        $('#addUserDiv').dialog('close');
                    }
                }]
            });
        }

        //添加用户
        function addTbUser()
        {
            //获取表单中用户输入的值，序列化为json格式（必须加name属性）
            var serverData = $("#addUserForm").serializeArray();
            $.post("AddTbUser.ashx", serverData, function (data) {
                if (data == "y")
                {
                    //清空表单中的旧数据
                    $("#addUserForm input").val("");



                    //关闭添加用户的窗口
                    $('#addUserDiv').dialog('close');


                    $("#tableList tbody").html("");
                    loadTbUserList();
                }
                else
                {
                    $.messager.alert("提示", "添加失败", "error");
                }
            });

        }

        //加载用户列表
        function loadTbUserList(pageIndex)
        {
            $.post("TB_USER_LIST.ashx", { "pageIndex": pageIndex }, function (data)
            {
                var serverData = $.parseJSON(data);
                var serverDataLenth = serverData.userList.length;
                for (var i = 0; i < serverDataLenth; i++)
                {
                    $("<tr><td>" + serverData.userList[i].UserID + "</td><td>" + serverData.userList[i].UserName + "</td><td>" + serverData.userList[i].UserType + "</td><td>" + serverData.userList[i].UserPwd + "</td><td>" + ChangeDateFormat(serverData.userList[i].UserRegTime) + "</td><td><a href='javascript:void(0)' class='detail' nID='" + serverData.userList[i].UserID + "'>详细信息</a></td><td><a href='javascript:void(0)' class='delete' nID='" + serverData.userList[i].UserID + "'>删除</a></td><td><a href='javascript:void(0)' class='edit' nID='" + serverData.userList[i].UserID + "'>编辑</a></td></tr>").appendTo("#tableList tbody");
                }



                //页码条绑定在DIV上
                $("#showPageBar").html(serverData.myPageBar);



                //数据全部加载到表格上以后，捕获“详细”超链接
                blindDetailClickEvent();
                blindDeleteClickEvent();
                blindEditClickEvent();
                binndPageBarClickEvent();//分页的超链接加上单击事件





            });
        }



        //分页的超链接加上单击事件
        function binndPageBarClickEvent()
        {
            $(".myPageBar").click(function () {
                var pageIndex = $(this).attr("href").split('=')[1];
                $("#tableList tbody").html("");
                loadTbUserList(pageIndex);




                return false;
            });
        }



        //展示编辑用户信息
        function blindEditClickEvent()
        {
            $(".edit").click(function () {
                //展示一下要修改的数据，并且将修改的数据填充到表单元素中。
                var id = $(this).attr("nID");
                $.post("ShowTbUserDetail.ashx", { "id": id }, function (data) {
                    var serverData = $.parseJSON(data);
                    $("#txtEditUserId").val(serverData.UserID);
                    $("#txtEditUserRegTime").val(ChangeDateFormat(serverData.UserRegTime));
                    $("#txtEditUserName").val(serverData.UserName);
                    $("#txtEditUserPwd").val(serverData.UserPwd);
                    $("#txtEditUserType").val(serverData.UserType);


                    $("#editUserDiv").css("display", "block");

                    $('#editUserDiv').dialog({
                        title: '编辑用户信息',
                        collapsible: true,
                        modal: true,


                        buttons: [
                            {
                                text: '确定',
                                iconCLs: 'icon-ok',
                                handler: function () {
                                    //将添加表单中的数据通过异步方式发送到服务器
                                    editTbUser();
                                }
                            },

                            {
                                text: '取消',
                                handler: function () {
                                    $('#editUserDiv').dialog('close');
                                }
                            }]
                    });




                });

            });
        }


        //完成编辑用户信息
        function editTbUser()
        {

            var serverData = $("#editUserForm").serializeArray();
            $.post("EditTbUser.ashx", serverData, function (data) {
                if (data == "y") {

                    //关闭添加用户的窗口
                    $('#editUserDiv').dialog('close');


                    $("#tableList tbody").html("");
                    loadTbUserList();


                    $.messager.show(
                        {
                            title: '修改提示',
                            msg: '修改成功',
                            showType: 'show',				
                            style: {
                                right: '',
                                bottom: ''
                            }
                        }
                    );

                }
                else {
                    $.messager.alert("提示", "编辑失败", "error");
                }

            });


        }



        //展示用户详细信息
        function blindDetailClickEvent()
        {
            $(".detail").click(function () {
                //获取本行的ID值
                var id = $(this).attr("nID");

                //发送异步请求
                $.post("ShowTbUserDetail.ashx", { "id": id }, function (data) {

                    var serverData = $.parseJSON(data);
                    $("#txtUserName").text(serverData.UserName);
                    $("#txtUserID").text(serverData.UserID);
                    $("#txtUserPwd").text(serverData.UserPwd);
                    $("#txtUserType").text(serverData.UserType);
                    $("#txtUserRegTime").text(ChangeDateFormat(serverData.UserRegTime));

                    $("#showDetail").css("display", "block");



                    $('#showDetail').dialog({
                        title: '详细信息',
                        collapsible: true,
                        modal: true,


                        buttons: [{
                            text: '确定',
                            handler: function () {
                                $('#showDetail').dialog('close');
                            }
                        }]
                    });
                });
            });
        }

        //删除用户数据
        function blindDeleteClickEvent()
        {
            $(".delete").click(function () {
                //获取用户ID
                var id = $(this).attr("nID");

                $.messager.confirm("提示", "确定要删除吗？", function (r) {

                    if (r)
                    {
                        //发送异步请求进行删除
                        $.post("DeleteTbUser.ashx", { "id": id }, function (data) {
                            if (data == "y") {
                                $("#tableList tbody").html("");
                                loadTbUserList();
                            }
                            else
                            {
                                $.messager.alert("提示", "删除失败", "error");
                            }

                        });
                    }
                });
            });
        }

        //将序列化成json格式后日期(毫秒数)转成日期格式
        function ChangeDateFormat(cellval) {
            var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
            //getMonth()从0开始算
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            return date.getFullYear() + "-" + month + "-" + currentDate;
        }



    </script> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>

    <a href="javascript:void(0)" id="addUser">添加用户</a>


    <table id="tableList">
        <thead>
        <tr><th>用户ID</th><th>用户名</th><th>用户类型</th><th>用户密码</th><th>注册时间</th><th>详细信息</th><th>删除</th><th>编辑</th></tr>
            </thead>
        <tbody></tbody>
        </table>

    <!--------展示页码条------->
    <div id="showPageBar" class="page_nav"></div>


    <!--------展示详细信息---------->
    <div id="showDetail">
        <table>
            <tr><td>用户ID</td><td><span id="txtUserID"/></td></tr>
            <tr><td>用户名</td><td><span id="txtUserName"/></td></tr>
            <tr><td>用户类型</td><td><span id="txtUserType"/></td></tr>
            <tr><td>用户密码</td><td><span id="txtUserPwd"/></td></tr>
            <tr><td>注册时间</td><td><span id="txtUserRegTime"/></td></tr>

        </table>
        </div>
     <!--------展示详细信息结束---------->


     <!--------添加用户---------->
    <div id="addUserDiv">
        <form id="addUserForm">
            <table>
                <tr><td>用户名</td><td><input name="userName" type="text"/></td></tr>
                <tr><td>用户类型</td><td><input name="userType" type="text"/></td></tr>
                <tr><td>用户密码</td><td><input name="userPwd" type="password"/></td></tr>
            </table>
        </form>


    </div>
     <!--------添加用户结束---------->

     <!--------编辑用户---------->
    <div id="editUserDiv">
        <form id="editUserForm">
            <input type="hidden" name="editUserId" id="txtEditUserId"/>
            <input type="hidden" name="editUserRegTime" id="txtEditUserRegTime"/>
            <table>
                <tr><td>用户名</td><td><input name="editUserName" id="txtEditUserName" type="text"/></td></tr>
                <tr><td>用户类型</td><td><input name="editUserType" id="txtEditUserType" type="text"/></td></tr>
                <tr><td>用户密码</td><td><input name="editUserPwd" id="txtEditUserPwd" type="password"/></td></tr>
            </table>
        </form>


    </div>
     <!--------编辑用户结束---------->


</body>
</html>
