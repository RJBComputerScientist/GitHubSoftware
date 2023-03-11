module.exports = function WaitTimer(seconds = Number){
    return new Promise((resolve, reject) => {
        setTimeout((resolve(console.log("Waiting"))), seconds * 1000)
    });
}