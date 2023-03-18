const { readFile } = require('fs');

console.log("I am before readFile");
// Checking file... i will go to libuv and process this method
readFile('./Test-content/first.txt', 'utf8', (err, result) => {
    if(err){
        console.error(err);
        return;
    }
    console.log(result);
    console.log("I completed the file reading");
});
console.log("I should be before the file reading is done");