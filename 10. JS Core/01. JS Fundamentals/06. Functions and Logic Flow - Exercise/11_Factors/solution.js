function solve() {
   let numElement = document.getElementById('num');
   let resultElement = document.getElementById('result');

   let num = +numElement.value;

   let factors = number => Array
      .from(Array(number + 1), (_, i) => i)
      .filter(i => number % i === 0);

   resultElement.textContent = factors(num).join(' ');
}