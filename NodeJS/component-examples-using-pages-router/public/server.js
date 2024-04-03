const greetInput = document.querySelector("#greet-input");
const greetMessage = document.querySelector("#greet-msg");
const btn = document.querySelector("#greet-btn");

function greetMessaging(name){
    return `Hello ${name}!! Our tour guide will show you around!`;
}

function greet(){
    let name = greetInput.value;
    greetMessage.textContent = greetMessaging(name);
}

btn.addEventListener("click", greet);
console.log("IM READ FROM THE PUBLIC FOLDER")