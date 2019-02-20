let CharLookup = require('./03.CharLookup');
let assert = require('chai').assert;

let lookupChar = CharLookup.lookupChar;
// let lookupChar = function (string, index) {
//     if (typeof (string) !== 'string' || typeof (index) !== 'number') {
//         return undefined;
//     }
//     if (string.length <= index || index < 0) {
//         return "Incorrect index";
//     }

//     return string.charAt(index);
// };

describe('lookupChar', function () {
    it('when first param is not a string, should return undefined', function () {
        let firstParam = 1;
        let index = 1;
        let expected = undefined;

        let result = lookupChar(firstParam, index);

        assert.isUndefined(result, 'Must return undefined, when first param is not a string');
    });
    it('when index is not a number, should return undefined', function () {
        let firstParam = 1;
        let index = '1';
        let expected = undefined;

        let result = lookupChar(firstParam, index);

        assert.isUndefined(result, 'Must return undefined, when index is not a number');
    });
    it('when index is out of range string length, should return "Incorrect index"', function () {
        let firstParam = 'text';
        let index = 4;
        let expected = 'Incorrect index';

        let result = lookupChar(firstParam, index);

        assert.equal(result, expected, `Must return ${expected}, when index is out of range, but return ${result}`);
    });
    it('when index is less of zero, should return "Incorrect index"', function () {
        let firstParam = 'text';
        let index = -1;
        let expected = 'Incorrect index';

        let result = lookupChar(firstParam, index);

        assert.equal(result, expected, `Must return ${expected}, when index is less of zero, but return ${result}`);
    });
    it('when string and index is correct, should return chart at that index', function () {
        let firstParam = 'text';
        let index = 1;
        let expected = firstParam.charAt(index);

        let result = lookupChar(firstParam, index);

        assert.equal(result, expected, `Must return ${expected}, but return ${result}`);
    });

    it('when index is not integer, should return isUndefined', function () {
        let firstParam = 'text';
        let index = 1.1;
        //let expected = firstParam.charAt(index);
        let result = lookupChar(firstParam, index);

        assert.isUndefined(result, `Must return undefined, when index in not integer return`);
    });
});