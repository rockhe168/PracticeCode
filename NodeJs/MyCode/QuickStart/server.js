var http = require("http");
var url = require("url");

function strat(route,handle) {

    function onRequest(request, response) {
        
        //获取请求Url
        var pathname = url.parse(request.url).pathname;

        console.log("Request for " + pathname + " received");

        route(handle, pathname);//路由模块

        response.writeHead(200, { "Content-Type": "text/plain" });

        response.write("Hello World");

        response.end();
        
    }

    http.createServer(onRequest).listen(8888);
    console.log("Server has started");
}

exports.start = strat;



//var http = require("http");
//var url = require("url");

//function onRequest(request, response) {

//    console.log("start init");

//    var pathname = url.parse(request.url).pathname;

//    console.log("Request for " + pathname + " received...");

//    response.writeHead(200, { "Content-Type": "text/plain" });
//    response.write("Hello World");
//    response.end();
//}

//http.createServer(onRequest).listen(8888);