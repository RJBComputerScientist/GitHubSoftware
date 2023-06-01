const http = require('http');
const { readFileSync } = require('fs');

// get all files
const HomePage = readFileSync('./navbar-app/index.html');
const HomeStyles = readFileSync('./navbar-app/styles.css');
const HomeImage = readFileSync('./navbar-app/logo.svg');
const HomeLogic = readFileSync('./navbar-app/browser-app.js');

const server = http.createServer((req, res) => {
    
})