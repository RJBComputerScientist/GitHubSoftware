const Product = require('../models/productModel');
/**
 * @param {string} req is the request 
 * @param {string} res is the response 
 * @readonly /api/products
 * @function {async} gets all products
 */
async function getProducts(req, res) {
    try {
        const products = await Product.findAll();
        res.writeHead(200, {'Content-Type': 'application/json'});
        res.end(JSON.stringify(products));
    } catch (error) {
        console.log(error)
    }
}

/**
 * @param {string} req is the request 
 * @param {string} res is the response 
 * @readonly /api/product/:id
 * @function {async} gets single product
 */
async function getProduct(req, res, id) {
    try {
        const product = await Product.findById(id);
        if(!product){
            res.writeHead(404, {'Content-Type': 'application/json'});
            res.end(JSON.stringify({ message: "Product Not Found" }));
        }else {
            res.writeHead(200, {'Content-Type': 'application/json'});
            res.end(JSON.stringify(product));
        }
    } catch (error) {
        console.log(error)
    }
}

module.exports = {
    getProducts,
    getProduct
}