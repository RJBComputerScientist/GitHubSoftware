setInterval(() => {
    console.log("Im in a Asynchronous Scope AND i keep running until i am cleared");
    console.log(a++);
}, 2000);
console.log("I go first since i am in a synchronous scope");
let a = 0;

// SERVER EXAMPLE
const http = require('http');

const Server = http.createServer((req, res) => {
    console.log("Im inside of the server, request event");
    res.end(`Hello Universe, Im a HTML tag! Using Hoisting ${a} is incrementing every two seconds`);
});

Server.listen(5000, () => {
    console.log("Server Is Listening On Port: 5000");
});