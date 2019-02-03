function solve() {
  let arrElement = document.getElementById('arr');
  let resultElement = document.getElementById('result');

  let arr = JSON.parse(arrElement.value);

  let specialKey = arr[0];

  for (let index = 1; index < arr.length; index++) {
    arr[index] = getMessage(arr[index], specialKey);
  }

  for (let index = 1; index < arr.length; index++) {
    let pElement = document.createElement('p');
    pElement.textContent = arr[index];
    resultElement.appendChild(pElement);
  }

  function getMessage(line, key) {
    let regex = new RegExp(key + `\\s+?((!|%|\\$|#|[A-Z]){8,})(\\s|\\.|,|$)`, 'isg');

    let matches = regex.exec(line);

    while (matches) {
      if (matches !== null) {
        let oldText = matches[1].trim();
        let newText = oldText;

        if (isContainsLowevCaseLetter(oldText)) {
          newText = decode(oldText);
        }

        line = line.replace(oldText, newText);
      }
      matches = regex.exec(line);
    }
    return line;
  }

  function isContainsLowevCaseLetter(text) {
    let regex = new RegExp('[a-z]+', 'sg');
    let match = regex.exec(text);

    if (match) {
      return false;
    }

    return true;
  }

  function decode(text) {
    text = replaceAll(text, '!', '1');
    text = replaceAll(text, '%', '2');
    text = replaceAll(text, '#', '3');
    text = replaceAll(text, '\\$', '4');
    text = text.toLowerCase();

    return text;
  }

  function replaceAll(text, search, replacement) {
    text = text.replace(new RegExp(search, 'g'), replacement);
    return text;
  }

}

solve(["specialKey",
  "In this text the specialKey HELLOWORLD! is correct, but",
  "the following specialKey $HelloWorl#d and spEcIaLKEy HOLLOWORLD1 are not, while",
  "SpeCIaLkeY SOM%%ETH$IN and SPECIALKEY ##$$##$$ are!"
]);