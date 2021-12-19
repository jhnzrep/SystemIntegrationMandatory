
const firstIframe = document.getElementsByTagName("iframe")[0];
const firstForm = document.getElementsByTagName("form")[0];
const btnCode = document.getElementsByClassName("btnCode");

const form = document.getElementsByTagName('form')
window.addEventListener("message", async (e) => {
    response = e.data
    console.log(response)
    const expiration = JwtExpiration(e.data);
    if (expiration == true) {
        return document.getElementById("errorMessage").innerHTML = "Json Web Token is expired"
    }

    firstIframe.classList.add("deactive");
    sendSms();
    firstForm.classList.remove("deactive");
})

async function getMessaage()
{
    try{
        let name = document.getElementById('username').value;
        let type = document.getElementById('type').value;
        console.log(name + type)
        await fetch("http://127.0.0.1:5000/nextmessage?name="+name+"&type="+type,{
            method:"POST"
        }).then(response=>response.text()).then((body)=>console.log(body))  
    }
    catch(ex){
        console.log(ex)
    }
}

async function sendCode() {
    var str;
    const numberInput = document.getElementById("numberInput");
    if (numberInput != null) {
        str = numberInput.value;
    }   
    try {
        const connection = await fetch("http://127.0.0.1:5000/check-code",  {
            method: "POST",
            body: str
        })
        const code = await connection.text()
        checkCode(code)
        changePage()
    }
    catch (ex) {
        console.log(ex)
    }
}

async function checkCode(code) {
    const printStatus = document.getElementById("printStatus");
    console.log(code)
    if(code == 'True'){
        const conn = await fetch("http://127.0.0.1:5000/dashboard",  {
            method: "POST"
        })
        console.log(conn)
        return conn;
    }
    printStatus.innerHTML = "Wrong code";
}


function JwtExpiration(JWT) {
    const expiry = (JSON.parse(atob(JWT.split('.')[1]))).exp;
    return (Math.floor((new Date).getTime() / 1000)) >= expiry;
}

function JwtEmailAccess(JWT){
    const email = (JSON.parse(atob(JWT.split('.')[1]))).email;
    return email
}

function changePage(){
    window.location.href = "dashboard.html"
}


async function sendSms() {
    try {
        const connection = await fetch("http://127.0.0.1:5000/send-sms",  {
            method: "POST",
        })
        console.log(connection);
    }
    catch (ex) {
        console.log(ex)
    }
}