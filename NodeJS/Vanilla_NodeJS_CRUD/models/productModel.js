let products = require("../data/products");
const { randomUUID } = require('crypto');
const { writeDataToFile } = require('../utils')

function findAll(){
    return new Promise((resolve, reject) => {
        resolve(products);
    })
}

function findById(id = ""){
    return new Promise((resolve, reject) => {
        const product = products.find((p) => p.id === id);
        resolve(product);
    })
}
/**
 * 
 * @param {Array} ArrayOfIds 
 * @param {Array} IdsRequested 
 * @returns New filtered array that is based on ArrayOfIds.
 */
function findManyIds(IdsRequested = []){
//return a promise
return new Promise((resolve, reject) => {
    var NewArray = [];
// for loop to look through IdsRequested 
    for(var x = 0; x < IdsRequested.length; x++){
        
        // Find object that matches id
        let FoundObject = products.find(z => z.id === IdsRequested[x]);
        // if FoundObject is undefined
        if(FoundObject === undefined){
            console.log("Not Found Since Its", FoundObject);
        } else {
            // else push FoundObject
            console.log("Found A Object", FoundObject);
            NewArray.push(FoundObject);
        }
    
    }
    resolve(NewArray);
})

}

function create(product){
    return new Promise((resolve, reject) => {
        const newProduct = {id: randomUUID(), ...product};
        // const newProduct = {id: products.length + 1, ...product};
        products.push(newProduct);
        writeDataToFile('./data/products.json', products);
        resolve(newProduct);
    })
}

function update(id, product){
    return new Promise((resolve, reject) => {
        const index = products.findIndex(x => x.id === id);
        products[index] = {id, ...product};
        writeDataToFile('./data/products.json', products);
        resolve(products[index]);
    })
}

function remove(id){
    return new Promise((resolve, reject) => {
        products = products.filter(x => x.id !== id)
        writeDataToFile('./data/products.json', products);
        resolve();
    })
}

module.exports = {
    findAll,
    findById,
    findManyIds,
    create,
    update,
    remove
}