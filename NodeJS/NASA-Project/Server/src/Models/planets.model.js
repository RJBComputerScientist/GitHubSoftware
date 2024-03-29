const { parse } = require('csv-parse');
const fs = require('fs');
const path = require('path');

const HabitablePlanets = [];

function isHabitablePlanet(planet) {
    return planet['koi_disposition'] === 'CONFIRMED'
        && (planet['koi_insol'] > 0.36 && planet['koi_insol'] < 1.11)
        && planet['koi_prad'] < 1.6;
}

function loadPlanetsData(){
    // to better know when the data is successful
return new Promise((resolve, reject) => {
    fs.createReadStream(path.join(__dirname, '..', '..', 'data','kepler_data.csv'))
    .pipe(parse({
        comment: '#',
        columns: true,
    }))
    .on('data', (data) => {
        if(isHabitablePlanet(data))
            HabitablePlanets.push(data);
    })
    .on('error', (err) => {
        console.error(err);
        reject(err);
    })
    .on('end', () => {
      
        console.log(`${HabitablePlanets.length} habitable planets found!`);
        resolve();
    })
    parse()
})
}
    module.exports = {
        loadPlanetsData,
        planets: HabitablePlanets
    }