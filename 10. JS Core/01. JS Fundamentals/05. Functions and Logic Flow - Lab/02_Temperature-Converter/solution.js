function solve() {
  let tempTable = {
    'celsius': function (degrees) { return (((degrees * 9) / 5) + 32); },
    'fahrenheit': function (degrees) { return (((degrees - 32) * 5) / 9); },
  };

  let firstInputElement = document.getElementById('num1');
  let secondInputElement = document.getElementById('type');

  let resultElement = document.getElementById('result');

  let degrees = +firstInputElement.value;
  let tempType = secondInputElement.value.toLowerCase();

  if (tempTable[tempType]) {
    resultElement.textContent = Math.round(tempTable[tempType](degrees));

  } else {
    resultElement.textContent = 'Error!';
  }
}