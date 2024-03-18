let tokenKey = "WebLibraryToken"

const email = document.getElementById("inputEmail")
const password = document.getElementById("inputPassword")

const emailHelp = document.getElementById("emailHelp")
const passwordHelp = document.getElementById("passwordHelp")
const errorHelp = document.getElementById("errorHelp")

document.getElementById("loginSubmit").addEventListener("click", async e => {

    e.preventDefault()

    if (!validateData()){
        errorHelp.innerText = ''
        return;
    }

    const response = await fetch("https://localhost:7106/api/User/Authorize", {
        method: "POST",
        headers: {
            "Accept": "*/*",
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email: email.value,
            password: password.value
        })
    });

    const responseData = await response.json()

    if (response.ok){
        localStorage.setItem(tokenKey, responseData.token)
        window.location.href = "https://localhost:7106/library.html"
    }
    else{
        errorHelp.innerText = responseData.message
    } 
});

document.getElementById("registerLink").addEventListener("click", e => {
    window.location.href = "https://localhost:7106/register.html"
});

function validateData(){
    const emailValue = email.value
    const passwordValue = password.value

    let isValidate = true

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
        setError(passwordHelp, "Password must not be less than 10 characters long!")
    }
    else{
        setSuccess(passwordHelp)
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