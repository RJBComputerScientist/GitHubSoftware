var http = require('http');
var fs = require('fs');

http.createServer( (req, res) => {
    // const text = fs.readFileSync('./Test-content/big.txt', 'utf8');
    // res.end(text);
    // ^^ not smart to send large files over http
    const fileStream = fs.createReadStream('./Test-content/big.txt', 'utf8');
    fileStream.on('open', () => {
        fileStream.pipe(res);
        // pipe streams
    })
    fileStream.on('error', (err) => {
        res.end(err)
    })
    // ^^ creating chunks is better if you want to send files across http
}).listen(5000)