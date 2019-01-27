function solve() {
  let arrElement = document.getElementById('arr');
  let resultElement = document.getElementById('result');

  let arr = JSON.parse(arrElement.value);
  console.log(arr);


  for (let index = 0; index < arr.length; index++) {
    let pElement = document.createElement('p');
    pElement.textContent = `${index} -> ${arr[index] * arr.length}`;

    resultElement.appendChild(pElement);
  }

}