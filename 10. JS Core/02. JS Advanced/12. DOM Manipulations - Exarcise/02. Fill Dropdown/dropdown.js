function addItem() {
    let textItem = document.getElementById('newItemText');
    let valueItem = document.getElementById('newItemValue');

    let newItemText = textItem.value;
    let newItemValue = valueItem.value;

    let menu = document.getElementById('menu');

    let option = document.createElement('option');
    option.text = newItemText;
    option.value = newItemValue;

    menu.appendChild(option);

    textItem.value = '';
    valueItem.value = '';
}
