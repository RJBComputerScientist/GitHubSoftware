const { WaitTimerAsync, WaitTimerPromise } = require('../utils/WaitTimer');
// Timing With Async
async function TimingWithAsync(){
    console.log(1)
    await WaitTimerAsync(5);
    console.log(2)
    console.log(3)
}
TimingWithAsync()

// Timing With Promises
console.log(4)
WaitTimerPromise(10).then(() => {
    console.log(5)
    console.log(6)
    console.log(7)
})
