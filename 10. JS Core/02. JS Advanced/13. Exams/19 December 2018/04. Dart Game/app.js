function dart() {
	let currentPlayer = 'Home';
	let isDartboardFunctioning = true;

	let layerNumbers = {
		'firstLayer': 1,
		'secondLayer': 2,
		'thirdLayer': 3,
		'fourthLayer': 4,
		'fifthLayer': 5,
		'sixthLayer': 6,
	};

	let playBoardElem = document.getElementById('playBoard');
	playBoardElem.addEventListener('click', (e) => {
		if (isDartboardFunctioning) {
			let score = getLayerScore(layerNumbers[e.target.id]);
			addPoints(currentPlayer, score);
			switchPlayer();
			checkForWinner();
		}
	});

	function switchPlayer() {
		let turnsElem = document.getElementById('turns');

		let turnOnElem = turnsElem.children[0];
		let turnOnTokens = turnOnElem.textContent.split(' ');

		let nextElem = turnsElem.children[1];
		let nextTokens = nextElem.textContent.split(' ');

		let currentTurn = turnOnTokens[2];
		let currentNext = nextTokens[2];
		turnOnTokens[2] = currentNext;
		nextTokens[2] = currentTurn;

		turnOnElem.textContent = turnOnTokens.join(' ');
		nextElem.textContent = nextTokens.join(' ');

		currentPlayer = currentNext;
	}

	function addPoints(playerId, points) {


		let playerPointsElem = document.getElementById(`${playerId}`);

		let pointsElem = playerPointsElem.children[0];
		let currentPoints = +pointsElem.textContent;

		pointsElem.textContent = currentPoints + points;
	}

	function checkForWinner() {
		let pointsElem = document.getElementById('points');

		let homeElem = pointsElem.children[0];
		let awayElem = pointsElem.children[1];

		if (+homeElem.children[0].textContent >= 100) {

			markWinnerAndStopGame(homeElem, awayElem);
		}

		if (+awayElem.children[0].textContent >= 100) {
			markWinnerAndStopGame(awayElem, homeElem);
		}
	}

	function markWinnerAndStopGame(winnerElem, lostElem) {

		winnerElem.children[1].style.backgroundColor = 'green';
		lostElem.children[1].style.backgroundColor = 'red';

		isDartboardFunctioning = false;
	}

	function getLayerScore(layerNumber) {
		let scoreStr = document.querySelectorAll('tbody tr')[layerNumber - 1].children[1].textContent;

		let score = +scoreStr.split(' ')[0];
		return score;
	}
}