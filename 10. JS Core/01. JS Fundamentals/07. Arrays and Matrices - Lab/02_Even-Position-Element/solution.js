function solve() {
  let arrElement = document.getElementById('arr');
  let resultElement = document.getElementById('result');

  let arr = JSON.parse(arrElement.value);

  let result = [];
  for (let index = 0; index < arr.length; index++) {
    if (index % 2 === 0) {
      result.push(arr[index]);
    }
  }

  resultElement.textContent = result.join(' x ');
}