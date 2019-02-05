function solve() {
  let textareas = document.querySelectorAll('#exercise textarea');
  let buttons = document.querySelectorAll('#exercise button');

  let products = [];
  let totalProfit = 0;

  let loadButton = buttons[0];
  loadButton.addEventListener('click', load);

  let buyButton = buttons[1];
  buyButton.addEventListener('click', buy);

  let endDayButton = buttons[2];
  endDayButton.addEventListener('click', endOfDay);

  //log total profit to log textarea and disable all buttons
  function endOfDay() {
    logNewLine(`Profit: ${totalProfit.toFixed(2)}.`);
    loadButton.disabled = true;
    buyButton.disabled = true;

    this.disabled = true;
  }

  //read input for ordered product from buy textarea and chech if has enough quantity
  function buy() {
    let buyProductsTextarea = textareas[1];

    let productForCheck = JSON.parse(buyProductsTextarea.value);

    let index = indexOfProduct(productForCheck);

    if (index < 0 ||
      products[index].quantity < productForCheck.quantity) {
      logNewLine('Cannot complete order.');
      return;
    }

    let orderedQuantity = productForCheck.quantity;
    let orderedName = productForCheck.name;
    let money = orderedQuantity * products[index].price;

    logNewLine(`${orderedQuantity} ${orderedName} sold for ${money}.`);

    products[index].quantity -= orderedQuantity;
    totalProfit += money;
  }

  // read input from textarea and save it
  function load() {
    let loadProductsTextarea = textareas[0];
    let productsInput = JSON.parse(loadProductsTextarea.value);

    productsInput.forEach((product) => {
      saveProduct(product);

      let logMessage = `Successfully added ${product.quantity} ${product.name}. Price: ${product.price}`;
      logNewLine(logMessage);
    });
  }

  // check if product exist and update quantity and price, otherwise save it
  function saveProduct(product) {
    index = indexOfProduct(product);

    if (index < 0) {
      products.push(product);
    } else {
      products[index].quantity += product.quantity;
      products[index].price = product.price;
    }
  }
  //write message in log textarea
  function logNewLine(message) {
    let logTextarea = textareas[2];
    logTextarea.value += message + '\n';
  }

  //get index of product
  function indexOfProduct(product) {
    return products.map(function (e) { return e.name; }).indexOf(product.name);
  }
}