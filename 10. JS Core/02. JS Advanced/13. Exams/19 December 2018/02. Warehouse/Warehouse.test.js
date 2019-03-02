let Warehouse = require('./Warehouse');
let assert = require('Chai').assert;

describe("Vacation", function () {
    describe('constructor', function () {
        it("constructor with valid capacity", function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            let actualCapacity = warehouse._capacity;

            assert.equal(actualCapacity, initCapacity, `Must be ${initCapacity}, but was ${actualCapacity}`);
        });
        it("constructor with invalid capacity type", function () {
            let initCapacity = [];
            assert.throws(() => new Warehouse(initCapacity), `Invalid given warehouse space`);
        });
        it("constructor with negative capacity type", function () {
            let initCapacity = -10;
            assert.throws(() => new Warehouse(initCapacity), `Invalid given warehouse space`);
        });
        it("constructor with zero capacity type", function () {
            let initCapacity = 0;
            assert.throws(() => new Warehouse(initCapacity), `Invalid given warehouse space`);
        });
        it("constructor init availableProducts with Food and Drink obj", function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            let property = Object.keys(warehouse.availableProducts);

            assert.include(property, 'Food', `availableProducts must contain "Food" property`);
            assert.include(property, 'Drink', `availableProducts must contain "Drink" property`);
        });
    });

    describe('capacity getter and setter', function () {
        it('getter', function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            let actualCapacity = warehouse.capacity;

            assert.equal(actualCapacity, initCapacity, `Capacity must be ${initCapacity}, but was ${actualCapacity}`);
        });
        it('setter with valid capacity', function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);
            let expectedCapacity = initCapacity + initCapacity;
            warehouse.capacity += initCapacity;

            let actualCapacity = warehouse.capacity;

            assert.equal(actualCapacity, expectedCapacity, `Capacity must be ${expectedCapacity}, but was ${actualCapacity}`);
        });
        it('setter with invalid capacity type', function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            assert.throws(() => warehouse.capacity = [], `Invalid given warehouse space`);
        });
        it('setter with negative capacity', function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            assert.throws(() => warehouse.capacity = 0, `Invalid given warehouse space`);
        });
    });

    describe('addProduct', function () {
        it('with not enough capacity', function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 11;

            assert.throws(() => warehouse.addProduct(type, product, quantity), `There is not enough space or the warehouse is already full`);
        });
        it('with new product', function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            let result = warehouse.addProduct(type, product, quantity);

            assert.property(result, product, `Returned obj must have property: ${product}`);
            assert.equal(result[product], quantity, `Quantity must be ${quantity}, but was ${result[product]}`);
        });
        it('with already added product, quantity must be increased', function () {
            let initCapacity = 10;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;
            let expectedQuantity = quantity + quantity;

            warehouse.addProduct(type, product, quantity);
            let result = warehouse.addProduct(type, product, quantity);

            assert.equal(result[product], expectedQuantity, `Quantity must be ${expectedQuantity}, but was ${result[product]}`);
        });
        it('with multiple product', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            let productsToAdd = [];
            let result;
            for (let index = 0; index < 5; index++) {
                let productToAdd = product + `${index}`;
                let quantityToAdd = quantity + index;

                let productObj = {
                    type: type,
                    product: productToAdd,
                    quantity: quantityToAdd
                };

                result = warehouse.addProduct(type, productToAdd, quantityToAdd);
                productsToAdd.push(productObj);
            }

            for (const productObj of productsToAdd) {
                assert.property(result, productObj.product, `Returned obj must have property: ${productObj.product}`);
                assert.equal(result[productObj.product], productObj.quantity, `Quantity must be ${productObj.quantity}, but was ${result[productObj.product]}`);
            }
        });
    });

    describe('orderProducts', function () {
        it('with already added products', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let foodType = 'Food';
            let drinkType = 'Drink';
            let product = 'TestProduct';
            let quantity = 5;

            let productsToAdd = [];
            for (let index = 0; index < 5; index++) {
                let typeToAdd = index % 2 === 0 ? foodType : drinkType;

                let productToAdd = product + `${index}`;
                let quantityToAdd = quantity + index;

                let productObj = {
                    type: typeToAdd,
                    product: productToAdd,
                    quantity: quantityToAdd
                };

                warehouse.addProduct(typeToAdd, productToAdd, quantityToAdd);
                productsToAdd.push(productObj);
            }

            let orderedProducts = warehouse.orderProducts(foodType);
            productsToAdd.sort((a, b) => b.quantity - a.quantity);

            let expectedObj = {};
            for (const product of productsToAdd.filter(p => p.type === foodType)) {
                expectedObj[product.product] = product.quantity;
            }


            assert.deepEqual(orderedProducts, expectedObj, `Result must be sorter descending by quantity, but was ${orderedProducts}`);
            // for (let index = 0; index < orderedProducts.length; index++) {
            //     let expectedProductName = sortedExpectedProducts[i].product;
            //     let actualProductName = orderedProducts[index].product;

            //     let expectedQuantity = sortedExpectedProducts[i].quantity;
            //     let actualQuantity = orderedProducts[index].quantity;

            //     assert.equal(actualQuantity, expectedQuantity, `Expected quantity: ${expectedQuantity}, but was ${actualQuantity}`);
            //     assert.equal(actualProductName, expectedProductName, `Expected product: ${expectedProductName}, but was ${actualProductName}`);
            // }
        });

        // it('with incorrect type', function () {
        //     let incorrectType = 'Incorrect';

        //     assert.throws(() => warehouse.orderProducts(incorrectType), `Cannot convert undefined or null to object`);
        // });
    });

    describe('occupiedCapacity', function () {
        it('with empty', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let occupied = warehouse.occupiedCapacity();
            let expected = 0;

            assert.equal(occupied, expected, `Must be ${expected}, but was ${occupied}`);
        });

        it('with added products', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            let productsToAdd = [];
            for (let index = 0; index < 5; index++) {
                let productToAdd = product + `${index}`;
                let quantityToAdd = quantity + index;

                let productObj = {
                    type: type,
                    product: productToAdd,
                    quantity: quantityToAdd
                };

                warehouse.addProduct(type, productToAdd, quantityToAdd);
                productsToAdd.push(productObj);
            }

            let actual = warehouse.occupiedCapacity();
            let expected = productsToAdd.map(p => p.quantity).reduce((a, b) => a + b);

            assert.equal(actual, expected, `Must be ${expected}, but was ${actual}`);
        });
    });

    describe('revision', function () {
        it('with empty warehouse', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let expected = `The warehouse is empty`;

            let actual = warehouse.revision();

            assert.equal(actual, expected, `Must be ${expected}, but was ${actual}`);
        });

        it('with added products', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            let productsToAdd = [];
            for (let index = 0; index < 5; index++) {
                let productToAdd = product + `${index}`;
                let quantityToAdd = quantity + index;

                let productObj = {
                    type: type,
                    product: productToAdd,
                    quantity: quantityToAdd
                };

                warehouse.addProduct(type, productToAdd, quantityToAdd);
                productsToAdd.push(productObj);
            }

            let expected = `Product type - [${type}]\n`;
            for (const product of productsToAdd) {
                expected += `- ${product.product} ${product.quantity}\n`;
            }
            expected += 'Product type - [Drink]';

            let actual = warehouse.revision();
            assert.equal(actual, expected, `Must be ${expected}, but was ${actual}`);
        });

        it('with trimed output', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            warehouse.addProduct(type, product, quantity);

            let actual = warehouse.revision();


            assert.isFalse(actual.endsWith('\n'), `Result must be trimmed`);
        });
    });

    describe('scrapeAProduct', function () {
        it('with no existing product', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let incorrectProduct = 'Incorrect';
            let quantity = 10;
            let expectedMessage = `${incorrectProduct} do not exists`;

            assert.throws(() => warehouse.scrapeAProduct(incorrectProduct, quantity), expectedMessage);
        });

        it('with valid quantity', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            let quantityToReduce = 2;
            let expectedQuantity = quantity - quantityToReduce;

            warehouse.addProduct(type, product, quantity);

            let result = warehouse.scrapeAProduct(product, quantityToReduce);
            let actualQuantity = result[product];

            assert.equal(actualQuantity, expectedQuantity, `Quantity must be reduced to ${expectedQuantity}, but was ${actualQuantity}`);
        });

        it('with invalid quantity', function () {
            let initCapacity = 100;
            let warehouse = new Warehouse(initCapacity);

            let type = 'Food';
            let product = 'TestProduct';
            let quantity = 5;

            let quantityToReduce = quantity + quantity;
            let expectedQuantity = 0;

            warehouse.addProduct(type, product, quantity);

            let result = warehouse.scrapeAProduct(product, quantityToReduce);
            let actualQuantity = result[product];

            assert.equal(actualQuantity, expectedQuantity, `Quantity must be reduced to ${expectedQuantity}, but was ${actualQuantity}`);
        });
    });
});