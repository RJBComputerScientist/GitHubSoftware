const express = require('express');
const dotenv = require('dotenv');
const morgan = require('morgan');
const connectDB = require('./config/db');

// Load Config
dotenv.config({ path: './config/config.env' });

// database call
connectDB()

const app = express();

if(process.env.NODE_ENV === 'developemnt'){
    app.use(morgan('dev'));
}

const PORT = process.env.PORT || 3000;

app.listen(
    PORT,
    console.log(`Server Running In ${process.env.NODE_ENV} Mode On Port ${PORT}`)
);