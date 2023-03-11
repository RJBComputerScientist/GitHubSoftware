const express = require('express');
const dotenv = require('dotenv');
const morgan = require('morgan');
const { engine } = require('express-handlebars');
const path = require('path');
const passport = require('passport');
const session = require("express-session");
const connectDB = require('./config/db');

// Load Config
dotenv.config({ path: './config/config.env' });

// Passport Config
require('./config/passport')(passport);

// database call
connectDB();

const app = express();

// Environment variable behavior 
if(process.env.NODE_ENV === 'developemnt'){
    app.use(morgan('dev'));
}

//  Handlebars
app.engine('.hbs', engine({ defaultLayout: 'main', extname: '.hbs'}));
app.set('view engine', '.hbs');

// Express Session
app.use(session({
    secret: 'keyboard cat',
    resave: false,
    saveUninitialized: false
  }))

// Passport Middleware
app.use(passport.initialize());
app.use(passport.session())

// Static Folder
app.use(express.static(path.join(__dirname, 'public')))

// Routes
app.use('/', require('./routes/index'));
app.use('/auth', require('./routes/auth'));

const PORT = process.env.PORT || 3000;

app.listen(
    PORT,
    console.log(`Server Running In ${process.env.NODE_ENV} Mode On Port ${PORT}`)
);