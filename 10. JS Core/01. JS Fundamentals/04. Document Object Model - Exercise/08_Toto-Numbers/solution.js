function solve() {
	let exerciseElement = document.getElementById('exercise');

	let buttonElement = exerciseElement.querySelector('#myNumbers button');
	buttonElement.addEventListener('click', function () {

		let inputElement = exerciseElement.querySelector('#myNumbers input');
		let inputValue = inputElement.value;

		let numbers = inputValue.split(' ');

		let isCorrect = isCorrectNumbers(numbers);
		if (isCorrect) {
			let allNumberElement = document.getElementById('allNumbers');

			for (let index = 1; index <= 49; index++) {

				let numberElement = document.createElement('div');
				numberElement.innerText = index;
				numberElement.classList.add('numbers');

				if (numbers.includes(index.toString())) {
					numberElement.style.background = 'orange';
				}

				allNumberElement.appendChild(numberElement);
			}
			buttonElement.disabled = true;
			inputElement.disabled = true;
		}
	});

	function isCorrectNumbers(numbers) {
		if (numbers.length !== 6) {
			return false;
		}

		for (let number of numbers) {
			if (!number.match('([1-4][0-9]*)')) {
				return false;
			}
		}

		return true;
	}
}