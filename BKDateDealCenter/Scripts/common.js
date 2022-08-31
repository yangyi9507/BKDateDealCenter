function getiev() {
    //var userAgent = window.navigator.userAgent.toLowerCase();
    //$.browser.msie8 = $.browser.msie && /msie 8\.0/i.test(userAgent);
    //$.browser.msie7 = $.browser.msie && /msie 7\.0/i.test(userAgent);
    //$.browser.msie6 = !$.browser.msie8 && !$.browser.msie7 && $.browser.msie && /msie 6\.0/i.test(userAgent);
    //var v;
    //if ($.browser.msie8) {
    //    v = 8;
    //}
    //else if ($.browser.msie7) {
    //    v = 7;
    //}
    //else if ($.browser.msie6) {
    //    v = 6;
    //}
    //else { v = -1; }
    //return v;
    var userAgent = navigator.userAgent; //取得浏览器的userAgent字符串  
    var isIE = userAgent.indexOf("compatible") > -1 && userAgent.indexOf("MSIE") > -1; //判断是否IE<11浏览器  
    var isEdge = userAgent.indexOf("Edge") > -1 && !isIE; //判断是否IE的Edge浏览器  
    var isIE11 = userAgent.indexOf('Trident') > -1 && userAgent.indexOf("rv:11.0") > -1;
    if (isIE) {
        var reIE = new RegExp("MSIE (\\d+\\.\\d+);");
        reIE.test(userAgent);
        var fIEVersion = parseFloat(RegExp["$1"]);
        if (fIEVersion == 7) {
            return 7;
        } else if (fIEVersion == 8) {
            return 8;
        } else if (fIEVersion == 9) {
            return 9;
        } else if (fIEVersion == 10) {
            return 10;
        } else {
            return 6;//IE版本<=7
        }
    } else if (isEdge) {
        return 'edge';//edge
    } else if (isIE11) {
        return 11; //IE11  
    } else {
        return -1;//不是ie浏览器
    }
}

//--------强验证通用js--------
$(document).ready(function () {
    var v = getiev()
    if (v > 0) {
        $(document.body).addClass("ie ie" + v);
    }

    //判断是否有父级页面,如果有,正常加载,否则跳转到错误页
    var flagTsCheck = getHttpParam("isTsCheck");//是否强验证
    flagTsCheck = FlagStrongSeCheck();
    var flagTest = getHttpParam("isTest");;// //是否是测试模式

    if (typeof (isTsCheck) != "undefined" && isTsCheck == '0') {
        flagTest = 1; //加入js判断 ，wangfeng 2014-12-9 
    }

    if (flagTest == "0" || flagTest == null) {
        if (window.top == window.self && window.location.pathname.toLowerCase().indexOf("lismain/index.aspx") < 0) {
            if (window.opener == null) {
                if (flagTsCheck == "1" || flagTsCheck == null) {
                    window.location.href("/lismain/err.aspx");
                }
            }
        }
    }
    else {
    }
});

//获取强验证配置
function FlagStrongSeCheck() {
    var flag = "";
    var lisIp = window.location.href.replace("http://", "").substring(0, window.location.href.replace("http://", "").indexOf('/'));
    $.ajax({
        cache: false,
        async: false,
        url: 'http://' + lisIp + '/LisMain/AjaxPage/LoginAjax.aspx?type=FlagStrongSecurityCheck',
        data: {},
        dataType: 'json', type: 'post',
        beforeSend: function () {
        },
        complete: function () {
        },
        success: function (result) {
            //获取到后赋值
            flag = result;
        },
        error: function (result, b) {
        }
    });

    return flag;
}

