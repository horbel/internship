//task 1
var values = function () {   
    var _counter = 0;
    var args = arguments;

    if (arguments.length>0) {       
        this.next = function () {
            if (_counter == args.length)
                _counter = 0;
            return args[_counter++];
        }
    }
}
var p =  new values(1, 3, 2);
//alert(p.next());
//alert(p.next());
//alert(p.next());
//alert(p.next());

//task2

Array.prototype.each = function (func) {
    for (var i = 0; i < this.length; i++) {
        func.call(this[i])
    }   
}

var test = [1, 2, 3];
test.each(function () {
    var c = 2 + this;
    //alert(c);
});

//task3

var Observer = (function () {

    var subscribers = {};

    function subscribe(type,fn) {
        if (!subscribers[type]) {
            subscribers[type] = [];
        }
        if (subscribers[type].indexOf(fn) == -1) {
            subscribers[type].push(fn);
        }
    }

    function unsubscribe(type, fn) {
        var listeners = subscribers[type];
        if (!listeners) {
            return;
        }
        var index = listeners.indexOf(fn);
        if (index > -1) {
            listeners.splice(index, 1);
        }
    }
    var dd = [];
    

    function publish(type, evtObj) {
        if (!subscribers[type]) {
            return;
        }
        if (evtObj.type == null) {
            evtObj.type = type;
        }
        var listeners = subscribers[type];
        for (var j = 0; j < listeners.length; j++) {
            listeners[j](evtObj);
        }
    }

    return {
        subscribe: subscribe,
        unsubscribe: unsubscribe,
        publish:publish
    }
})();
var foo = function(obj){console.log(obj.msg)}
Observer.subscribe("test", foo);
Observer.publish("test", { msg: "visible message" });
Observer.unsubscribe("test", foo);
Observer.subscribe("test", { msg: "unvisible message" });

//task 4
var customReverse1 = function (arr) {
    var tempArr = [];
    for (var ii = arr.length-1; ii >= 0 ; ii--) {
        tempArr.push(arr[ii]);
    }
    return tempArr;
}

var customReverse2 = function (arr) {
   
    var temp;
    for (var jj=0, ii = arr.length - 1 ; jj <= ii ; jj++, ii--) {
        temp = arr[ii];
        arr[ii] = arr[jj];
        arr[jj] = temp;
    }
       
}

var randomizer = function (min, max) {
    var val = min + Math.random() * (max - min + 1);
    return Math.floor(val);
}
var testArr = [];

for (var jj = 0; jj < 10000000; jj++) {
    testArr.push(randomizer(0, 100));
}
var start = Date.now();
var temp = customReverse1(testArr);
var end = Date.now()
var result = end - start;
//console.log("first function time :" + result);
//start = Date.now();
//customReverse2(testArr);
//end = Date.now();
//result = end - start;
//console.log("second function time :" + result);

//task 5

var number =  new RegExp("[-+]?(\d)*\.?[eE]?[-+]?d*");




["1", "-1", "+15", "1.55", ".5", "5.", "1.3e2", "1E-4", "1e+12"].forEach(function (s) {
    if (!number.test(s)) console.log("Не нашла '" + s + "'");
});
["1a", "+-1", "1.2.3", "1+1", "1e4.5", ".5.", "1f5", "."].forEach(function (s) {
    if (number.test(s)) console.log("Неправильно принято '" + s + "'");
});



