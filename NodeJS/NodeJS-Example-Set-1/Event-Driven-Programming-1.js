const EventEmitter = require('events');

const customEmitter = new EventEmitter();

customEmitter.on('response', (name, id) => {
    //            ^^^ name of event
    console.log('Data Received', name, id);
    // Inside callback   
});

customEmitter.on('response', () => {
    //            ^^^ name of event
    console.log('Some other logic');
    // Inside callback   
});

customEmitter.emit('response', "Mang", 40);
//           ^^^ calling event