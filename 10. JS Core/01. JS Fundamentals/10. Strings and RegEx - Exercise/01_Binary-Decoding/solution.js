function solve() {
  let strElement = document.getElementById('str');
  let resultElement = document.getElementById('result');

  let str = strElement.value;

  let sum = getSum(str);
  str = trim(str, sum);

  let arr = slice(str);

  resultElement.innerHTML = decoding(arr);

  function getSum(str) {
    let sum = [];
    for (let c of str) {
      sum.push(+c);
    }


    let result = sum.reduce(function (a, b) { return a + b; }, 0);

    while (result.toString().length !== 1) {
      let resultStr = result.toString();

      let currentSum = 0;
      for (let c of resultStr) {
        currentSum += +c;
      }
      result = currentSum;
    }
    return result;
  }

  function trim(str, count) {
    str = str.slice(count);
    str = str.slice(0, (count * -1));
    return str;
  }

  function slice(str) {
    let arr = str.match(/.{1,8}/g);

    return arr;
  }

  function decoding(arr) {
    let result = '';
    for (let element of arr) {
      let asciiCode = parseInt(element, 2);
      let strFromCode = String.fromCharCode(asciiCode);

      if (strFromCode.match(/[a-z]/i) || strFromCode === ' ') {
        result += strFromCode;
      }
    }

    return result;
  }
}