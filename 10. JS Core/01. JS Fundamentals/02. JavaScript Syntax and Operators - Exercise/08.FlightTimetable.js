function flightInformation(arr){

    let status = arr[0];
    let townName = arr[1];
    let time = arr[2];
    let flightNumber = arr[3];
    let gate = arr[4];

    console.log(`${status}: Destination - ${townName}, Flight - ${flightNumber}, Time - ${time}, Gate - ${gate}`);
}

flightInformation(['Departures', 'London', '22:45', 'BR117', '42']);