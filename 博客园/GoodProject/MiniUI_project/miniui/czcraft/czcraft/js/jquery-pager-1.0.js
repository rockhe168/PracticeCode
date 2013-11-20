//Download by http://www.codefans.net
//每次只显示5个页码
//修改:2012/4/26
//tianzhuanghu
//http://www.cnblogs.com/mysweet/ 我的博客
(function($) {
    //设定页码方法，初始化
    $.fn.setPager = function(options) {
        var opts = $.extend({}, pagerDefaults, options);
        return this.each(function() {
        //修改,能够动态设置PageSize
			pagerDefaults.PageSize=options.PageSize;
            $(this).empty().append(setPagerHtml(parseInt(options.RecordCount), parseInt(options.PageIndex), options.buttonClick));
             $('.pager a').mouseover(function() { document.body.style.cursor = "pointer"; }).mouseout(function() { document.body.style.cursor = "auto"; });
        });
    };
    //设定页数及html
    function setPagerHtml(RecordCount, PageIndex, pagerClick) {
			
        var $content = $("<div class=\"pager\"></div>");
        var startPageIndex = 1;
        //若页码超出
        if (RecordCount <= 0) RecordCount = pagerDefaults.PageSize;
		var	PageSize=pagerDefaults.PageSize;
		//alert(pagerDefaults.PageSize);
        //末页
        var endPageIndex = parseInt(RecordCount % parseInt(PageSize)) > 0 ? parseInt(RecordCount / parseInt(PageSize)) + 1 : RecordCount / parseInt(PageSize);

        if (PageIndex > endPageIndex) PageIndex = endPageIndex;
        if (PageIndex <= 0) PageIndex = startPageIndex;
        var nextPageIndex = PageIndex + 1;
        var prevPageIndex = PageIndex - 1;
        if (PageIndex == startPageIndex) {
            $content.append($("<span>首页</span>"));
            $content.append($("<span>上一页</span>"));
        } else {

            $content.append(renderButton(RecordCount, 1, pagerClick, "首页"));
            $content.append(renderButton(RecordCount, prevPageIndex, pagerClick, "上一页"));
        }
        //这里判断是否显示页码
        if (pagerDefaults.ShowPageNumber) {
            // var html = "";
            //页码部分隐藏 只显示中间区域
            if (endPageIndex <= 5 && PageIndex <= 5) {
                for (var i = 1; i <= endPageIndex; i++) {
                    if (i == PageIndex) {
                        $content.append($("<span>" + i + "</span>"));
                    } else {
                        $content.append(renderButton(RecordCount, i, pagerClick, i));
                    }

                }

            } else if (endPageIndex > 5 && endPageIndex - PageIndex <= 2) {

                $content.append($("<a>...</a>"));
                for (var i = endPageIndex - 4; i <= endPageIndex; i++) {
                    if (i == PageIndex) {
                        $content.append($("<span>" + i + "</span>"));
                    } else {
                        $content.append(renderButton(RecordCount, i, pagerClick, i));
                    }

                }
            } else if (endPageIndex > 5 && PageIndex > 3) {

                $content.append($("<a>...</a>"));
                for (var i = PageIndex - 2; i <= PageIndex + 2; i++) {
                    if (i == PageIndex) {
                       $content.append($("<span>" + i + "</span>"));
                    } else {
                        $content.append(renderButton(RecordCount, i, pagerClick, i));
                    }

                }
               $content.append($("<a>...</a>"));

            } else if (endPageIndex > 5 && PageIndex <= 3) {

                for (var i = 1; i <= 5; i++) {
                    if (i == PageIndex) {
                        $content.append($("<span>" + i + "</span>"));
                    } else {
                        $content.append(renderButton(RecordCount, i, pagerClick, i));
                    }

                }
               $content.append($("<a>...</a>"));
            }
        }
        if (PageIndex == endPageIndex) {
            $content.append($("<span>下一页</span>"));
            $content.append($("<span>末页</span>"));
        } else {
            $content.append(renderButton(RecordCount, nextPageIndex, pagerClick, "下一页"));
            $content.append(renderButton(RecordCount, endPageIndex, pagerClick, "末页"));
        }


        return $content;
    }
    function renderButton(recordCount, goPageIndex, EventHander, text) {
        var $goto = $("<a title=\"第" + goPageIndex + "页\">" + text + "</a>\"");
        $goto.click(function() {

            EventHander(recordCount, goPageIndex,pagerDefaults.PageSize);
        });
        return $goto;
    }
    var pagerDefaults = {
        DefaultPageCount: 1,
        DefaultPageIndex: 1,
		PageSize:20,
        ShowPageNumber: true //是否显示页码
    };
})(jQuery);