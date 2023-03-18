const { readFile } = require('fs');

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