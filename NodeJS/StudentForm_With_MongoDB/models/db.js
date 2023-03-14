const mongoose = require('mongoose');

// mongoose.connect('mongodb://localhost:27017/StudentDB', {useNewUrlParser: true},
// err => {
//     if(!err){
//         console.log("Connection Succeeded")
//     } else {
//         console.log('Error In Connection ' + err);
//     }
// }
// );
//      ^^^^^^^ THIS WAY IS OUT DATED ^^^^^^^

mongoose.connect("mongodb://localhost:27017/StudentDB")
mongoose.connection.once('open', () => console.log("Connection Succeeded")).on('error', (err) => {
    console.log('Error In Connection ' + err);
});
//      ^^^^^^^ MOST UPDATED WAY ^^^^^^^

require('./student.model');