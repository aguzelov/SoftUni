function solve() {

    let exerciseElement = document.getElementById('exercise');

    let buttonElements = exerciseElement.querySelectorAll('button');

    for (let element of buttonElements) {
        element.addEventListener('click', function (params) {
            let userName = this.name.slice(0, -3);

            let inputElement = exerciseElement.querySelector(`[id^="${userName}"]`);
            let message = inputElement.value;
            inputElement.value = '';

            let chatElement = document.getElementById('chatChronology');

            let messageContainerElement = document.createElement('div');

            if (userName === 'my') {
                messageContainerElement.setAttribute('align', 'left');
                userName = 'Me';
            } else {
                messageContainerElement.setAttribute('align', 'right');
                userName = userName.charAt(0).toUpperCase() + userName.slice(1);
            }

            let nameElement = document.createElement('span');
            nameElement.textContent = userName;

            let messageElement = document.createElement('p');
            messageElement.textContent = message;

            messageContainerElement.appendChild(nameElement);
            messageContainerElement.appendChild(messageElement);

            chatElement.appendChild(messageContainerElement);
        });
    }
}