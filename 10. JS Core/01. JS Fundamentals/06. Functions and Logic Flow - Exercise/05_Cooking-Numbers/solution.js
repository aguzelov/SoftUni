(function () {
    let outputElement = document.getElementById('output');
    let numberElement = document.querySelector('#exercise input');

    let actions = {
        'chop': function (num) { return num / 2; },
        'dice': function (num) { return Math.sqrt(num); },
        'spice': function (num) { return num + 1; },
        'bake': function (num) { return num * 3; },
        'fillet': function (num) {
            num = num;
            var val = num - (num * 0.20);
            return val;
        }
    };

    let buttons = document.querySelectorAll('#operations button');
    for (let button of buttons) {
        button.addEventListener('click', function () {
            let number = 0;

            if (outputElement.textContent === '') {
                number = numberElement.value === '' ? 0 : parseFloat(numberElement.value);
            } else {
                number = parseFloat(outputElement.textContent);
            }

            let command = this.textContent.toLowerCase();

            number = actions[command](number);

            outputElement.textContent = number;
            numberElement.value = '';
        });
    }
})();

