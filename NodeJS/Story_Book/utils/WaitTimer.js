function WaitTimerPromise(seconds = Number){
    return new Promise((resolve, reject) => {
         setTimeout(() => resolve(console.log("Waiting... In Promise")), seconds * 1000)
    });
}

async function WaitTimerAsync(seconds = Number){
  setTimeout(() => {
    console.log("Waiting... In Async Function");
  }, seconds * 1000)
}

module.exports = {
    WaitTimerAsync,
    WaitTimerPromise
}