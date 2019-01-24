(function validate() {
    let buttonElement = document.querySelector('#exercise button');
    buttonElement.addEventListener('click', () => GenerateEGN());

    let yearInputElement = document.getElementById('year');
    let monthSelectElement = document.getElementById('month');
    let dateInputElement = document.getElementById('date');
    let maleInputRadioElement = document.getElementById('male');
    let femaleInputRadioElement = document.getElementById('female');
    let regionInputElement = document.getElementById('region');
    let egnOutputParagraphElement = document.getElementById('egn');

    function GenerateEGN() {
        let EGN = '';
        let year = yearInputElement.value;
        let month = monthSelectElement.selectedIndex;
        let date = dateInputElement.value;
        let regionalCode = regionInputElement.value;
        let genderNumber = maleInputRadioElement.checked ? 2 : 1;

        yearInputElement.value = '';
        monthSelectElement.value = '';
        dateInputElement.value = '';
        maleInputRadioElement.checked = false;
        femaleInputRadioElement.checked = false;
        regionInputElement.value = '';

        let isYearInvalid = year < 1900 || year > 2100 || year.trim() === '';
        let isRegioCodeInvalid = regionalCode < 43 || regionalCode > 999 || regionalCode.trim() === '';

        if (isYearInvalid || isRegioCodeInvalid) {
            return;
        }

        let firstTwoDigits = year.toString().substr(-2);
        let secondTwoDigits = addLeadingZeroIfLowerThanNine(month);
        let thirdTwoDigits = addLeadingZeroIfLowerThanNine(date);
        let fourthTwoDigits = regionalCode.slice(0, 2);

        EGN += firstTwoDigits + secondTwoDigits + thirdTwoDigits + fourthTwoDigits + genderNumber;

        let remainder = calcutaleRemainder(EGN) > 9 ? 0 : calcutaleRemainder(EGN);
        EGN += remainder;

        egnOutputParagraphElement.textContent = `Your EGN is: ${EGN}`;
    }

    function addLeadingZeroIfLowerThanNine(value) {
        return value > 9 ? value : '0' + value;
    }

    function calcutaleRemainder(number) {
        let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let sum = 0;

        for (let i = 0; i < weightPosition.length; i++) {
            if (Number(number[i]) !== 0) {
                sum += (Number(number[i]) * Number(weightPosition[i]));
            }
        }
        return sum % 11;
    }
})();