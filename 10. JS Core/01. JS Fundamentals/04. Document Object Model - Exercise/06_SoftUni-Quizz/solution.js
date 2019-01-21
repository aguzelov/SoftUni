function solve() {
	let currentQuestionIndex = 0;
	let rightAnswersCount = 0;
	let rightAnswers = {
		'softUniYear': '2013',
		'popularName': 'Pesho',
		'softUniFounder': 'Nakov'
	};

	let exerciseElement = document.getElementById('exercise');

	let sections = exerciseElement.getElementsByTagName('section');
	for (let section of sections) {
		let buttonElement = section.querySelector('button');
		buttonElement.addEventListener('click', function () {

			let parent = this.parentElement;
			let radioButtons = parent.querySelectorAll('input');

			for (let radio of radioButtons) {
				if (radio.checked) {
					currentQuestionIndex++;
					isChecked = true;

					if (rightAnswers[radio.name] === radio.value) {
						rightAnswersCount++;
					}

					if (currentQuestionIndex < sections.length) {

						sections[currentQuestionIndex].style.display = 'block';
					} else {
						let resultElement = document.getElementById('result');

						if (rightAnswersCount < 3) {
							resultElement.innerHTML = `You have ${rightAnswersCount} right answers`;
						} else {
							resultElement.innerHTML = `You are recognized as top SoftUni fan!`;
						}
					}
				}
			}
		});
	}
}