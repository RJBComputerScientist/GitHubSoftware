// BUILT-IN MODULES

const os = require('os');

// INFO ABOUT CURRENT USER
const user = os.userInfo();
console.log(user);

// object returns the system uptime in seconds .. using 'global' isnt needed
global.console.log(`The System Uptime Is ${os.uptime()} Seconds`);

const currentOS = {
    name: os.type(),
    release: os.release(),
    totalMemory: os.totalmem(),
    freeMemory: os.freemem(),
};

console.log(currentOS);

const path = require('path');

console.log(path.sep);

const filepath = path.join('/Test-content/', 'Test-subfolder', 'test.txt');
const base = path.basename(filepath);
console.log(filepath, base);

const absolute = path.resolve(__dirname, 'Test-content', 'Test-subfolder', 'test.txt');
global.console.log(absolute)
