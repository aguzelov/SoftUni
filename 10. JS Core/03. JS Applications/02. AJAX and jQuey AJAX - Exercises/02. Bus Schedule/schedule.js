function solve() {
    return {
        depart: depart,
        arrive: arrive
    };
}

let currentStop = {
    name: 'depot',
    next: 'depot'
};

//Depart
function depart() {
    request('GET', getURL(currentStop.next), '', onDepartSuccess, onError);
    swapButtons();
}

function onDepartSuccess(data) {
    if (!data) {
        onError();
    } else {
        currentStop.name = data.name;
        currentStop.next = data.next;

        $('.info').text(`Next stop ${currentStop.name}`);
    }
}


//Arrive
function arrive() {
    $('.info').text(`Arriving at ${currentStop.name}`);
    swapButtons();
}

function onError() {
    $('.info').text(`Error`);

    disableButtons();
}

function getURL(currentId) {
    let url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;

    return url;
}

function request(method, url, data, onSuccess, onError) {
    $.ajax({
        method,
        url,
        data,
        success: onSuccess,
        error: onError
    });
}

function swapButtons() {
    let $depart = $('#depart');
    let $arrive = $('#arrive');

    if ($depart.is(":disabled")) {
        $depart.prop('disabled', false);
        $arrive.prop('disabled', true);
    } else {
        $depart.prop('disabled', true);
        $arrive.prop('disabled', false);
    }
}

function disableButtons() {
    $('#depart').prop('disabled', true);
    $('#arrive').prop('disabled', true);
}

let result = solve();