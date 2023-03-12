const GoogleStrategy = require('passport-google-oauth20').Strategy;
const mongoose = require('mongoose');
const passport = require('passport');
const User = require('../models/User');
const WaitTimer = require('../utils/WaitTimer');

module.exports = function() {
    passport.use(new GoogleStrategy({
        clientID: process.env.GOOGLE_CLIENT_ID,
        clientSecret: process.env.GOOGLE_CLIENT_SECRET,
        callbackURL: '/auth/google/callback'
    },
    async (accessToken, refreshToken, profile, done) => {
        // console.log(profile);
        // storing user here
        const newUser = {
            googleId: profile.id,
            displayName: profile.displayName,
            firstName: profile.name.givenName,
            lastName: profile.name.familyName,
            image: profile.photos[0].value
        }

        await WaitTimer(5)
            
        try {
            let user = await User.findOne({ googleId: profile.id });
            // let user = await User.findById({ googleId: profile.id });
            // seems the logic is going to fast to read so i will force the waiting time
            if(user){
                // console.log("USER FOUND")
                done(null, user)
            } else {
                // console.log("NEW USER")
                user = await User.create(newUser);
                done(null, user);
            }
        } catch (err) {
            console.error(err);
        }
    }
    ));

    passport.serializeUser((user, cb) => {
        // process.nextTick(() => cb(null, {
        //     id: user.id,
        //     // username: user.username,
        //     // picture: user.picture
        //   }))
        // console.log("SERIALIZED: "+user.value)
        process.nextTick(() => cb(null, user.id))
        // cb(null, {
        //     id: user.id,
        //     username: user.username,
        //     picture: user.picture
        //   })

        //   cb(null, user.id)
        
      });
      
      passport.deserializeUser(function(user, cb) {
    //   passport.deserializeUser(function(id, cb) {
        // User.findById(user.id, 
        //     (err, user) => 
        //     process.nextTick(() => cb(err, user))
        // )
        // User.findById(user.id, (err, user) => 
        // cb(err, user))
        // console.log("DESERIALIZED: "+user.value)
            // process.nextTick(() => cb(null, User.findById(user.id))
            process.nextTick(() => cb(null, User.findOne({ googleId: user.id}))
            // cb(null, User.findById(user.id)
        )
      });

    //   passport.deserializeUser(function(user, cb) {
    //     process.nextTick(function() {
    //       return cb(null, User.findById(user.id,));
    //     });
    //   });

    // passport.deserializeUser(function(user, cb) {
    //     process.nextTick(function() {
    //       return cb(null, user);
    //     });
    //   });
}