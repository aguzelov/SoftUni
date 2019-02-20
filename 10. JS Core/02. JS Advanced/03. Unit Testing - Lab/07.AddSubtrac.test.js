let assert = require('chai').assert;

function createCalculator() {
    let value = 0;
    return {
        add: function (num) { value += Number(num); },
        subtract: function (num) { value -= Number(num); },
        get: function () { return value; }
    };
}


describe('createCalculator', function () {
    it('correct', function () {
        let result = createCalculator();

        assert.isObject(result, `Result is not a object`);
        assert.property(result, 'add', 'Object not contain property add');
        assert.property(result, 'subtract', 'Object not contain property subtract');
        assert.property(result, 'get', 'Object not contain property get');
    });
    it('with add a number, should get return same number', function () {
        let result = createCalculator();
        let num = 10;

        result.add(num);
        result.add(num);

        assert.equal(result.get(), num + num, `Expected ${num + num}, but is ${result.get()}`);
    });
    it('with add a number twice, should get return same number twice', function () {
        let result = createCalculator();
        let num = 10;

        result.add(num);
        result.add(num);

        assert.equal(result.get(), num + num, `Expected ${num + num}, but is ${result.get()}`);
    });
    it('with substract a number twice, should get return substract number from total', function () {
        let result = createCalculator();
        let num = 10;

        result.add(num);
        result.subtract(num);

        assert.equal(result.get(), num - num, `Expected ${num - num}, but is ${result.get()}`);
    });
    it('with add, substract and add a number, should get return number', function () {
        let result = createCalculator();
        let num = 10;

        result.add(num);
        result.subtract(num);
        result.add(num);

        assert.equal(result.get(), num, `Expected ${num}, but is ${result.get()}`);
    });
    it('with add and substract a string, should get return number', function () {
        let result = createCalculator();
        let num = '10';

        result.add(num);
        result.subtract(num);

        let actualGetResult = result.get();
        assert.equal(actualGetResult, 0, `Expected ${0}, but is ${actualGetResult}`);
        assert.isNumber(actualGetResult, 'Get result is not a number');
    });
    it('return obj which does not contain internal sum', function () {
        let result = createCalculator();

        assert.notProperty(result, 'value', 'Returned object contain property value');
    });
    it('return obj which does not contain internal sum', function () {
        let result = createCalculator();
        let num = '10';
        result.add(num);
        result.add(num);

        assert.equal(result.get(), 20, `Result must be a 20, but is a ${result.get()}`);
    });
});