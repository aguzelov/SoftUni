function solve(input) {
    let strElement = document.getElementById('str');
    let resultElement = document.getElementById('result');

    let strArr = strElement.value.split(',');
    let str = strArr[0];
    let information = strArr[1].trim();

    let informations = {
        'name': function (text) {
            return `Mr/Ms, ${getName(text)}, have a nice flight!`;
        },
        'flight': function (text) {
            return `Your flight number ${getFlightNumber(text)} is from ${getAirport(text)}.`;
        },
        'company': function (text) {
            return `Have a nice flight with ${getCompany(text)}.`;
        },
        'all': function (text) {
            return `Mr/Ms, ${getName(text)}, your flight number ${getFlightNumber(text)} is from ${getAirport(text)}. Have a nice flight with ${getCompany(text)}.`;
        }
    };

    resultElement.innerHTML = informations[information](str);

    function getName(text) {
        let regex = new RegExp('\\s([A-Z][a-zA-Z]*)-(([A-Z][a-zA-Z]*).-)*([A-Z][a-zA-Z]*)\\s', 'gi');

        let match = regex.exec(text);
        let name = match[0].trim();
        name = name.replace(new RegExp('-', 'g'), ' ');

        return name;
    }

    function getAirport(text) {
        let regex = new RegExp('\\s([A-Z]{3})\/([A-Z]{3}\\s)', 'g');
        let match = regex.exec(text);
        let airport = match[0].trim();
        airport = airport.replace(new RegExp('\/', 'g'), ' to ');
        return airport;
    }

    function getFlightNumber(text) {
        let regex = new RegExp('\\s([A-Z]{1,3})([0-9]{1,5}\\s)', 'g');
        let match = regex.exec(text);
        let number = match[0].trim();

        return number;
    }

    function getCompany(text) {
        let regex = new RegExp('-\\s([A-Z][a-z]*)\\*([A-Z][a-z]*)\\s', 'g');
        let match = regex.exec(text);
        let company = match[0].trim();
        company = company.replace(new RegExp('- ', 'g'), '');
        company = company.replace(new RegExp('\\*', 'g'), ' ');

        return company;
    }
}

solve(' TEST-T.-TESTOV   SOF/VIE OS806 - Austrian*Airlines T24G55 STD11:15 STA11:50 , all');