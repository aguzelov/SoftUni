(function () {
    let exerciseElement = document.getElementById('exercise');
    let buttonElement = exerciseElement.lastElementChild;

    buttonElement.addEventListener('click', function () {
        let inputElement = document.querySelector('#exercise input');
        let input = inputElement.value;

        let divElement = document.getElementById('year');

        let headerElement = divElement.firstElementChild;
        headerElement.innerHTML = `${isLeap(input) ? 'Leap Year' : 'Not Leap Year'}`;

        let yearElement = divElement.lastElementChild;
        yearElement.innerHTML = input;

        inputElement.value = '';
    });

    function isLeap(year) {
        return ((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0);
    }

})();