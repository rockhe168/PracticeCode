var server = require("./server");
var route = require("./route");
var requestHanlder = require("./requestHandler");

//劫持请求，载入。。。
var handle = {};
handle["/"] = requestHanlder.start;
handle["/start"] = requestHanlder.start;
handle["/upload"] = requestHanlder.upload;

server.start(route.route,handle);