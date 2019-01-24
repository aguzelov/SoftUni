function greatestCD() {
   let firstNumberElement = document.getElementById('num1');
   let secondNumberElement = document.getElementById('num2');

   let resultElement = document.getElementById('result');

   let firstNumber = +firstNumberElement.value;
   let secondNumber = +secondNumberElement.value;

   resultElement.textContent = gcd(firstNumber, secondNumber);

   function gcd(a, b) {
      if (!b) {
         return a;
      }

      return gcd(b, a % b);
   }
}