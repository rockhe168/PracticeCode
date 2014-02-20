/*
* ����ת������
* LastModify:2013/08/27
*/
GV.util.parse = {
	url	: function(){

		var _myDecode = function(q){
			var q = (q + '').replace(/(&amp;|\?)/g, "&").split('&');
			var p = {};
			var c = q.length;
			for (var i = 0; i < c; i++) {
				var pos = q[i].indexOf('=');
				if ( - 1 == pos) continue;
				p[q[i].substr(0, pos).replace(/[^a-zA-Z0-9_]/g, '')] = unescape(q[i].substr(pos + 1));
			}

			return p;
		};

		var hash = location.href.toString().indexOf('#');
		if(hash < 0) hash = '';
		else {
			hash = location.href.toString().substring(hash, location.href.toString().length);
		}
		return {
			search	: _myDecode(location.search.substr(1)),
			hash	: _myDecode(hash)
		};
	},

	encodeHtml	: function(str){
		return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/'/g, "&#039;").replace(/"/g, "&quot;");
	},

	decodeHtml	: function(str){
		return str.replace(/&lt;/g, "<").replace(/&gt;/g, ">").replace(/&#0?39;/g, "'").replace(/&quot;/g, '"').replace(/&amp;/g, "&");
	},


	/**
	 * ��ʽ��ʱ���
	 * @param {Integer} ts ��ת��ʱ���
	 * @param {String} fstr ��ʽ����y-m-d h:i:s �����ִ�Сд
	 */
	timeFormat	: function(ts, fstr) {
		var d = GV.util.parse.getTimeInfo(ts);
		var r = {
			y: d.year,
			m: d.month,
			d: d.date,
			h: d.hour,
			i: d.minute,
			s: d.sec,
			w: d.week
		};
		$.each(r, function(k, v){
			if(k != 'y' && v < 10) r[k] = '0' + v;
		});
		return fstr.replace(/(?!\\)(y|m|d|h|i|s|w)/gi,
		function(a0, a1) {
			return r[a1.toLowerCase()];
		});
	},

	/**
	 * ʱ���ת����ʱ�����
	 */
	getTimeInfo	: function(t) {
		var week = ["������", "����һ", "���ڶ�", "������", "������", "������", "������"];
		var d = new Date(t * 1000);
		return {
			year: d.getFullYear(),
			month: d.getMonth() + 1,
			date: d.getDate(),
			hour: d.getHours(),
			minute: d.getMinutes(),
			sec: d.getSeconds(),
			week: week[d.getDay()]
		};
	},
	
	/**
	 * ������ת��Ϊjson��ʽ�ַ���
	 */
	jsonToStr : function(obj) {
		if(typeof(obj) == "number") {
			return isFinite(obj) ? obj.toString() : '""';
		} else if(typeof(obj) == "string") {
			return '"' + obj.replace(/(\\|\")/g, "\\$1").replace(/\n|\r|\t/g,
	            function(){   
		            var a = arguments[0];
		            return  (a == '\n') ? '\\n' :
		            	(a == '\r') ? '\\r' :
		            	(a == '\t') ? '\\t' : ''
		    	}
			) + '"';
		} else if(typeof(obj) == "boolean") {
			return obj ? 'true' : 'false';
		} else if($.isArray(obj)) {
			var jsonStr = '';
			for(var i = 0; i < obj.length; i++) {
				if(jsonStr == '')
					jsonStr = GV.util.parse.jsonToStr(obj[i]);
				else
					jsonStr += ',' + GV.util.parse.jsonToStr(obj[i]);
			}
			return '[' + jsonStr + ']';
		} else if($.isPlainObject(obj)) {
			var jsonStr = '';
			for(var p in obj) {
				if(jsonStr == '')
					jsonStr = '"' + p + '":' + GV.util.parse.jsonToStr(obj[p]);
				else
					jsonStr += ',"' + p + '":' + GV.util.parse.jsonToStr(obj[p]);
			}
			return '{' + jsonStr + '}';
		} else
			return '""';
	}
};