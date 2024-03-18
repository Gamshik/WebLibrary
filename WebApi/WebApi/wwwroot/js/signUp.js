let tokenKey = "WebLibraryToken"

const username = document.getElementById("inputUsername")
const email = document.getElementById("inputEmail")
const password = document.getElementById("inputPassword")
const passwordConfirm = document.getElementById("inputPasswordConfirm")

const usernameHelp = document.getElementById("usernameHelp")
const emailHelp = document.getElementById("emailHelp")
const passwordHelp = document.getElementById("passwordHelp")
const passwordConfirmHelp = document.getElementById("passwordConfirmHelp")
const errorHelp = document.getElementById("errorHelp")

document.getElementById("registerSubmit").addEventListener("click", async e => {
    e.preventDefault();

    if (!validateData()){
        errorHelp.innerText = ''
        return;
    }

    const response = await fetch("https://localhost:7106/api/User/Register", {
        method: "POST",
        headers: {
            "Accept": "*/*",
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            userName: username.value,
            email: email.value,
            password: password.value
        })
    });

    const responseData = await response.json()

    if (response.ok){
        window.location.href = "https://localhost:7106/login.html"
    }
    else{
        errorHelp.innerText = responseData.message
    }
});

document.getElementById("loginLink").addEventListener("click", e => {
    window.location.href = "https://localhost:7106/login.html"
});


function validateData(){
    const usernameValue = username.value
    const emailValue = email.value
    const passwordValue = password.value
    const passwordConfirmValue = passwordConfirm.value

    let isValidate = true

    if (usernameValue === ''){
        isValidate = false
        setError(usernameHelp, "Enter username please!")
    }
    if (usernameValue.length < 4){
        isValidate = false
        setError(usernameHelp, "Username can not be less than 4 character!")
    }
    else{
        setSuccess(usernameHelp)
    }

    if (emailValue === ''){
        isValidate = false
        setError(emailHelp, "Enter email please!")
    }
    else if (!validateEmail(emailValue)){
        isValidate = false
        setError(emailHelp, "Email is not correct!") 
    }
    else{
        setSuccess(emailHelp)
    }

    if (passwordValue === ''){
        isValidate = false
        setError(passwordHelp, "Enter password please!")
    }
    else if (passwordValue.length < 10){
        isValidate = false
        setError(passwordHelp, "Password can not be less than 10 character!!")
    }
    else{
        setSuccess(passwordHelp)
    }

    if (passwordValue != passwordConfirmValue){
        isValidate = false
        setError(passwordConfirmHelp, "Passwords must be match!")
    }
    else{
        setSuccess(passwordConfirmHelp)
    }

    return isValidate;
}

function validateEmail(email){
    return String(email).toLowerCase().match(/^[A-Za-z0-9_!#$%&'*+\/=?`{|}~^.-]+@[A-Za-z0-9.-]+$/);
}
function setError(element,message){
    element.innerText = message;
}
function setSuccess(element){
    element.innerText = '';
}