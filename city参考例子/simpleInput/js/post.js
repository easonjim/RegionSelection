/**
 * 
 */
var isMobile=/^(1[1-9][0-9])\d{8}$/;
//var isPhone=/^((0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/;
var isPhone=/^((0\d{2,3}))?([2-9]\d{6,7})(\d{3,})?$/;
//var isOtherPhone = /^(400|800)-(\d{3})-(\d{4})$/;
var isOtherPhone = /^(400|800)(\d{7})$/;
var isPre = /^((\+?86)|(\(\+86\)))/;	//+86	
var isSpaceAndLine = /\s|-/g; 			//空格和横线
var isSpace = /\s/g; 					//空格
var illegal = /[^0-9]*/g;				//非数字字符

function _mobile_phone_check(_input){
	var _target = $.trim(_input);
	_target = _target.replace(isPre, ""); 
	_target = _target.replace(illegal, ""); 
	if(isMobile.test(_target)){				
		return _target; //手机号码
	}
	if(isPhone.test(_target)){
		return _target; //固定座机
	}
	if(isOtherPhone.test(_target)){
		return _target; //400或800
	}			
	return "";
}

//设置cookie
function setCookie(c_name, value, expiredays) {
	var exdate = new Date()
	exdate.setDate(exdate.getDate() + expiredays)
	document.cookie = c_name + "=" + escape(value)
			+ ((expiredays == null) ? "" : ";expires=" + exdate.toGMTString())
}

// 取回cookie
function getCookie(c_name) {
	if (document.cookie.length > 0) {
		c_start = document.cookie.indexOf(c_name + "=")
		if (c_start != -1) {
			c_start = c_start + c_name.length + 1
			c_end = document.cookie.indexOf(";", c_start)
			if (c_end == -1)
				c_end = document.cookie.length
			return unescape(document.cookie.substring(c_start, c_end))
		}
	}
	return ""
}

function _save_input(_this, name){
	if($("#id").length != 0){
		var _id = $("#id").val();
		if(_id.length >0 ){
			return;
		}
	}
	
	var _input =$(_this).val();
	_input = $.trim(_input);
	if(_input.length > 0){
		setCookie(name, _input, 7); //1周有效
	}else{
		setCookie(name, _input, 0); //删除
	}
}

function _save_input_by_id(_id, name){
	var _input =$("#" + _id).val();
	_input = $.trim(_input);
	if(_input.length > 0){
		setCookie(name, _input, 7); //1周有效
	}else{
		setCookie(name, _input, 0); //删除
	}
}