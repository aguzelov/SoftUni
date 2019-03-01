function subtract() {
    let firstNumber = +document.getElementById('firstNumber').value;
    let secondNumber = +document.getElementById('secondNumber').value;

    document.getElementById('result').innerHTML = firstNumber - secondNumber;
}
