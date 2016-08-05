var http = require('http');
var server = new http.createServer();
server.listen('3000','127.0.0.1');
var count = 0;
server.on('request',function(req,res){
	res.end('hello');
	console.log(count++);
});

 