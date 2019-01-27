function solve() {
  let arrElement = document.getElementById('arr');
  let resultElement = document.getElementById('result');

  let arr = JSON.parse(arrElement.value);

  let result = [];
  for (let index = 0; index < arr.length; index++) {
    result.push(reverse(arr[index]));
  }

  resultElement.textContent = result.join(' ');

  function reverse(s) {
    let reveredString = s.split("").reverse().join("");
    return capitalizeFirstLetter(reveredString);
  }

  function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
  }
}