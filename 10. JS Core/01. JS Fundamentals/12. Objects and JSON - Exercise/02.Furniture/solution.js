function solve() {
  let inputTextArea = document.querySelector('#exercise textarea');
  let buttons = document.querySelectorAll('#exercise button');

  let currnetFurnitures = [];

  let generateButton = buttons[0];
  generateButton.addEventListener('click', generate);

  let buyButton = buttons[1];
  buyButton.addEventListener('click', buy);

  function buy() {
    let furnitureList = document.querySelectorAll('#furniture-list div');

    let furnituresToBuy = [];

    for (const furnitureDiv of furnitureList) {
      if (!isChecked(furnitureDiv)) {
        continue;
      }
      furnituresToBuy.push(currnetFurnitures[furnitureDiv.id]);
    }

    if (furnituresToBuy.length > 0) {
      let boughtFurniture = furnituresToBuy.map(f => f.name).join(', ');
      let totalPrice = furnituresToBuy.map(f => f.price).reduce((a, b) => { return a + b; }).toFixed(2);
      let totalDecorationFactor = furnituresToBuy.map(f => f.decFactor).reduce((a, b) => { return a + b; });
      let averageDecorationFactor = totalDecorationFactor / furnituresToBuy.length;

      let outputTextArea = document.querySelectorAll('#exercise textarea')[1];
      outputTextArea.value += `Bought furniture: ${boughtFurniture}\n`;
      outputTextArea.value += `Total price: ${totalPrice}\n`;
      outputTextArea.value += `Average decoration factor: ${averageDecorationFactor}`;
    }
  }

  function generate() {
    let parsedInput = JSON.parse(inputTextArea.value);
    for (const obj of parsedInput) {
      let furnitureListElement = document.getElementById('furniture-list');

      let furnitureDiv = document.createElement('div');
      furnitureDiv.classList.add('furniture');
      furnitureDiv.id = currnetFurnitures.length;

      let nameP = document.createElement('p');
      nameP.textContent = `Name: ${obj.name}`;
      furnitureDiv.appendChild(nameP);

      let img = document.createElement('img');
      img.src = obj.img;
      furnitureDiv.appendChild(img);

      let priceP = document.createElement('p');
      priceP.textContent = `Price: ${obj.price}`;
      furnitureDiv.appendChild(priceP);

      let decorationFactorP = document.createElement('p');
      decorationFactorP.textContent = `Decoration factor: ${obj.decFactor}`;
      furnitureDiv.appendChild(decorationFactorP);

      let checkbox = document.createElement('input');
      checkbox.type = 'checkbox';
      furnitureDiv.appendChild(checkbox);

      furnitureListElement.appendChild(furnitureDiv);
      currnetFurnitures.push(obj);
    }

  }


  function isChecked(div) {
    let checkbox = div.getElementsByTagName('input')[0];
    return checkbox.checked;
  }
}