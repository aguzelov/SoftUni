function solve(keywordStr, textString) {
  // let strElement = document.getElementById('str');
  // let textElement = document.getElementById('text');

  // let resultElement = document.getElementById('result');

  // let keyword = strElement.value;
  // let text = textElement.value;

  let keyword = keywordStr;
  let text = textString;

  let messageRegEx = new RegExp(keyword + '(.+)' + keyword, 'g');
  let message = messageRegEx.exec(text)[1];

  let north = getCoordinates(text, 'north');
  console.log(north);

  let east = getCoordinates(text, 'east');
  console.log(east);


  // let northParagraphElement = document.createElement('p');
  // northParagraphElement.textContent = north;
  // resultElement.appendChild(northParagraphElement);

  // let eastParagraphElement = document.createElement('p');
  // eastParagraphElement.textContent = east;
  // resultElement.appendChild(eastParagraphElement);

  // let messageElement = document.createElement('p');
  // messageElement.textContent = `Message: ${message}`;
  // resultElement.appendChild(messageElement);

  function getCoordinates(text, key) {
    let regEx = new RegExp(key + `.*?([0-9]{2}).*?,.*?([0-9]{6})`, 'gmi');
    let matches = text.match(regEx);

    let coordinate = '';
    if (key.toLowerCase() === 'east') {
      coordinate = matches[0];
    } else {
      coordinate = matches[matches.length - 1];
    }

    let partsRegEx = new RegExp('([0-9]{2}).*?,.*?([0-9]{6})', 'g');
    let parts = partsRegEx.exec(coordinate);

    let coordinateSign = key[0].toUpperCase();
    let part = parts[1] + '.' + parts[2] + ' ' + coordinateSign;

    return part;
  }

}

solve('4ds', 'eaSt 19,432567noRt north east 53,123456north 43,3213454dsNot all those who wander are lost.4dsnorth 47,874532');