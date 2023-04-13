const express = require("express");
const errorHandler = require("./middleware/errorHandling");
const dotenv = require("dotenv").config();
require("./config/db");
const app = express();
const port = process.env.PORT || 5000;

app.use(express.json());
app.use('/api/contacts', require("./routes/contactRoutes"));
app.use(errorHandler);

app.listen(port, () => {
    console.log(`Server Running On Port ${port}`);
});