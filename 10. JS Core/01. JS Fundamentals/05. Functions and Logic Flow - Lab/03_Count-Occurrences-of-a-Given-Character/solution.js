function solve() {
  let firstInputElement = document.getElementById('string');
  let secondInputElement = document.getElementById('character');

  let string = firstInputElement.value;
  let character = secondInputElement.value;

  let occurrence = string.match(new RegExp(character, "g")).length;

  let resultElement = document.getElementById('result');
  resultElement.textContent = `Count of ${character} is ${occurrence % 2 === 0 ? 'even' : 'odd'}.`;
}