function solve() {
  let numElement = document.getElementById('num');
  let arrElement = document.getElementById('arr');
  let resultElement = document.getElementById('result');

  let num = +numElement.value;
  let arr = JSON.parse(arrElement.value);

  console.log(arr);

  let result = [];
  for (let index = 0; index < arr.length; index++) {
    let indexOfChar = arr[index].indexOf(num);
    result.push(`${indexOfChar >= 0} -> ${indexOfChar}`);
  }

  resultElement.innerHTML = result.join(',');
}