function solve() {
  let str1Element = document.getElementById('str1');
  let str2Element = document.getElementById('str2');

  let resultElement = document.getElementById('result');

  let strArr = str1Element.value.split(' ');

  switch (str2Element.value) {
    case 'Camel Case': {
      scr(strArr, pascalCase);
      strArr[0] = strArr[0].toLocaleLowerCase();
    }
      break;
    case 'Pascal Case': {
      scr(strArr, pascalCase);
    } break;
    default: {
      resultElement.innerHTML = 'Error!';
      return;
    }
  }

  resultElement.innerHTML = strArr.join('');

  function scr(arr, func) {
    for (let index = 0; index < arr.length; index++) {
      arr[index] = func(arr[index]);
    }
  }

  function pascalCase(str) {
    return str.charAt(0).toUpperCase() + str.slice(1).toLocaleLowerCase();
  }
}