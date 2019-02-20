let MathEnforcer = require('./04.MathEnforcer');
let assert = require('chai').assert;

let mathEnforcer = MathEnforcer.mathEnforcer;

describe('mathEnforcer', function () {
    describe('addFive', function () {
        it('with a non-number parameter, should return correct undefined', function () {
            let num = 'test';

            let addFiveResult = mathEnforcer.addFive(num);

            assert.isUndefined(addFiveResult, 'When param is not a number, must return undefined');
        });
        it('with a number parameter, should return number with add 5', function () {
            let positiveNum = 10;
            let positiveExpected = positiveNum + 5;

            let negativeNum = -10;
            let negativeExpected = negativeNum + 5;

            let floatingNum = 10.1;
            let floatingExpected = floatingNum + 5;


            let addFivePositiveResult = mathEnforcer.addFive(positiveNum);
            let addFiveNegativeResult = mathEnforcer.addFive(negativeNum);
            let addFiveFloatingResult = mathEnforcer.addFive(floatingNum);

            assert.equal(addFivePositiveResult, positiveExpected, `Must be ${positiveExpected}, but was ${addFivePositiveResult}`);
            assert.equal(addFiveNegativeResult, negativeExpected, `Must be ${negativeExpected}, but was ${addFiveNegativeResult}`);
            assert.equal(addFiveFloatingResult, floatingExpected, `Must be ${floatingExpected}, but was ${addFiveFloatingResult}`);
        });
    });

    describe('subtractTen', function () {
        it('with a non-number parameter, should return correct undefined', function () {
            let num = 'test';

            let subtractTenResult = mathEnforcer.subtractTen(num);

            assert.isUndefined(subtractTenResult, 'When param is not a number, must return undefined');
        });
        it('with a number parameter, should return number with subtract 10', function () {
            let positiveNum = 10;
            let positiveExpected = positiveNum - 10;

            let negativeNum = -10;
            let negativeExpected = negativeNum - 10;

            let floatingNum = 10.1;
            let floatingExpected = floatingNum - 10;


            let subtractTenPositiveResult = mathEnforcer.subtractTen(positiveNum);
            let subtractTenNegativeResult = mathEnforcer.subtractTen(negativeNum);
            let subtractTenFloatingResult = mathEnforcer.subtractTen(floatingNum);

            assert.equal(subtractTenPositiveResult, positiveExpected, `Must be ${positiveExpected}, but was ${subtractTenPositiveResult}`);
            assert.equal(subtractTenNegativeResult, negativeExpected, `Must be ${negativeExpected}, but was ${subtractTenNegativeResult}`);
            assert.equal(subtractTenFloatingResult, floatingExpected, `Must be ${floatingExpected}, but was ${subtractTenFloatingResult}`);
        });
    });

    describe('sum', function () {
        it('with a non-number parameter, should return correct undefined', function () {
            let num = 'test';

            let sumResult = mathEnforcer.sum(num, num);

            assert.isUndefined(sumResult, 'When param is not a number, must return undefined');
        });
        it('with a non-number parameter, should return correct undefined', function () {
            let firstNum = 1;
            let secondNum = 'test';

            let sumResult = mathEnforcer.sum(firstNum, secondNum);

            assert.isUndefined(sumResult, 'When param is not a number, must return undefined');
        });
        it('with a non-number parameter, should return correct undefined', function () {
            let firstNum = 'test';
            let secondNum = 1;

            let sumResult = mathEnforcer.sum(firstNum, secondNum);

            assert.isUndefined(sumResult, 'When param is not a number, must return undefined');
        });
        it('with a number parameter, should return a sum', function () {
            let positiveNum = 10;

            let positiveExpected = positiveNum + positiveNum;

            let negativeNum = -10;
            let negativeExpected = negativeNum + negativeNum;

            let floatingNum = 10.1;
            let floatingExpected = floatingNum + floatingNum;


            let sumPositiveResult = mathEnforcer.sum(positiveNum, positiveNum);
            let sumNegativeResult = mathEnforcer.sum(negativeNum, negativeNum);
            let sumFloatingResult = mathEnforcer.sum(floatingNum, floatingNum);

            assert.equal(sumPositiveResult, positiveExpected, `Must be ${positiveExpected}, but was ${sumPositiveResult}`);
            assert.equal(sumNegativeResult, negativeExpected, `Must be ${negativeExpected}, but was ${sumNegativeResult}`);
            assert.equal(sumFloatingResult, floatingExpected, `Must be ${floatingExpected}, but was ${sumFloatingResult}`);
        });
    });

});