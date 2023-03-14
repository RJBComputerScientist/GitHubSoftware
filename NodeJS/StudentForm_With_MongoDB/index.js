require('./models/db')
const express = require('express');
const path = require('path');
const handleBars = require('handlebars');
const exphbs = require('express-handlebars');
const { allowInsecurePrototypeAccess } = require('@handlebars/allow-prototype-access');
const bodyParser = require('body-parser');

const studentController = require("./controllers/studentController");

var app = express();

app.use(bodyParser.urlencoded({extended: false}));
app.use(bodyParser.json());

app.get('/', (req, res) => {
    res.send(`
        <h2>Welcome To Students Database!!</h2>
        <h3>Click Here To Get Access To The <b> <a href="/student/list">Database</a></b></h3>
    `)
});

app.set("views", path.join(__dirname, '/views/'));

app.engine('hbs', exphbs.engine({
    handlebars: allowInsecurePrototypeAccess(handleBars),
    extname: 'hbs',
    defaultLayout: 'MainLayout',
    layoutsDir: __dirname + "/views/layouts/"
}));

app.set("view engine", "hbs")

app.listen(3000, () => {
    console.log('Server Started At Port 3000');
});

app.use("/student", studentController);
