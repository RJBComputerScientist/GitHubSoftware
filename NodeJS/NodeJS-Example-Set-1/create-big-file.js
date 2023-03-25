const { writeFileSync } = require('fs');
for( let i = 0; i < 1000; i++){
    writeFileSync('./Test-content/big.txt', `Hello Universe ${i}\n`, { flag: 'a' });
}