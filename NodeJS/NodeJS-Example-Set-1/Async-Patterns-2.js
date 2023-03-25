// const { readFile, writeFile } = require('fs');
const { readFile, writeFile } = require('fs').promises; //built-in promises
const util = require('util');
const readFilePromise = util.promisify(readFile);
const writeFilePromise = util.promisify(writeFile);

const getText = (path) => {
return new Promise((resolve, reject) => {
    readFile(path, 'utf8', (err, result) => {
        if(err){
            reject(err)
        } else {
            resolve(result)
        }
        });
    })
}   

getText('./Test-content/result-sync.txt')
.then((result) => console.log(result))
.catch((err) => console.error(err));

// async keyword
const start = async () => {
    try {
        const first =  await getText('./Test-content/result-sync.txt');
        const second =  await getText('./Test-content/first.txt');
        await writeFilePromise('./Test-content/result-fromt-util-package.txt', `This Is Awesome: ${first} ${second}`);
        console.log(first, second)
        // --------------------------------------------------------------------------
        const firstpromisify =  await readFilePromise('./Test-content/result-sync.txt', 'utf8');
        const secondpromisify =  await readFilePromise('./Test-content/first.txt', 'utf8');
        await writeFilePromise('./Test-content/result-fromt-util-package.txt', `This Is Awesome: ${firstpromisify} ${secondpromisify}`);
        console.log(firstpromisify, secondpromisify)
        // --------------------------------------------------------------------------
        // ^^ for the built-in promises
        const firstBuiltInPromises =  await readFile('./Test-content/result-sync.txt', 'utf-8');
        const secondBuiltInPromises =  await readFile('./Test-content/first.txt', 'utf-8');
        await writeFile('./Test-content/result-fromt-util-package.txt', `This Is Awesome: ${firstBuiltInPromises} ${secondBuiltInPromises}`,
        {flag: 'a'});
        console.log(firstBuiltInPromises, secondBuiltInPromises)
    } catch (error) {
        console.error(error)
    }
}

start();