// started operating system process
console.log("I go first, JavaScript is synchronous by default, NodeJS is Asynchronous by default");
setTimeout(() => {
    console.log("I go last since i am in a asynchronous scope");
}, 0);
console.log("I should be next since i am in a synchronous scope");