function solve() {
  let firstNumberInputElement = document.getElementById('firstNumber');
  let secondNumberInputElement = document.getElementById('secondNumber');
  let firstStringInputElement = document.getElementById('firstString');
  let secondStringInputElement = document.getElementById('secondString');
  let thirdStringInputElement = document.getElementById('thirdString');

  let resultElement = document.getElementById('result');

  let startNumber = +firstNumberInputElement.value;
  let endNumber = +secondNumberInputElement.value;
  let firstString = firstStringInputElement.value;
  let secondString = secondStringInputElement.value;
  let thirdString = thirdStringInputElement.value;

  for (let i = startNumber; i <= endNumber; i++) {
    let p = document.createElement('p');

    if (i % 3 === 0 && i % 5 === 0) {
      p.textContent = `${i} ${firstString}-${secondString}-${thirdString}`;
    } else if (i % 3 === 0) {
      p.textContent = `${i} ${secondString}`;
    } else if (i % 5 === 0) {
      p.textContent = `${i} ${thirdString}`;
    } else {
      p.textContent = `${i}`;
    }

    resultElement.appendChild(p);
  }
}