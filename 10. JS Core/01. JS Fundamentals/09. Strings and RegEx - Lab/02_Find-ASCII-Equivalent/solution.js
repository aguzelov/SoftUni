function solve() {
  let textElement = document.getElementById('str');
  let resultElement = document.getElementById('result');

  let textArr = textElement.value.split(' ');

  let fromNumbers = [];
  let fromWords = [];

  for (let element of textArr) {
    if (Number(element)) {
      fromNumbers.push(String.fromCharCode(+element));
    } else {
      let currendWordToCode = [];
      for (let char of element) {
        currendWordToCode.push(char.charCodeAt(0));
      }
      fromWords.push(currendWordToCode);
    }
  }
  for (let element of fromWords) {
    let paragraphElement = document.createElement('p');
    paragraphElement.textContent = element.join(' ');

    resultElement.appendChild(paragraphElement);
  }

  let paragraphElement = document.createElement('p');
  paragraphElement.textContent = fromNumbers.join('');
  resultElement.appendChild(paragraphElement);
}