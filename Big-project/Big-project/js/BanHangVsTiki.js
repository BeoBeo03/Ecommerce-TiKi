function getValue(id){
    return document.getElementById(id).value.trim();
}

function showError(key, mess){
    document.getElementById(key).innerHTML = mess;
}

function checkValue(){
    var flag = true;
    var nameInput = getValue('nameInput');
    if(nameInput == '') {
        flag = false;
        showError('name_error', 'Vui lòng nhập Họ và tên người liên hệ');
    }
    if(nameInput != ''){
        showError('name_error', '');
    }
    var numInput = getValue('numInput');
    if(numInput == '' || numInput.length != 10 ){
        flag = false;
        showError('num_error', 'Vui lòng nhập SĐT liên hệ');
    }
    if(numInput != '' || numInput.length == 10){
        showError('num_error', '');
    }
    var emailInput = getValue('emailInput');
    if(emailInput == '' || emailInput != '@gmail.com'){
        flag = false;
        showError('email_error', 'Vui lòng nhập Email liên hệ');
    }
    if(emailInput != '' ){
        showError('email_error', '');
    }
    var MST = getValue('MST')
    if(MST == ''){
        flag = false;
        showError('MST_error', 'Vui lòng nhập Vui lòng nhập MST doanh nghiệp/MST cá nhân(nếu có)');
    }
    if(MST != ''){
        showError('MST_error', '');
    }
    return flag;
}

function majorChanged1(){
    var major = getValue('major1')
    if(major == 'Vui lòng chọn'){
        flag = false;
        showError('chon_error', 'Vui lòng chọn Ngành hàng chủ lực của Anh/Chị?')
    }
    if(major == 'Điện thoại'){
        flag = true;
        showError('chon_error', '')
    }
}

function majorChanged2(){
    var major = getValue('major2')
    if(major == 'Vui lòng chọn'){
        flag = false;
        showError('chon2_error', 'Vui lòng chọn Cửa hàng/doanh nghiệp của Anh/Chị đã đăng ký kinh doanh?')
    }
    if(major == 'Đã đăng ký rồi'){
        flag = false;
        showError('chon2_error', '')
    }
    if(major == 'Chưa đăng ký'){
        flag = false;
        showError('chon2_error', '')
    }
}