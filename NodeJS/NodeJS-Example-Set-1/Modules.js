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

const {readFileSync, writeFileSync, writeSync, readSync, readFile, writeFile} = require('fs');
const { Console } = require('console');

const first = readFileSync('./Test-content/first.txt', 'utf8');
const second = readFileSync('./Test-content/second.txt', 'utf8');

console.log(first, second);
writeFileSync('./Test-content/result-sync.txt', `Here Is The Result: ${first}, ${second}`, {flag: 'a'});
console.log("Start Task")
readFile('./Test-content/first.txt', 'utf8', (err, buffer) => {
    if(err){
        console.log(err);
        return
    }
    const first = buffer;
    readFile('./Test-content/second.txt', 'utf8', (err, buffer) => {
        if(err){
            console.log(err);
            return
        }
        const second = buffer;
        writeFile('./Test-content/result-sync.txt', `Here Is The Result: ${first}, ${second}`, (err, buffer) => {
            if(err){
                console.log(err);
                return
            }
            console.log(buffer)
        });
    })
    console.log("Done With This Task")
});
//          ^^^^^^^^^^^ CALLBACK HELL ^^^^^^^^^^^
console.log('Starting Next Task')