function attachEventsListeners() {
    let buttons = document.querySelectorAll('div input:last-child');

    for (const button of buttons) {
        button.addEventListener('click', (e) => {
            let currentTextInput = e.target.parentNode.children[1];
            let currentText = currentTextInput.value;
            let currentId = currentTextInput.id;

            console.log(currentText);
            console.log(currentId);

            let newValues = {};

            let converter = {
                days: (value) => {
                    newValues.days = value;
                    newValues.hours = value * 24;
                    newValues.minutes = value * 1440;
                    newValues.seconds = value * 86400;
                    return newValues;
                },
                hours: (value) => {
                    newValues.days = value / 24;
                    newValues.hours = value;
                    newValues.minutes = value * 60;
                    newValues.seconds = value * 3600;
                    return newValues;
                },
                minutes: (value) => {
                    newValues.days = value / 1440;
                    newValues.hours = value / 60;
                    newValues.minutes = value;
                    newValues.seconds = value * 60;
                    return newValues;
                },
                seconds: (value) => {
                    newValues.days = value / 86400;
                    newValues.hours = value / 3600;
                    newValues.minutes = value / 60;
                    newValues.seconds = value;
                    return newValues;
                },
            };

            let convertedTime = converter[currentId](+currentText);

            for (const b of buttons) {
                let input = b.parentNode.children[1];
                input.value = convertedTime[input.id];
            }
        });
    }
}
