const EvenOrOdd = require('./02.EvenOrOdd');
let assert = require('chai').assert;

let isOddOrEven = EvenOrOdd.isOddOrEven;

describe('isOddOrEven', function () {
    it('when param is not string, must return undefined', function () {
        let arg = 1;

        let result = isOddOrEven(arg);

        assert.isUndefined(result, 'When param is not string, must return undefined, but return ' + result);
    });
    it('when param is empty string, must return even', function () {
        let arg = '';
        let expected = 'even';

        let result = isOddOrEven(arg);

        assert.equal(result, expected, `Must be ${expected}, but was ${result}`);
    });
    it('when param is string with one lenght, must return odd', function () {
        let arg = '1';
        let expected = 'odd';

        let result = isOddOrEven(arg);

        assert.equal(result, expected, `Must be ${expected}, but was ${result}`);
    });
});