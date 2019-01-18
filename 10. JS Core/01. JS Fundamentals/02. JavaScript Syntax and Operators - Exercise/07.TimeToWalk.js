function walkCalculator(steps, lengthOtFootprint, speed){

    let totalDistanceInMeters = steps * lengthOtFootprint;

    let minutesToAdd = Math.floor(totalDistanceInMeters / 500);

    let totalDistanceInKm = totalDistanceInMeters * 0.001;

    let totalTime = totalDistanceInKm / speed;

    let hours = Math.floor(totalTime);

    let minutesLeft =((totalTime % 1) * 60);
    let minutes = Math.floor((totalTime % 1) * 60) + minutesToAdd;

    let seconds = Math.round((minutesLeft % 1) * 60);

    console.log(`${("0" + hours).slice(-2)}:${("0" + minutes).slice(-2)}:${("0" + seconds).slice(-2)}`);

}

walkCalculator(4000, 0.60, 5);