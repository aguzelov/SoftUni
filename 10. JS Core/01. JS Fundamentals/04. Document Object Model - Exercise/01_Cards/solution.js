function solve() {
    let imgElements = document.querySelectorAll('#exercise div img');
    let resultElement = document.getElementById('result');

    let firstPlayerCard;
    let secondPlayerCard;

    let isFirstMove = false;
    let isSecondMove = false;

    for (let element of imgElements) {
        element.addEventListener('click', function () {

            let player = this.parentElement.id;

            if (player === 'player1Div' &&
                !isFirstMove &&
                !this.hasAttribute('checked')) {
                this.src = 'images/whiteCard.jpg';
                this.setAttribute('checked', 'checked');
                isFirstMove = true;

                let cardScore = +this.name;
                resultElement.firstChild.textContent = cardScore;
                firstPlayerCard = this;
            } else if (player === 'player2Div' &&
                !isSecondMove &&
                !this.hasAttribute('checked')) {
                this.src = 'images/whiteCard.jpg';
                this.setAttribute('checked', 'checked');
                isSecondMove = true;

                let cardScore = +this.name;
                resultElement.lastChild.textContent = cardScore;
                secondPlayerCard = this;
            }

            if (isFirstMove && isSecondMove) {
                isFirstMove = false;
                isSecondMove = false;

                let firstPlayerScore = resultElement.firstChild.textContent;
                let secondPlayerScore = resultElement.lastChild.textContent;
                if (firstPlayerScore && secondPlayerScore) {
                    if (firstPlayerScore > secondPlayerScore) {
                        firstPlayerCard.style.cssText = 'border: 2px solid green';
                        secondPlayerCard.style.cssText = 'border: 2px solid darkred';
                    } else {
                        firstPlayerCard.style.cssText = 'border: 2px solid darkred';
                        secondPlayerCard.style.cssText = 'border: 2px solid green';
                    }
                }

                let historyElement = document.getElementById('history');
                historyElement.innerHTML += `[${firstPlayerScore} vs ${secondPlayerScore}] `;

                setTimeout(function () {
                    resultElement.firstChild.textContent = '';
                    resultElement.lastChild.textContent = '';
                }, 2000);
            }
        });
    }
}