const express = require('express');
const cors = require('cors');
const rateLimit = require('express-rate-limit').rateLimit;
require('dotenv').config();
const PORT = process.env.PORT || 5000;

const app = express();

// Rate Limiting .. A type of Proxy
const Limiter = rateLimit({
    windowMs: 10 * 60 * 1000, //10 Minutes
    max: 5
});
app.use(Limiter);
app.set('Trust Proxy', 1)

// Set static folder
app.use(express.static('public'));
// How You Will Interact With The API Being Used Depends On The Documentation

// Routes
app.use('/api', require('./routes'))

// Enable cors
app.use(cors());

app.listen(PORT, () => console.log(`Server Running On Port ${PORT}`))