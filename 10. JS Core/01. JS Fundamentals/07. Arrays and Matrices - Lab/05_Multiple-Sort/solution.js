function solve() {
  let arrElement = document.getElementById('arr');
  let resultElement = document.getElementById('result');

  let arr = JSON.parse(arrElement.value);

  let ascendingOrderElement = document.createElement('div');
  ascendingOrderElement.textContent = arr.join(', ');
  resultElement.appendChild(ascendingOrderElement);

  let alphabeticallyOrderElement = document.createElement('div');
  alphabeticallyOrderElement.textContent = arr.sort((a, b) => {
    return +a - +b;
  }).sort().join(', ');
  resultElement.appendChild(alphabeticallyOrderElement);
}