function solve() {
   let rebuildedKindoms = [];

   rebuild();
   join();
   war();

   //War
   function war() {
      let actionsElem = $('#actions');

      let button = actionsElem.find('button');

      button.on('click', function () {
         let inputs = actionsElem.find('input');

         let attackerElem = inputs[0];
         let defenderElem = inputs[1];

         console.log('before if');

         console.log(isValidWarKingdom(attackerElem.value));
         console.log(isValidWarKingdom(defenderElem.value));


         if (isValidWarKingdom(attackerElem) && isValidWarKingdom(defenderElem)) {
            let attackerPoints = GetAttackerPoints(attackerElem.value);
            let defenderPoints = GetDefenderPoints(defenderElem.value);

            if (attackerPoints >= defenderPoints) {
               changeKing(defenderElem.value, getKingName(attackerElem.value));
            }
         }

         console.log('after if');
      });
   }

   function isValidWarKingdom(kingdomElem) {
      if (!kingdomElem.value) {
         kingdomElem.value = '';

         return false;
      }

      let validName = ['CASTLE', 'DUNGEON', 'FORTRESS', 'INFERNO', 'NECROPOLIS', 'RAMPART', 'STRONGHOLD', 'TOWER', 'CONFLUX'];

      if (!validName.includes(kingdomElem.value.toUpperCase()) || !rebuildedKindoms.includes(kingdomElem.value)) {
         kingdomElem.value = '';

         return false;
      }

      return true;
   }


   function getKingName(kingdomName) {
      let kingdoms = $('#map div');
      for (const kingdom of kingdoms) {
         if (kingdom.id === kingdomName.toLowerCase()) {
            return $(kingdom).find('h2').text();
         }
      }
   }


   function changeKing(oldKingType, newKing) {

      console.log('change');

      let kingdoms = $('#map div');
      for (const kingdom of kingdoms) {
         if (kingdom.id === oldKingType.toLowerCase()) {

            $(kingdom).find('h2').text(newKing);
         }
      }
   }


   function GetAttackerPoints(attackerName) {
      let kingdoms = $('#map div');

      let characterAttackingPoints = {
         mages: 70,
         fighters: 50,
         tanks: 20
      };

      let points = 0;
      for (const kingdom of kingdoms) {
         if (kingdom.id === attackerName.toLowerCase()) {
            let armyFieldset = $(kingdom).find('fieldset');
            for (const ctype of armyFieldset.find('p')) {
               let text = ctype.textContent;
               let textTokens = text.split(' ');
               let type = textTokens[0];
               let count = +textTokens[2];

               let point = characterAttackingPoints[type.toLowerCase()] * count;
               points += point;
            }
         }

      }

      return points;
   }


   function GetDefenderPoints(defenderName) {
      let kingdoms = $('#map div');

      let characterDefenderPoints = {
         mages: 30,
         fighters: 50,
         tanks: 80
      };

      let points = 0;
      for (const kingdom of kingdoms) {
         if (kingdom.id === defenderName.toLowerCase()) {
            let armyFieldset = $(kingdom).find('fieldset');
            for (const cTtype of armyFieldset.find('p')) {
               let text = cTtype.textContent;
               let textTokens = text.split(' ');
               let type = textTokens[0];
               let count = +textTokens[2];

               let point = characterDefenderPoints[type.toLowerCase()] * count;
               points += point;
            }

         }

      }

      return points;
   }


   //Join
   function join() {
      let charactersElem = $('#characters div');

      let button = $(charactersElem[3]).find('button');

      button.on('click', function () {

         let characterType;

         for (let index = 0; index < charactersElem.length - 1; index++) {
            let input = $(charactersElem[index]).find('input')[0];
            if (input.checked) {
               characterType = input.value;
            }
         }
         let characterInputs = $(charactersElem[3]).find('input');
         let characterNameElem = characterInputs[0];
         let characterKingdomElem = characterInputs[1];


         if (characterType || isValidCharacterName(characterNameElem) || isValidCharacterKingdom(characterKingdomElem)) {
            addCharacter(characterNameElem.value, characterKingdomElem.value, characterType);
         }
      });
   }

   function addCharacter(characterName, characterKingdom, characterType) {
      let kingdoms = $('#map div');

      let typeNumbers = {
         tank: 0,
         fighter: 1,
         mage: 2
      };

      for (const kingdom of kingdoms) {
         if (kingdom.id === characterKingdom.toLowerCase()) {
            let armyFieldset = $(kingdom).find('fieldset');

            let characterTypes = armyFieldset.find('p')[typeNumbers[characterType]];

            let text = characterTypes.textContent;
            let textTokens = text.split(' ');
            textTokens[2] = '' + (+textTokens[2] + 1);

            let newText = textTokens.join(' ');

            characterTypes.textContent = newText;


            let armyOutputElem = armyFieldset.find('div.armyOutput');
            let armyOutput = armyOutputElem.text();
            armyOutput += characterName + ' ';
            armyOutputElem.text(armyOutput);
         }
      }
   }

   function isValidCharacterName(characterNameElem) {
      if (!characterNameElem) {
         characterNameElem.value = '';
         return false;
      }

      if (characterNameElem.value.length < 2) {
         characterNameElem.value = '';
         return false;
      }

      return true;
   }

   function isValidCharacterKingdom(characterKingdomElem) {

      if (!characterKingdomElem) {
         characterKingdomElem.value = '';
         return false;
      }

      let validName = ['CASTLE', 'DUNGEON', 'FORTRESS', 'INFERNO', 'NECROPOLIS', 'RAMPART', 'STRONGHOLD', 'TOWER', 'CONFLUX'];

      if (!validName.includes(characterKingdomElem.value.toUpperCase())) {
         characterKingdomElem.value = '';
         return false;
      }

      return true;
   }


   //Rebuild 
   function rebuild() {
      let $rebuildDiv = $('#kingdom div');
      let rebuildButton = $rebuildDiv.find('button');

      rebuildButton.on('click', function () {
         let kingdomEle = $rebuildDiv.find('input')[0];
         let kingdomText = kingdomEle.value;

         let kingEle = $rebuildDiv.find('input')[1];
         let kingText = kingEle.value;

         if (isCorrectInput(kingdomEle, kingEle)) {
            createKingdom(kingdomText, kingText);

            rebuildedKindoms.push(kingdomText);
         }
      });
   }

   function isCorrectInput(kingdomElem, kingElem) {
      if (!isValidKingdomName(kingdomElem.value)) {
         kingdomElem.value = '';
         return false;
      }

      if (!isValidKingName(kingElem.value)) {
         kingElem.value = '';
         return false;
      }


      return true;
   }

   function isValidKingName(kingName) {
      return kingName.length >= 2;
   }

   function isValidKingdomName(kingdomName) {
      let validName = ['CASTLE', 'DUNGEON', 'FORTRESS', 'INFERNO', 'NECROPOLIS', 'RAMPART', 'STRONGHOLD', 'TOWER', 'CONFLUX'];

      return validName.includes(kingdomName.toUpperCase());
   }

   function createKingdom(kingdom, king) {
      let kingdomTypesElems = $('#map div');

      let kingdomTypeElem;
      for (const elem of kingdomTypesElems) {
         if (elem.id === kingdom.toLowerCase()) {
            kingdomTypeElem = $(elem);
         }
      }

      let kingdomNameEle = $(`<h1>${kingdom.toUpperCase()}</h1>`);
      kingdomTypeElem.append(kingdomNameEle);

      let castleElem = $('<div class="castle"></div>');
      kingdomTypeElem.append(castleElem);

      let kingNameEle = $(`<h2>${king.toUpperCase()}</h2>`);
      kingdomTypeElem.append(kingNameEle);

      let armyEle = $(`<fieldset></fieldset>`);
      armyEle.append($('<legend>Army</legend>'));
      armyEle.append($('<p>TANKS - 0</p>'));
      armyEle.append($('<p>FIGHTERS - 0</p>'));
      armyEle.append($('<p>MAGES - 0</p>'));
      let armyOutputElem = $('<div class="armyOutput"></div>');
      armyEle.append(armyOutputElem);
      kingdomTypeElem.append(armyEle);

      kingdomTypeElem.css("display", "inline-block");
   }
}


solve();



