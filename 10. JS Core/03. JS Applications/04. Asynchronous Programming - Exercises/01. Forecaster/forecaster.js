function attachEvents() {
    $('#submit').on('click', getWeather);
}

let currentLocationCode;
let symbols = {
    'Sunny': '☀', // ☀
    'Partly sunny': '⛅', // ⛅
    'Overcast': '☁', // ☁
    'Rain': '☂', // ☂
    'Degrees': '°'   // °
};

function getWeather() {
    getAsync('locations', getForecast, onError);

    $('#forecast').show();
}

function getForecast(locations) {
    let $location = $('#location').val();

    let location = locations.find(l => l.name === $location);
    if (location) {
        currentLocationCode = location.code;
        getAsync(`forecast/today/${location.code}`, findUpcoming, onError);
    }
}

function findUpcoming(location) {
    addCurrentCondition(location);
    getAsync(`forecast/upcoming/${currentLocationCode}`, addUpcoming, onError);
}

function addCurrentCondition(location) {
    let forecast = location.forecast;

    let $currentCondition = $('#current');

    let $symbol = $('<span>');
    $symbol.text(symbols[forecast.condition]);
    $symbol.addClass('condition symbol');
    $currentCondition.append($symbol);

    let $condition = $('<span>');
    $condition.addClass('condition');

    let $name = $('<span>');
    $name.addClass('forecast-data');
    $name.text(location.name);
    $condition.append($name);

    let $temp = $('<span>');
    $temp.addClass('forecast-data');
    $temp.text(`${forecast.low}${symbols.Degrees}/${forecast.high}${symbols.Degrees}`);
    $condition.append($temp);

    let $locationContition = $('<span>');
    $locationContition.addClass('forecast-data');
    $locationContition.text(forecast.condition);
    $condition.append($locationContition);

    $currentCondition.append($condition);
}

function addUpcoming(upcomingConditions) {
    console.log(upcomingConditions);

    let $upcoming = $('#upcoming');

    upcomingConditions.forecast.forEach(f => {
        let $upcomingSpan = $('<span>');
        $upcomingSpan.addClass('upcoming');

        let $symbol = $('<span>');
        $symbol.text(symbols[f.condition]);
        $symbol.addClass('symbol');
        $upcomingSpan.append($symbol);

        let $temp = $('<span>');
        $temp.addClass('forecast-data');
        $temp.text(`${f.low}${symbols.Degrees}/${f.high}${symbols.Degrees}`);
        $upcomingSpan.append($temp);

        let $locationContition = $('<span>');
        $locationContition.addClass('forecast-data');
        $locationContition.text(f.condition);
        $upcomingSpan.append($locationContition);

        $upcoming.append($upcomingSpan);
    });
}

function getAsync(path, resolve, reject) {
    let url = `https://judgetests.firebaseio.com/${path}.json`;

    $.ajax({
        url: url,
        method: 'GET'
    })
        .then(resolve)
        .catch(reject);
}

function onError(err) {
    console.log(err);
}

