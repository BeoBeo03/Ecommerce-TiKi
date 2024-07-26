function getValue(id){
    return document.getElementById(id).value;
}

function showError(key, mess){
    document.getElementById(key + '_error').innerHTML = mess;
}

function checkValue(){
    var flag = true;
    var email = getValue('emailInput');
    if(email == '' || email.length <= 10){
        flag = false;
        showError('email', 'Vui lòng nhập email');
    }
    else{
        showError('email', '')
    }
    const myArray = getValue('emailInput');
    if(myArray.match("@gmail.com") != '@gmail.com' || myArray.match(" ") == ' '){
        flag = false;
        showError('email', 'Vui lòng nhập đúng cú pháp email!');
    }
    var name = getValue('nameInput');
    if(name == '' || name.length > 30){
        flag = false;
        showError('name', 'Vui lòng nhập họ và tên');
    }
    else{
        showError('name', '')
    }
    var country = getValue('countryInput');
    if(country == ''){
        flag = false;
        showError('country', 'Vui lòng nhập Quốc gia');
    }
    else{
        showError('country', '')
    }
    var num = getValue('numInput');
    if(num == '' || num.length != 10){
        flag = false;
        showError('num', 'Vui lòng nhập số điện thoại');
    }
    else{
        showError('num', '')
    }
    var password = getValue('passwordInput');
    if(password.length < 8 || password == ''){
        flag = false;
        showError('password', 'Vui lòng nhập lại mật khẩu')
    }
    else{
        showError('password', '')
    }
    var repassword = getValue('repasswordInput');
    if(repassword.length < 8 || repassword != password){
        flag = false;
        showError('repassword', 'Vui lòng nhập lại mật khẩu')
    }
    else{
        showError('repassword', '')
    }
    return flag;
}



