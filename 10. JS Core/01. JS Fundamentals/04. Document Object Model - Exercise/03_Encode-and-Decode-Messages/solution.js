function solve() {
	let exerciseElement = document.getElementById('exercise');

	let encodeElement = exerciseElement.firstElementChild;
	let decodeElement = exerciseElement.lastElementChild;

	let encodeButton = encodeElement.getElementsByTagName('button')[0];
	encodeButton.addEventListener('click', function () {
		let encodeTextarea = encodeElement.getElementsByTagName('textarea')[0];
		let inputMessage = encodeTextarea.value;
		let message = '';
		for (let index = 0; index < inputMessage.length; index++) {
			message += String.fromCharCode(inputMessage[index].charCodeAt(0) + 1);
		}

		encodeTextarea.value = '';

		let dencodeTextarea = decodeElement.getElementsByTagName('textarea')[0];
		dencodeTextarea.value = message;

	});

	let decodeButton = decodeElement.getElementsByTagName('button')[0];
	decodeButton.addEventListener('click', function () {
		let dencodeTextarea = decodeElement.getElementsByTagName('textarea')[0];

		let inputMessage = dencodeTextarea.value;
		let message = '';
		for (let index = 0; index < inputMessage.length; index++) {
			message += String.fromCharCode(inputMessage[index].charCodeAt(0) - 1);
		}

		dencodeTextarea.value = message;
	});
}