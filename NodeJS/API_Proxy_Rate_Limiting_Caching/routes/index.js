const url = require('url');
const express = require('express');
const router = express.Router();
const needle = require('needle');
const apicache = require('apicache');

// Env Vars
const API_BASE_URL = process.env.API_BASE_URL;
const API_KEY_NAME = process.env.API_KEY_NAME;
const API_KEY_VALUE = process.env.API_KEY_VALUE;

// Initialize Cache
let cache = apicache.middleware

/**
 * @description For retrieving the API and its parameters
 */
router.get('/', cache('2 minutes'), async (req, res) => {
    try {
        console.log(url.parse(req.url, true).query)

        const params = new URLSearchParams({
            [API_KEY_NAME]: API_KEY_VALUE,
            ...url.parse(req.url, true).query
        })
        // REMEMBER I AM NOT USING A REAL API URL... So make or obtain one for full logic output
        const apiRes = await needle('get', `${API_BASE_URL}?${params}`);
        const data = apiRes.body;

        // Log The Request To The Public API
        if(process.env.NODE_ENV !== 'production'){
            console.log(`REQUESTURL: ${API_BASE_URL}?${params}`)
        }
    
        res.status(200).json(data);
    } catch (error) {
        res.status(500).json({error});
    
    }
});

module.exports = router;