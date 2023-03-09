const Product = require('../models/productModel');
const { getPostData } = require('../utils');
/**
 * @param {string} req is the request 
 * @param {string} res is the response 
 * @readonly GET /api/products
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
 * @readonly GET /api/product/:id
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

/**
 * @param {string} req is the request 
 * @param {string} res is the response 
 * @readonly  POST /api/products
 * @function {async} gets single product
 */
async function createProduct(req, res) {
    try {
        const body = await getPostData(req);

        const { name, description, price } = JSON.parse(body)

        const product = {
            name,
            description,
            price
           }
        const newProduct = await Product.create(product);
        res.writeHead(201, { 'Content-Type': 'application/json' })
        return res.end(JSON.stringify(newProduct))
    } catch (error) {
        console.log(error)
    }
}

/**
 * @param {string} req is the request 
 * @param {string} res is the response 
 * @readonly  PUT /api/products/:id
 * @function {async} Update single product
 */
async function updateProduct(req, res, id) {
    try {
        const product = await Product.findById(id);

        if(!product){
            res.writeHead(404, { 'Content-Type': 'application/json' });
            res.end(JSON.stringify({ message: 'Product Not Found' }))
        } else {
            const body = await getPostData(req);

        const { name, description, price } = JSON.parse(body)

        const productExist = {
            name: name || product.name,
            description: description || product.description,
            price: price || product.price
           }
        const updatedProduct = await Product.update(id, productExist);
        res.writeHead(200, { 'Content-Type': 'application/json' })
        return res.end(JSON.stringify(updatedProduct))
        }

    } catch (error) {
        console.log(error)
    }
}

/**
 * @param {string} req is the request 
 * @param {string} res is the response 
 * @readonly DELETE /api/products/:id
 * @function {async} Delete a product
 */
async function deleteProduct(req, res, id) {
    try {
        const product = await Product.findById(id);
        if(!product){
            res.writeHead(404, {'Content-Type': 'application/json'});
            res.end(JSON.stringify({ message: 'Product Not Found' }));
        } else {
            await Product.remove(id)
            res.writeHead(200, {'Content-Type': 'application/json'});
            res.end(JSON.stringify({ message: `Product ${id} removed` }));
        }
    } catch (error) {
        console.log(error)
    }
}

module.exports = {
    getProducts,
    getProduct,
    createProduct,
    updateProduct,
    deleteProduct
}