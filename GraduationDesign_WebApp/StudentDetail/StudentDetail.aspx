<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDetail.aspx.cs" Inherits="GraduationDesign_WebApp.StudentDetail.StudentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../css/PageBarStyle.css" rel="stylesheet" />
    <link href="../css/tableStyle.css" rel="stylesheet" />
    <link href="../css/themes/icon.css" rel="stylesheet" />
    <link href="../css/themes/metro/easyui.css" rel="stylesheet" />    
    <script src="../js/jquery-3.2.1.js"></script>
    <script src="../js/jquery.easyui.min.js"></script>
    <script src="../js/easyui-lang-zh_CN.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#showDetail").css("display", "none");
            $("#addStudentDetailDiv").css("display", "none");
            $("#editStudentDetailDiv").css("display", "none");

            //绑定添加事件
            $("#addStudentDetail").click(function () {
                showAddTbStudentDetail();

            });


            loadTbStudentList();

        });


        //加载用户列表
        function loadTbStudentList(pageIndex) {
            $.post("StudentDetail.ashx", { "pageIndex": pageIndex }, function (data) {
                var serverData = $.parseJSON(data);
                var serverDataLenth = serverData.studentList.length;
                for (var i = 0; i < serverDataLenth; i++) {
                    $("<tr><td>" + serverData.studentList[i].student_id + "</td><td>" + serverData.studentList[i].student_name + "</td><td>" + serverData.studentList[i].student_sex + "</td><td><a href='javascript:void(0)' class='detail' nID='" + serverData.studentList[i].student_id + "'>详细信息</a></td><td><a href='javascript:void(0)' class='delete' nID='" + serverData.studentList[i].student_id + "'>删除</a></td><td><a href='javascript:void(0)' class='edit' nID='" + serverData.studentList[i].student_id + "'>编辑</a></td></tr>").appendTo("#tableList tbody");
                }



                //页码条绑定在DIV上
                $("#showPageBar").html(serverData.myPageBar);



                //数据全部加载到表格上以后，捕获“详细”超链接
                blindDetailClickEvent();
                blindDeleteClickEvent();
                blindEditClickEvent();
                blindPageBarClickEvent();//分页的超链接加上单击事件





            });
        }



        //展示添加学生信息界面
        function showAddTbStudentDetail() {
            $("#addStudentDetailDiv").css("display", "block");

            $('#addStudentDetailDiv').dialog({
                title: '添加学生信息',
                collapsible: true,
                modal: true,


                buttons: [
                    {
                        text: '确定',
                        iconCLs: 'icon-ok',
                        handler: function () {
                            //将添加表单中的数据通过异步方式发送到服务器
                            addStudentDetail();
                        }
                    },

                    {
                        text: '取消',
                        handler: function () {
                            $('#addStudentDetailDiv').dialog('close');
                        }
                    }]
            });
        }

        //添加学生
        function addStudentDetail() {
            //获取表单中用户输入的值，序列化为json格式（必须加name属性）
            var serverData = $("#addStudentDetailForm").serializeArray();
            $.post("AddStudentDetail.ashx", serverData, function (data) {
                if (data == "y") {
                    //清空表单中的旧数据
                    $("#addStudentDetailForm input").val("");



                    //关闭添加用户的窗口
                    $('#addStudentDetailDiv').dialog('close');


                    $("#tableList tbody").html("");
                    loadTbStudentList();


                    $.messager.show(
                        {
                            title: '添加提示',
                            msg: '添加成功',
                            showType: 'show',
                            style: {
                                right: '',
                                bottom: ''
                            }
                        }
                    );





                }
                else {
                    $.messager.alert("提示", "添加失败", "error");
                }
            });

        }

















        //分页的超链接加上单击事件
        function blindPageBarClickEvent() {
            $(".myPageBar").click(function () {
                var pageIndex = $(this).attr("href").split('=')[1];
                $("#tableList tbody").html("");
                loadTbStudentList(pageIndex);

                return false;
            });
        }

        //展示学生详细信息
        function blindDetailClickEvent() {
            $(".detail").click(function () {
                //获取本行的ID值
                var id = $(this).attr("nID");

                //发送异步请求
                $.post("ShowStudentDetail.ashx", { "id": id }, function (data) {

                    var serverData = $.parseJSON(data);
                    $("#txtStudentName").text(serverData.student_name);
                    $("#txtStudentID").text(serverData.student_id);
                    $("#txtStudentSex").text(serverData.student_sex);

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





        //展示编辑学生信息
        function blindEditClickEvent() {
            $(".edit").click(function () {
                //展示一下要修改的数据，并且将修改的数据填充到表单元素中。
                var id = $(this).attr("nID");
                $.post("ShowStudentDetail.ashx", { "id": id }, function (data) {
                    var serverData = $.parseJSON(data);
                    $("#txtEditStudentDetailName").val(serverData.student_name);
                    $("#txtEditStudentDetailID").val(serverData.student_id);
                    $("#txtEditStudentDetailSex").val(serverData.student_sex);



                    $("#editStudentDetailDiv").css("display", "block");

                    $('#editStudentDetailDiv').dialog({
                        title: '编辑学生信息',
                        collapsible: true,
                        modal: true,


                        buttons: [
                            {
                                text: '确定',
                                iconCLs: 'icon-ok',
                                handler: function () {
                                    //将添加表单中的数据通过异步方式发送到服务器
                                    editStudentDetail();
                                }
                            },

                            {
                                text: '取消',
                                handler: function () {
                                    $('#editStudentDetailDiv').dialog('close');
                                }
                            }]
                    });




                });

            });
        }


        //完成编辑用学生信息
        function editStudentDetail() {

            var serverData = $("#editStudentDetailForm").serializeArray();
            $.post("EditStudentDetail.ashx", serverData, function (data) {
                if (data == "y") {

                    //关闭添加用户的窗口
                    $('#editStudentDetailDiv').dialog('close');


                    $("#tableList tbody").html("");
                    loadTbStudentList();


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


        //删除学生数据
        function blindDeleteClickEvent() {
            $(".delete").click(function () {
                //获取用户ID
                var id = $(this).attr("nID");

                $.messager.confirm("提示", "确定要删除吗？", function (r) {

                    if (r) {
                        //发送异步请求进行删除
                        $.post("DeleteStudentDetail.ashx", { "id": id }, function (data) {
                            if (data == "y") {
                                $("#tableList tbody").html("");
                                loadTbStudentList();



                                $.messager.show(
                                    {
                                        title: '删除提示',
                                        msg: '删除成功',
                                        showType: 'show',
                                        style: {
                                            right: '',
                                            bottom: ''
                                        }
                                    }
                                );


                            }
                            else {
                                $.messager.alert("提示", "删除失败", "error");
                            }

                        });
                    }
                });
            });
        }







        </script>


    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
        
    
        <a href="javascript:void(0)" id="addStudentDetail">添加学生</a>

        <table id="tableList">
        <thead>
        <tr><th>学生ID</th><th>学生姓名</th><th>学生性别</th><th>详细信息</th><th>删除</th><th>编辑</th></tr>
            </thead>
        <tbody></tbody>
        </table>

    
    <!--------展示页码条------->
    <div id="showPageBar" class="page_nav"></div>


        <!--------展示详细信息---------->
    <div id="showDetail">
        <table>
            <tr><td>学生ID</td><td><span id="txtStudentID"/></td></tr>
            <tr><td>学生姓名</td><td><span id="txtStudentName"/></td></tr>
            <tr><td>用户性别</td><td><span id="txtStudentSex"/></td></tr>

        </table>
        </div>
     <!--------展示详细信息结束---------->



         <!--------编辑学生信息---------->
    <div id="editStudentDetailDiv">
        <form id="editStudentDetailForm">
            <input type="hidden" name="editStudentDetailID" id="txtEditStudentDetailID"/>
            <table>
                <tr><td>学生姓名</td><td><input name="editStudentDetailName" id="txtEditStudentDetailName" type="text"/></td></tr>
                <tr><td>用户性别</td><td><input name="editStudentDetailSex" id="txtEditStudentDetailSex" type="text"/></td></tr>
            </table>
        </form>


    </div>
     <!--------编辑学生信息---------->


    
     <!--------添加学生---------->
    <div id="addStudentDetailDiv">
        <form id="addStudentDetailForm">
            <table>
                <tr><td>学生姓名</td><td><input name="studentName" type="text"/></td></tr>
                <tr><td>学生性别</td><td><input name="studentSex" type="text"/></td></tr>
            </table>
        </form>


    </div>
     <!--------添加用户结束---------->



</body>
</html>
