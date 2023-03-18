const http = require('http');

const server = http.createServer((req, res) => {
    if(req.url === '/'){
        res.write('Home Page')
        res.end();
    }else
    if(req.url === '/about'){
        res.write('About Page')
        res.end();
    } else {
        res.write('Error Page');
        res.end();
    }
});

server.listen(5000);

// npm - global command, comes with node
// npm --version

// local dependency - use it only in this particular project
// npm i <packageName>

// global dependency - use it in any project
//  npm install -g <packageName>
// sudo npm install -g <packageName> (mac)

// package.json - manifest file (stores important info about project/package)'
// manual approach (create package.json in the root, create properties etc)
// npm init (step by step, press enter to skip)
// npm init -y (everything default)

// npm install - is to install dependendcies to your project
// npm uninstall - is to uninstall dependendcies to your project
// npm update - is to update dependendcies to your project