(function () {
    let fromElement = document.getElementById('from');
    let toElement = document.getElementById('to');
    let selectElement = document.querySelector('#exercise select');

    let cardsElement = document.getElementById('cards');
    let cards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A',];

    let buttonElement = document.querySelector('#exercise button');
    buttonElement.addEventListener('click', function () {
        let from = fromElement.value;
        let startIndex = cards.indexOf(from);
        console.log(`Start index: ${startIndex} - from : ${from}`);

        let to = toElement.value;
        let endIndex = cards.indexOf(to);
        console.log(`End index: ${endIndex} - to : ${to}`);

        let selectOption = selectElement.options[selectElement.selectedIndex].value;
        let suit = selectOption[selectOption.length - 1];
        console.log(suit);


        for (let index = startIndex; index <= endIndex; index++) {
            let cardElement = document.createElement('div');
            cardElement.classList.add('card');

            let firstSuitElement = document.createElement('p');
            firstSuitElement.textContent = suit;
            cardElement.appendChild(firstSuitElement);

            let cardValueElement = document.createElement('p');
            cardValueElement.textContent = cards[index];
            cardElement.appendChild(cardValueElement);

            let lastSuitElement = document.createElement('p');
            lastSuitElement.textContent = suit;
            cardElement.appendChild(lastSuitElement);

            cardsElement.appendChild(cardElement);
        }
    });

})();