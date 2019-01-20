function solve() {
   let buttonElements = document.querySelectorAll('.profile button');

   for (let button of buttonElements) {
      button.addEventListener('click', function () {
         let parentElement = this.parentElement;

         let lockRadioElement = parentElement.querySelectorAll('input')[0];
         if (!lockRadioElement.checked) {

            let hiddenFieldElement = parentElement.querySelector('[id$="HiddenFields"]');

            if (this.textContent === 'Show more') {
               hiddenFieldElement.style.display = 'block';
               this.textContent = 'Hide it';
            } else {
               hiddenFieldElement.style.display = 'none';
               this.textContent = 'Show more';
            }
         }
      });
   }
} 