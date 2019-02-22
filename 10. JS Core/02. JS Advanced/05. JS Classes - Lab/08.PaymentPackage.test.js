let PaymentPackage = require('./08.PaymentPackage');
let assert = require('chai').assert;

describe('PaymentPackage', function () {
    describe('prototype', function () {
        it('prototype contains properties', function () {

            let pp = new PaymentPackage('name', 12);

            assert.isTrue(pp.hasOwnProperty('_name'), 'PaymentPackage prototype must contains name');
            assert.isTrue(pp.hasOwnProperty('_value'), 'PaymentPackage prototype must contains value');
            assert.isTrue(pp.hasOwnProperty('_VAT'), 'PaymentPackage prototype must contains VAT');
            assert.isTrue(pp.hasOwnProperty('_active'), 'PaymentPackage prototype must contains active');
            assert.isFunction(PaymentPackage.prototype.toString, 'PaymentPackage prototype must contains toString');
        });
    });

    describe('constructor', function () {
        it('with correct data', function () {
            let name = 'Name';
            let value = 12;
            let pp = new PaymentPackage(name, value);

            let expectedVat = value * (1 + pp.VAT / 100);

            let expected = `Package: ${name}\n- Value (excl. VAT): ${value}\n- Value (VAT 20%): ${expectedVat}`;
            let result = pp.toString();

            assert.equal(result, expected, `Must return ${expected}, but is a ${result}`);
        });
        it('default VAT is 20', function () {
            let name = 'Name';
            let value = 12;
            let pp = new PaymentPackage(name, value);

            let expected = 20;
            let result = pp.VAT;

            assert.equal(result, expected, `Must return ${expected}, but is a ${result}`);
        });
        it('default active is true', function () {
            let name = 'Name';
            let value = 12;
            let pp = new PaymentPackage(name, value);

            let expected = true;
            let result = pp.active;

            assert.equal(result, expected, `Must return ${expected}, but is a ${result}`);
        });
    });

    describe('name', function () {
        it('setter with correct data', function () {
            let name = 'Name';
            let value = 12;

            let pp = new PaymentPackage(name, value);

            let actual = pp._name;

            assert.deepEqual(actual, name, `Must be a ${name}, but was a ${actual}`);
        });
        it('setter with correct data', function () {
            let name = 'Name';
            let value = 12;

            let pp = new PaymentPackage(name, value);
            pp.name = name + name;
            let actual = pp._name;

            assert.deepEqual(actual, name + name, `Must be a ${name}, but was a ${actual}`);
        });
        it('setter with incorrect type', function () {
            let name = [];
            let value = 12;

            let expectedMessage = 'Name must be a non-empty string';

            assert.throw(() => { new PaymentPackage(name, value); }, expectedMessage);
        });
        it('setter with incorrect length', function () {
            let name = '';
            let value = 12;

            let expectedMessage = 'Name must be a non-empty string';

            assert.throw(() => { new PaymentPackage(name, value); }, expectedMessage);
        });
    });

    describe('value', function () {
        it('setter with correct data', function () {
            let name = 'Name';
            let value = 12;

            let pp = new PaymentPackage(name, value);

            let actual = pp._value;

            assert.deepEqual(actual, value, `Must be a ${value}, but was a ${actual}`);
        });
        it('setter with correct data', function () {
            let name = 'Name';
            let value = 12;

            let pp = new PaymentPackage(name, value);
            pp.value = value + value;
            let actual = pp._value;

            assert.deepEqual(actual, value + value, `Must be a ${value}, but was a ${actual}`);
        });
        it('setter with incorrect value type', function () {
            let name = 'Name';
            let value = [];

            let expectedMessage = 'Value must be a non-negative number';

            assert.throw(() => { new PaymentPackage(name, value); }, expectedMessage);
        });
        it('setter with negative value', function () {
            let name = 'Name';
            let value = -1;

            let expectedMessage = 'Value must be a non-negative number';

            assert.throw(() => { new PaymentPackage(name, value); }, expectedMessage);
        });
    });

    describe('VAT', function () {
        it('getter with correct data', function () {
            let name = 'Name';
            let value = 12;
            let VAT = 20;

            let pp = new PaymentPackage(name, value);

            let actual = pp._VAT;

            assert.deepEqual(actual, VAT, `Must be a ${VAT}, but was a ${actual}`);
        });
        it('setter with correct data', function () {
            let name = 'Name';
            let value = 12;
            let VAT = 30;

            let pp = new PaymentPackage(name, value);
            pp.VAT = VAT;
            let actual = pp._VAT;

            assert.deepEqual(actual, VAT, `Must be a ${VAT}, but was a ${actual}`);
        });
        it('setter with incorrect VAT type', function () {
            let name = 'Name';
            let value = 12;
            let VAT = [];

            let pp = new PaymentPackage(name, value);

            let expectedMessage = 'VAT must be a non-negative number';

            assert.throw(() => { pp.VAT = VAT; }, expectedMessage);
        });
        it('setter with negative value', function () {
            let name = 'Name';
            let value = 12;
            let VAT = [];

            let pp = new PaymentPackage(name, value);

            let expectedMessage = 'VAT must be a non-negative number';

            assert.throw(() => { pp.VAT = VAT; }, expectedMessage);
        });
    });

    describe('active', function () {
        it('getter with correct data', function () {
            let name = 'Name';
            let value = 12;
            let active = true;

            let pp = new PaymentPackage(name, value);

            let actual = pp._active;

            assert.deepEqual(actual, active, `Must be a ${active}, but was a ${actual}`);
        });
        it('setter with correct data', function () {
            let name = 'Name';
            let value = 12;
            let active = false;

            let pp = new PaymentPackage(name, value);
            pp.active = active;
            let actual = pp._active;

            assert.deepEqual(actual, active, `Must be a ${active}, but was a ${actual}`);
        });
        it('setter with incorrect VAT type', function () {
            let name = 'Name';
            let value = 12;
            let active = [];

            let pp = new PaymentPackage(name, value);

            let expectedMessage = 'Active status must be a boolean';

            assert.throw(() => { pp.active = active; }, expectedMessage);
        });
    });
});