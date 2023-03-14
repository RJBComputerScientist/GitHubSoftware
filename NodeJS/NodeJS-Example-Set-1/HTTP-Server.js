const http = require('http');

const server = http.createServer((req, res) => {
    if(req.url === '/'){
        res.end('Welcome To Our Home Page')
    }
    if(req.url === '/about'){
        res.end('Here Is Our Short History');
    } 
});

server.listen(5000);