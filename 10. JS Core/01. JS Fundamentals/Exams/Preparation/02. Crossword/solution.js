function solve() {
   let output = document.querySelector('#output p');
   let input = document.getElementById('input');

   let commands = {
      'filter': filter,
      'sort': sort,
      'rotate': rotate,
      'get': get
   };

   let fieldsets = document.querySelectorAll('#exercise section fieldset');

   for (const fieldset of fieldsets) {
      let command = fieldset.id;


      let button = fieldset.querySelector('button');
      button.addEventListener('click', function () {
         let element = execute(command);
         print(element);
      });
   }

   function execute(command) {
      let text = input.value;

      let positionId = command + 'Position';
      let position = +document.getElementById(positionId).value;

      let secondaryCmdId = command + 'SecondaryCmd';

      if (command === 'filter' || command === 'sort') {
         let select = document.getElementById(secondaryCmdId);

         let secondaryCmd = select.options[select.selectedIndex].value;

         return commands[command](text, position, secondaryCmd);
      } else if (command === 'rotate') {
         let rotations = +document.getElementById(secondaryCmdId).value;

         return commands[command](text, position, rotations);
      } else {
         return get(text, position);
      }
   }

   function filter(text, position, command) {
      let letters = [];
      console.log('Command: ' + command);
      console.log('Letters: ' + letters);

      for (let i = 0; i < text.length; i++) {

         if (command === 'uppercase' && isNaN(parseInt(text[i], 10))) {
            if (text[i] === text[i].toUpperCase()) {
               letters.push(text[i]);
            }
         }
         if (command === 'lowercase' && isNaN(parseInt(text[i], 10))) {
            if (text[i] === text[i].toLowerCase()) {
               letters.push(text[i]);
            }
         }

         if (command === 'nums') {
            if (!isNaN(parseInt(text[i], 10))) {
               letters.push(text[i]);
            }
         }
      }
      console.log('Letters: ' + letters);
      return get(letters, position);
   }

   function sort(text, position, command) {
      console.log(command);

      if (command === 'A') {
         text = text.split('').sort().join('');
      } else {
         text = text.split('').sort().reverse().join('');
      }


      return get(text, position);
   }

   function rotate(text, position, rotation) {
      let rotationCount = rotation % text.length;

      let tempArr = text.split('');
      for (let i = 0; i < rotationCount; i++) {
         let end = tempArr.pop();
         tempArr.unshift(end);
      }
      text = tempArr.join('');

      return get(text, position);
   }

   function get(text, position) {
      return text[position - 1];
   }

   function print(element) {
      output.textContent += element;
   }
}