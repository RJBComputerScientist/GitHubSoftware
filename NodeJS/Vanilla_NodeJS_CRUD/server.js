const http = require('http');
const { getProducts, getProduct, createProduct, updateProduct, deleteProduct, getManyProducts } = require('./controllers/productController');
const Enum = require('./models/HTTP');

const server = http.createServer((req, res) => {
    if(req.url === '/api/products' && req.method === Enum.GET){
        getProducts(req, res)
    } else if(req.url.match(/\/api\/products\/([a-z0-9]+)/) && req.method === Enum.GET){
        const id = req.url.split('/')[3]; //api/products/1
        //           '' as zero than..     ^^1,   ^^ 2,  ^^ 3
        console.log(req.url.split("&"))
        getProduct(req, res, id);
    } else if(req.url.match(/\/api\/products\/([,][a-z0-9]+)/) && req.method === Enum.GET){
        console.log("Multiple IDS");
        console.log(req.url);
        // console.log(req.url.split('/')[3].split(","));
        const ArrayProductsRequested = req.url.split('/')[3].split(",");
        console.log(ArrayProductsRequested);
        getManyProducts(req, res, ArrayProductsRequested);
    }
     else if(req.url.match(/\/api\/products/) && req.method === Enum.POST){
        createProduct(req, res);
    } else if(req.url.match(/\/api\/products\/([a-z0-9]+)/) && req.method === Enum.PUT){
        const id = req.url.split('/')[3]; //api/products/1
        //           '' as zero than..    ^^1, ^^ 2, ^^ 3
        updateProduct(req, res, id);
    } else if(req.url.match(/\/api\/products\/([a-z0-9]+)/) && req.method === Enum.DELETE){
        const id = req.url.split('/')[3]; //api/products/1
        //           '' as zero than..    ^^1, ^^ 2, ^^ 3
        deleteProduct(req, res, id);
    }
    else {
        res.writeHead(404, {'Content-Type': 'application/json'});
        res.end(JSON.stringify({ message: 'Route Not Found' }));
    }

});

const PORT = process.env.PORT || 5000;

server.listen(PORT, () => console.log(`Server running on port ${PORT}`));