//获取网站更目录
function Application_GetRoot() {

    var pathArr = window.location.pathname.split("/");

    if (pathArr.length == 1) {
        return "/";
    } else if (pathArr.length == 2) {
        return pathArr[0];
    } else {

        if (pathArr[0] == "") {  //模式对话框

            if (pathArr[2].indexOf("(") > -1 && pathArr[2].indexOf(")") > -1)
                return "/" + pathArr[1] + "/" + pathArr[2];
            else
                return "/" + pathArr[1];

        } else {

            if (pathArr[2].indexOf("(") > -1 && pathArr[2].indexOf(")") > -1)
                return "/" + pathArr[0] + "/" + pathArr[1];
            else
                return "/" + pathArr[0];

        }
    }
}
/*********************动态载入JS Satrt************************/
function ansyloadJS(url, onload) {
    var domscript = document.createElement('script');
    domscript.src = url;
    if (!!onload) {
        domscript.afterLoad = onload;
        domscript.onreadystatechange = function () {
            if (domscript.readyState == "loaded" || domscript.readyState == "complete" || domscript.readyState == "interactive") {
                domscript.afterLoad();
            }
        }
        domscript.onload = function () {
            if (!!domscript.afterLoad)
                domscript.afterLoad();
        }
    }
    document.getElementsByTagName('head')[0].appendChild(domscript);
}

