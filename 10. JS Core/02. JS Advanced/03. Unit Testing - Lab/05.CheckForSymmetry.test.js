let assert = require('chai').assert;

function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

describe('isSymmetric', function () {
    it('with not array, should return false', function () {
        let input = 'array';

        let expected = false;
        let result = isSymmetric(input);

        assert.equal(result, expected, `${result} must be equal to ${expected}`);
    });
    it('with non symmetric array, should return false', function () {
        let input = [1, 2, 3, 3, 1];

        let expected = false;
        let result = isSymmetric(input);

        assert.equal(result, expected, `${input} is symmetric, and return ${result}`);
    });
    it('with symmetric array, should return true', function () {
        let input = [1, 2, 3, 2, 1];

        let expected = true;
        let result = isSymmetric(input);

        assert.equal(result, expected, `${input} is not symmetric, and return ${result}`);
    });
    it('with empty array, should return true', function () {
        let input = [];

        let expected = true;
        let result = isSymmetric(input);

        assert.equal(result, expected, `${input} is not symmetric, and return ${result}`);
    });
    it('with one element array, should return true', function () {
        let input = [1];

        let expected = true;
        let result = isSymmetric(input);

        assert.equal(result, expected, `${input} is not symmetric, and return ${result}`);
    });
    it('with elements of different types, should return false', function () {
        let input = [1, '2', 3, 2, 1];

        let expected = false;
        let result = isSymmetric(input);

        assert.equal(result, expected, `${input} is not symmetric, and return ${result}`);
    });
});