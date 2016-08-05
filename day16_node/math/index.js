function math(){
	var sum =  function (one, two){
	return one+two;
	}
	function sub(one, two){
	return one-two;
	}
	return {
		sum:sum,
		sub:sub
	}
}
module.exports = math;

