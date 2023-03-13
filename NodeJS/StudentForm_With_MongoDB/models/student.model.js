const mongoose = require('mongoose');

var studentSchema = new mongoose.Schema({
    fullName: {
        type: String,
        required: "This Field Is Required"
    },
    email: {
        type: String,
        required: "This Field Is Required"
    },
    mobile: {
        type: Number,
        required: "This Field Is Required"
    },
    city: {
        type: String,
        required: "This Field Is Required"
    }
});

mongoose.model('Student', studentSchema);