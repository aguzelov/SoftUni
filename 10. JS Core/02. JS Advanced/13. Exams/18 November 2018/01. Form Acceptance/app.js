function acceptance() {
	let fieldsRow = document.getElementById('fields');
	let fieldsCol = fieldsRow.children;

	let shippingCompanyInput = fieldsCol[0].children[0];
	let productNameInput = fieldsCol[1].children[0];
	let productQuantityInput = fieldsCol[2].children[0];
	let productScrapeInput = fieldsCol[3].children[0];

	let shippingCompany = shippingCompanyInput.value;
	let productName = productNameInput.value;
	let productQuantity = +productQuantityInput.value;
	let productScrape = +productScrapeInput.value;

	if (isCorrectInput(shippingCompany, productName, productQuantity, productScrape)) {

		addToWarehouse(shippingCompany, productName, productQuantity, productScrape);

	}
	resetInput(shippingCompanyInput);
	resetInput(productNameInput);
	resetInput(productQuantityInput);
	resetInput(productScrapeInput);

	function addToWarehouse(shippingCompany, productName, productQuantity, productScrape) {
		let divElem = document.createElement('div');

		let pElem = document.createElement('p');
		pElem.textContent = `[${shippingCompany}] ${productName} - ${productQuantity - productScrape} pieces`;
		divElem.appendChild(pElem);

		let buttonElem = document.createElement('button');
		buttonElem.textContent = 'Out of stock';
		buttonElem.addEventListener('click', (e) => {
			e.target.parentNode.remove();
		});

		divElem.appendChild(buttonElem);

		document.getElementById('warehouse').appendChild(divElem);
	}

	function isCorrectInput(shippingCompany, productName, productQuantity, productScrape) {

		let isValid = isNonEmptyString(shippingCompany) &&
			isNonEmptyString(productName) &&
			isNumber(productQuantity) &&
			isNumber(productScrape) &&
			productQuantity > productScrape;

		return isValid;
	}

	function isNonEmptyString(value) {

		return typeof value === 'string' && value.length > 0;
	}

	function isNumber(value) {
		return typeof value === 'number';
	}

	function resetInput(elem) {
		elem.value = '';
	}
}