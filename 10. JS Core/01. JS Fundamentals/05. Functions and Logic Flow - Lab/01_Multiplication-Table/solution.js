function solve() {
  let firstInputElement = document.getElementById('num1');
  let secondInputElement = document.getElementById('num2');

  let startingNumber = +firstInputElement.value;
  let multiplier = +secondInputElement.value;

  let resultElement = document.getElementById('result');

  if (startingNumber > multiplier) {
    resultElement.innerHTML = 'Try with other numbers.';
    return;
  }

  for (let index = startingNumber; index <= multiplier; index++) {

    let p = document.createElement('p');
    p.innerHTML = `${index} * ${multiplier} = ${index * multiplier}`;

    resultElement.appendChild(p);
  }
}