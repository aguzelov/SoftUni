function solution() {
	$('#fields button').on('click', add);
}

function add() {
	let toyTypeElem = document.getElementById('toyType');
	let toyType = toyTypeElem.value;

	let toyPriceElem = document.getElementById('toyPrice');
	let toyPrice = toyPriceElem.value;

	let toyDescriptionElem = document.getElementById('toyDescription');
	let toyDescription = toyDescriptionElem.value;

	if (toyType && !isNaN(toyPrice) && !toyPrice.startsWith('-') && toyDescription.length <= 50) {
		let giftElem = document.createElement('div');
		giftElem.classList.add('gift');

		let imgElem = document.createElement('img');
		imgElem.src = 'gift.png';
		giftElem.appendChild(imgElem);

		let typeElem = document.createElement('h2');
		typeElem.textContent = toyType;
		giftElem.appendChild(typeElem);

		let descriptionElem = document.createElement('p');
		descriptionElem.textContent = toyDescription;
		giftElem.appendChild(descriptionElem);

		let priceElem = document.createElement('button');
		priceElem.textContent = `Buy it for $${toyPrice}`;
		priceElem.addEventListener('click', (e) => {
			e.target.parentNode.remove();
		});
		giftElem.appendChild(priceElem);

		document.getElementById('christmasGiftShop').appendChild(giftElem);

		toyTypeElem.value = '';
		toyPriceElem.value = '';
		toyDescriptionElem.value = '';
	}
}