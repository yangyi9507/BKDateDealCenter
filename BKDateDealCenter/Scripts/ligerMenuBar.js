/**
* jQuery ligerUI 1.3.2
* 
* http://ligerui.com
*  
* Author daomi 2015 [ gd_star@163.com ] 
* 
*/
(function ($) {
    $.fn.ligerMenuBar = function (options) {
        return $.ligerui.run.call(this, "ligerMenuBar", arguments);
    };
    $.fn.ligerGetMenuBarManager = function () {
        return $.ligerui.run.call(this, "ligerGetMenuBarManager", arguments);
    };

    $.ligerDefaults.MenuBar = {};

    $.ligerMethos.MenuBar = {};

    $.ligerui.controls.MenuBar = function (element, options) {
        $.ligerui.controls.MenuBar.base.constructor.call(this, element, options);
    };
    var IsShow = 1; // wangfeng 加入是否展示状态
    $.ligerui.controls.MenuBar.ligerExtend($.ligerui.core.UIComponent, {
        __getType: function () {
            return 'MenuBar';
        },
        __idPrev: function () {
            return 'MenuBar';
        },
        _extendMethods: function () {
            return $.ligerMethos.MenuBar;
        },
        _render: function () {
            var g = this, p = this.options;
            g.menubar = $(this.element);
            if (!g.menubar.hasClass("l-menubar")) g.menubar.addClass("l-menubar");
            if (p && p.items) {
                $(p.items).each(function (i, item) {
                    g.addItem(item);
                });
            }
            $(document).click(function () {
                $(".l-panel-btn-selected", g.menubar).removeClass("l-panel-btn-selected");
                $(this).removeClass("l-panel-btn-over");
                if (IsShow == 0) {
                    if (g.actionMenu != null) {
                        IsShow = 1; //wangfeng 2013-1-1 将状态变为隐藏
                        g.actionMenu.hide();
                    }
                }
                else {
                    if ($(".l-menu").eq(0).length>0) {
                        var strDisplay = $(".l-menu").eq(0).css("display").toLowerCase();
                        if (strDisplay != "none") {
                            IsShow = 0;
                        }
                        else if ($(document.activeElement).hasClass("l-menubar-item")) {
                            IsShow = 0;
                            g.actionMenu.show();
                        }
                       
                    }
                    
                }
            });
            g.set(p);
        },
        addItem: function (item) {
            var g = this, p = this.options;
            var ditem = $('<div class="l-menubar-item l-panel-btn l-panel-btn-over"><span></span><div class="l-panel-btn-l"></div><div class="l-panel-btn-r"></div><div class="l-menubar-item-down"></div></div>');
            g.menubar.append(ditem);
            item.id && ditem.attr("menubarid", item.id);
            item.text && $("span:first", ditem).html(item.text);
            item.disable && ditem.addClass("l-menubar-item-disable");
            item.click && ditem.click(function () {
                item.click(item);
            });
            if (item.menu) {
                var menu = $.ligerMenu(item.menu);
                ditem.click(function () {
                    //g.actionMenu && g.actionMenu.hide();
                    if (g.actionMenu == null) {
                        IsShow = 1;
                    }
                    var left = $(this).offset().left;
                    var top = $(this).offset().top + $(this).height();
                    menu.show({ top: top, left: left });
                    g.actionMenu = menu;
                    $(this).addClass("l-panel-btn-over l-panel-btn-selected").siblings(".l-menubar-item").removeClass("l-panel-btn-selected");

                //}, function () {
                //    $(".l-menu-inner").hover(function () {
                //        $(this).removeClass("l-panel-btn-over");
                //    }, function () {
                //        $(this).removeClass("l-panel-btn-over");
                //        g.actionMenu.hide();
                //    });
                });
            }
            else {
                ditem.hover(function () {
                    $(this).addClass("l-panel-btn-over");
                }, function () {
                    $(this).removeClass("l-panel-btn-over");
                });
                $(".l-menubar-item-down", ditem).remove();
            }
        }
    });
})(jQuery);