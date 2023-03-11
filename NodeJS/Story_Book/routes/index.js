const express = require('express');
const router = express.Router();

/**
 * @description Login/Landing Page
 * @readonly GET /
 */
router.get('/login', (req, res) => {
    res.render('login');
    //          ^^ make sure its all lowercase
});

/**
 * @description Dashboard Page
 * @readonly GET /dashboard
 */
router.get('/dashboard', (req, res) => {
    res.render('dashboard');
    //          ^^ make sure its all lowercase
});

module.exports = router