mini.parse();
var grid = mini.get("datagrids");
var tempPageIndex = getQuery("pageIndex"), tempzPageSize = getQuery('pageSize');
grid.load();
if (tempPageIndex) {
    grid.gotoPage((tempPageIndex - 1), tempzPageSize);
}


//取值url
function getQuery(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}
$(function () {
    //添加
    $(".btn-add").click(function () {
        //判断是否弹出框还是跳转
        var isHref = $(this).attr("data-box");
        var url = $(this).attr("data-url");
        var par = $(this).attr("data-par");
        if (typeof(par)=="undefined"){par="";}
        var boxsize = $(this).attr("data-size");
        boxsize = boxsize.split("|"); 
        if (isHref == "1") {
            //弹出框
            dig.Open("添加", url + par, boxsize[0] + "px", boxsize[1] + "px", function () {
                grid.reload();
            });
        } else {
            //直接跳转链接，判断Url是否包含ID
            window.location.href = url + par;
        }
    });
    //刷新
    $("#tb-refresh").click(function () {
        grid.reload();
    });
    //删除
    $("#tb-delete").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confim("删除提示", "确定要删除选择的项目吗？", function () {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    if (typeof (r.ID) != "undefined") {
                        ids.push(r.ID);
                    } else {
                        ids.push(r.GUID);
                    }
                    
                }
                dig.close();
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { id: ids.join(',') },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
            });
        } else {
            dig.alertFa("提示", "请选择要删除的项！");
        }
    });
    $("#tb-cdelete").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confimclose("删除提示", "确定要删除选择的项目吗？", function (index) {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    ids.push(r.ID);
                }
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { id: ids.join(',') },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
                dig.closesingle(index);
            });
        } else {
            dig.alertFa("提示", "请选择要删除的项！");
        }
    });
    //编辑
    $("#tb_Modfiy").click(function () {
        //判断是否弹出框还是跳转
        var isHref = $(this).attr("data-box");
        var url = $(this).attr("data-url");
        var par = $(this).attr("data-par");
        var rows = grid.getSelecteds();
        var ids = [];
        if (rows.length > 0) {
            for (var i = 0, l = rows.length; i < l; i++) {
                var r = rows[i];
                if (typeof (r.ID) != "undefined") {
                    ids.push(r.ID);
                } else {
                    ids.push(r.GUID);
                }
            }
            if (ids.length > 1) {
                dig.alertFa("提示", "编辑只能选择一条，请重新选择！");
                return;
            }
            if (isHref == "1") {
                //弹出框
                dig.Open("编辑", url + ids[0] + par, $(this).attr("data-width"), $(this).attr("data-height"), function () {
                    grid.reload();
                });
            } else {
                //直接跳转链接，判断Url是否包含ID
                window.location.href = url + ids[0] + par;
            }
        } else {
            dig.alertFa("提示", "请选择要编辑的项！");
        }
    });
    //审核通过
    $("#tb-audit").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confim("状态修改提示", "确定要修改所选项状态吗？", function () {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    ids.push(r.ID);
                }
                dig.close();
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { ids: ids.join(','), types: "1" },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
            });
        } else {
            dig.alertFa("提示", "请选择要修改的项！");
        }
    });
    $("#tb-caudit").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confimclose("状态修改提示", "确定要修改所选项状态吗？", function (index) {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    ids.push(r.ID);
                }
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { ids: ids.join(','), types: "1" },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
                dig.closesingle(index);
            });
        } else {
            dig.alertFa("提示", "请选择要修改的项！");
        }
    });
    //审核不通过
    $("#tb-unaudit").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confim("状态修改提示", "确定要修改所选项状态吗？", function () {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    ids.push(r.ID);
                }
                dig.close();
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { ids: ids.join(','), types: "2" },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
            });
        } else {
            dig.alertFa("提示", "请选择要修改的项！");
        }
    });
    $("#tb-cunaudit").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confimclose("状态修改提示", "确定要修改所选项状态吗？", function (index) {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    ids.push(r.ID);
                }
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { ids: ids.join(','), types: "2" },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
                dig.closesingle(index);
            });
        } else {
            dig.alertFa("提示", "请选择要修改的项！");
        }
    });
    //设为精华
    $("#tb-popular").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confim("状态修改提示", "确定要修改所选项状态吗？", function () {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    ids.push(r.ID);
                }
                dig.close();
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { ids: ids.join(','), types: "1" },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
            });
        } else {
            dig.alertFa("提示", "请选择要修改的项！");
        }
    });
    //取消精华
    $("#tb-unpopular").click(function () {
        var urls = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            dig.confim("状态修改提示", "确定要修改所选项状态吗？", function () {
                var ids = [];
                for (var i = 0, l = rows.length; i < l; i++) {
                    var r = rows[i];
                    ids.push(r.ID);
                }
                dig.close();
                $.ajax({
                    type: "post",
                    url: urls,
                    data: { ids: ids.join(','), types: "2" },
                    success: function (res) {
                        if (res.status == "y") {
                            grid.reload();
                        } else {
                            dig.alertErr("错误提示", res.msg);
                        }
                    }
                });
            });
        } else {
            dig.alertFa("提示", "请选择要修改的项！");
        }
    });
    //商品加入活动
    $("#tb-addactivity").click(function () {
        var url = $(this).attr("data-url");
        var rows = grid.getSelecteds();
        if (rows.length > 0) {
            var ids = [];
            for (var i = 0, l = rows.length; i < l; i++) {
                var r = rows[i];
                ids.push(r.ID);
            }
            //弹出框
            dig.Open("选择活动", url + ids.join(','), $(this).attr("data-width"), $(this).attr("data-height"), function () {
                grid.reload();
            });
        } else {
            dig.alertFa("提示", "请选择要加入活动的项！");
        }
    });
});