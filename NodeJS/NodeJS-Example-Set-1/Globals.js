// GLOBAL - NO WINDOW !!!!
// __dirname  - path to current directory
// __filename - file name
// require    - function to use modules (CommonJS)
// module     - info about current module (file) Encapsulated Code (only share minimum)
// process    - info about env where the program is being executed

console.log(__dirname);
// setInterval(() => {
//     console.log("Hello Universe");
// }, 1000);

console.log(module)
module.exports.items = ['Item 1', 'Item 2'];
// ^^ Alternative Syntax ^^
console.log(require)