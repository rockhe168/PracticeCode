/*
* lazyload
* LastModify:2013/08/27
*/
(function($, window, undefined) {
	function lazyload(options) {
		var self = this,
			settings = {
				threshold			: 100, //Ԥ��ʾ�ľ���
				cachePosition	: true, //�Ƿ񻺴�ڵ��λ��
				attributeName	:'ksrc', //����ͼƬ��ַ������
				target				: null, // �ӳټ��صĽڵ�selector
				container			: window, //�����Ĺ�������Ĭ��Ϊwindow
				show : function(src) { //��ҪչʾͼƬ�Ļص�, ��������ڴ�����Ϊ������ʾ
					this.src = src;
				}
			},
			isWindow = settings.container === window,
			elementData = [],
			container = $(settings.container);

		$.extend(settings, options || {});

		function _getElements(settings) {
			var elementData = [];
			$(settings.target).each(function() {
				if (this.nodeName === 'IMG' && this.getAttribute(settings.attributeName) !== null)
					elementData.push( {obj: $(this)} );
			});
			return elementData;
		};

		var _scroll = function() {
			var res = [],
				data = $.extend({
									width: container.width(),
									height : container.height()
								},
								isWindow ? {
									left : container.scrollLeft(),
									top : container.scrollTop()
								} : container.offset()
							);

			var item, pos, elem, name;
			for(var i = 0, len = elementData.length; i < len; i++) {
				item = elementData[i];
				pos = _position(item, data);

				if (!pos.belowthefold && !pos.rightoffold && !pos.abovethetop && !pos.leftofbegin) {
					elem = item.obj[0];
					name = settings.attributeName;

					settings.show.call(elem, elem.getAttribute(name));
					elem.removeAttribute(name);
					delete item.obj;
					item = null;
				}
				else {
					res.push(item);
				}
			}

			if (res.length === 0) {
				container.unbind("scroll", arguments.callee);
			}
			elementData = res;
		};

		var _position = function (item, data) {
			if ( !settings.cachePosition || !item.cache ) {
				var obj = item.obj,
					offset = obj.offset(),
					elePos = [offset.left, offset.top, obj.width(), obj.height()];

				if ( settings.cachePosition ) {
					item.cache = elePos;
				}
			}
			else {
				elePos = item.cache;
			}

			return {
				belowthefold : data.height + data.top <= elePos[1] - settings.threshold,
				abovethetop : data.top >= elePos[1] + settings.threshold + elePos[3],
				rightoffold : data.width + data.left <= elePos[0] - settings.threshold,
				leftofbegin : data.left >= elePos[0] + settings.threshold + elePos[2]
			};
		}

		elementData = _getElements(settings);
		container.bind("scroll", _scroll).trigger("scroll");

		return {
			refresh : function() {
				elementData = _getElements(settings);
				elementData.length > 0 && container.bind("scroll", _scroll).trigger("scroll");
			}
		}
	};
	window.GV.ui.lazyload = lazyload;
})(jQuery, window);
