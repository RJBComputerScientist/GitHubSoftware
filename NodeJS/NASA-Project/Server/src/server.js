// const express = require('express');

// const app = express();
// app.listen();
// ^^^ First way of starting a express server

// const http = require('http');
// const SERVER = http.createServer(/*SOMETHING*/);
// SERVER.listen(PORT, () => {
//     console.log(`Listening On Port ${PORT}...`);
// });
// Manual server creation #1



const http = require('http');
const app = require('./app');
const {loadPlanetsData} = require('./Models/planets.model')
const PORT = process.env.PORT || 8000;
const SERVER = http.createServer(app);
async function startServer(params) {
    await loadPlanetsData();
    SERVER.listen(PORT, () => {
        console.log(`Listening On Port ${PORT}...`);
    });
}
startServer();
// Combining Both Ways .. Good for better organization. Seperate server funcitonality and express code

// console.log(PORT);