/*********************动态载入JS End************************/
var popUpWin;
function PopUpCenterWindow(URLStr, width, height, newWin, scrollbars) {
    var popUpWin = 0;
    if (typeof (newWin) == "undefined") {
        newWin = false;
    }
    if (typeof (scrollbars) == "undefined") {
        scrollbars = 0;
    }
    if (typeof (width) == "undefined") {
        width = 800;
    }
    if (typeof (height) == "undefined") {
        height = 600;
    }
    var left = 0;
    var top = 0;
    if (screen.width >= width) {
        left = Math.floor((screen.width - width) / 2);
    }
    if (screen.height >= height) {
        top = Math.floor((screen.height - height) / 2);
    }
    if (newWin) {
        open(URLStr, '', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
        return;
    }

    if (popUpWin) {
        if (!popUpWin.closed) popUpWin.close();
    }
    popUpWin = open(URLStr, 'popUpWin', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=' + scrollbars + ',resizable=yes,copyhistory=yes,width=' + width + ',height=' + height + ',left=' + left + ', top=' + top + ',screenX=' + left + ',screenY=' + top + '');
    popUpWin.focus();
}
function OpenModalDialog(url, option) {
    option.type = 2;
    if ($.ShowIfrmDailog) {
        $.ShowIfrmDailog(url, option);
    }
}
function CloseModalDialog(callback, dooptioncallback, userstate) {
    if (parent && parent.$.closeIfrm) {
        parent.$.closeIfrm(callback, dooptioncallback, userstate);
    }
}
function OpenModelWindow(url, option) {
    var fun;
    try {
        if (parent != null && parent.$ != null && parent.$.ShowIfrmDailog != undefined) {
            fun = parent.$.ShowIfrmDailog
        }
        else {
            fun = $.ShowIfrmDailog;
        }
    }
    catch (e) {
        fun = $.ShowIfrmDailog;
    }
    fun(url, option);
}
function CloseModelWindow(callback, dooptioncallback, userstate) {
    if (parent) {
        parent.$.closeIfrm(callback, dooptioncallback, userstate);
    }
    else {
        window.close();
    }
}


function StrFormat(temp, dataarry) {
    return temp.replace(/\{([\d]+)\}/g, function (s1, s2) { var s = dataarry[s2]; if (typeof (s) != "undefined") { if (s instanceof (Date)) { return s.getTimezoneOffset() } else { return encodeURIComponent(s) } } else { return "" } });
}
function StrFormatNoEncode(temp, dataarry) {
    return temp.replace(/\{([\d]+)\}/g, function (s1, s2) { var s = dataarry[s2]; if (typeof (s) != "undefined") { if (s instanceof (Date)) { return s.getTimezoneOffset() } else { return (s); } } else { return ""; } });
}

function showLoadingMsg(msg, position, isautohide, timeout) {
    var loadpanel = $("#loadpanel");
    if (loadpanel.length == 0) {
        loadpanel = $("<div id=\"loadpanel\" class=\"loadingpanel\"/>").appendTo("body");
    }
    loadpanel.html("<span>" + msg + "</span>");
    if (!position) {
        position = { right: 20, top: 3 };
    }
    loadpanel.css(position).show();
    if (isautohide) {
        showLoadTipTimerId = setTimeout(hideLoadingMsg, timeout);
    }
}

function showMsg(msg, position) {
    if (!position) {
        position = { right: 20, top: 3 };
    }
    showLoadingMsg(msg, position, true, 3000);
}

function hideLoadingMsg() {
    var loadpanel = $("#loadpanel");
    if (loadpanel.length > 0) {
        loadpanel.hide();
    }
}
var showErrorTipTimerId;
var showLoadTipTimerId;
var msg;
function showErrorTip(msg, position, isautohide, timeout) {
    var errorpanel = $("#errorpanel");
    if (errorpanel.length == 0) {
        errorpanel = $("<div id=\"errorpanel\" class=\"errorpanel\"/>").appendTo("body");
    }
    if (errorpanel.css("display") != "none") {
        //----此处判断消息内容是否包含了相同文字，如果不包含则加入---
        if (errorpanel.text().indexOf(msg) == -1) {
            errorpanel.find(">dt").append("<dl>" + msg + "</dl>");
            if (showErrorTipTimerId) {
                window.clearTimeout(showErrorTipTimerId);
            }
        }
    }
    else {
        errorpanel.html("<dt><dl>" + msg + "</dl></dt>");
        if (!position) {
            position = { right: 20, top: 3 };
        }
        errorpanel.css(position).fadeIn();
    }
    if (isautohide) {
        showErrorTipTimerId = setTimeout(hideErrortip, timeout);
    }

}
function hideErrortip() {
    var errorpanel = $("#errorpanel");
    if (errorpanel.length > 0) {
        //errorpanel.fadeOut();
        errorpanel.hide();
    }
}
function removeParent() {
    $(this).parent().hide();
    return false;
}
function showValidateError(error, element) {
    //var close = $("<a href=\"javascript:void(0)\" class=\"valiclose\">&nbsp;</a>").click(removeParent);  
    var pos = element.position();
    var height = element.height();
    if (pos.left + 155 >= document.documentElement.clientWidth) {
        pos.left = document.documentElement.clientWidth - 156;
    }
    var newpos = { left: pos.left, top: pos.top + height + 2 }
    error.appendTo("#fmEdit").css(newpos);
}

function getHttpParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

////首先备份下jquery的ajax方法  
//var _ajax = $.ajax;

////重写jquery的ajax方法
//$.ajax = function (opt) {
//    //备份opt中error和success方法 
//    var fn = {
//        error: function (XMLHttpRequest, textStatus, errorThrown) { },
//        success: function (data, textStatus) { }
//    }
//    if (opt.error) {
//        fn.error = opt.error;
//    }
//    if (opt.success) {
//        fn.success = opt.success;
//    }

//    //扩展增强处理 
//    var _opt = $.extend(opt, {
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            if ((XMLHttpRequest.responseText != null) && (XMLHttpRequest.responseText != "") && (XMLHttpRequest.responseText.indexOf('<script') != -1)) {
//                var tmpreStr = XMLHttpRequest.responseText;
//                tmpreStr = tmpreStr.replace(/<([^<>]*)>/g, "");
//                erro = eval(tmpreStr);

//                if (erro.err_code == 500)
//                    alert(erro.err_msg);
//            }


//            //错误方法增强处理 
//            fn.error(XMLHttpRequest, textStatus, errorThrown);
//        },
//        success: function (data, textStatus) {
//            //成功回调方法增强处理  
//            fn.success(data, textStatus);
//        }
//        //,
//        //beforeSend: function (xhr) {
//        //    xhr.setRequestHeader('X-Token', $.getCookie("X-Token"));
//        //    xhr.setRequestHeader('X-Client', "PC");
//        //    xhr.setRequestHeader('Content-Type', "application/json");
//        //}
//    });
//    return _ajax(_opt);
//};