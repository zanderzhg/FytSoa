$(function () {
    btnBack();
});
var btnSaveTxt = "确定保存";
//返回上一页
function btnBack() {
    $(".btn-back").click(function () {
        history.go(-1);
    });
    $(".btn-dig-close").click(function () {
        dig.close();
    });
};

var fyt = {
    Success: function (res) {
        console.log(res);
        if (res.status == 200) {
            dig.alert(res.msg, function () {
                if (res.backurl != "" && res.backurl != "close") {
                    dig.close();
                    window.location = res.backurl;
                }
                if (res.backurl == "close") {
                    dig.close();
                }
            });
        } else {
            //提示信息
            dig.alertErr("错误提示", res.msg);
        }
        $(".btn-save").attr("disabled", false).html(btnSaveTxt);
    },
    SpSuccess: function (res) {
        if (res.status == 200) {
            dig.alert("提示", res.msg, function () {
                dig.close();
                window.location = "/fytadmin/sysbasic/index";
            });
        } else {
            //提示信息
            dig.alertErr("错误提示", res.msg);
        }
        $(".btn-save").attr("disabled", false).html(btnSaveTxt);
    },
    FsSuccess: function (res) {
        if (res.status == 200) {
            dig.alertCOk("提示", res.msg, function (index) {
                if (res.backurl != "" && res.backurl != "close") {
                    window.location = res.backurl;
                    dig.closesingle(index);
                    var ti = parent.layer.getFrameIndex(window.name); //获取窗口索引
                    parent.layer.close(ti);
                }
                if (res.backurl == "close") {
                    dig.closesingle(index);
                    var ti = parent.layer.getFrameIndex(window.name); //获取窗口索引
                    parent.layer.close(ti);
                }
            });
        } else {
            //提示信息
            dig.alertErr("错误提示", res.msg);
        }
    },
    Begin: function () {
        $(".btn-save").attr("disabled", "disabled").html('<i class="fa fa-spinner r360" aria-hidden="true"></i>');
    },
    Complete: function () {
        $(".btn-save").attr("disabled", false).html(btnSaveTxt);
    },
    Failure: function (res) {
        console.log(res);
        dig.alertErr("错误提示", "提交失败~");
    },
    asyncall: function () {
        $("#checkall").checkall({ chname: "checkbox_name", callback: function (e) { } });
        fyt.tabCbk();
    },
    tabCbk: function () {
        //单机行，选中复选框
        $(".table tr").slice(1).each(function (g) {
            var p = this;
            $(this).children().slice(1).click(function () {
                $($(p).children()[0]).children().each(function () {
                    if (this.type == "checkbox") {
                        if (!this.checked) {
                            this.checked = true;
                        } else {
                            this.checked = false;
                        }
                    }
                });
            });
        });
    },
    uEditors: function () {
        return [['FullScreen', 'Source', 'Undo', 'Redo', 'bold', 'italic', 'underline', 'test', 'forecolor', 'insertorderedlist', 'insertunorderedlist', 'fontfamily', 'fontsize',
            'link', 'unlink', 'lineheight', 'justifyleft', 'justifycenter', 'justifyright', 'indent', 'inserttable']];
    }
};

var dig = {
    //打开一个iframe窗口
    Open: function (title, url, width, height, fun) {
        top.layer.open({
            type: 2,
            title: title,
            shadeClose: true,
            shade: 0.3,
            maxmin: false, //开启最大化最小化按钮
            area: [width, height],
            content: url,
            zIndex: "10",
            end: function () {
                if (fun) fun();
            }
        });
    },
    //关闭所有
    close: function () {
        top.layer.closeAll();
    },
    //关闭单个
    closesingle: function (index) {
        top.layer.close(index);
    },
    //正确提示
    alert: function (msg, funcSuc) {
        top.layer.alert(msg, { icon: 6, title: '提示' }, function () {
            if (funcSuc) {
                funcSuc();
            } else {
                dig.close();
            }
        });
    },
    //正确提示
    alertCOk: function (msg, funcSuc) {
        top.layer.alert(msg, { icon: 6, title: '提示' }, function (index) {
            if (funcSuc) {
                funcSuc();
            } else {
                dig.close();
            }
        });
    },
    //错误提示
    alertErr: function (msg, funcSuc) {
        top.layer.alert(msg, { icon: 2, title: '提示' }, function () {
            if (funcSuc) {
                funcSuc();
            } else {
                dig.close();
            }
        });
    },
    //确认框=询问框
    confim: function (msg, funcSuc, funcErr) {
        top.layer.confirm(msg, {
            title: '提示',
            icon: 3,
            btn: ['确定', '取消'] //按钮
        }, function () {
            if (funcSuc) funcSuc();
        }, function () {
            if (funcErr) funcErr();
        });
    },
    //确认框=询问框(可自动关闭)
    confimclose: function (msg, funcSuc, funcErr) {
        top.layer.confirm(msg, {
            title: '提示',
            icon: 3,
            btn: ['确认', '取消'] //按钮
        }, function (index) {
            if (funcSuc) funcSuc(index);
        }, function () {
            if (funcErr) funcErr();
        });
    },
    //弹出一个输入的框
    prompts: function ( fun) {
        layer.prompt({
            title: '提示',
            formType: 1
        }, function (pass) {
            if (fun) fun(pass);
        });
    },
    //消息的提示
    msg: function (msg) {
        top.layer.msg(msg);
    },
    tips: function () {
        $(".tips").each(function () {
            $(this).mouseover(function () {
                layer.tips($(this).attr("title"), $(this),
                {
                    tips: [1, '#0FA6D8']
                });
            });
            $(this).mouseout(function () {
                layer.closeAll();
            });

        });
    }
};