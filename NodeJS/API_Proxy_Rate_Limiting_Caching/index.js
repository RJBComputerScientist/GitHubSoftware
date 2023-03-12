const express = require('express');
const cors = require('cors');
require('dotenv').config();
const PORT = process.env.PORT || 5000;

const app = express();

// Routes
app.get('/api', (req, res) => {
    res.json({SUCCESS: "OBJECT SUCCESS"})
})

// Enable cors
app.use(cors());

app.listen(PORT, () => console.log(`Server Running On Port ${PORT}`))