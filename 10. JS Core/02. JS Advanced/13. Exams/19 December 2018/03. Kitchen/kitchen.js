class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products) {
        for (const product of products) {
            let productTokens = product.split(' ');
            let name = productTokens[0];
            let quantity = +productTokens[1];
            let price = +productTokens[2];

            if (this.budget >= price) {
                this.budget -= price;

                if (!this.productsInStock.hasOwnProperty(name)) {
                    this.productsInStock[name] = 0;
                }

                this.productsInStock[name] += quantity;

                this.actionsHistory.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.actionsHistory.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        return this.actionsHistory.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in the our menu, try something different.`;
        }

        let products = {};

        for (const product of neededProducts) {
            let productTokens = product.split(' ');
            let name = productTokens[0];
            let quantity = +productTokens[1];
            products[name] = quantity;
        }

        this.menu[meal] = {
            products,
            price: +price
        };

        return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;

    }

    showTheMenu() {
        let meals = [];

        for (const key in this.menu) {
            if (this.menu.hasOwnProperty(key)) {
                meals.push(`${key} - $ ${this.menu[key].price}`);
            }
        }

        let result = meals.length === 0 ? 'Our menu is not ready yet, please come later...' : meals.join('\n') + '\n';

        return result;
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = this.menu[meal].products;

        for (const key in neededProducts) {
            if (neededProducts.hasOwnProperty(key)) {
                if (!this.productsInStock.hasOwnProperty(key) ||
                    neededProducts[key] > this.productsInStock[key]) {
                    return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
                }
            }
        }

        for (const key in neededProducts) {
            if (neededProducts.hasOwnProperty(key)) {
                this.productsInStock[key] -= neededProducts[key];
            }
        }

        let mealPrice = this.menu[meal].price;
        this.budget += mealPrice;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${mealPrice}.`;
    }
}