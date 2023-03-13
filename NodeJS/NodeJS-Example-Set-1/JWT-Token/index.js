const express = require('express');
const jwt = require('jsonwebtoken');

const app = express();

app.get('/api', (req, res) => {
    res.json({
        message: "Hello Universe, ANOTHER API SERVICE"
    })
});

app.post('/api/posts', (req, res) => {
    res.json({
        message: 'Posts Created...'
    });
})

app.post('/api/login', (req, res) => {
    const user = {
        id: 1,
        username: "Universe",
        email: "Universe@hello.com"
    };

    jwt.sign({ user: user }, "secretkey", (err, token) => {
        res.json({token});
    });
});

app.listen(3000, (req, res) => {
    console.log("Server Started On Port 3000")
});