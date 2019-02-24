class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = [];
        this.productsInStock = [];
        this.actionsHistory = [];
    }

    loadProducts(products) {
        for (const productsStr of products) {
            let productTokens = productsStr.split(' ');
            let name = productTokens[0];
            let quantity = +productTokens[1];
            let price = +productTokens[2];

            if (this.budget >= price) {
                this.budget -= price;

                this._addProduct(name, quantity, price);

            } else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        let result = this.actionsHistory.join('\n');
        return result;
    }

    addToMenu(mealStr, neededProducts, price) {
        let indexOfMeal = this._indexOfMeal(mealStr);

        if (indexOfMeal !== -1) {
            return `The ${mealStr} is already in our menu, try something different.`;
        }

        let meal = {
            name: mealStr,
            products: this._getProducts(neededProducts),
            price: +price
        };
        this.menu.push(meal);

        return `Great idea! Now with the ${mealStr} we have ${this.menu.length} meals in the menu, other ideas?`;

    }

    showTheMenu() {
        if (this.menu.length === 0) {
            return 'Our menu is not ready yet, please come later...';
        }

        return this.menu.map(x => `${x.name} - $ ${x.price}`).join('\n') + '\n';
    }

    makeTheOrder(mealStr) {
        let indexOfMeal = this._indexOfMeal(mealStr);

        if (indexOfMeal === -1) {
            return `There is not ${mealStr} yet in our menu, do you want to order something else?`;
        }

        let meal = this.menu[indexOfMeal];

        if (!this._hasNeededProducts(meal.products)) {
            return `For the time being, we cannot complete your order (${meal.name}), we are very sorry...`;
        }

        this._removeProducts(meal.products);
        this.budget += meal.price;
        return `Your order (${meal.name}) will be completed in the next 30 minutes and will cost you ${meal.price}.`;

    }

    _removeProducts(products) {
        for (const product of products) {
            let indexOfProduct = this._indexOfProduct(product.name);
            let productInStock = this.productsInStock[indexOfProduct];

            productInStock.quantity -= product.quantity;

            // if (productInStock.quantity === product.quantity) {
            //     this.productsInStock.splice(indexOfProduct, 1);
            // } else {

            // }
        }
    }

    _getProducts(neededProducts) {
        let products = [];
        for (const productText of neededProducts) {
            let productTokens = productText.split(' ');
            let name = productTokens[0];
            let quantity = +productTokens[1];

            let product = {
                name: name,
                quantity: quantity
            };

            products.push(product);
        }

        return products;
    }

    _addProduct(name, quantity, price) {
        let indexOfProduct = this._indexOfProduct(name);
        if (indexOfProduct !== -1) {
            this.productsInStock[indexOfProduct].quantity += quantity;
        } else {
            let product = {
                name: name,
                quantity: quantity,
                price: price
            };
            this.productsInStock.push(product);
        }
        this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`);
    }

    _hasNeededProducts(products) {
        for (const product of products) {
            let indexOfProduct = this._indexOfProduct(product.name);
            if (indexOfProduct === -1) {
                return false;
            }

            if (this.productsInStock[indexOfProduct].quantity < product.quantity) {
                return false;
            }
        }

        return true;
    }

    _indexOfProduct(name) {
        var index = -1;
        for (var i = 0; i < this.productsInStock.length; i++) {
            if (this.productsInStock[i].name === name) {
                index = i;
                break;
            }
        }
        return index;
    }

    _indexOfMeal(name) {
        var index = -1;
        for (var i = 0; i < this.menu.length; i++) {
            if (this.menu[i].name === name) {
                index = i;
                break;
            }
        }
        return index;
    }
}

let kitchen = new Kitchen(1000);

// console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
console.log(kitchen.budget);
// console.log(kitchen.showTheMenu());
// console.log(kitchen.budget);
// console.log(kitchen.productsInStock);
for (let i = 0; i < 5; i++) {
    console.log('==================================================');

    console.log(kitchen.makeTheOrder('frozenYogurt'));
    console.log(kitchen.budget);
    console.log(kitchen.productsInStock);
}

