let Calculator = require('./Calculator');
let assert = require('chai').assert;

describe('Calculator', function () {
    describe('constructor', function () {
        it('has property "expreses"', function () {
            let calculator = new Calculator();

            assert.property(calculator, 'expenses');
        });

        it('property "expreses" is initialized to an empty array', function () {
            let calculator = new Calculator();

            assert.isArray(calculator.expenses, 'expenses must be an array');
            assert.isTrue(calculator.expenses.length === 0, 'expenses must be an empty array');
        });
    });

    describe('add', function () {
        let calc;

        beforeEach(function () {
            calc = new Calculator();
        });

        it('add string', function () {
            let item = 'item';

            calc.add(item);
            let firstItem = calc.expenses[0];

            assert.equal(firstItem, item);
            assert.isString(firstItem);
        });

        it('add bool', function () {
            let item = true;

            calc.add(item);
            let firstItem = calc.expenses[0];

            assert.equal(firstItem, item);
            assert.isBoolean(firstItem);
        });

        it('add positive number', function () {
            let item = 10;

            calc.add(item);
            let firstItem = calc.expenses[0];

            assert.equal(firstItem, item);
            assert.isNumber(firstItem);
        });

        it('add negative number', function () {
            let item = -10;

            calc.add(item);
            let firstItem = calc.expenses[0];

            assert.equal(firstItem, item);
            assert.isNumber(firstItem);
        });


        it('add floating point number', function () {
            let item = 1.1233;

            calc.add(item);
            let firstItem = calc.expenses[0];

            assert.equal(firstItem, item);
            assert.isNumber(firstItem);
        });
    });

    describe('toString', function () {
        let calc;

        beforeEach(function () {
            calc = new Calculator();
        });

        it('with no item stored', function () {
            let expected = 'empty array';

            let result = calc.toString();

            assert.equal(result, expected);
        });

        it('with one item', function () {
            let item = -1;
            calc.add(item);

            let expected = item.toString();

            let result = calc.toString();

            assert.equal(result, expected);
        });

        it('with multiple items', function () {
            let addedItems = [];

            for (let index = 1; index < 10; index++) {
                calc.add(index);

                addedItems.push(index);
            }

            let expected = addedItems.join(" -> ");

            let result = calc.toString();

            assert.equal(result, expected);
        });
    });

    describe('divideNums', function () {
        let calc;

        beforeEach(function () {
            calc = new Calculator();
        });

        it('with no items', function () {
            let expectedErrorMessage = 'There are no numbers in the array!';

            assert.throw(() => calc.divideNums(), expectedErrorMessage);
        });

        it('with multiple numbers', function () {
            let expectedResult;

            for (let index = 1; index < 10; index++) {
                calc.add(index);

                if (expectedResult === undefined) {
                    expectedResult = index;
                }
                expectedResult /= index;
            }

            let actualResult = calc.divideNums();

            assert.equal(actualResult, expectedResult);
        });

        it('with multyple types', function () {
            calc.add(1);
            calc.add([]);
            calc.add('1');
            calc.add({});
            calc.add(true);
            calc.add(-3);

            let expectedResult = 1 / -3;

            let actualResult = calc.divideNums();

            assert.equal(actualResult, expectedResult);
        });

        it('with including zero', function () {
            calc.add(1);
            calc.add([]);
            calc.add(0);
            calc.add(3);

            let expectedResult = 'Cannot divide by zero';

            let actualResult = calc.divideNums();

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('orderBy', function () {
        let calc;

        beforeEach(() => {
            calc = new Calculator();
        });

        it('with no items', function () {
            let expectedResult = 'empty';

            let actualResult = calc.orderBy();

            assert.equal(actualResult, expectedResult);
        });

        it('with only numbers', function () {
            let addedItems = [];

            for (let index = 1; index < 10; index++) {
                calc.add(index);

                addedItems.push(index);
            }

            let expectedResult = addedItems.join(', ');

            let actualResult = calc.orderBy();

            assert.equal(actualResult, expectedResult);
        });

        it('with multiple types', function () {
            let addedItems = [];
            addedItems.push(1);
            addedItems.push('1');
            addedItems.push([]);
            addedItems.push(true);

            for (const item of addedItems) {
                calc.add(item);
            }

            addedItems.sort((a, b) => a - b);

            let expectedResult = addedItems.join(', ');

            let actualResult = calc.orderBy();

            assert.equal(actualResult, expectedResult);
        });
    });
});
