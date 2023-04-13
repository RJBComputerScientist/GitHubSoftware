const asyncHandler = require("express-async-handler");
const bcrypt = require("bcrypt");
const User = require("../models/userModel");
/** 
 * @description Register A User
 * @requires POST /api/users/register
 * @access public
 */
const registerUser = asyncHandler(async(req, res) => {
    const { username, email, password } = req.body;
    if(!username || !email || !password) {
        res.status(400);
        throw new Error("All Fields Are Mandatory!");
    }
    const userAvailable = await User.findOne({email});
    if(userAvailable) {
        res.status(400);
        throw new Error("User Already Registered!")
    }

    // Hash Password
    const hashedPassword = await bcrypt.hash(password, 10);
    console.log("Hashed Password: " + hashedPassword);
    const user = await User.create({
        username,
        email, 
        password: hashedPassword
    });
    console.log(`User Created ${user}`);
    if(user){
        res.status(201).json({_id: user.id, email: user.email});
    } else {
        res.status(400);
        throw new Error("User Data Is Not Valid");
    };
    res.json({ messageMang: "Register the user" });
});
/** 
 * @description Login User
 * @requires POST /api/users/login
 * @access public
 */
const loginUser = asyncHandler(async(req, res) => {
    res.json({ messageMang: "login user" });
});

/** 
 * @description Login User
 * @requires POST /api/users/login
 * @access public
 */
const currentUser = asyncHandler(async(req, res) => {
    res.json({ messageMang: "Current user info" });
});

module.exports = { registerUser, loginUser, currentUser }