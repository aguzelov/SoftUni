function realEstateAgency() {
	// Find Offer
	let findOfferButton = document.querySelector('#findOffer button');
	findOfferButton.addEventListener('click', () => {
		findOffer();
	});

	function findOffer() {
		let inputs = document.querySelectorAll('#findOffer input');

		let familyBudgetElem = inputs[0];
		let familyApartmentTypeElem = inputs[1];
		let familyNameElem = inputs[2];

		let familyBudget = +familyBudgetElem.value;
		let familyApartmentType = familyApartmentTypeElem.value;
		let familyName = familyNameElem.value;

		if (!isFindOfferValid(familyBudget, familyApartmentType, familyName) ||
			!tryFindApartment(familyBudget, familyApartmentType, familyName)) {
			printMessage('We were unable to find you a home, so sorry :(');

		} else {
			printMessage('Enjoy your new home! :))');
		}

		clearInputElements(inputs);
	}

	function isFindOfferValid(familyBudget, familyApartmentType, familyName) {
		let isValid = isPositiveNumber(familyBudget) &&
			isValidString(familyApartmentType) &&
			isValidString(familyName);

		return isValid;
	}

	function tryFindApartment(familyBudget, familyApartmentType, familyName) {
		let buildingElem = document.getElementById('building');
		let index = indexOfApartment(buildingElem, familyApartmentType, familyBudget);

		if (index < 0) {
			return false;
		}
		let apartment = buildingElem.children[index];

		changeAgencyProfit(apartment, familyName);

		changeApartment(apartment, familyName);
		return true;
	}

	function changeAgencyProfit(apartment, familyName) {
		let rent = +apartment.children[0].textContent.split(': ')[1];
		let commission = +apartment.children[2].textContent.split(': ')[1];

		let newProfit = (rent * (commission / 100)) * 2;

		let roofElem = document.getElementById('roof');
		let profitElem = roofElem.children[0];

		let profitTokens = profitElem.textContent.split(' ');
		profitTokens[2] = '' + (+profitTokens[2] + newProfit);

		profitElem.textContent = profitTokens.join(' ');
	}

	function changeApartment(apartment, familyName) {
		let rentElem = apartment.children[0];
		let typeElem = apartment.children[1];
		let commissionElem = apartment.children[2];
		commissionElem.remove();

		rentElem.textContent = familyName;
		typeElem.textContent = 'live here now';

		let moveOutButton = document.createElement('button');
		moveOutButton.textContent = 'MoveOut';
		moveOutButton.addEventListener('click', (e) => {
			let elemToRemove = e.target.parentNode;
			let familyName = elemToRemove.children[0].textContent;
			elemToRemove.remove();

			printMessage(`They had found cockroaches in ${familyName}\'s apartment`);
		});
		apartment.appendChild(moveOutButton);
	}

	function indexOfApartment(building, familyApartmentType, familyBudget) {
		let apartments = building.children;

		for (let index = 0; index < apartments.length; index++) {
			let apartment = apartments[index];
			let rentElem = apartment.children[0];
			let typeElem = apartment.children[1];
			let commissionElem = apartment.children[2];

			if (isCorrectType(familyApartmentType, typeElem.textContent) &&
				isEnoughBudget(familyBudget, rentElem.textContent, commissionElem.textContent)) {
				return index;
			}
		}

		return -1;
	}

	function isEnoughBudget(familyBudget, rentText, commissionText) {
		let rent = +rentText.split(': ')[1];
		let commission = +commissionText.split(': ')[1];

		let apartmentCost = rent + (rent * (commission / 100));


		return familyBudget >= apartmentCost;
	}

	function isCorrectType(familyApartmentType, apartmenTypeText) {
		if (apartmenTypeText === 'live here now') {
			return false;
		}

		console.log(apartmenTypeText);

		let apartmenType = apartmenTypeText.split(':')[1].trim();

		return familyApartmentType === apartmenType;
	}








	// Reg Offer part
	let regOfferButton = document.querySelector('#regOffer button');
	regOfferButton.addEventListener('click', () => {
		regOffer();
	});

	function regOffer() {
		let inputs = document.querySelectorAll('#regOffer input');

		let rentPriceElem = inputs[0];
		let apartmentTypeElem = inputs[1];
		let commissionRateElem = inputs[2];

		let rentPrice = +rentPriceElem.value;
		let apartmentType = apartmentTypeElem.value;
		let commissionRate = +commissionRateElem.value;

		if (!isRegOfferValid(rentPrice, apartmentType, commissionRate)) {
			printMessage('Your offer registration went wrong, try again.');
		} else {
			addBuildingElement(rentPrice, apartmentType, commissionRate);
			printMessage('Your offer was created successfully.');
		}

		clearInputElements(inputs);
	}

	function addBuildingElement(rentPrice, apartmentType, commissionRate) {
		let buildingElem = document.getElementById('building');

		let apartmentDiv = document.createElement('div');
		apartmentDiv.classList.add('apartment');

		let rentP = document.createElement('p');
		rentP.textContent = `Rent: ${rentPrice}`;
		apartmentDiv.appendChild(rentP);

		let typeP = document.createElement('p');
		typeP.textContent = `Type: ${apartmentType}`;
		apartmentDiv.appendChild(typeP);

		let commissionP = document.createElement('p');
		commissionP.textContent = `Commission: ${commissionRate}`;
		apartmentDiv.appendChild(commissionP);

		buildingElem.appendChild(apartmentDiv);
	}

	function isRegOfferValid(rentPrice, apartmentType, commissionRate) {
		let isValid = isPositiveNumber(rentPrice) &&
			isValidCommissionRate(commissionRate) &&
			isValidApartmentType(apartmentType);

		return isValid;
	}

	function isValidApartmentType(apartmentType) {
		return isValidString(apartmentType) && !apartmentType.includes(':');
	}

	function isValidCommissionRate(commissionRate) {
		return isNumber(commissionRate) && (commissionRate >= 0 && commissionRate <= 100);
	}

	function isValidString(value) {
		return typeof value === 'string' && value.length > 0;
	}

	function isPositiveNumber(rentPrice) {
		return isNumber(rentPrice) && rentPrice > 0;
	}

	function isNumber(value) {
		return typeof value === 'number';
	}

	function clearInputElements(inputs) {
		for (const input of inputs) {
			input.value = '';
		}
	}

	function printMessage(message) {
		let messageElem = document.getElementById('message');
		messageElem.textContent = message;
	}
}