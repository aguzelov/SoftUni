function solve() {
  let arrElement = document.getElementById('arr');
  let strElement = document.getElementById('str');
  let resultElement = document.getElementById('result');

  let arr = JSON.parse(arrElement.value);
  let replace = strElement.value;

  let regex = new RegExp('[a-zA-Z]+', 'g');
  let match = regex.exec(arr[2]);
  console.log(match);

  let wordToReplace = match[0];
  console.log(wordToReplace);

  for (let index = 0; index < arr.length; index++) {
    arr[index] = arr[index].replace(new RegExp(wordToReplace, 'gsi'), replace);
  }

  for (let element of arr) {
    let paragraphElement = document.createElement('p');
    paragraphElement.textContent = element;
    resultElement.appendChild(paragraphElement);
  }

  function isLetter(c) {
    return c.toLowerCase() != c.toUpperCase();
  }
}