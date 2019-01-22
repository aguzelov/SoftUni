function solve() {
  let firstInputElement = document.getElementById('string');

  let resultElement = document.getElementById('result');

  let text = firstInputElement.value;

  let chars = [];

  for (let index = 0; index < text.length; index++) {
    if (!chars.includes(text[index]) || text[index] === ' ') {
      chars.push(text[index]);
    }
  }

  resultElement.textContent = chars.join('');
}