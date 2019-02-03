function solve() {
  let strElement = document.getElementById('str');
  let numElement = document.getElementById('num');
  let resultElement = document.getElementById('result');

  let text = strElement.value;
  let number = +numElement.value;

  let fromIndex = 0;

  let result = [];

  while (fromIndex + number <= text.length) {
    result.push(text.substr(fromIndex, number));
    fromIndex += number;
  }

  if (text.length % number !== 0) {
    result.push([]);
    for (let index = text.length - text.length % number; index < text.length; index++) {
      result[result.length - 1] += text[index];
    }
    let remain = number - (text.length % number);

    for (let index = 0; index < remain; index++) {
      result[result.length - 1] += text[index];
    }
  }

  resultElement.textContent = result.join(' ');
}