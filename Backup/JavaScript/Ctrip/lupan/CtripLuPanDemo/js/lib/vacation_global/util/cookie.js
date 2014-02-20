/**
 * Cookie 相关操作
 * @see 达人的开发js库
 */
GV.util.cookie = {
	get	: function(name) {
		var r = new RegExp("(^|;|\\s+)" + name + "=([^;]*)(;|$)");
		var m = document.cookie.match(r);
		return (!m ? "": unescape(m[2]));
	},

	add	: function(name, v, path, expire, domain) {
		var s = name + "=" + escape(v)
			+ "; path=" + ( path || '/' ) // 默认根目录
			+ (domain ? ("; domain=" + domain) : ''); 
		if (expire > 0) {
			var d = new Date();
			d.setTime(d.getTime() + expire * 1000);
			s += ";expires=" + d.toGMTString();
		}
		document.cookie = s;
	},

	del	: function(name, domain) {
		document.cookie = name + "=;path=/;" +(domain ? ("domain=" + domain + ";") : '') +"expires=" + (new Date(0)).toGMTString();
	}
};