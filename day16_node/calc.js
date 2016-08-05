var http = require("http");
var ipAddress = "127.0.0.1";
var portNumber = "3000";
var server = new http.createServer();

server.listen(portNumber, ipAddress);
server.on('request',
 function serviceRequest (request, response) { 
	 
    response.setHeader('Access-Control-Allow-Origin', 'http://localhost:50261');
    response.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, PATCH, DELETE');  
    response.setHeader('Access-Control-Allow-Headers', 'X-Requested-With,content-type');  
    response.setHeader('Access-Control-Allow-Credentials', true);

  var queryString = new String(request.url);
	console.log("Request string is: "+queryString);

  var keyValuePairs = queryString.split("&"); 

 
  var action = keyValuePairs[0].replace("/","").split("=")[1]; // extracting the action specified in the URL
  var firstNumber = new String(keyValuePairs[1].split("&")).split("=")[1] || "0"; // extracting the first number
  var secondNumber = new String(keyValuePairs[2].split("&")).split("=")[1].split("?")[0] || "0"; // extracting the second number
	console.log("First number is: "+firstNumber);
	console.log("Operation is: "+action);
	console.log("Second number is: "+secondNumber);
	

  var result = getResult(action, Number(firstNumber) , Number(secondNumber));
console.log("Result is: "+result);  
  response.end(String(result));
  
 }
);


function getResult(op, num1, num2)
{
 var result = 0;
 switch(op){
	 case '+':
		result = num1+num2;
		break;
	 case '-':
		result = num1-num2;
		break;
	 case '*':
		result = num1*num2;
		break;
	 case '/':
		if(num2==0)
		{
			result = 0;
			break;
		}
		result = num1/num2;
		break;
	default:
		result = 0;
		break;
 }

 return result;
}
